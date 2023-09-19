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
    public partial class ValuePicker : UserControl
    {
        bool userInput = true;
        public event EventHandler ValueChanged;

        public ValuePicker()
        {
            InitializeComponent();
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            userInput = false;
            trackBar.Value = (int)(numericUpDown.Value * 100);
            userInput = true ;
            if (this.ValueChanged != null)
                this.ValueChanged(sender, e);
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            if(userInput)
                numericUpDown.Value = (decimal)trackBar.Value / (decimal)100;
        }

        public string Description { 
            get { return label.Text; }
            set { label.Text = value; }
        }

        public Decimal Value
        {
            get { return numericUpDown.Value; }
            set { numericUpDown.Value = value; }
        }
    }
}
