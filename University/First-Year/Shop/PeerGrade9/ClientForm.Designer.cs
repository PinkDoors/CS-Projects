
namespace PeerGrade9
{
    partial class ClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddToBasketButton = new System.Windows.Forms.Button();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.PhotoBox = new System.Windows.Forms.PictureBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.AmountTextBox = new System.Windows.Forms.TextBox();
            this.CodeTextBox = new System.Windows.Forms.TextBox();
            this.CodeLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.Tree = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.ClientNameLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.AddToBasketButton);
            this.panel1.Controls.Add(this.DescriptionLabel);
            this.panel1.Controls.Add(this.PhotoBox);
            this.panel1.Controls.Add(this.DescriptionTextBox);
            this.panel1.Controls.Add(this.PriceTextBox);
            this.panel1.Controls.Add(this.PriceLabel);
            this.panel1.Controls.Add(this.AmountLabel);
            this.panel1.Controls.Add(this.AmountTextBox);
            this.panel1.Controls.Add(this.CodeTextBox);
            this.panel1.Controls.Add(this.CodeLabel);
            this.panel1.Controls.Add(this.NameTextBox);
            this.panel1.Controls.Add(this.NameLabel);
            this.panel1.Location = new System.Drawing.Point(232, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 373);
            this.panel1.TabIndex = 4;
            // 
            // AddToBasketButton
            // 
            this.AddToBasketButton.Location = new System.Drawing.Point(427, 340);
            this.AddToBasketButton.Name = "AddToBasketButton";
            this.AddToBasketButton.Size = new System.Drawing.Size(124, 23);
            this.AddToBasketButton.TabIndex = 12;
            this.AddToBasketButton.Text = "Add to basket";
            this.AddToBasketButton.UseVisualStyleBackColor = true;
            this.AddToBasketButton.Click += new System.EventHandler(this.AddToBasketButton_Click);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(14, 129);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(67, 15);
            this.DescriptionLabel.TabIndex = 9;
            this.DescriptionLabel.Text = "Description";
            // 
            // PhotoBox
            // 
            this.PhotoBox.Image = ((System.Drawing.Image)(resources.GetObject("PhotoBox.Image")));
            this.PhotoBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("PhotoBox.InitialImage")));
            this.PhotoBox.Location = new System.Drawing.Point(347, 9);
            this.PhotoBox.MaximumSize = new System.Drawing.Size(204, 111);
            this.PhotoBox.MinimumSize = new System.Drawing.Size(204, 111);
            this.PhotoBox.Name = "PhotoBox";
            this.PhotoBox.Size = new System.Drawing.Size(204, 111);
            this.PhotoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PhotoBox.TabIndex = 11;
            this.PhotoBox.TabStop = false;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DescriptionTextBox.Location = new System.Drawing.Point(87, 126);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.ReadOnly = true;
            this.DescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DescriptionTextBox.Size = new System.Drawing.Size(468, 208);
            this.DescriptionTextBox.TabIndex = 8;
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.PriceTextBox.Location = new System.Drawing.Point(87, 97);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.ReadOnly = true;
            this.PriceTextBox.Size = new System.Drawing.Size(254, 23);
            this.PriceTextBox.TabIndex = 7;
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(14, 100);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(33, 15);
            this.PriceLabel.TabIndex = 6;
            this.PriceLabel.Text = "Price";
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.Location = new System.Drawing.Point(14, 71);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(51, 15);
            this.AmountLabel.TabIndex = 5;
            this.AmountLabel.Text = "Amount";
            // 
            // AmountTextBox
            // 
            this.AmountTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.AmountTextBox.Location = new System.Drawing.Point(87, 68);
            this.AmountTextBox.Name = "AmountTextBox";
            this.AmountTextBox.ReadOnly = true;
            this.AmountTextBox.Size = new System.Drawing.Size(254, 23);
            this.AmountTextBox.TabIndex = 4;
            // 
            // CodeTextBox
            // 
            this.CodeTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.CodeTextBox.Location = new System.Drawing.Point(87, 38);
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.ReadOnly = true;
            this.CodeTextBox.Size = new System.Drawing.Size(254, 23);
            this.CodeTextBox.TabIndex = 3;
            // 
            // CodeLabel
            // 
            this.CodeLabel.AutoSize = true;
            this.CodeLabel.Location = new System.Drawing.Point(14, 41);
            this.CodeLabel.Name = "CodeLabel";
            this.CodeLabel.Size = new System.Drawing.Size(35, 15);
            this.CodeLabel.TabIndex = 2;
            this.CodeLabel.Text = "Code";
            // 
            // NameTextBox
            // 
            this.NameTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.NameTextBox.Location = new System.Drawing.Point(87, 9);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.ReadOnly = true;
            this.NameTextBox.Size = new System.Drawing.Size(254, 23);
            this.NameTextBox.TabIndex = 1;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(14, 12);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(39, 15);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name";
            // 
            // Tree
            // 
            this.Tree.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Tree.Location = new System.Drawing.Point(12, 12);
            this.Tree.Name = "Tree";
            this.Tree.Size = new System.Drawing.Size(214, 426);
            this.Tree.TabIndex = 5;
            this.Tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tree_AfterSelect);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(721, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 48);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OpenBasket);
            // 
            // ClientNameLabel
            // 
            this.ClientNameLabel.Location = new System.Drawing.Point(305, 13);
            this.ClientNameLabel.Name = "ClientNameLabel";
            this.ClientNameLabel.Size = new System.Drawing.Size(256, 47);
            this.ClientNameLabel.TabIndex = 7;
            this.ClientNameLabel.Text = "label1";
            this.ClientNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(232, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 48);
            this.button2.TabIndex = 8;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OpenProfile);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ClientNameLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Tree);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "ClientForm";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.PictureBox PhotoBox;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.TextBox AmountTextBox;
        private System.Windows.Forms.TextBox CodeTextBox;
        private System.Windows.Forms.Label CodeLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TreeView Tree;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ClientNameLabel;
        private System.Windows.Forms.Button AddToBasketButton;
        private System.Windows.Forms.Button button2;
    }
}