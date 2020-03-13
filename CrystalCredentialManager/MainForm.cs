using System;
using System.Windows.Forms;
using MirCredentialManager.Common;

namespace CrystalCredentialManager
{
    public partial class MainForm : Form
    {
        private readonly ICredentialsManager _credentialsManager;
        private ICredentialEntry _selectedEntry;
        public MainForm()
        {
            InitializeComponent();

            startButton.Enabled = false;
            removeButton.Enabled = false;
            _credentialsManager = new CredentialsManager();
            _credentialsManager.MappedTypes.Add(typeof(CrystalCredentials).Name, typeof(CrystalCredentials));
            _credentialsManager.MappedTypes.Add(typeof(ZirconCredentials).Name, typeof(ZirconCredentials));
            _credentialsManager.Load();
            RefreshUi();
        }

        private void credentialListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            removeButton.Enabled = false;
            if (!(credentialListBox.SelectedItem is BaseEntry entry)) return;
            _selectedEntry = entry;
            startButton.Enabled = true;
            removeButton.Enabled = true;
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
                switch (credentialsManagerCredential)
                {
                    case ZirconCredentials zircon:
                        credentialListBox.Items.Add(zircon);
                        break;
                    case CrystalCredentials crystal:
                        credentialListBox.Items.Add(crystal);
                        break;
                }
            }
        }
        private void addNewButton_Click(object sender, EventArgs e)
        {
            var form = new AddEntryForm();
            form.EntryAdded += FormOnEntryAdded;
            var result = form.ShowDialog();
            if (result != DialogResult.OK)
            {
                _credentialsManager.Save();
            }

            if (form != null && !form.IsDisposed && !form.Disposing)
            {
                form.EntryAdded -= FormOnEntryAdded;
                form.Close();
                form.Dispose();
            }
            _credentialsManager.Save();
            RefreshUi();
        }

        private void FormOnEntryAdded(object sender, BaseEntry e)
        {
            _credentialsManager.Credentials.Add(e);
        }
    }
}
