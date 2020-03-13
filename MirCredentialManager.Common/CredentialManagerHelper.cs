// Created By Pete Smith
// Created 08/03/2020
// Last Edit 08/03/2020

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MirCredentialManager.Common
{
    public static class CredentialManagerHelper
    {
        private static string EncryptionKey = string.Empty;

        public static void GetEncryptionKey()
        {
            if (!File.Exists(Path.Combine(BasePath(), "credentialkey.txt")))
            {
                EncryptionKey = GenerateRandomString(20);
                File.AppendAllText(Path.Combine(BasePath(), "credentialkey.txt"), EncryptionKey);
            }
            else
                EncryptionKey = File.ReadAllText(Path.Combine(BasePath(), "credentialkey.txt"));
        }

        private static string BasePath() => Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
        public static string GetSaveFilePath() => Path.Combine(BasePath(), "credentials.mcred");
        public static void CreateSaveFile() => File.AppendAllText(GetSaveFilePath(), "");
        public const string CrystalConfigFileName = "Mir2Config.ini";
        public const string CrystalTestConfigFileName = "Mir2Test.ini";
        public const string CrystalClientFileName = "Client.exe";
        public const string CrystalAccountIdKey = "AccountID=";
        public const string CrystalPasswordKey = "Password=";

        public const string ZirconConfigFileName = "Zircon.ini";
        public const string ZirconTestConfigFileName = "Client.ini";
        public const string ZirconFileName = "Zircon.exe";
        public const string ZirconAccountIdKey = "RememberedEMail=";
        public const string ZirconPasswordKey = "RememberedPassword=";
        public static string GetAccountId(string inputLine) =>
            inputLine.Replace(CrystalAccountIdKey, "");
        public static string GetPassword(string inputLine) =>
            inputLine.Replace(CrystalPasswordKey, "");
        public static void PutAccountId(string filePath, string accountId, bool isDebug = false)
        {
            
            //Assume crystal files
            if (File.Exists(Path.Combine(filePath, CrystalClientFileName)))
            {
                var config =
                    isDebug ? CrystalTestConfigFileName : CrystalConfigFileName;
                if (!File.Exists(Path.Combine(filePath, config)))
                    throw new FileNotFoundException($"File cannot be found {Path.Combine(filePath, config)}");
                var lines = File.ReadAllLines(Path.Combine(filePath, config));
                var result = new string[lines.Length];
                var currentLine = 0;
                foreach (var line in lines)
                {
                
                    if (!line.StartsWith(CrystalAccountIdKey))
                    {
                        result[currentLine] = line;
                        currentLine++;
                        continue;
                    }
                    result[currentLine] = $"{CrystalAccountIdKey}{accountId}";
                    currentLine++;
                }
                File.WriteAllLines(Path.Combine(filePath, config), result);
            }
            else
            {
                var config = isDebug ? ZirconTestConfigFileName : ZirconConfigFileName;
                if (!File.Exists(Path.Combine(filePath, config)))
                    throw new FileNotFoundException($"File cannot be found {filePath} {config}");
                var lines = File.ReadAllLines(Path.Combine(filePath, config));
                var result = new string[lines.Length];
                var currentLine = 0;
                foreach (var line in lines)
                {
                
                    if (!line.StartsWith(ZirconAccountIdKey))
                    {
                        result[currentLine] = line;
                        currentLine++;
                        continue;
                    }
                    result[currentLine] = $"{ZirconAccountIdKey}{accountId}";
                    currentLine++;
                }
                File.WriteAllLines(Path.Combine(filePath, config), result);
            }
        }
        public static void PutAccountPassword(string filePath, string password, bool isDebug = false)
        {
            if (File.Exists(Path.Combine(filePath, CrystalClientFileName)))
            {
                var config =
                    isDebug ? CrystalTestConfigFileName : CrystalConfigFileName;
                if (!File.Exists(Path.Combine(filePath, config)))
                    throw new FileNotFoundException($"File cannot be found {Path.Combine(filePath, config)}");
                if (!File.Exists(Path.Combine(filePath, config)))
                    throw new FileNotFoundException($"File cannot be found {Path.Combine(filePath, config)}");
                var lines = File.ReadAllLines(Path.Combine(filePath, config));
                var result = new string[lines.Length];
                var currentLine = 0;
                foreach (var line in lines)
                {
                    if (!line.StartsWith(CrystalPasswordKey))
                    {
                        result[currentLine] = line;
                        currentLine++;
                        continue;
                    }

                    result[currentLine] = $"{CrystalPasswordKey}{password}";
                    currentLine++;
                }

                File.WriteAllLines(Path.Combine(filePath, config), result);
            }
            else if (File.Exists(Path.Combine(filePath, ZirconFileName)))
            {
                var config = isDebug ? ZirconTestConfigFileName : ZirconConfigFileName;
                if (!File.Exists(Path.Combine(filePath, config)))
                    throw new FileNotFoundException($"File cannot be found {Path.Combine(filePath, config)}");
                var lines = File.ReadAllLines(Path.Combine(filePath, config));
                var result = new string[lines.Length];
                var currentLine = 0;
                foreach (var line in lines)
                {
                    if (!line.StartsWith(ZirconPasswordKey))
                    {
                        result[currentLine] = line;
                        currentLine++;
                        continue;
                    }

                    result[currentLine] = $"{ZirconPasswordKey}{password}";
                    currentLine++;
                }

                File.WriteAllLines(Path.Combine(filePath, config), result);
            }
        }

        public static string Encrypt(string input)
        {
            if (string.IsNullOrEmpty(EncryptionKey))
                GetEncryptionKey();
            var clearBytes = Encoding.Unicode.GetBytes(input);  
            using(var encryptor = Aes.Create())   
            {  
                var pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {  
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76  
                });
                if (encryptor == null) return input;
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using var ms = new MemoryStream();
                using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }

                input = Convert.ToBase64String(ms.ToArray());
            }  
            return input;
        }

        public static string Decrypt(string input)
        {
            if (string.IsNullOrEmpty(EncryptionKey))
                GetEncryptionKey();
            input = input.Replace(" ", "+");  
            var cipherBytes = Convert.FromBase64String(input);  
            using(var encryptor = Aes.Create())   
            {  
                var pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {  
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76  
                });
                if (encryptor == null) return input;
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using var ms = new MemoryStream();
                using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }

                input = Encoding.Unicode.GetString(ms.ToArray());
            }  
            return input;  
        }

        private static string GenerateRandomString(int length)
        {
            // creating a StringBuilder object()
            var str_build = new StringBuilder();  
            var random = new Random();  

            char letter;  

            for (var i = 0; i < length; i++)
            {
                var flt = random.NextDouble();
                var shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);  
            }

            return str_build.ToString();
        }
    }
}