
namespace PeerGrade9
{
    partial class Profile
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FirstnameTextBox = new System.Windows.Forms.TextBox();
            this.LastnameTextBox = new System.Windows.Forms.TextBox();
            this.MiddlenameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PhoneTextBox = new System.Windows.Forms.TextBox();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profile";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Firstname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lastname";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Middlename";
            // 
            // FirstnameTextBox
            // 
            this.FirstnameTextBox.Location = new System.Drawing.Point(113, 50);
            this.FirstnameTextBox.Name = "FirstnameTextBox";
            this.FirstnameTextBox.Size = new System.Drawing.Size(241, 23);
            this.FirstnameTextBox.TabIndex = 4;
            this.FirstnameTextBox.TextChanged += new System.EventHandler(this.FirstnameTextBox_TextChanged);
            // 
            // LastnameTextBox
            // 
            this.LastnameTextBox.Location = new System.Drawing.Point(113, 79);
            this.LastnameTextBox.Name = "LastnameTextBox";
            this.LastnameTextBox.Size = new System.Drawing.Size(241, 23);
            this.LastnameTextBox.TabIndex = 5;
            this.LastnameTextBox.TextChanged += new System.EventHandler(this.LastnameTextBox_TextChanged);
            // 
            // MiddlenameTextBox
            // 
            this.MiddlenameTextBox.Location = new System.Drawing.Point(113, 107);
            this.MiddlenameTextBox.Name = "MiddlenameTextBox";
            this.MiddlenameTextBox.Size = new System.Drawing.Size(241, 23);
            this.MiddlenameTextBox.TabIndex = 6;
            this.MiddlenameTextBox.TextChanged += new System.EventHandler(this.MiddlenameTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Phone";
            // 
            // PhoneTextBox
            // 
            this.PhoneTextBox.Location = new System.Drawing.Point(113, 137);
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.Size = new System.Drawing.Size(241, 23);
            this.PhoneTextBox.TabIndex = 8;
            this.PhoneTextBox.TextChanged += new System.EventHandler(this.PhoneTextBox_TextChanged);
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Location = new System.Drawing.Point(113, 167);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(241, 23);
            this.AddressTextBox.TabIndex = 9;
            this.AddressTextBox.TextChanged += new System.EventHandler(this.AddressTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Address";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(279, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CloseProfile);
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size(371, 230);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.PhoneTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MiddlenameTextBox);
            this.Controls.Add(this.LastnameTextBox);
            this.Controls.Add(this.FirstnameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Profile";
            this.Text = "Phone";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FirstnameTextBox;
        private System.Windows.Forms.TextBox LastnameTextBox;
        private System.Windows.Forms.TextBox MiddlenameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PhoneTextBox;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}