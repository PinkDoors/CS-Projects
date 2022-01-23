
namespace Tables
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.OpenButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.HistogramButton = new System.Windows.Forms.ToolStripButton();
            this.TwoDimensionGraphButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.AverageValueLabel = new System.Windows.Forms.ToolStripLabel();
            this.MedianLabel = new System.Windows.Forms.ToolStripLabel();
            this.MSELabel = new System.Windows.Forms.ToolStripLabel();
            this.DispersionLabel = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGrid
            // 
            this.DataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGrid.BackgroundColor = System.Drawing.Color.White;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Location = new System.Drawing.Point(12, 41);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.Size = new System.Drawing.Size(780, 398);
            this.DataGrid.TabIndex = 0;
            this.DataGrid.SelectionChanged += new System.EventHandler(this.DataGrid_SelectionChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenButton,
            this.toolStripSeparator1,
            this.HistogramButton,
            this.TwoDimensionGraphButton,
            this.toolStripSeparator2,
            this.AverageValueLabel,
            this.MedianLabel,
            this.MSELabel,
            this.DispersionLabel});
            this.toolStrip1.Location = new System.Drawing.Point(12, 6);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(780, 32);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // OpenButton
            // 
            this.OpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OpenButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenButton.Image")));
            this.OpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(40, 29);
            this.OpenButton.Text = "Open";
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // HistogramButton
            // 
            this.HistogramButton.AutoSize = false;
            this.HistogramButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.HistogramButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HistogramButton.Name = "HistogramButton";
            this.HistogramButton.Size = new System.Drawing.Size(70, 29);
            this.HistogramButton.Text = "Histogram";
            this.HistogramButton.Click += new System.EventHandler(this.HistogramButton_Click);
            // 
            // TwoDimensionGraphButton
            // 
            this.TwoDimensionGraphButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TwoDimensionGraphButton.Image = ((System.Drawing.Image)(resources.GetObject("TwoDimensionGraphButton.Image")));
            this.TwoDimensionGraphButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TwoDimensionGraphButton.Name = "TwoDimensionGraphButton";
            this.TwoDimensionGraphButton.Size = new System.Drawing.Size(136, 29);
            this.TwoDimensionGraphButton.Text = "Two-dimensional graph";
            this.TwoDimensionGraphButton.Click += new System.EventHandler(this.TwoDimensionGraphButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // AverageValueLabel
            // 
            this.AverageValueLabel.Name = "AverageValueLabel";
            this.AverageValueLabel.Size = new System.Drawing.Size(84, 29);
            this.AverageValueLabel.Text = "Average Value:";
            // 
            // MedianLabel
            // 
            this.MedianLabel.Name = "MedianLabel";
            this.MedianLabel.Size = new System.Drawing.Size(53, 29);
            this.MedianLabel.Text = "Median: ";
            // 
            // MSELabel
            // 
            this.MSELabel.Name = "MSELabel";
            this.MSELabel.Size = new System.Drawing.Size(36, 29);
            this.MSELabel.Text = "MSE: ";
            // 
            // DispersionLabel
            // 
            this.DispersionLabel.Name = "DispersionLabel";
            this.DispersionLabel.Size = new System.Drawing.Size(65, 29);
            this.DispersionLabel.Text = "Dispersion:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(804, 451);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.DataGrid);
            this.MinimumSize = new System.Drawing.Size(820, 490);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton HistogramButton;
        private System.Windows.Forms.ToolStripButton TwoDimensionGraphButton;
        private System.Windows.Forms.ToolStripButton OpenButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel AverageValueLabel;
        private System.Windows.Forms.ToolStripLabel MedianLabel;
        private System.Windows.Forms.ToolStripLabel MSELabel;
        private System.Windows.Forms.ToolStripLabel DispersionLabel;
    }
}

