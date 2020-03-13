namespace CrystalCredentialManager
{
    partial class AddEntryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addEntryControl1 = new CrystalCredentialManager.AddEntryControl();
            this.SuspendLayout();
            // 
            // addEntryControl1
            // 
            this.addEntryControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addEntryControl1.Location = new System.Drawing.Point(0, 0);
            this.addEntryControl1.Name = "addEntryControl1";
            this.addEntryControl1.Size = new System.Drawing.Size(363, 139);
            this.addEntryControl1.TabIndex = 0;
            this.addEntryControl1.Load += new System.EventHandler(this.addEntryControl1_Load);
            // 
            // AddEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 139);
            this.Controls.Add(this.addEntryControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddEntryForm";
            this.Text = "AddEntryForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddEntryForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private AddEntryControl addEntryControl1;
    }
}