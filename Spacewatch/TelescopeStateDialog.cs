using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spacewatch
{
    public partial class TelescopeStateDialog : Form
    {
        public TelescopeStateDialog()
        {
            InitializeComponent();
        }

        public static async void ShowDialog()
        {
            TelescopeStateDialog entity = new TelescopeStateDialog();
            entity.Show();
            while (entity.Visible)
                await Task.Delay(10);
        }

        private void button_set_Click(object sender, EventArgs e)
        {
            TelescopeState.setCoords(angleInput_phi.getAngle(), angleInput_theta.getAngle());
            Visible = false;
            Close();
        }

        private void TelescopeStateDialog_Load(object sender, EventArgs e)
        {
            angleInput_phi.setAngle(TelescopeState.azimut);
            angleInput_theta.setAngle(TelescopeState.polar);
        }
    }
}
