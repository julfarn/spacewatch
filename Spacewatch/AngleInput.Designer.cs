namespace Spacewatch
{
    partial class AngleInput
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.input_radians = new System.Windows.Forms.NumericUpDown();
            this.input_deg = new System.Windows.Forms.NumericUpDown();
            this.input_amin = new System.Windows.Forms.NumericUpDown();
            this.input_asec = new System.Windows.Forms.NumericUpDown();
            this.input_sec = new System.Windows.Forms.NumericUpDown();
            this.input_min = new System.Windows.Forms.NumericUpDown();
            this.input_h = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.visualisation = new System.Windows.Forms.PictureBox();
            this.checkBox_negative = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.input_radians)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_deg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_amin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_asec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_sec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_h)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualisation)).BeginInit();
            this.SuspendLayout();
            // 
            // input_radians
            // 
            this.input_radians.DecimalPlaces = 10;
            this.input_radians.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.input_radians.Location = new System.Drawing.Point(43, 17);
            this.input_radians.Maximum = new decimal(new int[] {
            629,
            0,
            0,
            131072});
            this.input_radians.Name = "input_radians";
            this.input_radians.Size = new System.Drawing.Size(129, 20);
            this.input_radians.TabIndex = 0;
            this.input_radians.ValueChanged += new System.EventHandler(this.input_radians_ValueChanged);
            // 
            // input_deg
            // 
            this.input_deg.Location = new System.Drawing.Point(3, 43);
            this.input_deg.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.input_deg.Name = "input_deg";
            this.input_deg.Size = new System.Drawing.Size(37, 20);
            this.input_deg.TabIndex = 1;
            this.input_deg.ValueChanged += new System.EventHandler(this.input_deg_ValueChanged);
            // 
            // input_amin
            // 
            this.input_amin.Location = new System.Drawing.Point(60, 43);
            this.input_amin.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.input_amin.Name = "input_amin";
            this.input_amin.Size = new System.Drawing.Size(37, 20);
            this.input_amin.TabIndex = 2;
            this.input_amin.ValueChanged += new System.EventHandler(this.input_amin_ValueChanged);
            // 
            // input_asec
            // 
            this.input_asec.DecimalPlaces = 5;
            this.input_asec.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.input_asec.Location = new System.Drawing.Point(120, 43);
            this.input_asec.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.input_asec.Name = "input_asec";
            this.input_asec.Size = new System.Drawing.Size(82, 20);
            this.input_asec.TabIndex = 3;
            this.input_asec.ValueChanged += new System.EventHandler(this.input_asec_ValueChanged);
            // 
            // input_sec
            // 
            this.input_sec.DecimalPlaces = 7;
            this.input_sec.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.input_sec.Location = new System.Drawing.Point(129, 69);
            this.input_sec.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.input_sec.Name = "input_sec";
            this.input_sec.Size = new System.Drawing.Size(73, 20);
            this.input_sec.TabIndex = 6;
            this.input_sec.ValueChanged += new System.EventHandler(this.input_sec_ValueChanged);
            // 
            // input_min
            // 
            this.input_min.Location = new System.Drawing.Point(65, 69);
            this.input_min.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.input_min.Name = "input_min";
            this.input_min.Size = new System.Drawing.Size(37, 20);
            this.input_min.TabIndex = 5;
            this.input_min.ValueChanged += new System.EventHandler(this.input_min_ValueChanged);
            // 
            // input_h
            // 
            this.input_h.Location = new System.Drawing.Point(3, 69);
            this.input_h.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.input_h.Name = "input_h";
            this.input_h.Size = new System.Drawing.Size(37, 20);
            this.input_h.TabIndex = 4;
            this.input_h.ValueChanged += new System.EventHandler(this.input_h_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "radians";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "°";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(103, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "\'";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(208, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "\'\'";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "h";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "m";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(208, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "s";
            // 
            // visualisation
            // 
            this.visualisation.Location = new System.Drawing.Point(228, 19);
            this.visualisation.Name = "visualisation";
            this.visualisation.Size = new System.Drawing.Size(70, 70);
            this.visualisation.TabIndex = 14;
            this.visualisation.TabStop = false;
            // 
            // checkBox_negative
            // 
            this.checkBox_negative.AutoSize = true;
            this.checkBox_negative.Location = new System.Drawing.Point(3, 18);
            this.checkBox_negative.Name = "checkBox_negative";
            this.checkBox_negative.Size = new System.Drawing.Size(29, 17);
            this.checkBox_negative.TabIndex = 15;
            this.checkBox_negative.Text = "-";
            this.checkBox_negative.UseVisualStyleBackColor = true;
            this.checkBox_negative.CheckedChanged += new System.EventHandler(this.checkBox_negative_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 90);
            this.panel1.TabIndex = 16;
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(5, 0);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(63, 13);
            this.label_Name.TabIndex = 0;
            this.label_Name.Text = "label_Name";
            // 
            // AngleInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.checkBox_negative);
            this.Controls.Add(this.visualisation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.input_sec);
            this.Controls.Add(this.input_min);
            this.Controls.Add(this.input_h);
            this.Controls.Add(this.input_asec);
            this.Controls.Add(this.input_amin);
            this.Controls.Add(this.input_deg);
            this.Controls.Add(this.input_radians);
            this.Controls.Add(this.panel1);
            this.Name = "AngleInput";
            this.Size = new System.Drawing.Size(307, 98);
            this.Load += new System.EventHandler(this.AngleInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.input_radians)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_deg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_amin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_asec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_sec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_h)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualisation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown input_radians;
        private System.Windows.Forms.NumericUpDown input_deg;
        private System.Windows.Forms.NumericUpDown input_amin;
        private System.Windows.Forms.NumericUpDown input_asec;
        private System.Windows.Forms.NumericUpDown input_sec;
        private System.Windows.Forms.NumericUpDown input_min;
        private System.Windows.Forms.NumericUpDown input_h;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox visualisation;
        private System.Windows.Forms.CheckBox checkBox_negative;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Name;
    }
}
