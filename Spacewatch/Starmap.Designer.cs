namespace Spacewatch
{
    partial class Starmap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Starmap));
            this.picBox_skymap = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.numericUpDown_magLimit = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox_objCollection = new System.Windows.Forms.GroupBox();
            this.textBox_objectFilter = new System.Windows.Forms.TextBox();
            this.button_goto = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.button_remove = new System.Windows.Forms.Button();
            this.groupBox_currentObj = new System.Windows.Forms.GroupBox();
            this.numericUpDown_magnitude = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_secondaryName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rb_other = new System.Windows.Forms.RadioButton();
            this.rb_nebula = new System.Windows.Forms.RadioButton();
            this.rb_galaxy = new System.Windows.Forms.RadioButton();
            this.rb_star = new System.Windows.Forms.RadioButton();
            this.textBox_ObjName = new System.Windows.Forms.TextBox();
            this.button_addObj = new System.Windows.Forms.Button();
            this.angleInput_ra = new Spacewatch.AngleInput();
            this.angleInput_dec = new Spacewatch.AngleInput();
            this.listBox_objects = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.objectCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDefaultCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_skymap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_magLimit)).BeginInit();
            this.groupBox_objCollection.SuspendLayout();
            this.groupBox_currentObj.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_magnitude)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBox_skymap
            // 
            this.picBox_skymap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox_skymap.Location = new System.Drawing.Point(0, 0);
            this.picBox_skymap.Name = "picBox_skymap";
            this.picBox_skymap.Size = new System.Drawing.Size(536, 663);
            this.picBox_skymap.TabIndex = 0;
            this.picBox_skymap.TabStop = false;
            this.picBox_skymap.SizeChanged += new System.EventHandler(this.picBox_skymap_SizeChanged);
            this.picBox_skymap.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.picBox_skymap);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox_objCollection);
            this.splitContainer1.Size = new System.Drawing.Size(889, 663);
            this.splitContainer1.SplitterDistance = 536;
            this.splitContainer1.TabIndex = 1;
            // 
            // numericUpDown_magLimit
            // 
            this.numericUpDown_magLimit.DecimalPlaces = 2;
            this.numericUpDown_magLimit.Location = new System.Drawing.Point(96, 563);
            this.numericUpDown_magLimit.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_magLimit.Name = "numericUpDown_magLimit";
            this.numericUpDown_magLimit.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_magLimit.TabIndex = 18;
            this.numericUpDown_magLimit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 566);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Magnitude Limit";
            // 
            // groupBox_objCollection
            // 
            this.groupBox_objCollection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_objCollection.Controls.Add(this.numericUpDown_magLimit);
            this.groupBox_objCollection.Controls.Add(this.label6);
            this.groupBox_objCollection.Controls.Add(this.textBox_objectFilter);
            this.groupBox_objCollection.Controls.Add(this.button_goto);
            this.groupBox_objCollection.Controls.Add(this.button_edit);
            this.groupBox_objCollection.Controls.Add(this.button_remove);
            this.groupBox_objCollection.Controls.Add(this.groupBox_currentObj);
            this.groupBox_objCollection.Controls.Add(this.listBox_objects);
            this.groupBox_objCollection.Location = new System.Drawing.Point(0, 0);
            this.groupBox_objCollection.Name = "groupBox_objCollection";
            this.groupBox_objCollection.Size = new System.Drawing.Size(346, 593);
            this.groupBox_objCollection.TabIndex = 0;
            this.groupBox_objCollection.TabStop = false;
            this.groupBox_objCollection.Text = "Sky Objects";
            // 
            // textBox_objectFilter
            // 
            this.textBox_objectFilter.Location = new System.Drawing.Point(3, 18);
            this.textBox_objectFilter.Name = "textBox_objectFilter";
            this.textBox_objectFilter.Size = new System.Drawing.Size(298, 20);
            this.textBox_objectFilter.TabIndex = 9;
            this.textBox_objectFilter.TextChanged += new System.EventHandler(this.textBox_objectFilter_TextChanged);
            // 
            // button_goto
            // 
            this.button_goto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_goto.Location = new System.Drawing.Point(307, 74);
            this.button_goto.Name = "button_goto";
            this.button_goto.Size = new System.Drawing.Size(33, 23);
            this.button_goto.TabIndex = 8;
            this.button_goto.Text = "go";
            this.button_goto.UseVisualStyleBackColor = true;
            this.button_goto.Click += new System.EventHandler(this.button_goto_Click);
            // 
            // button_edit
            // 
            this.button_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_edit.Location = new System.Drawing.Point(307, 45);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(33, 23);
            this.button_edit.TabIndex = 7;
            this.button_edit.Text = "edit";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // button_remove
            // 
            this.button_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_remove.Location = new System.Drawing.Point(307, 16);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(33, 23);
            this.button_remove.TabIndex = 6;
            this.button_remove.Text = "-";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // groupBox_currentObj
            // 
            this.groupBox_currentObj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_currentObj.Controls.Add(this.numericUpDown_magnitude);
            this.groupBox_currentObj.Controls.Add(this.label5);
            this.groupBox_currentObj.Controls.Add(this.label4);
            this.groupBox_currentObj.Controls.Add(this.textBox_secondaryName);
            this.groupBox_currentObj.Controls.Add(this.label3);
            this.groupBox_currentObj.Controls.Add(this.rb_other);
            this.groupBox_currentObj.Controls.Add(this.rb_nebula);
            this.groupBox_currentObj.Controls.Add(this.rb_galaxy);
            this.groupBox_currentObj.Controls.Add(this.rb_star);
            this.groupBox_currentObj.Controls.Add(this.textBox_ObjName);
            this.groupBox_currentObj.Controls.Add(this.button_addObj);
            this.groupBox_currentObj.Controls.Add(this.angleInput_ra);
            this.groupBox_currentObj.Controls.Add(this.angleInput_dec);
            this.groupBox_currentObj.Location = new System.Drawing.Point(6, 195);
            this.groupBox_currentObj.Name = "groupBox_currentObj";
            this.groupBox_currentObj.Size = new System.Drawing.Size(334, 362);
            this.groupBox_currentObj.TabIndex = 1;
            this.groupBox_currentObj.TabStop = false;
            this.groupBox_currentObj.Text = "Add Object";
            // 
            // numericUpDown_magnitude
            // 
            this.numericUpDown_magnitude.DecimalPlaces = 2;
            this.numericUpDown_magnitude.Location = new System.Drawing.Point(69, 233);
            this.numericUpDown_magnitude.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_magnitude.Name = "numericUpDown_magnitude";
            this.numericUpDown_magnitude.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_magnitude.TabIndex = 16;
            this.numericUpDown_magnitude.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Magnitude";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Secondary Name";
            // 
            // textBox_secondaryName
            // 
            this.textBox_secondaryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_secondaryName.Location = new System.Drawing.Point(9, 333);
            this.textBox_secondaryName.Name = "textBox_secondaryName";
            this.textBox_secondaryName.Size = new System.Drawing.Size(235, 20);
            this.textBox_secondaryName.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Official Name";
            // 
            // rb_other
            // 
            this.rb_other.AutoSize = true;
            this.rb_other.Location = new System.Drawing.Point(187, 258);
            this.rb_other.Name = "rb_other";
            this.rb_other.Size = new System.Drawing.Size(51, 17);
            this.rb_other.TabIndex = 11;
            this.rb_other.Text = "Other";
            this.rb_other.UseVisualStyleBackColor = true;
            this.rb_other.CheckedChanged += new System.EventHandler(this.rb_other_CheckedChanged);
            // 
            // rb_nebula
            // 
            this.rb_nebula.AutoSize = true;
            this.rb_nebula.Location = new System.Drawing.Point(122, 258);
            this.rb_nebula.Name = "rb_nebula";
            this.rb_nebula.Size = new System.Drawing.Size(59, 17);
            this.rb_nebula.TabIndex = 10;
            this.rb_nebula.Text = "Nebula";
            this.rb_nebula.UseVisualStyleBackColor = true;
            this.rb_nebula.CheckedChanged += new System.EventHandler(this.rb_nebula_CheckedChanged);
            // 
            // rb_galaxy
            // 
            this.rb_galaxy.AutoSize = true;
            this.rb_galaxy.Location = new System.Drawing.Point(59, 258);
            this.rb_galaxy.Name = "rb_galaxy";
            this.rb_galaxy.Size = new System.Drawing.Size(57, 17);
            this.rb_galaxy.TabIndex = 9;
            this.rb_galaxy.Text = "Galaxy";
            this.rb_galaxy.UseVisualStyleBackColor = true;
            this.rb_galaxy.CheckedChanged += new System.EventHandler(this.rb_galaxy_CheckedChanged);
            // 
            // rb_star
            // 
            this.rb_star.AutoSize = true;
            this.rb_star.Checked = true;
            this.rb_star.Location = new System.Drawing.Point(9, 258);
            this.rb_star.Name = "rb_star";
            this.rb_star.Size = new System.Drawing.Size(44, 17);
            this.rb_star.TabIndex = 8;
            this.rb_star.TabStop = true;
            this.rb_star.Text = "Star";
            this.rb_star.UseVisualStyleBackColor = true;
            this.rb_star.CheckedChanged += new System.EventHandler(this.rb_star_CheckedChanged);
            // 
            // textBox_ObjName
            // 
            this.textBox_ObjName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ObjName.Location = new System.Drawing.Point(9, 294);
            this.textBox_ObjName.Name = "textBox_ObjName";
            this.textBox_ObjName.Size = new System.Drawing.Size(316, 20);
            this.textBox_ObjName.TabIndex = 3;
            // 
            // button_addObj
            // 
            this.button_addObj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_addObj.Location = new System.Drawing.Point(250, 331);
            this.button_addObj.Name = "button_addObj";
            this.button_addObj.Size = new System.Drawing.Size(75, 23);
            this.button_addObj.TabIndex = 2;
            this.button_addObj.Text = "Add";
            this.button_addObj.UseVisualStyleBackColor = true;
            this.button_addObj.Click += new System.EventHandler(this.button_addObj_Click);
            // 
            // angleInput_ra
            // 
            this.angleInput_ra.BackColor = System.Drawing.SystemColors.Control;
            this.angleInput_ra.description = "Right Ascension";
            this.angleInput_ra.Location = new System.Drawing.Point(6, 123);
            this.angleInput_ra.Name = "angleInput_ra";
            this.angleInput_ra.Size = new System.Drawing.Size(307, 98);
            this.angleInput_ra.TabIndex = 1;
            // 
            // angleInput_dec
            // 
            this.angleInput_dec.BackColor = System.Drawing.SystemColors.Control;
            this.angleInput_dec.description = "Declination";
            this.angleInput_dec.Location = new System.Drawing.Point(6, 19);
            this.angleInput_dec.Name = "angleInput_dec";
            this.angleInput_dec.Size = new System.Drawing.Size(307, 98);
            this.angleInput_dec.TabIndex = 0;
            // 
            // listBox_objects
            // 
            this.listBox_objects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_objects.FormattingEnabled = true;
            this.listBox_objects.Location = new System.Drawing.Point(3, 42);
            this.listBox_objects.Name = "listBox_objects";
            this.listBox_objects.Size = new System.Drawing.Size(298, 147);
            this.listBox_objects.TabIndex = 0;
            this.listBox_objects.SelectedIndexChanged += new System.EventHandler(this.listBox_objects_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.objectCollectionToolStripMenuItem,
            this.saveToolStripMenuItem1,
            this.loadDefaultCollectionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(889, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // objectCollectionToolStripMenuItem
            // 
            this.objectCollectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.importDetailsToolStripMenuItem});
            this.objectCollectionToolStripMenuItem.Name = "objectCollectionToolStripMenuItem";
            this.objectCollectionToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.objectCollectionToolStripMenuItem.Text = "ObjectCollection";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveToolStripMenuItem.Text = "Save As";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // importDetailsToolStripMenuItem
            // 
            this.importDetailsToolStripMenuItem.Name = "importDetailsToolStripMenuItem";
            this.importDetailsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.importDetailsToolStripMenuItem.Text = "Import Details";
            this.importDetailsToolStripMenuItem.Click += new System.EventHandler(this.importDetailsToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // loadDefaultCollectionToolStripMenuItem
            // 
            this.loadDefaultCollectionToolStripMenuItem.Name = "loadDefaultCollectionToolStripMenuItem";
            this.loadDefaultCollectionToolStripMenuItem.Size = new System.Drawing.Size(143, 20);
            this.loadDefaultCollectionToolStripMenuItem.Text = "Load Default Collection";
            this.loadDefaultCollectionToolStripMenuItem.Click += new System.EventHandler(this.loadDefaultCollectionToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Sky Object Collection|*.soc|All Files|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Sky Object Collection|*.soc";
            // 
            // Starmap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 687);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Starmap";
            this.Text = "Starmap";
            this.Shown += new System.EventHandler(this.Starmap_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_skymap)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_magLimit)).EndInit();
            this.groupBox_objCollection.ResumeLayout(false);
            this.groupBox_objCollection.PerformLayout();
            this.groupBox_currentObj.ResumeLayout(false);
            this.groupBox_currentObj.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_magnitude)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox_skymap;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox_objCollection;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem objectCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox_currentObj;
        private System.Windows.Forms.TextBox textBox_ObjName;
        private System.Windows.Forms.Button button_addObj;
        private AngleInput angleInput_ra;
        private AngleInput angleInput_dec;
        private System.Windows.Forms.ListBox listBox_objects;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_secondaryName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rb_other;
        private System.Windows.Forms.RadioButton rb_nebula;
        private System.Windows.Forms.RadioButton rb_galaxy;
        private System.Windows.Forms.RadioButton rb_star;
        private System.Windows.Forms.NumericUpDown numericUpDown_magnitude;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_goto;
        private System.Windows.Forms.NumericUpDown numericUpDown_magLimit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadDefaultCollectionToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_objectFilter;
        private System.Windows.Forms.ToolStripMenuItem importDetailsToolStripMenuItem;
    }
}