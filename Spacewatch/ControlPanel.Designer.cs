namespace Spacewatch
{
    partial class ControlPanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            this.picBox_starmap_unfocussed = new System.Windows.Forms.PictureBox();
            this.picBox_starmap_focussed = new System.Windows.Forms.PictureBox();
            this.listBox_skyObjects = new System.Windows.Forms.ListBox();
            this.textBox_filter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_navigateTo = new System.Windows.Forms.Button();
            this.button_search = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox_search = new System.Windows.Forms.GroupBox();
            this.checkBox_identify_with_coords = new System.Windows.Forms.CheckBox();
            this.checkBox_visualIdentification = new System.Windows.Forms.CheckBox();
            this.checkBox_local_coords = new System.Windows.Forms.CheckBox();
            this.timer_update_starmaps = new System.Windows.Forms.Timer(this.components);
            this.angleInput_dec = new Spacewatch.AngleInput();
            this.angleInput_ra = new Spacewatch.AngleInput();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_starmap_unfocussed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_starmap_focussed)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox_search.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBox_starmap_unfocussed
            // 
            this.picBox_starmap_unfocussed.BackColor = System.Drawing.Color.Navy;
            this.picBox_starmap_unfocussed.Location = new System.Drawing.Point(12, 25);
            this.picBox_starmap_unfocussed.Name = "picBox_starmap_unfocussed";
            this.picBox_starmap_unfocussed.Size = new System.Drawing.Size(300, 300);
            this.picBox_starmap_unfocussed.TabIndex = 0;
            this.picBox_starmap_unfocussed.TabStop = false;
            // 
            // picBox_starmap_focussed
            // 
            this.picBox_starmap_focussed.BackColor = System.Drawing.Color.Navy;
            this.picBox_starmap_focussed.Location = new System.Drawing.Point(12, 344);
            this.picBox_starmap_focussed.Name = "picBox_starmap_focussed";
            this.picBox_starmap_focussed.Size = new System.Drawing.Size(300, 300);
            this.picBox_starmap_focussed.TabIndex = 1;
            this.picBox_starmap_focussed.TabStop = false;
            // 
            // listBox_skyObjects
            // 
            this.listBox_skyObjects.FormattingEnabled = true;
            this.listBox_skyObjects.Location = new System.Drawing.Point(6, 45);
            this.listBox_skyObjects.Name = "listBox_skyObjects";
            this.listBox_skyObjects.Size = new System.Drawing.Size(215, 186);
            this.listBox_skyObjects.TabIndex = 2;
            this.listBox_skyObjects.SelectedIndexChanged += new System.EventHandler(this.listBox_skyObjects_SelectedIndexChanged);
            // 
            // textBox_filter
            // 
            this.textBox_filter.Location = new System.Drawing.Point(6, 19);
            this.textBox_filter.Name = "textBox_filter";
            this.textBox_filter.Size = new System.Drawing.Size(215, 20);
            this.textBox_filter.TabIndex = 3;
            this.textBox_filter.TextChanged += new System.EventHandler(this.textBox_filter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Global";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Local";
            // 
            // button_navigateTo
            // 
            this.button_navigateTo.Location = new System.Drawing.Point(468, 238);
            this.button_navigateTo.Name = "button_navigateTo";
            this.button_navigateTo.Size = new System.Drawing.Size(75, 23);
            this.button_navigateTo.TabIndex = 7;
            this.button_navigateTo.Text = "Go To";
            this.button_navigateTo.UseVisualStyleBackColor = true;
            this.button_navigateTo.Click += new System.EventHandler(this.button_navigateTo_Click);
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(134, 38);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 8;
            this.button_search.Text = "Search";
            this.button_search.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox_search);
            this.groupBox1.Controls.Add(this.angleInput_dec);
            this.groupBox1.Controls.Add(this.angleInput_ra);
            this.groupBox1.Controls.Add(this.checkBox_local_coords);
            this.groupBox1.Controls.Add(this.textBox_filter);
            this.groupBox1.Controls.Add(this.button_navigateTo);
            this.groupBox1.Controls.Add(this.listBox_skyObjects);
            this.groupBox1.Location = new System.Drawing.Point(318, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 635);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // groupBox_search
            // 
            this.groupBox_search.Controls.Add(this.checkBox_identify_with_coords);
            this.groupBox_search.Controls.Add(this.checkBox_visualIdentification);
            this.groupBox_search.Controls.Add(this.button_search);
            this.groupBox_search.Location = new System.Drawing.Point(6, 271);
            this.groupBox_search.Name = "groupBox_search";
            this.groupBox_search.Size = new System.Drawing.Size(215, 71);
            this.groupBox_search.TabIndex = 12;
            this.groupBox_search.TabStop = false;
            this.groupBox_search.Text = "Search for Object";
            // 
            // checkBox_identify_with_coords
            // 
            this.checkBox_identify_with_coords.AutoSize = true;
            this.checkBox_identify_with_coords.Checked = true;
            this.checkBox_identify_with_coords.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_identify_with_coords.Location = new System.Drawing.Point(6, 19);
            this.checkBox_identify_with_coords.Name = "checkBox_identify_with_coords";
            this.checkBox_identify_with_coords.Size = new System.Drawing.Size(141, 17);
            this.checkBox_identify_with_coords.TabIndex = 10;
            this.checkBox_identify_with_coords.Text = "Identify with Coordinates";
            this.checkBox_identify_with_coords.UseVisualStyleBackColor = true;
            // 
            // checkBox_visualIdentification
            // 
            this.checkBox_visualIdentification.AutoSize = true;
            this.checkBox_visualIdentification.Checked = true;
            this.checkBox_visualIdentification.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_visualIdentification.Location = new System.Drawing.Point(6, 42);
            this.checkBox_visualIdentification.Name = "checkBox_visualIdentification";
            this.checkBox_visualIdentification.Size = new System.Drawing.Size(98, 17);
            this.checkBox_visualIdentification.TabIndex = 9;
            this.checkBox_visualIdentification.Text = "Identify Visually";
            this.checkBox_visualIdentification.UseVisualStyleBackColor = true;
            this.checkBox_visualIdentification.CheckedChanged += new System.EventHandler(this.checkBox_visualIdentification_CheckedChanged);
            // 
            // checkBox_local_coords
            // 
            this.checkBox_local_coords.AutoSize = true;
            this.checkBox_local_coords.Location = new System.Drawing.Point(432, 16);
            this.checkBox_local_coords.Name = "checkBox_local_coords";
            this.checkBox_local_coords.Size = new System.Drawing.Size(111, 17);
            this.checkBox_local_coords.TabIndex = 9;
            this.checkBox_local_coords.Text = "Local Coordinates";
            this.checkBox_local_coords.UseVisualStyleBackColor = true;
            // 
            // timer_update_starmaps
            // 
            this.timer_update_starmaps.Enabled = true;
            this.timer_update_starmaps.Interval = 15000;
            this.timer_update_starmaps.Tick += new System.EventHandler(this.timer_update_starmaps_Tick);
            // 
            // angleInput_dec
            // 
            this.angleInput_dec.BackColor = System.Drawing.SystemColors.Control;
            this.angleInput_dec.description = "Declination";
            this.angleInput_dec.Location = new System.Drawing.Point(236, 134);
            this.angleInput_dec.Name = "angleInput_dec";
            this.angleInput_dec.Size = new System.Drawing.Size(307, 98);
            this.angleInput_dec.TabIndex = 11;
            // 
            // angleInput_ra
            // 
            this.angleInput_ra.BackColor = System.Drawing.SystemColors.Control;
            this.angleInput_ra.description = "Right Ascension";
            this.angleInput_ra.Location = new System.Drawing.Point(236, 30);
            this.angleInput_ra.Name = "angleInput_ra";
            this.angleInput_ra.Size = new System.Drawing.Size(307, 98);
            this.angleInput_ra.TabIndex = 10;
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 650);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBox_starmap_focussed);
            this.Controls.Add(this.picBox_starmap_unfocussed);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ControlPanel";
            this.Text = "ControlPanel";
            this.Load += new System.EventHandler(this.ControlPanel_Load);
            this.Shown += new System.EventHandler(this.ControlPanel_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_starmap_unfocussed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_starmap_focussed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_search.ResumeLayout(false);
            this.groupBox_search.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox_starmap_unfocussed;
        private System.Windows.Forms.PictureBox picBox_starmap_focussed;
        private System.Windows.Forms.ListBox listBox_skyObjects;
        private System.Windows.Forms.TextBox textBox_filter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_navigateTo;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_local_coords;
        private AngleInput angleInput_dec;
        private AngleInput angleInput_ra;
        private System.Windows.Forms.GroupBox groupBox_search;
        private System.Windows.Forms.CheckBox checkBox_visualIdentification;
        private System.Windows.Forms.CheckBox checkBox_identify_with_coords;
        private System.Windows.Forms.Timer timer_update_starmaps;
    }
}