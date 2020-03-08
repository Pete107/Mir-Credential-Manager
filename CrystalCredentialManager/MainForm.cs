using System;
using System.IO;
using System.Windows.Forms;
using MirCredentialManager.Common;

namespace CrystalCredentialManager
{
    public partial class MainForm : Form
    {
        private readonly ICredentialsManager<CredentialEntry> _credentialsManager;
        private CredentialEntry _selectedEntry;
        public MainForm()
        {
            InitializeComponent();
            debugBox.Checked = false;
            serverNameBox.Text = string.Empty;
            clientDirBox.Text = string.Empty;
            userNameBox.Text = string.Empty;
            passwordBox.Text = string.Empty;
            startButton.Enabled = false;
            removeButton.Enabled = false;
            _credentialsManager = new CredentialsManager<CredentialEntry>();
            _credentialsManager.Load();
            RefreshUi();
        }

        private void credentialListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            debugBox.Checked = false;
            serverNameBox.Text = string.Empty;
            clientDirBox.Text = string.Empty;
            userNameBox.Text = string.Empty;
            passwordBox.Text = string.Empty;
            startButton.Enabled = false;
            removeButton.Enabled = false;
            if (!(credentialListBox.SelectedItem is CredentialEntry entry)) return;
            _selectedEntry = entry;
            serverNameBox.Text = entry.ServerName;
            clientDirBox.Text = entry.FilePath;
            userNameBox.Text = entry.UserName;
            passwordBox.Text = entry.Password;
            debugBox.Checked = entry.IsDebug;
            startButton.Enabled = true;
            removeButton.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (_selectedEntry == null)
            {
                if (!Directory.Exists(clientDirBox.Text))
                    return;
                var entry = new CredentialEntry
                {
                    ServerName = serverNameBox.Text,
                    FilePath = clientDirBox.Text,
                    UserName = userNameBox.Text,
                    Password = passwordBox.Text,
                    IsDebug = debugBox.Checked
                };
                _credentialsManager.AddEntry(entry);
            }
            else
                _credentialsManager.UpdateEntry(_selectedEntry);
            
            _credentialsManager.Save();
            RefreshUi();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (_selectedEntry == null) return;
            _credentialsManager.Start(_selectedEntry.Id);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            _credentialsManager.RemoveEntry(_selectedEntry);
            _credentialsManager.Save();
            RefreshUi();

        }

        private void RefreshUi()
        {
            credentialListBox.Items.Clear();
            foreach (var credentialsManagerCredential in _credentialsManager.Credentials)
            {
                credentialListBox.Items.Add(credentialsManagerCredential);
            }
        }

        private void debugBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void addNewButton_Click(object sender, EventArgs e)
        {
            _selectedEntry = null;
            credentialListBox.SelectedItem = null;
            credentialListBox.SelectedIndex = -1;
        }
    }
}
