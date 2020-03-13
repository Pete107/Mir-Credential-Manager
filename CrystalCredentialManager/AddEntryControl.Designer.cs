namespace CrystalCredentialManager
{
    partial class AddEntryControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.credentialControlPanel = new System.Windows.Forms.Panel();
            this.debugBox = new System.Windows.Forms.CheckBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.clientDirBox = new System.Windows.Forms.TextBox();
            this.serverNameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.credentialControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // credentialControlPanel
            // 
            this.credentialControlPanel.Controls.Add(this.debugBox);
            this.credentialControlPanel.Controls.Add(this.passwordBox);
            this.credentialControlPanel.Controls.Add(this.userNameBox);
            this.credentialControlPanel.Controls.Add(this.clientDirBox);
            this.credentialControlPanel.Controls.Add(this.serverNameBox);
            this.credentialControlPanel.Controls.Add(this.label4);
            this.credentialControlPanel.Controls.Add(this.label3);
            this.credentialControlPanel.Controls.Add(this.label2);
            this.credentialControlPanel.Controls.Add(this.label1);
            this.credentialControlPanel.Controls.Add(this.saveButton);
            this.credentialControlPanel.Location = new System.Drawing.Point(3, 3);
            this.credentialControlPanel.Name = "credentialControlPanel";
            this.credentialControlPanel.Size = new System.Drawing.Size(363, 138);
            this.credentialControlPanel.TabIndex = 2;
            // 
            // debugBox
            // 
            this.debugBox.AutoSize = true;
            this.debugBox.Location = new System.Drawing.Point(6, 113);
            this.debugBox.Name = "debugBox";
            this.debugBox.Size = new System.Drawing.Size(69, 17);
            this.debugBox.TabIndex = 9;
            this.debugBox.Text = "Is Debug";
            this.debugBox.UseVisualStyleBackColor = true;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(93, 84);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(266, 20);
            this.passwordBox.TabIndex = 8;
            // 
            // userNameBox
            // 
            this.userNameBox.Location = new System.Drawing.Point(93, 58);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(266, 20);
            this.userNameBox.TabIndex = 7;
            // 
            // clientDirBox
            // 
            this.clientDirBox.Location = new System.Drawing.Point(93, 32);
            this.clientDirBox.Name = "clientDirBox";
            this.clientDirBox.Size = new System.Drawing.Size(266, 20);
            this.clientDirBox.TabIndex = 6;
            this.clientDirBox.TextChanged += new System.EventHandler(this.clientDirBox_TextChanged);
            // 
            // serverNameBox
            // 
            this.serverNameBox.Location = new System.Drawing.Point(93, 6);
            this.serverNameBox.Name = "serverNameBox";
            this.serverNameBox.Size = new System.Drawing.Size(266, 20);
            this.serverNameBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "User Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Client Directory :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server Name :";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(284, 110);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // AddEntryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.credentialControlPanel);
            this.Name = "AddEntryControl";
            this.Size = new System.Drawing.Size(369, 147);
            this.credentialControlPanel.ResumeLayout(false);
            this.credentialControlPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel credentialControlPanel;
        private System.Windows.Forms.CheckBox debugBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox userNameBox;
        private System.Windows.Forms.TextBox clientDirBox;
        private System.Windows.Forms.TextBox serverNameBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        protected internal System.Windows.Forms.Button saveButton;
    }
}
