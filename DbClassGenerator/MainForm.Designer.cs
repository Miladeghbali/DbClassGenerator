namespace DbClassGenerator
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
            this.DataSourceLabel = new System.Windows.Forms.Label();
            this.DataSourceTextBox = new System.Windows.Forms.TextBox();
            this.UserIDTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UserIDCheckBox = new System.Windows.Forms.CheckBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DataBasesComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TablesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.RootNamespaceLabel = new System.Windows.Forms.Label();
            this.RootNamespaceTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DataSourceLabel
            // 
            this.DataSourceLabel.AutoSize = true;
            this.DataSourceLabel.Location = new System.Drawing.Point(7, 16);
            this.DataSourceLabel.Name = "DataSourceLabel";
            this.DataSourceLabel.Size = new System.Drawing.Size(67, 13);
            this.DataSourceLabel.TabIndex = 0;
            this.DataSourceLabel.Text = "Data Source";
            // 
            // DataSourceTextBox
            // 
            this.DataSourceTextBox.Location = new System.Drawing.Point(80, 13);
            this.DataSourceTextBox.Name = "DataSourceTextBox";
            this.DataSourceTextBox.Size = new System.Drawing.Size(100, 20);
            this.DataSourceTextBox.TabIndex = 1;
            // 
            // UserIDTextBox
            // 
            this.UserIDTextBox.Enabled = false;
            this.UserIDTextBox.Location = new System.Drawing.Point(254, 14);
            this.UserIDTextBox.Name = "UserIDTextBox";
            this.UserIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.UserIDTextBox.TabIndex = 1;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(369, 17);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 0;
            this.PasswordLabel.Text = "Password";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Enabled = false;
            this.PasswordTextBox.Location = new System.Drawing.Point(428, 13);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(100, 20);
            this.PasswordTextBox.TabIndex = 1;
            // 
            // UserIDCheckBox
            // 
            this.UserIDCheckBox.AutoSize = true;
            this.UserIDCheckBox.Location = new System.Drawing.Point(186, 16);
            this.UserIDCheckBox.Name = "UserIDCheckBox";
            this.UserIDCheckBox.Size = new System.Drawing.Size(62, 17);
            this.UserIDCheckBox.TabIndex = 2;
            this.UserIDCheckBox.Text = "User ID";
            this.UserIDCheckBox.UseVisualStyleBackColor = true;
            this.UserIDCheckBox.CheckedChanged += new System.EventHandler(this.UserIDCheckBox_CheckedChanged);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(534, 11);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 3;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DataBasesComboBox
            // 
            this.DataBasesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataBasesComboBox.Enabled = false;
            this.DataBasesComboBox.FormattingEnabled = true;
            this.DataBasesComboBox.Location = new System.Drawing.Point(80, 48);
            this.DataBasesComboBox.Name = "DataBasesComboBox";
            this.DataBasesComboBox.Size = new System.Drawing.Size(529, 21);
            this.DataBasesComboBox.TabIndex = 4;
            this.DataBasesComboBox.SelectedIndexChanged += new System.EventHandler(this.DataBasesComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Source";
            // 
            // TablesCheckedListBox
            // 
            this.TablesCheckedListBox.FormattingEnabled = true;
            this.TablesCheckedListBox.Location = new System.Drawing.Point(12, 75);
            this.TablesCheckedListBox.Name = "TablesCheckedListBox";
            this.TablesCheckedListBox.Size = new System.Drawing.Size(613, 289);
            this.TablesCheckedListBox.TabIndex = 5;
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(550, 371);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(75, 23);
            this.GenerateButton.TabIndex = 6;
            this.GenerateButton.Text = "Generate...";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // RootNamespaceLabel
            // 
            this.RootNamespaceLabel.AutoSize = true;
            this.RootNamespaceLabel.Location = new System.Drawing.Point(12, 376);
            this.RootNamespaceLabel.Name = "RootNamespaceLabel";
            this.RootNamespaceLabel.Size = new System.Drawing.Size(90, 13);
            this.RootNamespaceLabel.TabIndex = 7;
            this.RootNamespaceLabel.Text = "Root Namespace";
            // 
            // RootNamespaceTextBox
            // 
            this.RootNamespaceTextBox.Location = new System.Drawing.Point(109, 374);
            this.RootNamespaceTextBox.Name = "RootNamespaceTextBox";
            this.RootNamespaceTextBox.Size = new System.Drawing.Size(435, 20);
            this.RootNamespaceTextBox.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 406);
            this.Controls.Add(this.RootNamespaceTextBox);
            this.Controls.Add(this.RootNamespaceLabel);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.TablesCheckedListBox);
            this.Controls.Add(this.DataBasesComboBox);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.UserIDCheckBox);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserIDTextBox);
            this.Controls.Add(this.DataSourceTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataSourceLabel);
            this.Name = "MainForm";
            this.Text = "Database .Net Classes Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DataSourceLabel;
        private System.Windows.Forms.TextBox DataSourceTextBox;
        private System.Windows.Forms.TextBox UserIDTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.CheckBox UserIDCheckBox;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.ComboBox DataBasesComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox TablesCheckedListBox;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Label RootNamespaceLabel;
        private System.Windows.Forms.TextBox RootNamespaceTextBox;
    }
}

