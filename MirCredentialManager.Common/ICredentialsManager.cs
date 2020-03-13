using System;
using System.Collections.Generic;

namespace MirCredentialManager.Common
{
    public interface ICredentialsManager
    {
        Dictionary<string, Type> MappedTypes { get; }
        List<ICredentialEntry> Credentials { get; set; }
        void Load();
        void Save();
        void Start(Guid id);
        void AddEntry(ICredentialEntry entry);
        void RemoveEntry(ICredentialEntry entry);
        void UpdateEntry(ICredentialEntry entry);
    }
}