using System;
using System.Windows.Forms;

namespace Spacewatch
{
    partial class mainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.cameraList = new System.Windows.Forms.ComboBox();
            this.videoBox = new System.Windows.Forms.PictureBox();
            this.groupBox_cameraControl = new System.Windows.Forms.GroupBox();
            this.comboBox_configs = new System.Windows.Forms.ComboBox();
            this.trackBar_saturation = new System.Windows.Forms.TrackBar();
            this.checkBox_saturation = new System.Windows.Forms.CheckBox();
            this.checkBox_contrast = new System.Windows.Forms.CheckBox();
            this.checkBox_brightness = new System.Windows.Forms.CheckBox();
            this.trackBar_contrast = new System.Windows.Forms.TrackBar();
            this.trackBar_brightness = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigateToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calibrateToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.identifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skymapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.telescopeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sestdjkfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recalculateStringLengthsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_histLog = new System.Windows.Forms.CheckBox();
            this.checkBox_histogram = new System.Windows.Forms.CheckBox();
            this.checkBox_mirrorY = new System.Windows.Forms.CheckBox();
            this.checkBox_mirrorX = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox_compMove = new System.Windows.Forms.CheckBox();
            this.button_snapshot = new System.Windows.Forms.Button();
            this.numericUpDown_intCorrection = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_snapshot = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_integration = new System.Windows.Forms.NumericUpDown();
            this.checkBox_integration = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_follow = new System.Windows.Forms.CheckBox();
            this.button_identify = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_starPicker = new System.Windows.Forms.ComboBox();
            this.button_set_marker = new System.Windows.Forms.Button();
            this.button_goto = new System.Windows.Forms.Button();
            this.button_connect = new System.Windows.Forms.Button();
            this.button_imgedit = new System.Windows.Forms.Button();
            this.button_open_skymap = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel_telescope = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_frameTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel_moving = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel_mouseCoords = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer_follow = new System.Windows.Forms.Timer(this.components);
            this.timer_loop = new System.Windows.Forms.Timer(this.components);
            this.histogram = new AForge.Controls.Histogram();
            this.label7 = new System.Windows.Forms.Label();
            this.button_zoomOut = new System.Windows.Forms.Button();
            this.button_zoomIn = new System.Windows.Forms.Button();
            this.timer_updateDynamicDetail = new System.Windows.Forms.Timer(this.components);
            this.button_openControlPanel = new System.Windows.Forms.Button();
            this.angleInput_ra = new Spacewatch.AngleInput();
            this.angleInput_dec = new Spacewatch.AngleInput();
            ((System.ComponentModel.ISupportInitialize)(this.videoBox)).BeginInit();
            this.groupBox_cameraControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_saturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_contrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_brightness)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_intCorrection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_snapshot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_integration)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(130, 588);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(555, 120);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // cameraList
            // 
            this.cameraList.FormattingEnabled = true;
            this.cameraList.Location = new System.Drawing.Point(6, 19);
            this.cameraList.Name = "cameraList";
            this.cameraList.Size = new System.Drawing.Size(330, 21);
            this.cameraList.TabIndex = 2;
            this.cameraList.Text = "Choose a camera...";
            this.cameraList.SelectedIndexChanged += new System.EventHandler(this.cameraList_SelectedIndexChanged);
            // 
            // videoBox
            // 
            this.videoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.videoBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.videoBox.Location = new System.Drawing.Point(12, 27);
            this.videoBox.Name = "videoBox";
            this.videoBox.Size = new System.Drawing.Size(790, 552);
            this.videoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.videoBox.TabIndex = 3;
            this.videoBox.TabStop = false;
            this.videoBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.videoBox_MouseDown);
            this.videoBox.MouseEnter += new System.EventHandler(this.videoBox_MouseEnter);
            this.videoBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.videoBox_MouseMove);
            this.videoBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.videoBox_MouseUp);
            this.videoBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.videoBox_MouseWheel);
            // 
            // groupBox_cameraControl
            // 
            this.groupBox_cameraControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_cameraControl.Controls.Add(this.comboBox_configs);
            this.groupBox_cameraControl.Controls.Add(this.trackBar_saturation);
            this.groupBox_cameraControl.Controls.Add(this.checkBox_saturation);
            this.groupBox_cameraControl.Controls.Add(this.checkBox_contrast);
            this.groupBox_cameraControl.Controls.Add(this.checkBox_brightness);
            this.groupBox_cameraControl.Controls.Add(this.trackBar_contrast);
            this.groupBox_cameraControl.Controls.Add(this.trackBar_brightness);
            this.groupBox_cameraControl.Controls.Add(this.cameraList);
            this.groupBox_cameraControl.Location = new System.Drawing.Point(808, 27);
            this.groupBox_cameraControl.Name = "groupBox_cameraControl";
            this.groupBox_cameraControl.Size = new System.Drawing.Size(342, 232);
            this.groupBox_cameraControl.TabIndex = 5;
            this.groupBox_cameraControl.TabStop = false;
            this.groupBox_cameraControl.Text = "Camera Control";
            // 
            // comboBox_configs
            // 
            this.comboBox_configs.FormattingEnabled = true;
            this.comboBox_configs.Location = new System.Drawing.Point(6, 46);
            this.comboBox_configs.Name = "comboBox_configs";
            this.comboBox_configs.Size = new System.Drawing.Size(330, 21);
            this.comboBox_configs.TabIndex = 11;
            this.comboBox_configs.Text = "Configurations";
            this.comboBox_configs.SelectedIndexChanged += new System.EventHandler(this.comboBox_configs_SelectedIndexChanged);
            // 
            // trackBar_saturation
            // 
            this.trackBar_saturation.Enabled = false;
            this.trackBar_saturation.Location = new System.Drawing.Point(119, 179);
            this.trackBar_saturation.Maximum = 100;
            this.trackBar_saturation.Name = "trackBar_saturation";
            this.trackBar_saturation.Size = new System.Drawing.Size(217, 45);
            this.trackBar_saturation.TabIndex = 10;
            this.trackBar_saturation.Value = 50;
            this.trackBar_saturation.Scroll += new System.EventHandler(this.trackBar_saturation_Scroll);
            // 
            // checkBox_saturation
            // 
            this.checkBox_saturation.AutoSize = true;
            this.checkBox_saturation.Location = new System.Drawing.Point(10, 184);
            this.checkBox_saturation.Name = "checkBox_saturation";
            this.checkBox_saturation.Size = new System.Drawing.Size(74, 17);
            this.checkBox_saturation.TabIndex = 9;
            this.checkBox_saturation.Text = "Saturation";
            this.checkBox_saturation.UseVisualStyleBackColor = true;
            this.checkBox_saturation.CheckedChanged += new System.EventHandler(this.checkBox_saturation_CheckedChanged);
            // 
            // checkBox_contrast
            // 
            this.checkBox_contrast.AutoSize = true;
            this.checkBox_contrast.Location = new System.Drawing.Point(10, 128);
            this.checkBox_contrast.Name = "checkBox_contrast";
            this.checkBox_contrast.Size = new System.Drawing.Size(65, 17);
            this.checkBox_contrast.TabIndex = 8;
            this.checkBox_contrast.Text = "Contrast";
            this.checkBox_contrast.UseVisualStyleBackColor = true;
            this.checkBox_contrast.CheckedChanged += new System.EventHandler(this.checkBox_contrast_CheckedChanged);
            // 
            // checkBox_brightness
            // 
            this.checkBox_brightness.AutoSize = true;
            this.checkBox_brightness.Location = new System.Drawing.Point(10, 77);
            this.checkBox_brightness.Name = "checkBox_brightness";
            this.checkBox_brightness.Size = new System.Drawing.Size(75, 17);
            this.checkBox_brightness.TabIndex = 7;
            this.checkBox_brightness.Text = "Brightness";
            this.checkBox_brightness.UseVisualStyleBackColor = true;
            this.checkBox_brightness.CheckedChanged += new System.EventHandler(this.checkBox_brightness_CheckedChanged);
            // 
            // trackBar_contrast
            // 
            this.trackBar_contrast.Enabled = false;
            this.trackBar_contrast.Location = new System.Drawing.Point(119, 128);
            this.trackBar_contrast.Maximum = 100;
            this.trackBar_contrast.Name = "trackBar_contrast";
            this.trackBar_contrast.Size = new System.Drawing.Size(217, 45);
            this.trackBar_contrast.TabIndex = 5;
            this.trackBar_contrast.Value = 50;
            this.trackBar_contrast.Scroll += new System.EventHandler(this.trackBar_contrast_Scroll);
            // 
            // trackBar_brightness
            // 
            this.trackBar_brightness.Enabled = false;
            this.trackBar_brightness.Location = new System.Drawing.Point(119, 77);
            this.trackBar_brightness.Maximum = 100;
            this.trackBar_brightness.Name = "trackBar_brightness";
            this.trackBar_brightness.Size = new System.Drawing.Size(217, 45);
            this.trackBar_brightness.TabIndex = 3;
            this.trackBar_brightness.Value = 50;
            this.trackBar_brightness.Scroll += new System.EventHandler(this.trackBar_brightness_Scroll);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.markerToolStripMenuItem,
            this.skymapToolStripMenuItem,
            this.telescopeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1162, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // markerToolStripMenuItem
            // 
            this.markerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navigateToToolStripMenuItem,
            this.calibrateToToolStripMenuItem,
            this.identifyToolStripMenuItem});
            this.markerToolStripMenuItem.Name = "markerToolStripMenuItem";
            this.markerToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.markerToolStripMenuItem.Text = "Marker";
            // 
            // navigateToToolStripMenuItem
            // 
            this.navigateToToolStripMenuItem.Name = "navigateToToolStripMenuItem";
            this.navigateToToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.navigateToToolStripMenuItem.Text = "Navigate To";
            this.navigateToToolStripMenuItem.Click += new System.EventHandler(this.navigateToToolStripMenuItem_Click);
            // 
            // calibrateToToolStripMenuItem
            // 
            this.calibrateToToolStripMenuItem.Name = "calibrateToToolStripMenuItem";
            this.calibrateToToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.calibrateToToolStripMenuItem.Text = "Calibrate To";
            this.calibrateToToolStripMenuItem.Click += new System.EventHandler(this.calibrateToToolStripMenuItem_Click);
            // 
            // identifyToolStripMenuItem
            // 
            this.identifyToolStripMenuItem.Name = "identifyToolStripMenuItem";
            this.identifyToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.identifyToolStripMenuItem.Text = "Identify";
            this.identifyToolStripMenuItem.Click += new System.EventHandler(this.identifyToolStripMenuItem_Click);
            // 
            // skymapToolStripMenuItem
            // 
            this.skymapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.gridToolStripMenuItem});
            this.skymapToolStripMenuItem.Name = "skymapToolStripMenuItem";
            this.skymapToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.skymapToolStripMenuItem.Text = "Skymap";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Checked = true;
            this.showToolStripMenuItem.CheckOnClick = true;
            this.showToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showToolStripMenuItem_CheckedChanged);
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.Checked = true;
            this.gridToolStripMenuItem.CheckOnClick = true;
            this.gridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.gridToolStripMenuItem.Text = "Grid";
            // 
            // telescopeToolStripMenuItem
            // 
            this.telescopeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sestdjkfToolStripMenuItem,
            this.recalculateStringLengthsToolStripMenuItem});
            this.telescopeToolStripMenuItem.Name = "telescopeToolStripMenuItem";
            this.telescopeToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.telescopeToolStripMenuItem.Text = "Telescope";
            // 
            // sestdjkfToolStripMenuItem
            // 
            this.sestdjkfToolStripMenuItem.Name = "sestdjkfToolStripMenuItem";
            this.sestdjkfToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.sestdjkfToolStripMenuItem.Text = "Set Angles";
            this.sestdjkfToolStripMenuItem.Click += new System.EventHandler(this.sestdjkfToolStripMenuItem_Click);
            // 
            // recalculateStringLengthsToolStripMenuItem
            // 
            this.recalculateStringLengthsToolStripMenuItem.Name = "recalculateStringLengthsToolStripMenuItem";
            this.recalculateStringLengthsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.recalculateStringLengthsToolStripMenuItem.Text = "Recalculate String Lengths";
            this.recalculateStringLengthsToolStripMenuItem.Click += new System.EventHandler(this.recalculateStringLengthsToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkBox_histLog);
            this.groupBox1.Controls.Add(this.checkBox_histogram);
            this.groupBox1.Controls.Add(this.checkBox_mirrorY);
            this.groupBox1.Controls.Add(this.checkBox_mirrorX);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.checkBox_compMove);
            this.groupBox1.Controls.Add(this.button_snapshot);
            this.groupBox1.Controls.Add(this.numericUpDown_intCorrection);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDown_snapshot);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDown_integration);
            this.groupBox1.Controls.Add(this.checkBox_integration);
            this.groupBox1.Location = new System.Drawing.Point(808, 265);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 130);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Analysis";
            // 
            // checkBox_histLog
            // 
            this.checkBox_histLog.AutoSize = true;
            this.checkBox_histLog.Checked = true;
            this.checkBox_histLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_histLog.Location = new System.Drawing.Point(256, 19);
            this.checkBox_histLog.Name = "checkBox_histLog";
            this.checkBox_histLog.Size = new System.Drawing.Size(44, 17);
            this.checkBox_histLog.TabIndex = 22;
            this.checkBox_histLog.Text = "Log";
            this.checkBox_histLog.UseVisualStyleBackColor = true;
            this.checkBox_histLog.CheckedChanged += new System.EventHandler(this.checkBox_histLog_CheckedChanged);
            // 
            // checkBox_histogram
            // 
            this.checkBox_histogram.AutoSize = true;
            this.checkBox_histogram.Location = new System.Drawing.Point(181, 19);
            this.checkBox_histogram.Name = "checkBox_histogram";
            this.checkBox_histogram.Size = new System.Drawing.Size(73, 17);
            this.checkBox_histogram.TabIndex = 21;
            this.checkBox_histogram.Text = "Histogram";
            this.checkBox_histogram.UseVisualStyleBackColor = true;
            this.checkBox_histogram.CheckedChanged += new System.EventHandler(this.checkBox_histogram_CheckedChanged);
            // 
            // checkBox_mirrorY
            // 
            this.checkBox_mirrorY.AutoSize = true;
            this.checkBox_mirrorY.Location = new System.Drawing.Point(87, 20);
            this.checkBox_mirrorY.Name = "checkBox_mirrorY";
            this.checkBox_mirrorY.Size = new System.Drawing.Size(33, 17);
            this.checkBox_mirrorY.TabIndex = 20;
            this.checkBox_mirrorY.Text = "Y";
            this.checkBox_mirrorY.UseVisualStyleBackColor = true;
            // 
            // checkBox_mirrorX
            // 
            this.checkBox_mirrorX.AutoSize = true;
            this.checkBox_mirrorX.Location = new System.Drawing.Point(48, 20);
            this.checkBox_mirrorX.Name = "checkBox_mirrorX";
            this.checkBox_mirrorX.Size = new System.Drawing.Size(33, 17);
            this.checkBox_mirrorX.TabIndex = 19;
            this.checkBox_mirrorX.Text = "X";
            this.checkBox_mirrorX.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Mirror";
            // 
            // checkBox_compMove
            // 
            this.checkBox_compMove.AutoSize = true;
            this.checkBox_compMove.Checked = true;
            this.checkBox_compMove.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_compMove.Location = new System.Drawing.Point(116, 104);
            this.checkBox_compMove.Name = "checkBox_compMove";
            this.checkBox_compMove.Size = new System.Drawing.Size(138, 17);
            this.checkBox_compMove.TabIndex = 17;
            this.checkBox_compMove.Text = "Compensate Movement";
            this.checkBox_compMove.UseVisualStyleBackColor = true;
            // 
            // button_snapshot
            // 
            this.button_snapshot.Location = new System.Drawing.Point(256, 100);
            this.button_snapshot.Name = "button_snapshot";
            this.button_snapshot.Size = new System.Drawing.Size(77, 22);
            this.button_snapshot.TabIndex = 16;
            this.button_snapshot.Text = "Snapshot";
            this.button_snapshot.UseVisualStyleBackColor = true;
            this.button_snapshot.Click += new System.EventHandler(this.button_snapshot_Click);
            // 
            // numericUpDown_intCorrection
            // 
            this.numericUpDown_intCorrection.DecimalPlaces = 3;
            this.numericUpDown_intCorrection.Enabled = false;
            this.numericUpDown_intCorrection.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_intCorrection.Location = new System.Drawing.Point(284, 50);
            this.numericUpDown_intCorrection.Name = "numericUpDown_intCorrection";
            this.numericUpDown_intCorrection.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown_intCorrection.TabIndex = 13;
            this.numericUpDown_intCorrection.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_intCorrection.ValueChanged += new System.EventHandler(this.numericUpDown_intCorrection_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Snapshot Integration";
            // 
            // numericUpDown_snapshot
            // 
            this.numericUpDown_snapshot.Location = new System.Drawing.Point(115, 77);
            this.numericUpDown_snapshot.Name = "numericUpDown_snapshot";
            this.numericUpDown_snapshot.Size = new System.Drawing.Size(78, 20);
            this.numericUpDown_snapshot.TabIndex = 14;
            this.numericUpDown_snapshot.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Corection Factor";
            // 
            // numericUpDown_integration
            // 
            this.numericUpDown_integration.Enabled = false;
            this.numericUpDown_integration.Location = new System.Drawing.Point(115, 51);
            this.numericUpDown_integration.Name = "numericUpDown_integration";
            this.numericUpDown_integration.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown_integration.TabIndex = 11;
            this.numericUpDown_integration.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown_integration.ValueChanged += new System.EventHandler(this.numericUpDown_integration_ValueChanged);
            // 
            // checkBox_integration
            // 
            this.checkBox_integration.AutoSize = true;
            this.checkBox_integration.Location = new System.Drawing.Point(6, 54);
            this.checkBox_integration.Name = "checkBox_integration";
            this.checkBox_integration.Size = new System.Drawing.Size(108, 17);
            this.checkBox_integration.TabIndex = 7;
            this.checkBox_integration.Text = "Frame Integration";
            this.checkBox_integration.UseVisualStyleBackColor = true;
            this.checkBox_integration.CheckedChanged += new System.EventHandler(this.checkBox_integration_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(808, 401);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 313);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Navigation";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox_follow);
            this.panel1.Controls.Add(this.button_identify);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBox_starPicker);
            this.panel1.Controls.Add(this.button_set_marker);
            this.panel1.Controls.Add(this.button_goto);
            this.panel1.Controls.Add(this.angleInput_ra);
            this.panel1.Controls.Add(this.angleInput_dec);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 294);
            this.panel1.TabIndex = 0;
            // 
            // checkBox_follow
            // 
            this.checkBox_follow.AutoSize = true;
            this.checkBox_follow.Location = new System.Drawing.Point(257, 270);
            this.checkBox_follow.Name = "checkBox_follow";
            this.checkBox_follow.Size = new System.Drawing.Size(56, 17);
            this.checkBox_follow.TabIndex = 15;
            this.checkBox_follow.Text = "Follow";
            this.checkBox_follow.UseVisualStyleBackColor = true;
            this.checkBox_follow.CheckedChanged += new System.EventHandler(this.checkBox_follow_CheckedChanged);
            // 
            // button_identify
            // 
            this.button_identify.Location = new System.Drawing.Point(91, 266);
            this.button_identify.Name = "button_identify";
            this.button_identify.Size = new System.Drawing.Size(87, 23);
            this.button_identify.TabIndex = 14;
            this.button_identify.Text = "Identify Marker";
            this.button_identify.UseVisualStyleBackColor = true;
            this.button_identify.Click += new System.EventHandler(this.button_identify_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Objects";
            // 
            // comboBox_starPicker
            // 
            this.comboBox_starPicker.FormattingEnabled = true;
            this.comboBox_starPicker.Location = new System.Drawing.Point(3, 25);
            this.comboBox_starPicker.Name = "comboBox_starPicker";
            this.comboBox_starPicker.Size = new System.Drawing.Size(311, 21);
            this.comboBox_starPicker.TabIndex = 12;
            this.comboBox_starPicker.SelectedIndexChanged += new System.EventHandler(this.comboBox_starPicker_SelectedIndexChanged);
            this.comboBox_starPicker.TextUpdate += new System.EventHandler(this.comboBox_starPicker_TextUpdate);
            this.comboBox_starPicker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_starPicker_KeyDown);
            // 
            // button_set_marker
            // 
            this.button_set_marker.Location = new System.Drawing.Point(10, 266);
            this.button_set_marker.Name = "button_set_marker";
            this.button_set_marker.Size = new System.Drawing.Size(75, 23);
            this.button_set_marker.TabIndex = 11;
            this.button_set_marker.Text = "Set Marker";
            this.button_set_marker.UseVisualStyleBackColor = true;
            this.button_set_marker.Click += new System.EventHandler(this.button_set_telescope_Click);
            // 
            // button_goto
            // 
            this.button_goto.Location = new System.Drawing.Point(184, 266);
            this.button_goto.Name = "button_goto";
            this.button_goto.Size = new System.Drawing.Size(67, 23);
            this.button_goto.TabIndex = 10;
            this.button_goto.Text = "Go To";
            this.button_goto.UseVisualStyleBackColor = true;
            this.button_goto.Click += new System.EventHandler(this.button_goto_Click);
            // 
            // button_connect
            // 
            this.button_connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_connect.Location = new System.Drawing.Point(13, 585);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(111, 37);
            this.button_connect.TabIndex = 13;
            this.button_connect.Text = "Connect To Telescope";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_imgedit
            // 
            this.button_imgedit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_imgedit.Location = new System.Drawing.Point(13, 628);
            this.button_imgedit.Name = "button_imgedit";
            this.button_imgedit.Size = new System.Drawing.Size(111, 37);
            this.button_imgedit.TabIndex = 14;
            this.button_imgedit.Text = "Open Image Editor";
            this.button_imgedit.UseVisualStyleBackColor = true;
            this.button_imgedit.Click += new System.EventHandler(this.button_imgedit_Click);
            // 
            // button_open_skymap
            // 
            this.button_open_skymap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_open_skymap.Location = new System.Drawing.Point(13, 671);
            this.button_open_skymap.Name = "button_open_skymap";
            this.button_open_skymap.Size = new System.Drawing.Size(111, 37);
            this.button_open_skymap.TabIndex = 15;
            this.button_open_skymap.Text = "Open Skymap";
            this.button_open_skymap.UseVisualStyleBackColor = true;
            this.button_open_skymap.Click += new System.EventHandler(this.button_open_skymap_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel_telescope,
            this.status_frameTime,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel_moving,
            this.statusLabel_mouseCoords});
            this.statusStrip1.Location = new System.Drawing.Point(0, 717);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1162, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel_telescope
            // 
            this.statusLabel_telescope.Name = "statusLabel_telescope";
            this.statusLabel_telescope.Size = new System.Drawing.Size(142, 17);
            this.statusLabel_telescope.Text = "Telescope: not connected";
            // 
            // status_frameTime
            // 
            this.status_frameTime.Name = "status_frameTime";
            this.status_frameTime.Size = new System.Drawing.Size(101, 17);
            this.status_frameTime.Text = "Frame Time: 0 ms";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel_moving
            // 
            this.toolStripStatusLabel_moving.Name = "toolStripStatusLabel_moving";
            this.toolStripStatusLabel_moving.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusLabel_moving.Text = "Idle";
            // 
            // statusLabel_mouseCoords
            // 
            this.statusLabel_mouseCoords.Name = "statusLabel_mouseCoords";
            this.statusLabel_mouseCoords.Size = new System.Drawing.Size(112, 17);
            this.statusLabel_mouseCoords.Text = "Cursor Coordinates:";
            // 
            // timer_follow
            // 
            this.timer_follow.Interval = 10000;
            this.timer_follow.Tick += new System.EventHandler(this.timer_follow_Tick);
            // 
            // timer_loop
            // 
            this.timer_loop.Enabled = true;
            this.timer_loop.Interval = 50;
            this.timer_loop.Tick += new System.EventHandler(this.timer_loop_Tick);
            // 
            // histogram
            // 
            this.histogram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.histogram.BackColor = System.Drawing.SystemColors.Control;
            this.histogram.IsLogarithmicView = true;
            this.histogram.Location = new System.Drawing.Point(546, 479);
            this.histogram.Name = "histogram";
            this.histogram.Size = new System.Drawing.Size(256, 100);
            this.histogram.TabIndex = 17;
            this.histogram.Text = "swag";
            this.histogram.Values = null;
            this.histogram.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(727, 482);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Std. Dev:  0";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label7.Visible = false;
            // 
            // button_zoomOut
            // 
            this.button_zoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_zoomOut.Location = new System.Drawing.Point(779, 27);
            this.button_zoomOut.Name = "button_zoomOut";
            this.button_zoomOut.Size = new System.Drawing.Size(23, 23);
            this.button_zoomOut.TabIndex = 19;
            this.button_zoomOut.Text = "-";
            this.button_zoomOut.UseVisualStyleBackColor = true;
            this.button_zoomOut.Click += new System.EventHandler(this.button_zoomOut_Click);
            // 
            // button_zoomIn
            // 
            this.button_zoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_zoomIn.Location = new System.Drawing.Point(750, 27);
            this.button_zoomIn.Name = "button_zoomIn";
            this.button_zoomIn.Size = new System.Drawing.Size(23, 23);
            this.button_zoomIn.TabIndex = 20;
            this.button_zoomIn.Text = "+";
            this.button_zoomIn.UseVisualStyleBackColor = true;
            this.button_zoomIn.Click += new System.EventHandler(this.button_zoomIn_Click);
            // 
            // timer_updateDynamicDetail
            // 
            this.timer_updateDynamicDetail.Interval = 5000;
            this.timer_updateDynamicDetail.Tick += new System.EventHandler(this.timer_updateDynamicDetail_Tick);
            // 
            // button_openControlPanel
            // 
            this.button_openControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_openControlPanel.Location = new System.Drawing.Point(691, 588);
            this.button_openControlPanel.Name = "button_openControlPanel";
            this.button_openControlPanel.Size = new System.Drawing.Size(111, 37);
            this.button_openControlPanel.TabIndex = 21;
            this.button_openControlPanel.Text = "Control Panel";
            this.button_openControlPanel.UseVisualStyleBackColor = true;
            this.button_openControlPanel.Click += new System.EventHandler(this.button_openControlPanel_Click);
            // 
            // angleInput_ra
            // 
            this.angleInput_ra.BackColor = System.Drawing.SystemColors.Control;
            this.angleInput_ra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.angleInput_ra.description = "Right Ascension";
            this.angleInput_ra.Location = new System.Drawing.Point(3, 156);
            this.angleInput_ra.Name = "angleInput_ra";
            this.angleInput_ra.Size = new System.Drawing.Size(307, 98);
            this.angleInput_ra.TabIndex = 7;
            // 
            // angleInput_dec
            // 
            this.angleInput_dec.BackColor = System.Drawing.SystemColors.Control;
            this.angleInput_dec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.angleInput_dec.description = "Declination";
            this.angleInput_dec.Location = new System.Drawing.Point(3, 52);
            this.angleInput_dec.Name = "angleInput_dec";
            this.angleInput_dec.Size = new System.Drawing.Size(307, 98);
            this.angleInput_dec.TabIndex = 6;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 739);
            this.Controls.Add(this.button_openControlPanel);
            this.Controls.Add(this.button_zoomIn);
            this.Controls.Add(this.button_zoomOut);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.histogram);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_open_skymap);
            this.Controls.Add(this.button_imgedit);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_cameraControl);
            this.Controls.Add(this.videoBox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "mainForm";
            this.Text = "Spacewatch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mainForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.videoBox)).EndInit();
            this.groupBox_cameraControl.ResumeLayout(false);
            this.groupBox_cameraControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_saturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_contrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_brightness)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_intCorrection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_snapshot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_integration)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox cameraList;
        private System.Windows.Forms.PictureBox videoBox;
        private System.Windows.Forms.GroupBox groupBox_cameraControl;
        private System.Windows.Forms.TrackBar trackBar_contrast;
        private System.Windows.Forms.TrackBar trackBar_brightness;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_contrast;
        private System.Windows.Forms.CheckBox checkBox_brightness;
        private System.Windows.Forms.CheckBox checkBox_saturation;
        private System.Windows.Forms.TrackBar trackBar_saturation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown_integration;
        private System.Windows.Forms.CheckBox checkBox_integration;
        private System.Windows.Forms.NumericUpDown numericUpDown_intCorrection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_snapshot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_snapshot;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_configs;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_imgedit;
        private System.Windows.Forms.Button button_open_skymap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_goto;
        private AngleInput angleInput_ra;
        private AngleInput angleInput_dec;
        private System.Windows.Forms.Button button_set_marker;
        private System.Windows.Forms.ComboBox comboBox_starPicker;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_telescope;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_mouseCoords;
        private System.Windows.Forms.ToolStripMenuItem markerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem navigateToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calibrateToToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_identify;
        private System.Windows.Forms.ToolStripMenuItem identifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skymapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_compMove;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel status_frameTime;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem telescopeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sestdjkfToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_mirrorY;
        private System.Windows.Forms.CheckBox checkBox_mirrorX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox_follow;
        private System.Windows.Forms.Timer timer_follow;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_moving;
        private System.Windows.Forms.Timer timer_loop;
        private System.Windows.Forms.CheckBox checkBox_histogram;
        private AForge.Controls.Histogram histogram;
        private System.Windows.Forms.CheckBox checkBox_histLog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_zoomOut;
        private Button button_zoomIn;
        private Timer timer_updateDynamicDetail;
        private ToolStripMenuItem recalculateStringLengthsToolStripMenuItem;
        private Button button_openControlPanel;
    }
}

