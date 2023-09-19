namespace Spacewatch
{
    partial class TelescopeStateDialog
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
            this.angleInput_phi = new Spacewatch.AngleInput();
            this.angleInput_theta = new Spacewatch.AngleInput();
            this.button_set = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // angleInput_phi
            // 
            this.angleInput_phi.BackColor = System.Drawing.SystemColors.Control;
            this.angleInput_phi.description = "Azimuth";
            this.angleInput_phi.Location = new System.Drawing.Point(12, 12);
            this.angleInput_phi.Name = "angleInput_phi";
            this.angleInput_phi.Size = new System.Drawing.Size(307, 98);
            this.angleInput_phi.TabIndex = 0;
            // 
            // angleInput_theta
            // 
            this.angleInput_theta.BackColor = System.Drawing.SystemColors.Control;
            this.angleInput_theta.description = "Polar";
            this.angleInput_theta.Location = new System.Drawing.Point(12, 116);
            this.angleInput_theta.Name = "angleInput_theta";
            this.angleInput_theta.Size = new System.Drawing.Size(307, 98);
            this.angleInput_theta.TabIndex = 1;
            // 
            // button_set
            // 
            this.button_set.Location = new System.Drawing.Point(246, 220);
            this.button_set.Name = "button_set";
            this.button_set.Size = new System.Drawing.Size(75, 23);
            this.button_set.TabIndex = 4;
            this.button_set.Text = "Set";
            this.button_set.UseVisualStyleBackColor = true;
            this.button_set.Click += new System.EventHandler(this.button_set_Click);
            // 
            // TelescopeStateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 249);
            this.Controls.Add(this.button_set);
            this.Controls.Add(this.angleInput_theta);
            this.Controls.Add(this.angleInput_phi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TelescopeStateDialog";
            this.Text = "Telescope State";
            this.Load += new System.EventHandler(this.TelescopeStateDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AngleInput angleInput_phi;
        private AngleInput angleInput_theta;
        private System.Windows.Forms.Button button_set;
    }
}