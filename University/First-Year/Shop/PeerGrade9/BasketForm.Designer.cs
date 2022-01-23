
namespace PeerGrade9
{
    partial class BasketForm
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
            this.SectionDataGrid = new System.Windows.Forms.DataGridView();
            this.SetAnOrderButton = new System.Windows.Forms.Button();
            this.ShowAllOrdersButton = new System.Windows.Forms.Button();
            this.CurrentGrid = new System.Windows.Forms.Label();
            this.ShowBasketButton = new System.Windows.Forms.Button();
            this.PayButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SectionDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // SectionDataGrid
            // 
            this.SectionDataGrid.AllowUserToAddRows = false;
            this.SectionDataGrid.AllowUserToDeleteRows = false;
            this.SectionDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SectionDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SectionDataGrid.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.SectionDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SectionDataGrid.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.SectionDataGrid.Location = new System.Drawing.Point(12, 64);
            this.SectionDataGrid.Name = "SectionDataGrid";
            this.SectionDataGrid.ReadOnly = true;
            this.SectionDataGrid.RowHeadersVisible = false;
            this.SectionDataGrid.RowHeadersWidth = 51;
            this.SectionDataGrid.Size = new System.Drawing.Size(776, 374);
            this.SectionDataGrid.TabIndex = 3;
            this.SectionDataGrid.Text = "dataGridView1";
            // 
            // SetAnOrderButton
            // 
            this.SetAnOrderButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.SetAnOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SetAnOrderButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SetAnOrderButton.Location = new System.Drawing.Point(651, 13);
            this.SetAnOrderButton.Name = "SetAnOrderButton";
            this.SetAnOrderButton.Size = new System.Drawing.Size(136, 45);
            this.SetAnOrderButton.TabIndex = 4;
            this.SetAnOrderButton.Text = "Set an order";
            this.SetAnOrderButton.UseVisualStyleBackColor = false;
            this.SetAnOrderButton.Click += new System.EventHandler(this.SetAnOrderButton_Click);
            // 
            // ShowAllOrdersButton
            // 
            this.ShowAllOrdersButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ShowAllOrdersButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShowAllOrdersButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ShowAllOrdersButton.Location = new System.Drawing.Point(367, 13);
            this.ShowAllOrdersButton.Name = "ShowAllOrdersButton";
            this.ShowAllOrdersButton.Size = new System.Drawing.Size(136, 45);
            this.ShowAllOrdersButton.TabIndex = 5;
            this.ShowAllOrdersButton.Text = "Show all orders";
            this.ShowAllOrdersButton.UseVisualStyleBackColor = false;
            this.ShowAllOrdersButton.Click += new System.EventHandler(this.ShowAllOrdersButton_Click);
            // 
            // label1
            // 
            this.CurrentGrid.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CurrentGrid.Location = new System.Drawing.Point(12, 9);
            this.CurrentGrid.Name = "label1";
            this.CurrentGrid.Size = new System.Drawing.Size(242, 45);
            this.CurrentGrid.TabIndex = 6;
            this.CurrentGrid.Text = "Orders";
            this.CurrentGrid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ShowBasketButton
            // 
            this.ShowBasketButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ShowBasketButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShowBasketButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ShowBasketButton.Location = new System.Drawing.Point(367, 13);
            this.ShowBasketButton.Name = "ShowBasketButton";
            this.ShowBasketButton.Size = new System.Drawing.Size(136, 45);
            this.ShowBasketButton.TabIndex = 7;
            this.ShowBasketButton.Text = "Show basket";
            this.ShowBasketButton.UseVisualStyleBackColor = false;
            this.ShowBasketButton.Visible = false;
            this.ShowBasketButton.Click += new System.EventHandler(this.ShowBasketButton_Click);
            // 
            // PayButton
            // 
            this.PayButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.PayButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PayButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PayButton.Location = new System.Drawing.Point(509, 13);
            this.PayButton.Name = "PayButton";
            this.PayButton.Size = new System.Drawing.Size(136, 45);
            this.PayButton.TabIndex = 8;
            this.PayButton.Text = "Pay";
            this.PayButton.UseVisualStyleBackColor = false;
            this.PayButton.Click += new System.EventHandler(this.PayButton_Click);
            // 
            // BasketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PayButton);
            this.Controls.Add(this.ShowBasketButton);
            this.Controls.Add(this.CurrentGrid);
            this.Controls.Add(this.ShowAllOrdersButton);
            this.Controls.Add(this.SetAnOrderButton);
            this.Controls.Add(this.SectionDataGrid);
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "BasketForm";
            this.Text = "BasketForm";
            ((System.ComponentModel.ISupportInitialize)(this.SectionDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView SectionDataGrid;
        private System.Windows.Forms.Button SetAnOrderButton;
        private System.Windows.Forms.Button ShowAllOrdersButton;
        private System.Windows.Forms.Label CurrentGrid;
        private System.Windows.Forms.Button ShowBasketButton;
        private System.Windows.Forms.Button PayButton;
    }
}