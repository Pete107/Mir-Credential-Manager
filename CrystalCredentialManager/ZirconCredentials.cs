using System;
using MirCredentialManager.Common;

namespace CrystalCredentialManager
{
    public class ZirconCredentials : BaseEntry
    {
        public override Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() =>
            $"[Zircon {(IsDebug ? "Debug" : "Release")}] Server {ServerName} Account {UserName}";
    }
}