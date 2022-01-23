namespace PeerGrade9
{
    partial class CostReportForm
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
            this.MinimumOrderLabel = new System.Windows.Forms.Label();
            this.MinimumAmount = new System.Windows.Forms.TextBox();
            this.GetCSVButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MinimumOrderLabel
            // 
            this.MinimumOrderLabel.AutoSize = true;
            this.MinimumOrderLabel.Location = new System.Drawing.Point(11, 10);
            this.MinimumOrderLabel.Name = "MinimumOrderLabel";
            this.MinimumOrderLabel.Size = new System.Drawing.Size(85, 15);
            this.MinimumOrderLabel.TabIndex = 0;
            this.MinimumOrderLabel.Text = "Minimum cost";
            // 
            // MinimumAmount
            // 
            this.MinimumAmount.BackColor = System.Drawing.SystemColors.Menu;
            this.MinimumAmount.Location = new System.Drawing.Point(198, 8);
            this.MinimumAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumAmount.Name = "MinimumAmount";
            this.MinimumAmount.Size = new System.Drawing.Size(114, 23);
            this.MinimumAmount.TabIndex = 1;
            // 
            // GetCSVButton
            // 
            this.GetCSVButton.BackColor = System.Drawing.SystemColors.Menu;
            this.GetCSVButton.Location = new System.Drawing.Point(11, 31);
            this.GetCSVButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GetCSVButton.Name = "GetCSVButton";
            this.GetCSVButton.Size = new System.Drawing.Size(300, 22);
            this.GetCSVButton.TabIndex = 2;
            this.GetCSVButton.Text = "Get Cost Report";
            this.GetCSVButton.UseVisualStyleBackColor = false;
            this.GetCSVButton.Click += new System.EventHandler(this.GetCostButton_Click);
            // 
            // CostReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size(322, 62);
            this.Controls.Add(this.GetCSVButton);
            this.Controls.Add(this.MinimumAmount);
            this.Controls.Add(this.MinimumOrderLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CostReportForm";
            this.Text = "CostReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MinimumOrderLabel;
        private System.Windows.Forms.TextBox MinimumAmount;
        private System.Windows.Forms.Button GetCSVButton;
    }
}