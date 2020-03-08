namespace CrystalCredentialManager
{
    partial class MainForm
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.credentialListBox = new System.Windows.Forms.ListBox();
            this.credentialControlPanel = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.serverNameBox = new System.Windows.Forms.TextBox();
            this.clientDirBox = new System.Windows.Forms.TextBox();
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.debugBox = new System.Windows.Forms.CheckBox();
            this.addNewButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.credentialControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.removeButton);
            this.mainPanel.Controls.Add(this.startButton);
            this.mainPanel.Controls.Add(this.credentialControlPanel);
            this.mainPanel.Controls.Add(this.credentialListBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 177);
            this.mainPanel.TabIndex = 0;
            // 
            // credentialListBox
            // 
            this.credentialListBox.FormattingEnabled = true;
            this.credentialListBox.Location = new System.Drawing.Point(380, 18);
            this.credentialListBox.Name = "credentialListBox";
            this.credentialListBox.Size = new System.Drawing.Size(408, 121);
            this.credentialListBox.TabIndex = 0;
            this.credentialListBox.SelectedIndexChanged += new System.EventHandler(this.credentialListBox_SelectedIndexChanged);
            // 
            // credentialControlPanel
            // 
            this.credentialControlPanel.Controls.Add(this.addNewButton);
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
            this.credentialControlPanel.Location = new System.Drawing.Point(12, 12);
            this.credentialControlPanel.Name = "credentialControlPanel";
            this.credentialControlPanel.Size = new System.Drawing.Size(362, 157);
            this.credentialControlPanel.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(284, 131);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Client Directory :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "User Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password :";
            // 
            // serverNameBox
            // 
            this.serverNameBox.Location = new System.Drawing.Point(93, 27);
            this.serverNameBox.Name = "serverNameBox";
            this.serverNameBox.Size = new System.Drawing.Size(266, 20);
            this.serverNameBox.TabIndex = 5;
            // 
            // clientDirBox
            // 
            this.clientDirBox.Location = new System.Drawing.Point(93, 53);
            this.clientDirBox.Name = "clientDirBox";
            this.clientDirBox.Size = new System.Drawing.Size(266, 20);
            this.clientDirBox.TabIndex = 6;
            // 
            // userNameBox
            // 
            this.userNameBox.Location = new System.Drawing.Point(93, 79);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(266, 20);
            this.userNameBox.TabIndex = 7;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(93, 105);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(266, 20);
            this.passwordBox.TabIndex = 8;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(713, 142);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(380, 142);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // debugBox
            // 
            this.debugBox.AutoSize = true;
            this.debugBox.Location = new System.Drawing.Point(209, 134);
            this.debugBox.Name = "debugBox";
            this.debugBox.Size = new System.Drawing.Size(69, 17);
            this.debugBox.TabIndex = 9;
            this.debugBox.Text = "Is Debug";
            this.debugBox.UseVisualStyleBackColor = true;
            this.debugBox.CheckedChanged += new System.EventHandler(this.debugBox_CheckedChanged);
            // 
            // addNewButton
            // 
            this.addNewButton.Location = new System.Drawing.Point(3, 131);
            this.addNewButton.Name = "addNewButton";
            this.addNewButton.Size = new System.Drawing.Size(75, 23);
            this.addNewButton.TabIndex = 10;
            this.addNewButton.Text = "New";
            this.addNewButton.UseVisualStyleBackColor = true;
            this.addNewButton.Click += new System.EventHandler(this.addNewButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 177);
            this.Controls.Add(this.mainPanel);
            this.Name = "MainForm";
            this.Text = "Legend of Mir 2 : Crystal Credential Manager";
            this.mainPanel.ResumeLayout(false);
            this.credentialControlPanel.ResumeLayout(false);
            this.credentialControlPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ListBox credentialListBox;
        private System.Windows.Forms.Panel credentialControlPanel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox serverNameBox;
        private System.Windows.Forms.TextBox clientDirBox;
        private System.Windows.Forms.TextBox userNameBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.CheckBox debugBox;
        private System.Windows.Forms.Button addNewButton;
    }
}

