using System;
using System.Windows.Forms;
using MirCredentialManager.Common;

namespace CrystalCredentialManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CredentialManagerHelper.GetEncryptionKey();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
