using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spacewatch
{
    public partial class AngleInput : UserControl
    {
        Graphics g;
        bool userEvent = true;
        Angle angle;
        Bitmap visual;

        public void setAngle(Angle a)
        {
            angle = a.clone(); updateValues();
        }

        public Angle getAngle()
        {
            return angle.clone();
        }

        public AngleInput()
        {
            InitializeComponent();
        }

        private void AngleInput_Load(object sender, EventArgs e)
        {
            angle = new Angle(0D);
            visual = new Bitmap(visualisation.Width, visualisation.Height);
            g = Graphics.FromImage(visual);
            drawVisual();
        }

        void drawVisual()
        {
            g.Clear(this.BackColor);
            g.DrawEllipse(Pens.Black, 1, 1, 68, 68);
            g.DrawLine(Pens.Black, 35, 35, 68, 35);
            g.DrawLine(Pens.Red, 35F, 35F, 35F + 34F * (float)Math.Cos(angle.radians), 35F - 34F * (float)Math.Sin(angle.radians));
            visualisation.Image = visual;
        }

        void updateValues()
        {
            userEvent = false;
            try
            {
                input_radians.Value = (decimal)angle.absradians;
                input_deg.Value = (decimal)angle.deg;
                input_amin.Value = (decimal)angle.amin;
                input_asec.Value = (decimal)angle.asec;
                input_h.Value = (decimal)angle.h;
                input_min.Value = (decimal)angle.min;
                input_sec.Value = (decimal)angle.sec;
                checkBox_negative.Checked = angle.sign < 0;
                drawVisual();
            }
            catch { }

            userEvent = true;
        }

        private void input_radians_ValueChanged(object sender, EventArgs e)
        {
            if (userEvent)
            {
                angle.set(r: (double)input_radians.Value * angle.sign);
                updateValues();
            }
        }

        private void input_deg_ValueChanged(object sender, EventArgs e)
        {
            if (userEvent)
            {
                angle.set(d: (int)input_deg.Value, am: (int)input_amin.Value, asc: (double)input_asec.Value, sig: angle.sign);
                updateValues();
            }
        }

        private void input_amin_ValueChanged(object sender, EventArgs e)
        {
            if (userEvent)
            {
                angle.set(d: (int)input_deg.Value, am: (int)input_amin.Value, asc: (double)input_asec.Value, sig: angle.sign);
                updateValues();
            }
        }

        private void input_asec_ValueChanged(object sender, EventArgs e)
        {
            if (userEvent)
            {
                angle.set(d: (int)input_deg.Value, am: (int)input_amin.Value, asc: (double)input_asec.Value, sig: angle.sign);
                updateValues();
            }
        }

        private void input_h_ValueChanged(object sender, EventArgs e)
        {
            if (userEvent)
            {
                angle.seth(hours: (int)input_h.Value, m: (int)input_min.Value, s: (double)input_sec.Value, sig:angle.sign);
                updateValues();
            }
        }

        private void input_min_ValueChanged(object sender, EventArgs e)
        {
            if (userEvent)
            {
                angle.seth(hours: (int)input_h.Value, m: (int)input_min.Value, s: (double)input_sec.Value, sig: angle.sign);
                updateValues();
            }
        }

        private void input_sec_ValueChanged(object sender, EventArgs e)
        {
            if (userEvent)
            {
                angle.seth(hours: (int)input_h.Value, m: (int)input_min.Value, s: (double)input_sec.Value, sig: angle.sign);
                updateValues();
            }
        }

        private void checkBox_negative_CheckedChanged(object sender, EventArgs e)
        {
            if (userEvent)
            {
                if (checkBox_negative.Checked) angle.sign = -1;
                else angle.sign = 1;

                angle.set(angle.sign * angle.absradians);
                updateValues();
            }
        }

        public string description { get { return label_Name.Text; } set { label_Name.Text = value; } }
    }
}
