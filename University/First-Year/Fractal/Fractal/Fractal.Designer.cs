namespace Fractal
{
    partial class Fractal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fractal));
            this.DrawPicture = new System.Windows.Forms.Button();
            this.FractalTree = new System.Windows.Forms.Button();
            this.TheKochCurve = new System.Windows.Forms.Button();
            this.TheSierpinskiCarpet = new System.Windows.Forms.Button();
            this.TheSierpinskiTriangle = new System.Windows.Forms.Button();
            this.TheCantorSet = new System.Windows.Forms.Button();
            this.RecursionDepth = new System.Windows.Forms.TrackBar();
            this.startColor = new System.Windows.Forms.Button();
            this.endColor = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cantorLengthValue = new System.Windows.Forms.Label();
            this.trackBarCantorLength = new System.Windows.Forms.TrackBar();
            this.labelCantorLength = new System.Windows.Forms.Label();
            this.coefficientValue = new System.Windows.Forms.Label();
            this.trackBarCoefficient = new System.Windows.Forms.TrackBar();
            this.labelCoefficient = new System.Windows.Forms.Label();
            this.secondAngleValue = new System.Windows.Forms.Label();
            this.trackBarSecondAngle = new System.Windows.Forms.TrackBar();
            this.labelSecondAngle = new System.Windows.Forms.Label();
            this.firstAngleValue = new System.Windows.Forms.Label();
            this.trackBarFirstAngle = new System.Windows.Forms.TrackBar();
            this.labelFirstAngle = new System.Windows.Forms.Label();
            this.lengthVaule = new System.Windows.Forms.Label();
            this.trackBarLength = new System.Windows.Forms.TrackBar();
            this.labelLength = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Minus = new System.Windows.Forms.Button();
            this.Plus = new System.Windows.Forms.Button();
            this.SavePicture = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.RecursionDepth)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCantorLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCoefficient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSecondAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFirstAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLength)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawPicture
            // 
            this.DrawPicture.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DrawPicture.BackColor = System.Drawing.Color.Blue;
            this.DrawPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DrawPicture.FlatAppearance.BorderSize = 0;
            this.DrawPicture.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DrawPicture.ForeColor = System.Drawing.Color.Black;
            this.DrawPicture.Location = new System.Drawing.Point(37, 16);
            this.DrawPicture.Name = "DrawPicture";
            this.DrawPicture.Size = new System.Drawing.Size(398, 59);
            this.DrawPicture.TabIndex = 0;
            this.DrawPicture.Text = "Draw";
            this.DrawPicture.UseVisualStyleBackColor = false;
            this.DrawPicture.Click += new System.EventHandler(this.button1_Click);
            // 
            // FractalTree
            // 
            this.FractalTree.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FractalTree.AutoSize = true;
            this.FractalTree.BackColor = System.Drawing.Color.White;
            this.FractalTree.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.FractalTree.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FractalTree.ForeColor = System.Drawing.Color.Black;
            this.FractalTree.Location = new System.Drawing.Point(12, 12);
            this.FractalTree.Name = "FractalTree";
            this.FractalTree.Size = new System.Drawing.Size(295, 130);
            this.FractalTree.TabIndex = 1;
            this.FractalTree.Text = "Fractal tree";
            this.FractalTree.UseVisualStyleBackColor = false;
            this.FractalTree.Click += new System.EventHandler(this.FractalTree_Click);
            // 
            // TheKochCurve
            // 
            this.TheKochCurve.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TheKochCurve.BackColor = System.Drawing.Color.White;
            this.TheKochCurve.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.TheKochCurve.FlatAppearance.BorderSize = 0;
            this.TheKochCurve.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TheKochCurve.ForeColor = System.Drawing.Color.Black;
            this.TheKochCurve.Location = new System.Drawing.Point(12, 148);
            this.TheKochCurve.Name = "TheKochCurve";
            this.TheKochCurve.Size = new System.Drawing.Size(295, 130);
            this.TheKochCurve.TabIndex = 1;
            this.TheKochCurve.Text = "The Koch Curve";
            this.TheKochCurve.UseVisualStyleBackColor = false;
            this.TheKochCurve.Click += new System.EventHandler(this.TheKochCurve_Click);
            // 
            // TheSierpinskiCarpet
            // 
            this.TheSierpinskiCarpet.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TheSierpinskiCarpet.BackColor = System.Drawing.Color.White;
            this.TheSierpinskiCarpet.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.TheSierpinskiCarpet.FlatAppearance.BorderSize = 0;
            this.TheSierpinskiCarpet.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TheSierpinskiCarpet.ForeColor = System.Drawing.Color.Black;
            this.TheSierpinskiCarpet.Location = new System.Drawing.Point(12, 284);
            this.TheSierpinskiCarpet.Name = "TheSierpinskiCarpet";
            this.TheSierpinskiCarpet.Size = new System.Drawing.Size(295, 130);
            this.TheSierpinskiCarpet.TabIndex = 1;
            this.TheSierpinskiCarpet.Text = " The Sierpinski Carpet";
            this.TheSierpinskiCarpet.UseVisualStyleBackColor = false;
            this.TheSierpinskiCarpet.Click += new System.EventHandler(this.TheSierpinskiCarpet_Click);
            // 
            // TheSierpinskiTriangle
            // 
            this.TheSierpinskiTriangle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TheSierpinskiTriangle.BackColor = System.Drawing.Color.White;
            this.TheSierpinskiTriangle.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.TheSierpinskiTriangle.FlatAppearance.BorderSize = 0;
            this.TheSierpinskiTriangle.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TheSierpinskiTriangle.ForeColor = System.Drawing.Color.Black;
            this.TheSierpinskiTriangle.Location = new System.Drawing.Point(12, 420);
            this.TheSierpinskiTriangle.Name = "TheSierpinskiTriangle";
            this.TheSierpinskiTriangle.Size = new System.Drawing.Size(295, 130);
            this.TheSierpinskiTriangle.TabIndex = 1;
            this.TheSierpinskiTriangle.Text = "The Sierpinski Triangle";
            this.TheSierpinskiTriangle.UseVisualStyleBackColor = false;
            this.TheSierpinskiTriangle.Click += new System.EventHandler(this.TheSierpinskiTriangle_Click);
            // 
            // TheCantorSet
            // 
            this.TheCantorSet.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TheCantorSet.BackColor = System.Drawing.Color.White;
            this.TheCantorSet.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.TheCantorSet.FlatAppearance.BorderSize = 0;
            this.TheCantorSet.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TheCantorSet.ForeColor = System.Drawing.Color.Black;
            this.TheCantorSet.Location = new System.Drawing.Point(12, 556);
            this.TheCantorSet.Name = "TheCantorSet";
            this.TheCantorSet.Size = new System.Drawing.Size(295, 130);
            this.TheCantorSet.TabIndex = 1;
            this.TheCantorSet.Text = "The Cantor Set";
            this.TheCantorSet.UseVisualStyleBackColor = false;
            this.TheCantorSet.Click += new System.EventHandler(this.TheCantorSet_Click);
            // 
            // RecursionDepth
            // 
            this.RecursionDepth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RecursionDepth.LargeChange = 1;
            this.RecursionDepth.Location = new System.Drawing.Point(6, 58);
            this.RecursionDepth.Maximum = 9;
            this.RecursionDepth.Name = "RecursionDepth";
            this.RecursionDepth.Size = new System.Drawing.Size(201, 45);
            this.RecursionDepth.TabIndex = 2;
            this.RecursionDepth.ValueChanged += new System.EventHandler(this.RecursionDepth_ValueChanged);
            // 
            // startColor
            // 
            this.startColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.startColor.BackColor = System.Drawing.Color.White;
            this.startColor.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startColor.Location = new System.Drawing.Point(6, 580);
            this.startColor.Name = "startColor";
            this.startColor.Size = new System.Drawing.Size(201, 50);
            this.startColor.TabIndex = 4;
            this.startColor.Text = "Start Color";
            this.startColor.UseVisualStyleBackColor = false;
            this.startColor.BackColorChanged += new System.EventHandler(this.startColor_BackColorChanged);
            this.startColor.Click += new System.EventHandler(this.StartColor_Click);
            // 
            // endColor
            // 
            this.endColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.endColor.BackColor = System.Drawing.Color.White;
            this.endColor.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.endColor.Location = new System.Drawing.Point(6, 636);
            this.endColor.Name = "endColor";
            this.endColor.Size = new System.Drawing.Size(201, 50);
            this.endColor.TabIndex = 4;
            this.endColor.Text = "End Color";
            this.endColor.UseVisualStyleBackColor = false;
            this.endColor.BackColorChanged += new System.EventHandler(this.endColor_BackColorChanged);
            this.endColor.Click += new System.EventHandler(this.EndColor_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.TheCantorSet);
            this.panel1.Controls.Add(this.FractalTree);
            this.panel1.Controls.Add(this.TheSierpinskiTriangle);
            this.panel1.Controls.Add(this.TheKochCurve);
            this.panel1.Controls.Add(this.TheSierpinskiCarpet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(321, 729);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.cantorLengthValue);
            this.panel2.Controls.Add(this.trackBarCantorLength);
            this.panel2.Controls.Add(this.labelCantorLength);
            this.panel2.Controls.Add(this.coefficientValue);
            this.panel2.Controls.Add(this.trackBarCoefficient);
            this.panel2.Controls.Add(this.labelCoefficient);
            this.panel2.Controls.Add(this.secondAngleValue);
            this.panel2.Controls.Add(this.trackBarSecondAngle);
            this.panel2.Controls.Add(this.labelSecondAngle);
            this.panel2.Controls.Add(this.firstAngleValue);
            this.panel2.Controls.Add(this.trackBarFirstAngle);
            this.panel2.Controls.Add(this.labelFirstAngle);
            this.panel2.Controls.Add(this.lengthVaule);
            this.panel2.Controls.Add(this.trackBarLength);
            this.panel2.Controls.Add(this.labelLength);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.RecursionDepth);
            this.panel2.Controls.Add(this.endColor);
            this.panel2.Controls.Add(this.startColor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(795, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(213, 729);
            this.panel2.TabIndex = 6;
            // 
            // cantorLengthValue
            // 
            this.cantorLengthValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cantorLengthValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cantorLengthValue.Location = new System.Drawing.Point(39, 550);
            this.cantorLengthValue.Name = "cantorLengthValue";
            this.cantorLengthValue.Size = new System.Drawing.Size(143, 23);
            this.cantorLengthValue.TabIndex = 6;
            this.cantorLengthValue.Text = "10";
            this.cantorLengthValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarCantorLength
            // 
            this.trackBarCantorLength.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.trackBarCantorLength.LargeChange = 1;
            this.trackBarCantorLength.Location = new System.Drawing.Point(6, 528);
            this.trackBarCantorLength.Maximum = 100;
            this.trackBarCantorLength.Minimum = 10;
            this.trackBarCantorLength.Name = "trackBarCantorLength";
            this.trackBarCantorLength.Size = new System.Drawing.Size(201, 45);
            this.trackBarCantorLength.TabIndex = 2;
            this.trackBarCantorLength.Value = 10;
            this.trackBarCantorLength.ValueChanged += new System.EventHandler(this.trackBarCantorLength_ValueChanged);
            // 
            // labelCantorLength
            // 
            this.labelCantorLength.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCantorLength.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCantorLength.Location = new System.Drawing.Point(6, 482);
            this.labelCantorLength.Name = "labelCantorLength";
            this.labelCantorLength.Size = new System.Drawing.Size(201, 43);
            this.labelCantorLength.TabIndex = 5;
            this.labelCantorLength.Text = "Cantor Length";
            this.labelCantorLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // coefficientValue
            // 
            this.coefficientValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.coefficientValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.coefficientValue.Location = new System.Drawing.Point(39, 456);
            this.coefficientValue.Name = "coefficientValue";
            this.coefficientValue.Size = new System.Drawing.Size(143, 23);
            this.coefficientValue.TabIndex = 6;
            this.coefficientValue.Text = "0.7";
            this.coefficientValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarCoefficient
            // 
            this.trackBarCoefficient.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.trackBarCoefficient.LargeChange = 1;
            this.trackBarCoefficient.Location = new System.Drawing.Point(6, 434);
            this.trackBarCoefficient.Minimum = 6;
            this.trackBarCoefficient.Name = "trackBarCoefficient";
            this.trackBarCoefficient.Size = new System.Drawing.Size(201, 45);
            this.trackBarCoefficient.TabIndex = 2;
            this.trackBarCoefficient.Value = 7;
            this.trackBarCoefficient.ValueChanged += new System.EventHandler(this.trackBarCoefficient_ValueChanged);
            // 
            // labelCoefficient
            // 
            this.labelCoefficient.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCoefficient.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCoefficient.Location = new System.Drawing.Point(6, 388);
            this.labelCoefficient.Name = "labelCoefficient";
            this.labelCoefficient.Size = new System.Drawing.Size(201, 43);
            this.labelCoefficient.TabIndex = 5;
            this.labelCoefficient.Text = "Coefficient";
            this.labelCoefficient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // secondAngleValue
            // 
            this.secondAngleValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.secondAngleValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secondAngleValue.Location = new System.Drawing.Point(39, 362);
            this.secondAngleValue.Name = "secondAngleValue";
            this.secondAngleValue.Size = new System.Drawing.Size(143, 23);
            this.secondAngleValue.TabIndex = 6;
            this.secondAngleValue.Text = "20";
            this.secondAngleValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarSecondAngle
            // 
            this.trackBarSecondAngle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.trackBarSecondAngle.LargeChange = 1;
            this.trackBarSecondAngle.Location = new System.Drawing.Point(6, 340);
            this.trackBarSecondAngle.Maximum = 90;
            this.trackBarSecondAngle.Name = "trackBarSecondAngle";
            this.trackBarSecondAngle.Size = new System.Drawing.Size(201, 45);
            this.trackBarSecondAngle.TabIndex = 2;
            this.trackBarSecondAngle.Value = 20;
            this.trackBarSecondAngle.ValueChanged += new System.EventHandler(this.trackBarSecondAngle_ValueChanged);
            // 
            // labelSecondAngle
            // 
            this.labelSecondAngle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSecondAngle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSecondAngle.Location = new System.Drawing.Point(6, 294);
            this.labelSecondAngle.Name = "labelSecondAngle";
            this.labelSecondAngle.Size = new System.Drawing.Size(201, 43);
            this.labelSecondAngle.TabIndex = 5;
            this.labelSecondAngle.Text = "Second Angle";
            this.labelSecondAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // firstAngleValue
            // 
            this.firstAngleValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.firstAngleValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.firstAngleValue.Location = new System.Drawing.Point(39, 268);
            this.firstAngleValue.Name = "firstAngleValue";
            this.firstAngleValue.Size = new System.Drawing.Size(143, 23);
            this.firstAngleValue.TabIndex = 6;
            this.firstAngleValue.Text = "20";
            this.firstAngleValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarFirstAngle
            // 
            this.trackBarFirstAngle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.trackBarFirstAngle.LargeChange = 1;
            this.trackBarFirstAngle.Location = new System.Drawing.Point(6, 246);
            this.trackBarFirstAngle.Maximum = 90;
            this.trackBarFirstAngle.Name = "trackBarFirstAngle";
            this.trackBarFirstAngle.Size = new System.Drawing.Size(201, 45);
            this.trackBarFirstAngle.TabIndex = 2;
            this.trackBarFirstAngle.Value = 20;
            this.trackBarFirstAngle.ValueChanged += new System.EventHandler(this.trackBarFirstAngle_ValueChanged);
            // 
            // labelFirstAngle
            // 
            this.labelFirstAngle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelFirstAngle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelFirstAngle.Location = new System.Drawing.Point(6, 200);
            this.labelFirstAngle.Name = "labelFirstAngle";
            this.labelFirstAngle.Size = new System.Drawing.Size(201, 43);
            this.labelFirstAngle.TabIndex = 5;
            this.labelFirstAngle.Text = "First Angle";
            this.labelFirstAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lengthVaule
            // 
            this.lengthVaule.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lengthVaule.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lengthVaule.Location = new System.Drawing.Point(39, 174);
            this.lengthVaule.Name = "lengthVaule";
            this.lengthVaule.Size = new System.Drawing.Size(143, 23);
            this.lengthVaule.TabIndex = 6;
            this.lengthVaule.Text = "250";
            this.lengthVaule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarLength
            // 
            this.trackBarLength.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.trackBarLength.LargeChange = 1;
            this.trackBarLength.Location = new System.Drawing.Point(6, 152);
            this.trackBarLength.Maximum = 600;
            this.trackBarLength.Minimum = 250;
            this.trackBarLength.Name = "trackBarLength";
            this.trackBarLength.Size = new System.Drawing.Size(201, 45);
            this.trackBarLength.TabIndex = 2;
            this.trackBarLength.Value = 250;
            this.trackBarLength.ValueChanged += new System.EventHandler(this.trackBarLength_ValueChanged);
            // 
            // labelLength
            // 
            this.labelLength.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelLength.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelLength.Location = new System.Drawing.Point(6, 106);
            this.labelLength.Name = "labelLength";
            this.labelLength.Size = new System.Drawing.Size(201, 43);
            this.labelLength.TabIndex = 5;
            this.labelLength.Text = "Length";
            this.labelLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(39, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 43);
            this.label1.TabIndex = 5;
            this.label1.Text = "Recursion Depth";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.DrawPicture);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(321, 640);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(474, 89);
            this.panel3.TabIndex = 7;
            // 
            // Minus
            // 
            this.Minus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Minus.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Minus.Location = new System.Drawing.Point(524, 616);
            this.Minus.Name = "Minus";
            this.Minus.Size = new System.Drawing.Size(32, 32);
            this.Minus.TabIndex = 1;
            this.Minus.TabStop = false;
            this.Minus.Text = "-";
            this.Minus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.Minus.UseVisualStyleBackColor = true;
            this.Minus.Click += new System.EventHandler(this.Minus_Click);
            // 
            // Plus
            // 
            this.Plus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Plus.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Plus.Location = new System.Drawing.Point(562, 616);
            this.Plus.Name = "Plus";
            this.Plus.Size = new System.Drawing.Size(32, 32);
            this.Plus.TabIndex = 1;
            this.Plus.TabStop = false;
            this.Plus.Text = "+";
            this.Plus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Plus.UseVisualStyleBackColor = true;
            this.Plus.Click += new System.EventHandler(this.Plus_Click);
            // 
            // SavePicture
            // 
            this.SavePicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SavePicture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SavePicture.BackgroundImage")));
            this.SavePicture.Location = new System.Drawing.Point(747, 600);
            this.SavePicture.Name = "SavePicture";
            this.SavePicture.Size = new System.Drawing.Size(48, 48);
            this.SavePicture.TabIndex = 0;
            this.SavePicture.UseVisualStyleBackColor = true;
            this.SavePicture.Click += new System.EventHandler(this.SavePicture_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 4;
            this.toolTip1.ToolTipTitle = "Warning";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "png";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.pictureBox);
            this.panel4.Location = new System.Drawing.Point(321, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(474, 594);
            this.panel4.TabIndex = 8;
            this.panel4.SizeChanged += new System.EventHandler(this.panel4_SizeChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(61, 55);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(335, 417);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // Fractal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.Minus);
            this.Controls.Add(this.SavePicture);
            this.Controls.Add(this.Plus);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(960, 540);
            this.Name = "Fractal";
            this.Text = "Fractal";
            ((System.ComponentModel.ISupportInitialize)(this.RecursionDepth)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCantorLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCoefficient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSecondAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFirstAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLength)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DrawPicture;
        private System.Windows.Forms.Button FractalTree;
        private System.Windows.Forms.Button TheKochCurve;
        private System.Windows.Forms.Button TheSierpinskiCarpet;
        private System.Windows.Forms.Button TheSierpinskiTriangle;
        private System.Windows.Forms.Button TheCantorSet;
        private System.Windows.Forms.TrackBar RecursionDepth;
        private System.Windows.Forms.Button startColor;
        private System.Windows.Forms.Button endColor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button SavePicture;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button Minus;
        private System.Windows.Forms.Button Plus;
        protected System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TrackBar trackBarLength;
        private System.Windows.Forms.Label labelLength;
        private System.Windows.Forms.Label lengthVaule;
        private System.Windows.Forms.Label cantorLengthValue;
        private System.Windows.Forms.TrackBar trackBarCantorLength;
        private System.Windows.Forms.Label labelCantorLength;
        private System.Windows.Forms.Label coefficientValue;
        private System.Windows.Forms.TrackBar trackBarCoefficient;
        private System.Windows.Forms.Label labelCoefficient;
        private System.Windows.Forms.Label secondAngleValue;
        private System.Windows.Forms.TrackBar trackBarSecondAngle;
        private System.Windows.Forms.Label labelSecondAngle;
        private System.Windows.Forms.Label firstAngleValue;
        private System.Windows.Forms.TrackBar trackBarFirstAngle;
        private System.Windows.Forms.Label labelFirstAngle;
    }
}

