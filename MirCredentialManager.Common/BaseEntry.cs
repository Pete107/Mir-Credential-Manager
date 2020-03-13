using System;
using System.IO;

namespace MirCredentialManager.Common
{
    public class BaseEntry : ICredentialEntry
    {
        public virtual Guid Id { get; set; }
        public virtual string ServerName { get; set; }
        public virtual  string FilePath { get; set; }
        public virtual  string UserName { get; set; }
        public virtual  string Password { get; set; }
        public virtual  bool IsDebug { get; set; }

        public BaseEntry()
        {

        }

        public virtual void Load(BinaryReader reader)
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

        public virtual void Save(BinaryWriter writer)
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
    }
}