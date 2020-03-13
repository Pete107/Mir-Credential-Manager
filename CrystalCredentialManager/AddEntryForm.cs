using System;
using System.Windows.Forms;
using MirCredentialManager.Common;

namespace CrystalCredentialManager
{
    public partial class AddEntryForm : Form
    {
        public event EventHandler<BaseEntry> EntryAdded;
        public AddEntryForm()
        {
            InitializeComponent();
            addEntryControl1.saveButton.Click += SaveButtonOnClick;
            addEntryControl1.EntryAdded += (o, e) => EntryAdded?.Invoke(o, e);
        }

        private void SaveButtonOnClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void AddEntryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show($"Do you wish to save the changes before closing?", "Save Warning!",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                addEntryControl1.saveButton.PerformClick();
                DialogResult = DialogResult.OK;
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void addEntryControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
