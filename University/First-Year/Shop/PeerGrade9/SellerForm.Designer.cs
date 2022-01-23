namespace PeerGrade9
{
    partial class SellerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("New Section");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SellerForm));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CostReport = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tree = new System.Windows.Forms.TreeView();
            this.EditNodes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteSectionContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AddSectionContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameNodeContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SectionDataGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.CSVReportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.GoodsPage = new System.Windows.Forms.TabPage();
            this.ClientsPage = new System.Windows.Forms.TabPage();
            this.ClientDataGrid = new System.Windows.Forms.DataGridView();
            this.ClientNameLabel = new System.Windows.Forms.Label();
            this.ActiveOrdersCheckBox = new System.Windows.Forms.CheckBox();
            this.ClientsTree = new System.Windows.Forms.TreeView();
            this.MenuStrip.SuspendLayout();
            this.EditNodes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SectionDataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.GoodsPage.SuspendLayout();
            this.ClientsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.MediumTurquoise;
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.CostReport,
            this.helpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(804, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // CostReport
            // 
            this.CostReport.Name = "CostReport";
            this.CostReport.Size = new System.Drawing.Size(81, 20);
            this.CostReport.Text = "Cost Report";
            this.CostReport.Click += new System.EventHandler(this.CSVReport_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // Tree
            // 
            this.Tree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Tree.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tree.ContextMenuStrip = this.EditNodes;
            this.Tree.Location = new System.Drawing.Point(3, 3);
            this.Tree.Name = "Tree";
            treeNode1.Name = "NewSection";
            treeNode1.Text = "New Section";
            this.Tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.Tree.Size = new System.Drawing.Size(203, 380);
            this.Tree.TabIndex = 1;
            this.Tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tree_AfterSelect);
            // 
            // EditNodes
            // 
            this.EditNodes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.EditNodes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteSectionContextMenu,
            this.AddSectionContextMenu,
            this.RenameNodeContextMenu});
            this.EditNodes.Name = "EditNodes";
            this.EditNodes.Size = new System.Drawing.Size(139, 70);
            this.EditNodes.Opening += new System.ComponentModel.CancelEventHandler(this.EditNodes_Opening);
            // 
            // DeleteSectionContextMenu
            // 
            this.DeleteSectionContextMenu.Name = "DeleteSectionContextMenu";
            this.DeleteSectionContextMenu.Size = new System.Drawing.Size(138, 22);
            this.DeleteSectionContextMenu.Text = "Delete";
            // 
            // AddSectionContextMenu
            // 
            this.AddSectionContextMenu.Name = "AddSectionContextMenu";
            this.AddSectionContextMenu.Size = new System.Drawing.Size(138, 22);
            this.AddSectionContextMenu.Text = "Add Section";
            // 
            // RenameNodeContextMenu
            // 
            this.RenameNodeContextMenu.Name = "RenameNodeContextMenu";
            this.RenameNodeContextMenu.Size = new System.Drawing.Size(138, 22);
            this.RenameNodeContextMenu.Text = "Rename";
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
            this.SectionDataGrid.Location = new System.Drawing.Point(215, 3);
            this.SectionDataGrid.Name = "SectionDataGrid";
            this.SectionDataGrid.ReadOnly = true;
            this.SectionDataGrid.RowHeadersVisible = false;
            this.SectionDataGrid.RowHeadersWidth = 51;
            this.SectionDataGrid.Size = new System.Drawing.Size(556, 380);
            this.SectionDataGrid.TabIndex = 2;
            this.SectionDataGrid.Text = "dataGridView1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.panel1.Location = new System.Drawing.Point(215, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 383);
            this.panel1.TabIndex = 3;
            this.panel1.Visible = false;
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
            this.PhotoBox.DoubleClick += new System.EventHandler(this.PhotoTextBox_DoubleClick);
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
            this.DescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DescriptionTextBox.Size = new System.Drawing.Size(458, 246);
            this.DescriptionTextBox.TabIndex = 8;
            this.DescriptionTextBox.TextChanged += new System.EventHandler(this.DescriprionTextBox_TextChanged);
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.PriceTextBox.Location = new System.Drawing.Point(87, 97);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(254, 23);
            this.PriceTextBox.TabIndex = 7;
            this.PriceTextBox.TextChanged += new System.EventHandler(this.PriceTextBox_TextChanged);
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
            this.AmountTextBox.Size = new System.Drawing.Size(254, 23);
            this.AmountTextBox.TabIndex = 4;
            this.AmountTextBox.TextChanged += new System.EventHandler(this.AmountTextBox_TextChanged);
            // 
            // CodeTextBox
            // 
            this.CodeTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.CodeTextBox.Location = new System.Drawing.Point(87, 38);
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.Size = new System.Drawing.Size(254, 23);
            this.CodeTextBox.TabIndex = 3;
            this.CodeTextBox.TextChanged += new System.EventHandler(this.CodeTextBox_TextChanged);
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
            this.NameTextBox.Size = new System.Drawing.Size(254, 23);
            this.NameTextBox.TabIndex = 1;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
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
            // CSVReportMenuItem
            // 
            this.CSVReportMenuItem.Name = "CSVReportMenuItem";
            this.CSVReportMenuItem.Size = new System.Drawing.Size(167, 26);
            this.CSVReportMenuItem.Text = "&CSV Report";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.GoodsPage);
            this.tabControl1.Controls.Add(this.ClientsPage);
            this.tabControl1.Location = new System.Drawing.Point(13, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(779, 411);
            this.tabControl1.TabIndex = 4;
            // 
            // GoodsPage
            // 
            this.GoodsPage.BackColor = System.Drawing.Color.MediumTurquoise;
            this.GoodsPage.Controls.Add(this.Tree);
            this.GoodsPage.Controls.Add(this.panel1);
            this.GoodsPage.Controls.Add(this.SectionDataGrid);
            this.GoodsPage.Location = new System.Drawing.Point(4, 24);
            this.GoodsPage.Name = "GoodsPage";
            this.GoodsPage.Padding = new System.Windows.Forms.Padding(3);
            this.GoodsPage.Size = new System.Drawing.Size(771, 383);
            this.GoodsPage.TabIndex = 0;
            this.GoodsPage.Text = "Goods";
            // 
            // ClientsPage
            // 
            this.ClientsPage.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientsPage.Controls.Add(this.ClientDataGrid);
            this.ClientsPage.Controls.Add(this.ClientNameLabel);
            this.ClientsPage.Controls.Add(this.ActiveOrdersCheckBox);
            this.ClientsPage.Controls.Add(this.ClientsTree);
            this.ClientsPage.Location = new System.Drawing.Point(4, 24);
            this.ClientsPage.Name = "ClientsPage";
            this.ClientsPage.Padding = new System.Windows.Forms.Padding(3);
            this.ClientsPage.Size = new System.Drawing.Size(771, 383);
            this.ClientsPage.TabIndex = 1;
            this.ClientsPage.Text = "Clients";
            // 
            // ClientDataGrid
            // 
            this.ClientDataGrid.AllowUserToAddRows = false;
            this.ClientDataGrid.AllowUserToDeleteRows = false;
            this.ClientDataGrid.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.ClientDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientDataGrid.Location = new System.Drawing.Point(214, 25);
            this.ClientDataGrid.Name = "ClientDataGrid";
            this.ClientDataGrid.ReadOnly = true;
            this.ClientDataGrid.RowTemplate.Height = 25;
            this.ClientDataGrid.Size = new System.Drawing.Size(557, 358);
            this.ClientDataGrid.TabIndex = 4;
            this.ClientDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClientDataGrid_CellClick);
            // 
            // ClientNameLabel
            // 
            this.ClientNameLabel.AutoSize = true;
            this.ClientNameLabel.Location = new System.Drawing.Point(214, 7);
            this.ClientNameLabel.Name = "ClientNameLabel";
            this.ClientNameLabel.Size = new System.Drawing.Size(0, 15);
            this.ClientNameLabel.TabIndex = 3;
            // 
            // ActiveOrdersCheckBox
            // 
            this.ActiveOrdersCheckBox.AutoSize = true;
            this.ActiveOrdersCheckBox.Location = new System.Drawing.Point(673, 6);
            this.ActiveOrdersCheckBox.Name = "ActiveOrdersCheckBox";
            this.ActiveOrdersCheckBox.Size = new System.Drawing.Size(95, 19);
            this.ActiveOrdersCheckBox.TabIndex = 2;
            this.ActiveOrdersCheckBox.Text = "Active orders";
            this.ActiveOrdersCheckBox.UseVisualStyleBackColor = true;
            this.ActiveOrdersCheckBox.CheckStateChanged += new System.EventHandler(this.ActiveOrdersCheckBox_CheckStateChanged);
            // 
            // ClientsTree
            // 
            this.ClientsTree.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientsTree.Location = new System.Drawing.Point(4, 4);
            this.ClientsTree.Name = "ClientsTree";
            this.ClientsTree.Size = new System.Drawing.Size(203, 380);
            this.ClientsTree.TabIndex = 0;
            this.ClientsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ClientsTree_AfterSelect);
            // 
            // SellerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size(804, 451);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.MaximumSize = new System.Drawing.Size(820, 490);
            this.MinimumSize = new System.Drawing.Size(820, 490);
            this.Name = "SellerForm";
            this.Text = "Seller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SellerForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SellerForm_FormClosed);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.EditNodes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SectionDataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.GoodsPage.ResumeLayout(false);
            this.ClientsPage.ResumeLayout(false);
            this.ClientsPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.DataGridView SectionDataGrid;
        private System.Windows.Forms.ContextMenuStrip EditNodes;
        private System.Windows.Forms.ToolStripMenuItem DeleteSectionContextMenu;
        private System.Windows.Forms.ToolStripMenuItem AddSectionContextMenu;
        private System.Windows.Forms.ToolStripMenuItem RenameNodeContextMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.TextBox AmountTextBox;
        private System.Windows.Forms.TextBox CodeTextBox;
        private System.Windows.Forms.Label CodeLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.PictureBox PhotoBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.ToolStripMenuItem CostReport;
        private System.Windows.Forms.ToolStripMenuItem CSVReportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        internal System.Windows.Forms.TreeView Tree;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage GoodsPage;
        private System.Windows.Forms.TabPage ClientsPage;
        private System.Windows.Forms.TreeView ClientsTree;
        private System.Windows.Forms.Label ClientNameLabel;
        private System.Windows.Forms.CheckBox ActiveOrdersCheckBox;
        private System.Windows.Forms.DataGridView ClientDataGrid;
    }
}

