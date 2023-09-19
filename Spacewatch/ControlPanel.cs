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
    public partial class ControlPanel : Form
    {
        Skymap globalSkymap, localSkymap;
        private SkyObject[] filteredObjectList;

        public ControlPanel()
        {
            InitializeComponent();
        }

        private void angleInput1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox_visualIdentification_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer_update_starmaps_Tick(object sender, EventArgs e)
        {
            updateStarmaps();
        }

        private void updateStarmaps()
        {
            picBox_starmap_unfocussed.Image = globalSkymap.draw(null, schematicBackground: true, names: false, magLimit: 10, telescope: true);
            //localSkymap.centerAzimut = TelescopeState.coordinates.azimut.clone(); localSkymap.centerPolar = TelescopeState.coordinates.polar.clone();
            picBox_starmap_focussed.Image = localSkymap.draw(null, schematicBackground: false, names: false, magLimit: 10, telescope: true);
        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {
            globalSkymap = new Skymap(new Angle(true, 90, 0, 0), new Angle(0), SkyObjectCollection.defaultCollection, 1, picBox_starmap_unfocussed.Width, picBox_starmap_unfocussed.Height);
            localSkymap = new Skymap(TelescopeState.polar, TelescopeState.azimut, SkyObjectCollection.defaultCollection, 3, picBox_starmap_focussed.Width, picBox_starmap_focussed.Height);
        }

        private void ControlPanel_Shown(object sender, EventArgs e)
        {
            updateStarmaps();
            updateObjectList("");
            
        }

        private void textBox_filter_TextChanged(object sender, EventArgs e)
        {
            updateObjectList(textBox_filter.Text);
        }

        private void updateObjectList(string filter)
        {
            filteredObjectList = SkyObjectCollection.defaultCollection.getFilteredList(filter);
            listBox_skyObjects.Items.Clear();
            foreach (SkyObject o in filteredObjectList)
            {
                listBox_skyObjects.Items.Add(o.name);
            }
        }

        private async void button_navigateTo_Click(object sender, EventArgs e)
        {
            Coordinates c = new Coordinates(TelescopeState.coordinates.lat, TelescopeState.coordinates.lon);
            c.setGlobal(angleInput_dec.getAngle(), angleInput_ra.getAngle(), DateTime.Now);
            await TelescopeControl.goToIterated(c, TP.defaultStepSize);
        }

        private void listBox_skyObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_skyObjects.SelectedIndex >= 0)
            {
                globalSkymap.placeMarker(filteredObjectList[listBox_skyObjects.SelectedIndex].coordinates);
                localSkymap.placeMarker(filteredObjectList[listBox_skyObjects.SelectedIndex].coordinates);
                updateStarmaps();
            }
        }
    }
}
