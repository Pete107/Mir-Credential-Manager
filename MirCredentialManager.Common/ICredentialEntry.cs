// Created By Pete Smith
// Created //
// Last Edit 13/03/2020

using System;
using System.IO;

namespace MirCredentialManager.Common
{
    public interface ICredentialEntry
    {
        Guid Id { get; set; }
        string ServerName { get; set; }
        string FilePath { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        bool IsDebug { get; set; }
        void Load(BinaryReader reader);
        void Save(BinaryWriter writer);
    }
}