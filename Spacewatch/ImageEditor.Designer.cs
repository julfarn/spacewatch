namespace Spacewatch
{
    partial class ImageEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageEditor));
            this.picBox = new System.Windows.Forms.PictureBox();
            this.picBox_Curve = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button_apply = new System.Windows.Forms.Button();
            this.groupBox_curetype = new System.Windows.Forms.GroupBox();
            this.comboBox_curves = new System.Windows.Forms.ComboBox();
            this.button_saveCurve = new System.Windows.Forms.Button();
            this.textBox_curveName = new System.Windows.Forms.TextBox();
            this.valuePicker_param = new Spacewatch.ValuePicker();
            this.valuePicker_max = new Spacewatch.ValuePicker();
            this.valuePicker_min = new Spacewatch.ValuePicker();
            this.rB_log = new System.Windows.Forms.RadioButton();
            this.rB_exp = new System.Windows.Forms.RadioButton();
            this.rB_root = new System.Windows.Forms.RadioButton();
            this.rB_lin = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zwiebelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.substractDarkImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skymapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showOverlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Curve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox_curetype.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox.Location = new System.Drawing.Point(0, 0);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(650, 574);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // picBox_Curve
            // 
            this.picBox_Curve.BackColor = System.Drawing.Color.White;
            this.picBox_Curve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox_Curve.Location = new System.Drawing.Point(0, 0);
            this.picBox_Curve.Name = "picBox_Curve";
            this.picBox_Curve.Size = new System.Drawing.Size(307, 213);
            this.picBox_Curve.TabIndex = 1;
            this.picBox_Curve.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.picBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(961, 574);
            this.splitContainer1.SplitterDistance = 650;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.picBox_Curve);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.button_apply);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox_curetype);
            this.splitContainer2.Size = new System.Drawing.Size(307, 574);
            this.splitContainer2.SplitterDistance = 213;
            this.splitContainer2.TabIndex = 0;
            // 
            // button_apply
            // 
            this.button_apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_apply.Location = new System.Drawing.Point(204, 269);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(90, 23);
            this.button_apply.TabIndex = 2;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // groupBox_curetype
            // 
            this.groupBox_curetype.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_curetype.Controls.Add(this.comboBox_curves);
            this.groupBox_curetype.Controls.Add(this.button_saveCurve);
            this.groupBox_curetype.Controls.Add(this.textBox_curveName);
            this.groupBox_curetype.Controls.Add(this.valuePicker_param);
            this.groupBox_curetype.Controls.Add(this.valuePicker_max);
            this.groupBox_curetype.Controls.Add(this.valuePicker_min);
            this.groupBox_curetype.Controls.Add(this.rB_log);
            this.groupBox_curetype.Controls.Add(this.rB_exp);
            this.groupBox_curetype.Controls.Add(this.rB_root);
            this.groupBox_curetype.Controls.Add(this.rB_lin);
            this.groupBox_curetype.Location = new System.Drawing.Point(3, 3);
            this.groupBox_curetype.Name = "groupBox_curetype";
            this.groupBox_curetype.Size = new System.Drawing.Size(301, 351);
            this.groupBox_curetype.TabIndex = 1;
            this.groupBox_curetype.TabStop = false;
            this.groupBox_curetype.Text = "Curve Type";
            // 
            // comboBox_curves
            // 
            this.comboBox_curves.FormattingEnabled = true;
            this.comboBox_curves.Location = new System.Drawing.Point(7, 324);
            this.comboBox_curves.Name = "comboBox_curves";
            this.comboBox_curves.Size = new System.Drawing.Size(284, 21);
            this.comboBox_curves.TabIndex = 8;
            this.comboBox_curves.SelectedIndexChanged += new System.EventHandler(this.comboBox_curves_SelectedIndexChanged);
            // 
            // button_saveCurve
            // 
            this.button_saveCurve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_saveCurve.Location = new System.Drawing.Point(201, 295);
            this.button_saveCurve.Name = "button_saveCurve";
            this.button_saveCurve.Size = new System.Drawing.Size(90, 23);
            this.button_saveCurve.TabIndex = 3;
            this.button_saveCurve.Text = "Save";
            this.button_saveCurve.UseVisualStyleBackColor = true;
            this.button_saveCurve.Click += new System.EventHandler(this.button_saveCurve_Click);
            // 
            // textBox_curveName
            // 
            this.textBox_curveName.Location = new System.Drawing.Point(7, 298);
            this.textBox_curveName.Name = "textBox_curveName";
            this.textBox_curveName.Size = new System.Drawing.Size(188, 20);
            this.textBox_curveName.TabIndex = 7;
            this.textBox_curveName.Text = "Name";
            // 
            // valuePicker_param
            // 
            this.valuePicker_param.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valuePicker_param.Description = "Parameter";
            this.valuePicker_param.Location = new System.Drawing.Point(6, 200);
            this.valuePicker_param.Name = "valuePicker_param";
            this.valuePicker_param.Size = new System.Drawing.Size(285, 61);
            this.valuePicker_param.TabIndex = 6;
            this.valuePicker_param.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.valuePicker_param.ValueChanged += new System.EventHandler(this.valuePicker_param_ValueChanged);
            // 
            // valuePicker_max
            // 
            this.valuePicker_max.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valuePicker_max.Description = "Ceiling";
            this.valuePicker_max.Location = new System.Drawing.Point(7, 133);
            this.valuePicker_max.Name = "valuePicker_max";
            this.valuePicker_max.Size = new System.Drawing.Size(285, 61);
            this.valuePicker_max.TabIndex = 5;
            this.valuePicker_max.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.valuePicker_max.ValueChanged += new System.EventHandler(this.valuePicker_max_ValueChanged);
            // 
            // valuePicker_min
            // 
            this.valuePicker_min.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valuePicker_min.Description = "Floor";
            this.valuePicker_min.Location = new System.Drawing.Point(7, 66);
            this.valuePicker_min.Name = "valuePicker_min";
            this.valuePicker_min.Size = new System.Drawing.Size(285, 61);
            this.valuePicker_min.TabIndex = 4;
            this.valuePicker_min.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.valuePicker_min.ValueChanged += new System.EventHandler(this.valuePicker_min_ValueChanged);
            // 
            // rB_log
            // 
            this.rB_log.AutoSize = true;
            this.rB_log.Location = new System.Drawing.Point(89, 42);
            this.rB_log.Name = "rB_log";
            this.rB_log.Size = new System.Drawing.Size(79, 17);
            this.rB_log.TabIndex = 3;
            this.rB_log.Text = "Logarithmic";
            this.rB_log.UseVisualStyleBackColor = true;
            this.rB_log.CheckedChanged += new System.EventHandler(this.rB_log_CheckedChanged);
            // 
            // rB_exp
            // 
            this.rB_exp.AutoSize = true;
            this.rB_exp.Location = new System.Drawing.Point(89, 19);
            this.rB_exp.Name = "rB_exp";
            this.rB_exp.Size = new System.Drawing.Size(80, 17);
            this.rB_exp.TabIndex = 2;
            this.rB_exp.Text = "Exponential";
            this.rB_exp.UseVisualStyleBackColor = true;
            this.rB_exp.CheckedChanged += new System.EventHandler(this.rB_exp_CheckedChanged);
            // 
            // rB_root
            // 
            this.rB_root.AutoSize = true;
            this.rB_root.Location = new System.Drawing.Point(6, 42);
            this.rB_root.Name = "rB_root";
            this.rB_root.Size = new System.Drawing.Size(48, 17);
            this.rB_root.TabIndex = 1;
            this.rB_root.Text = "Root";
            this.rB_root.UseVisualStyleBackColor = true;
            this.rB_root.CheckedChanged += new System.EventHandler(this.rB_root_CheckedChanged);
            // 
            // rB_lin
            // 
            this.rB_lin.AutoSize = true;
            this.rB_lin.Checked = true;
            this.rB_lin.Location = new System.Drawing.Point(6, 19);
            this.rB_lin.Name = "rB_lin";
            this.rB_lin.Size = new System.Drawing.Size(54, 17);
            this.rB_lin.TabIndex = 0;
            this.rB_lin.TabStop = true;
            this.rB_lin.Text = "Linear";
            this.rB_lin.UseVisualStyleBackColor = true;
            this.rB_lin.CheckedChanged += new System.EventHandler(this.rB_lin_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.zwiebelToolStripMenuItem,
            this.skymapToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(961, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // zwiebelToolStripMenuItem
            // 
            this.zwiebelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.substractDarkImageToolStripMenuItem});
            this.zwiebelToolStripMenuItem.Name = "zwiebelToolStripMenuItem";
            this.zwiebelToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.zwiebelToolStripMenuItem.Text = "Image";
            // 
            // substractDarkImageToolStripMenuItem
            // 
            this.substractDarkImageToolStripMenuItem.Name = "substractDarkImageToolStripMenuItem";
            this.substractDarkImageToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.substractDarkImageToolStripMenuItem.Text = "Substract Dark Image";
            this.substractDarkImageToolStripMenuItem.Click += new System.EventHandler(this.substractDarkImageToolStripMenuItem_Click);
            // 
            // skymapToolStripMenuItem
            // 
            this.skymapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showOverlayToolStripMenuItem});
            this.skymapToolStripMenuItem.Name = "skymapToolStripMenuItem";
            this.skymapToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.skymapToolStripMenuItem.Text = "Skymap";
            // 
            // showOverlayToolStripMenuItem
            // 
            this.showOverlayToolStripMenuItem.CheckOnClick = true;
            this.showOverlayToolStripMenuItem.Name = "showOverlayToolStripMenuItem";
            this.showOverlayToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.showOverlayToolStripMenuItem.Text = "Show Overlay";
            this.showOverlayToolStripMenuItem.Click += new System.EventHandler(this.showOverlayToolStripMenuItem_Click);
            // 
            // exportDialog
            // 
            this.exportDialog.DefaultExt = "jpg";
            this.exportDialog.Filter = "JPG-Image|*.jpg";
            this.exportDialog.Title = "Export current Image";
            // 
            // saveDialog
            // 
            this.saveDialog.DefaultExt = "swi";
            this.saveDialog.Filter = "Spacewatch Image|*.swi";
            this.saveDialog.Title = "Save Raw Spacewatch Image";
            // 
            // openDialog
            // 
            this.openDialog.DefaultExt = "swi";
            this.openDialog.Filter = "Spacewatch Images|*.swi";
            this.openDialog.Title = "Open Raw Spacewatch Image";
            // 
            // ImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 598);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ImageEditor";
            this.Text = "ImageEditor";
            this.Load += new System.EventHandler(this.ImageEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Curve)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox_curetype.ResumeLayout(false);
            this.groupBox_curetype.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.PictureBox picBox_Curve;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox_curetype;
        private System.Windows.Forms.RadioButton rB_log;
        private System.Windows.Forms.RadioButton rB_exp;
        private System.Windows.Forms.RadioButton rB_root;
        private System.Windows.Forms.RadioButton rB_lin;
        private ValuePicker valuePicker_min;
        private ValuePicker valuePicker_param;
        private ValuePicker valuePicker_max;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.SaveFileDialog exportDialog;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.ToolStripMenuItem zwiebelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem substractDarkImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skymapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showOverlayToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox_curves;
        private System.Windows.Forms.Button button_saveCurve;
        private System.Windows.Forms.TextBox textBox_curveName;
    }
}