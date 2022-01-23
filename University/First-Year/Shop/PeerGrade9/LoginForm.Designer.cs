
namespace PeerGrade9
{
    partial class LoginForm
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
            this.LoginAsLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.LoginAsComboBox = new System.Windows.Forms.ComboBox();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.SignInButton = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginAsLabel
            // 
            this.LoginAsLabel.Location = new System.Drawing.Point(12, 9);
            this.LoginAsLabel.Name = "LoginAsLabel";
            this.LoginAsLabel.Size = new System.Drawing.Size(100, 23);
            this.LoginAsLabel.TabIndex = 0;
            this.LoginAsLabel.Text = "Enter as";
            this.LoginAsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmailLabel
            // 
            this.EmailLabel.Location = new System.Drawing.Point(13, 39);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(100, 23);
            this.EmailLabel.TabIndex = 1;
            this.EmailLabel.Text = "Login";
            this.EmailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Location = new System.Drawing.Point(12, 69);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(100, 23);
            this.PasswordLabel.TabIndex = 2;
            this.PasswordLabel.Text = "Password";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginAsComboBox
            // 
            this.LoginAsComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.LoginAsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LoginAsComboBox.FormattingEnabled = true;
            this.LoginAsComboBox.Items.AddRange(new object[] {
            "Client",
            "Seller"});
            this.LoginAsComboBox.Location = new System.Drawing.Point(118, 9);
            this.LoginAsComboBox.Name = "LoginAsComboBox";
            this.LoginAsComboBox.Size = new System.Drawing.Size(182, 23);
            this.LoginAsComboBox.TabIndex = 3;
            this.LoginAsComboBox.SelectedIndexChanged += new System.EventHandler(this.LoginAsComboBox_SelectedIndexChanged);
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.EmailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EmailTextBox.Location = new System.Drawing.Point(118, 39);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(182, 23);
            this.EmailTextBox.TabIndex = 4;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTextBox.Location = new System.Drawing.Point(118, 69);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(182, 23);
            this.PasswordTextBox.TabIndex = 5;
            // 
            // SignInButton
            // 
            this.SignInButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SignInButton.FlatAppearance.BorderSize = 0;
            this.SignInButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SignInButton.Location = new System.Drawing.Point(171, 111);
            this.SignInButton.Name = "SignInButton";
            this.SignInButton.Size = new System.Drawing.Size(129, 23);
            this.SignInButton.TabIndex = 6;
            this.SignInButton.Text = "Sign in";
            this.SignInButton.UseVisualStyleBackColor = false;
            this.SignInButton.Click += new System.EventHandler(this.SignInButton_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RegisterButton.FlatAppearance.BorderSize = 0;
            this.RegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RegisterButton.Location = new System.Drawing.Point(12, 111);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(129, 23);
            this.RegisterButton.TabIndex = 7;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Visible = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size(316, 148);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.SignInButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.LoginAsComboBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.LoginAsLabel);
            this.MaximumSize = new System.Drawing.Size(332, 187);
            this.MinimumSize = new System.Drawing.Size(332, 187);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoginAsLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.ComboBox LoginAsComboBox;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button SignInButton;
        private System.Windows.Forms.Button RegisterButton;
    }
}