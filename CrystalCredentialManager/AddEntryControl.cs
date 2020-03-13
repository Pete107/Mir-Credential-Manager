using System;
using System.IO;
using System.Windows.Forms;
using MirCredentialManager.Common;

namespace CrystalCredentialManager
{
    public partial class AddEntryControl : UserControl
    {
        public event EventHandler<BaseEntry> EntryAdded;
        private BaseEntry _entry;
        private byte _mirType = 0;
        public AddEntryControl()
        {
            InitializeComponent();
            debugBox.Checked = false;
            serverNameBox.Text = string.Empty;
            clientDirBox.Text = string.Empty;
            userNameBox.Text = string.Empty;
            passwordBox.Text = string.Empty;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (_mirType == 0)
            {
                _entry = new CrystalCredentials
                {
                    FilePath = clientDirBox.Text,
                    IsDebug = debugBox.Checked,
                    ServerName = serverNameBox.Text,
                    UserName = userNameBox.Text,
                    Password = passwordBox.Text
                };
                EntryAdded?.Invoke(this, _entry);
            }
            else if (_mirType == 1)
            {
                _entry = new ZirconCredentials
                {
                    FilePath = clientDirBox.Text,
                    IsDebug = debugBox.Checked,
                    ServerName = serverNameBox.Text,
                    UserName = userNameBox.Text,
                    Password = passwordBox.Text
                };
                EntryAdded?.Invoke(this, _entry);
            }
        }

        private void clientDirBox_TextChanged(object sender, EventArgs e)
        {
            var path = Path.Combine(clientDirBox.Text);
            if (Directory.Exists(path))
            {
                if (File.Exists(Path.Combine(path, CredentialManagerHelper.CrystalConfigFileName)))
                    _mirType = 0;
                else if (File.Exists(Path.Combine(path, CredentialManagerHelper.ZirconFileName)))
                    _mirType = 1;
            }
        }
    }
}
