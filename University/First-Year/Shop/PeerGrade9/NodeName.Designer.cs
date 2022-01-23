namespace PeerGrade9
{
    partial class NodeName
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
            this.NewNameTextBox = new System.Windows.Forms.TextBox();
            this.Continue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the name of the node";
            // 
            // NewNameTextBox
            // 
            this.NewNameTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.NewNameTextBox.Location = new System.Drawing.Point(211, 13);
            this.NewNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NewNameTextBox.Name = "NewNameTextBox";
            this.NewNameTextBox.Size = new System.Drawing.Size(221, 27);
            this.NewNameTextBox.TabIndex = 1;
            // 
            // Continue
            // 
            this.Continue.BackColor = System.Drawing.SystemColors.Menu;
            this.Continue.Location = new System.Drawing.Point(15, 52);
            this.Continue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(418, 31);
            this.Continue.TabIndex = 2;
            this.Continue.Text = "Continue";
            this.Continue.UseVisualStyleBackColor = false;
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // NodeName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size(453, 91);
            this.Controls.Add(this.Continue);
            this.Controls.Add(this.NewNameTextBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NodeName";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NodeName_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NewNameTextBox;
        private System.Windows.Forms.Button Continue;
    }
}