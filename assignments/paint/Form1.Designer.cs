namespace paint
{
    partial class PaintApp
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
            this.picBox = new System.Windows.Forms.PictureBox();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.grpBoxTools = new System.Windows.Forms.GroupBox();
            this.tlStrp = new System.Windows.Forms.ToolStrip();
            this.btnPencil = new System.Windows.Forms.ToolStripButton();
            this.btnRectangle = new System.Windows.Forms.ToolStripButton();
            this.btnEllipse = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnBin = new System.Windows.Forms.ToolStripButton();
            this.grpBoxColors = new System.Windows.Forms.GroupBox();
            this.btnColorPicker = new System.Windows.Forms.Button();
            this.btnBlack = new System.Windows.Forms.Button();
            this.btnPurple = new System.Windows.Forms.Button();
            this.btnBlue = new System.Windows.Forms.Button();
            this.btnGreen = new System.Windows.Forms.Button();
            this.btnPink = new System.Windows.Forms.Button();
            this.btnYellow = new System.Windows.Forms.Button();
            this.btnOrange = new System.Windows.Forms.Button();
            this.btnRed = new System.Windows.Forms.Button();
            this.trckB1 = new System.Windows.Forms.TrackBar();
            this.lbl1 = new System.Windows.Forms.Label();
            this.chckBxShps = new System.Windows.Forms.CheckBox();
            this.btnErease = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.pnl2.SuspendLayout();
            this.grpBoxTools.SuspendLayout();
            this.tlStrp.SuspendLayout();
            this.grpBoxColors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckB1)).BeginInit();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox.Location = new System.Drawing.Point(81, 109);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(802, 381);
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // pnl1
            // 
            this.pnl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl1.Location = new System.Drawing.Point(0, 109);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(81, 381);
            this.pnl1.TabIndex = 1;
            // 
            // pnl2
            // 
            this.pnl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnl2.Controls.Add(this.lbl1);
            this.pnl2.Controls.Add(this.trckB1);
            this.pnl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl2.Location = new System.Drawing.Point(0, 490);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(883, 74);
            this.pnl2.TabIndex = 2;
            // 
            // grpBoxTools
            // 
            this.grpBoxTools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grpBoxTools.Controls.Add(this.tlStrp);
            this.grpBoxTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBoxTools.Location = new System.Drawing.Point(0, 0);
            this.grpBoxTools.Name = "grpBoxTools";
            this.grpBoxTools.Size = new System.Drawing.Size(1090, 109);
            this.grpBoxTools.TabIndex = 0;
            this.grpBoxTools.TabStop = false;
            this.grpBoxTools.Text = "Nástroje";
            // 
            // tlStrp
            // 
            this.tlStrp.BackColor = System.Drawing.Color.Transparent;
            this.tlStrp.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tlStrp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPencil,
            this.btnRectangle,
            this.btnEllipse,
            this.btnSave,
            this.btnOpen,
            this.btnBin});
            this.tlStrp.Location = new System.Drawing.Point(3, 27);
            this.tlStrp.Name = "tlStrp";
            this.tlStrp.Size = new System.Drawing.Size(1084, 42);
            this.tlStrp.TabIndex = 0;
            // 
            // btnPencil
            // 
            this.btnPencil.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnPencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPencil.Image = global::paint.Properties.Resources.imgPencil;
            this.btnPencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPencil.Name = "btnPencil";
            this.btnPencil.Size = new System.Drawing.Size(46, 36);
            this.btnPencil.Text = "toolStripButton1";
            this.btnPencil.Click += new System.EventHandler(this.btnPencil_Click);
            // 
            // btnRectangle
            // 
            this.btnRectangle.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRectangle.Image = global::paint.Properties.Resources.imgRectangle;
            this.btnRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(46, 36);
            this.btnRectangle.Text = "toolStripButton2";
            this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEllipse.Image = global::paint.Properties.Resources.imgEllipse;
            this.btnEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(46, 36);
            this.btnEllipse.Text = "toolStripButton3";
            this.btnEllipse.Click += new System.EventHandler(this.btnEllipse_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.ForeColor = System.Drawing.Color.Transparent;
            this.btnSave.Image = global::paint.Properties.Resources.imgSave;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(46, 36);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = global::paint.Properties.Resources.imgOpen;
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(46, 36);
            this.btnOpen.Text = "toolStripButton1";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnBin
            // 
            this.btnBin.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnBin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBin.Image = global::paint.Properties.Resources.imgBin;
            this.btnBin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBin.Name = "btnBin";
            this.btnBin.Size = new System.Drawing.Size(46, 36);
            this.btnBin.Text = "toolStripButton1";
            this.btnBin.Click += new System.EventHandler(this.btnBin_Click);
            // 
            // grpBoxColors
            // 
            this.grpBoxColors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grpBoxColors.Controls.Add(this.btnErease);
            this.grpBoxColors.Controls.Add(this.chckBxShps);
            this.grpBoxColors.Controls.Add(this.btnColorPicker);
            this.grpBoxColors.Controls.Add(this.btnBlack);
            this.grpBoxColors.Controls.Add(this.btnPurple);
            this.grpBoxColors.Controls.Add(this.btnBlue);
            this.grpBoxColors.Controls.Add(this.btnGreen);
            this.grpBoxColors.Controls.Add(this.btnPink);
            this.grpBoxColors.Controls.Add(this.btnYellow);
            this.grpBoxColors.Controls.Add(this.btnOrange);
            this.grpBoxColors.Controls.Add(this.btnRed);
            this.grpBoxColors.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpBoxColors.Location = new System.Drawing.Point(883, 109);
            this.grpBoxColors.Name = "grpBoxColors";
            this.grpBoxColors.Size = new System.Drawing.Size(207, 455);
            this.grpBoxColors.TabIndex = 3;
            this.grpBoxColors.TabStop = false;
            this.grpBoxColors.Text = "Barvy";
            // 
            // btnColorPicker
            // 
            this.btnColorPicker.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnColorPicker.ForeColor = System.Drawing.Color.White;
            this.btnColorPicker.Image = global::paint.Properties.Resources.imgColorPicker;
            this.btnColorPicker.Location = new System.Drawing.Point(103, 30);
            this.btnColorPicker.Name = "btnColorPicker";
            this.btnColorPicker.Size = new System.Drawing.Size(98, 94);
            this.btnColorPicker.TabIndex = 8;
            this.btnColorPicker.Tag = "";
            this.btnColorPicker.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnColorPicker.UseVisualStyleBackColor = false;
            this.btnColorPicker.UseWaitCursor = true;
            this.btnColorPicker.Click += new System.EventHandler(this.btnColorPicker_Click);
            // 
            // btnBlack
            // 
            this.btnBlack.BackColor = System.Drawing.Color.Black;
            this.btnBlack.Location = new System.Drawing.Point(53, 183);
            this.btnBlack.Name = "btnBlack";
            this.btnBlack.Size = new System.Drawing.Size(44, 46);
            this.btnBlack.TabIndex = 7;
            this.btnBlack.UseVisualStyleBackColor = false;
            this.btnBlack.Click += new System.EventHandler(this.btnBlack_Click);
            // 
            // btnPurple
            // 
            this.btnPurple.BackColor = System.Drawing.Color.MediumPurple;
            this.btnPurple.Location = new System.Drawing.Point(3, 183);
            this.btnPurple.Name = "btnPurple";
            this.btnPurple.Size = new System.Drawing.Size(44, 46);
            this.btnPurple.TabIndex = 6;
            this.btnPurple.UseVisualStyleBackColor = false;
            this.btnPurple.Click += new System.EventHandler(this.btnPurple_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.BackColor = System.Drawing.Color.PowderBlue;
            this.btnBlue.Location = new System.Drawing.Point(53, 131);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(44, 46);
            this.btnBlue.TabIndex = 5;
            this.btnBlue.UseVisualStyleBackColor = false;
            this.btnBlue.Click += new System.EventHandler(this.btnBlue_Click);
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnGreen.Location = new System.Drawing.Point(3, 131);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(44, 46);
            this.btnGreen.TabIndex = 4;
            this.btnGreen.UseVisualStyleBackColor = false;
            this.btnGreen.Click += new System.EventHandler(this.btnGreen_Click);
            // 
            // btnPink
            // 
            this.btnPink.BackColor = System.Drawing.Color.Pink;
            this.btnPink.Location = new System.Drawing.Point(53, 79);
            this.btnPink.Name = "btnPink";
            this.btnPink.Size = new System.Drawing.Size(44, 46);
            this.btnPink.TabIndex = 3;
            this.btnPink.UseVisualStyleBackColor = false;
            this.btnPink.Click += new System.EventHandler(this.btnPink_Click);
            // 
            // btnYellow
            // 
            this.btnYellow.BackColor = System.Drawing.Color.Khaki;
            this.btnYellow.Location = new System.Drawing.Point(3, 79);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.Size = new System.Drawing.Size(44, 46);
            this.btnYellow.TabIndex = 2;
            this.btnYellow.UseVisualStyleBackColor = false;
            this.btnYellow.Click += new System.EventHandler(this.btnYellow_Click);
            // 
            // btnOrange
            // 
            this.btnOrange.BackColor = System.Drawing.Color.SandyBrown;
            this.btnOrange.Location = new System.Drawing.Point(53, 27);
            this.btnOrange.Name = "btnOrange";
            this.btnOrange.Size = new System.Drawing.Size(44, 46);
            this.btnOrange.TabIndex = 1;
            this.btnOrange.UseVisualStyleBackColor = false;
            this.btnOrange.Click += new System.EventHandler(this.btnOrange_Click);
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.IndianRed;
            this.btnRed.Location = new System.Drawing.Point(3, 27);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(44, 46);
            this.btnRed.TabIndex = 0;
            this.btnRed.UseVisualStyleBackColor = false;
            this.btnRed.Click += new System.EventHandler(this.btnRed_Click);
            // 
            // trckB1
            // 
            this.trckB1.Location = new System.Drawing.Point(145, 20);
            this.trckB1.Margin = new System.Windows.Forms.Padding(5);
            this.trckB1.Name = "trckB1";
            this.trckB1.Size = new System.Drawing.Size(544, 90);
            this.trckB1.TabIndex = 4;
            this.trckB1.ValueChanged += new System.EventHandler(this.trckB1_ValueChanged);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl1.Location = new System.Drawing.Point(0, 49);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(137, 25);
            this.lbl1.TabIndex = 5;
            this.lbl1.Text = "tloušťka pera";
            // 
            // chckBxShps
            // 
            this.chckBxShps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chckBxShps.AutoSize = true;
            this.chckBxShps.Location = new System.Drawing.Point(21, 235);
            this.chckBxShps.Name = "chckBxShps";
            this.chckBxShps.Size = new System.Drawing.Size(148, 29);
            this.chckBxShps.TabIndex = 1;
            this.chckBxShps.Text = "vyplnit tvar";
            this.chckBxShps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chckBxShps.UseVisualStyleBackColor = true;
            // 
            // btnErease
            // 
            this.btnErease.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnErease.ForeColor = System.Drawing.Color.White;
            this.btnErease.Location = new System.Drawing.Point(103, 135);
            this.btnErease.Name = "btnErease";
            this.btnErease.Size = new System.Drawing.Size(98, 94);
            this.btnErease.TabIndex = 9;
            this.btnErease.Tag = "";
            this.btnErease.Text = "GUMA";
            this.btnErease.UseVisualStyleBackColor = false;
            this.btnErease.UseWaitCursor = true;
            this.btnErease.Click += new System.EventHandler(this.btnErease_Click);
            // 
            // PaintApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 564);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.pnl2);
            this.Controls.Add(this.grpBoxColors);
            this.Controls.Add(this.grpBoxTools);
            this.Name = "PaintApp";
            this.Text = "Malování";
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.pnl2.ResumeLayout(false);
            this.pnl2.PerformLayout();
            this.grpBoxTools.ResumeLayout(false);
            this.grpBoxTools.PerformLayout();
            this.tlStrp.ResumeLayout(false);
            this.tlStrp.PerformLayout();
            this.grpBoxColors.ResumeLayout(false);
            this.grpBoxColors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckB1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.GroupBox grpBoxTools;
        private System.Windows.Forms.GroupBox grpBoxColors;
        private System.Windows.Forms.ToolStrip tlStrp;
        private System.Windows.Forms.ToolStripButton btnPencil;
        private System.Windows.Forms.ToolStripButton btnRectangle;
        private System.Windows.Forms.ToolStripButton btnEllipse;
        private System.Windows.Forms.Button btnRed;
        private System.Windows.Forms.Button btnOrange;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.Button btnGreen;
        private System.Windows.Forms.Button btnPink;
        private System.Windows.Forms.Button btnYellow;
        private System.Windows.Forms.Button btnBlack;
        private System.Windows.Forms.Button btnPurple;
        private System.Windows.Forms.Button btnColorPicker;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnBin;
        private System.Windows.Forms.TrackBar trckB1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.CheckBox chckBxShps;
        private System.Windows.Forms.Button btnErease;
    }
}

