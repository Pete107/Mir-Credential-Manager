using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace MirCredentialManager.Common
{
    public interface ICredentialsManager<T> where T : ICredentialEntry
    {
        List<T> Credentials { get; set; }
        void Load();
        void Save();
        void Start(Guid id);
        void AddEntry(T entry);
        void RemoveEntry(T entry);
        void UpdateEntry(T entry);
    }

    public class CredentialsManager<T> : ICredentialsManager<T> where T : ICredentialEntry
    {
        public List<T> Credentials { get; set; }

        public CredentialsManager()
        {
            Credentials = new List<T>();
        }

        public void Load()
        {
            if (!File.Exists(CredentialManagerHelper.GetSaveFilePath()))
            {
                Save();
                return;
            }

            using var stream = File.OpenRead(CredentialManagerHelper.GetSaveFilePath());
            using var reader = new BinaryReader(stream);
            var count = reader.ReadInt32();
            for (var i = 0; i < count; i++)
            {
                var result = (T)Activator.CreateInstance(typeof(T), reader);
                Credentials.Add(result);
            }
        }

        public void Save()
        {
            using var stream = File.Create(CredentialManagerHelper.GetSaveFilePath());
            using var writer = new BinaryWriter(stream);
            writer.Write(Credentials.Count);
            foreach (var credentialEntry in Credentials)
            {
                credentialEntry.Save(writer);
            }
        }

        public void Start(Guid id)
        {
            var entry = Credentials.FirstOrDefault(a => a.Id == id);
            if (entry == null)
            {
                throw new NullReferenceException(nameof(entry));
            }
            var configFile =
                entry.IsDebug ? CredentialManagerHelper.TestConfigFileName : CredentialManagerHelper.ConfigFileName;
            var configPath = Path.Combine(entry.FilePath, configFile);
            CredentialManagerHelper.PutAccountId(configPath, entry.UserName);
            CredentialManagerHelper.PutAccountPassword(configPath, entry.Password);
            Thread.Sleep(500);
            var startInfo = new ProcessStartInfo {WorkingDirectory = entry.FilePath, FileName = CredentialManagerHelper.ClientExeName};
            Process.Start(startInfo);
        }

        public void AddEntry(T entry) => Credentials.Add(entry);

        public void RemoveEntry(T entry)
        {
            for (var i = 0; i < Credentials.Count; i++)
            {
                if (Credentials[i].Id != entry.Id) continue;
                Credentials.RemoveAt(i);
                break;
            }
        }

        public void UpdateEntry(T entry)
        {
            for (var i = 0; i < Credentials.Count; i++)
            {
                if (Credentials[i].Id != entry.Id) continue;
                Credentials[i] = entry;
                break;
            }
        }
    }
    public interface ICredentialEntry
    {
        Guid Id { get; set; }
        string ServerName { get; set; }
        string FilePath { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        bool IsDebug { get; set; }
        void Save(BinaryWriter writer);
    }

    public class CredentialEntry : ICredentialEntry
    {
        public Guid Id { get; set; }
        public string ServerName { get; set; }
        public string FilePath { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsDebug { get; set; }

        public CredentialEntry()
        {
            Id = Guid.NewGuid();
        }
        public CredentialEntry(BinaryReader reader)
        {
            var id = reader.ReadString();
            Id = Guid.Parse(CredentialManagerHelper.Decrypt(id));
            var serverName = reader.ReadString();
            ServerName = CredentialManagerHelper.Decrypt(serverName);
            var filePath = reader.ReadString();
            FilePath = CredentialManagerHelper.Decrypt(filePath);
            var userName = reader.ReadString();
            UserName = CredentialManagerHelper.Decrypt(userName);
            var password = reader.ReadString();
            Password = CredentialManagerHelper.Decrypt(password);
            IsDebug = reader.ReadBoolean();
        }
        public void Save(BinaryWriter writer)
        {
            var id = CredentialManagerHelper.Encrypt(Id.ToString());
            writer.Write(id);
            var serverName = CredentialManagerHelper.Encrypt(ServerName);
            writer.Write(serverName);
            var filePath = CredentialManagerHelper.Encrypt(FilePath);
            writer.Write(filePath);
            var userName = CredentialManagerHelper.Encrypt(UserName);
            writer.Write(userName);
            var password = CredentialManagerHelper.Encrypt(Password);
            writer.Write(password);
            writer.Write(IsDebug);
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() => $"[{(IsDebug ? "Debug" : "Release")}] Server {ServerName} Account {UserName}";
    }
}