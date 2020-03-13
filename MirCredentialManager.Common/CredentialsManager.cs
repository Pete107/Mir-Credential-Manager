using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace MirCredentialManager.Common
{
    public class CredentialsManager : ICredentialsManager
    {
        public Dictionary<string, Type> MappedTypes { get; } = new Dictionary<string, Type>();
        public List<ICredentialEntry> Credentials { get; set; }

        public CredentialsManager()
        {
            Credentials = new List<ICredentialEntry>();
        }

        public void Load()
        {
            if (!File.Exists(CredentialManagerHelper.GetSaveFilePath()))
            {
                return;
            }

            using var stream = File.OpenRead(CredentialManagerHelper.GetSaveFilePath());
            using var reader = new BinaryReader(stream);
            var count = reader.ReadInt32();
            for (var i = 0; i < count; i++)
            {
                var type = reader.ReadString();
                if (MappedTypes.ContainsKey(type))
                {
                    var res = Activator.CreateInstance(MappedTypes[type]);

                    ((ICredentialEntry) res).Load(reader);
                    Credentials.Add(res as ICredentialEntry);
                }
            }
        }

        public void Save()
        {
            using var stream = File.Create(CredentialManagerHelper.GetSaveFilePath());
            using var writer = new BinaryWriter(stream);
            writer.Write(Credentials.Count);
            foreach (var credentialEntry in Credentials)
            {
                writer.Write(credentialEntry.GetType().Name);
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
            
            var configPath = entry.FilePath;
            CredentialManagerHelper.PutAccountId(configPath, entry.UserName, entry.IsDebug);
            CredentialManagerHelper.PutAccountPassword(configPath, entry.Password, entry.IsDebug);
            Thread.Sleep(500);
            var crystalClient = File.Exists(Path.Combine(CredentialManagerHelper.CrystalClientFileName));
            var startInfo = new ProcessStartInfo
            {
                WorkingDirectory = entry.FilePath,
                FileName = crystalClient
                    ? CredentialManagerHelper.CrystalClientFileName
                    : CredentialManagerHelper.ZirconFileName
            };
            Process.Start(startInfo);
        }

        public void AddEntry(ICredentialEntry entry) => Credentials.Add(entry);

        public void RemoveEntry(ICredentialEntry entry)
        {
            for (var i = 0; i < Credentials.Count; i++)
            {
                if (Credentials[i].Id != entry.Id) continue;
                Credentials.RemoveAt(i);
                break;
            }
        }

        public void UpdateEntry(ICredentialEntry entry)
        {
            for (var i = 0; i < Credentials.Count; i++)
            {
                if (Credentials[i].Id != entry.Id) continue;
                Credentials[i] = entry;
                break;
            }
        }
    }
}