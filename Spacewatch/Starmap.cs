using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Spacewatch
{
    public partial class Starmap : Form
    {
        Skymap skymap; bool editing = false;
        SkyObjectType newtype = SkyObjectType.Star;
        private SkyObject[] filteredObjectList;

        public Starmap()
        {
            InitializeComponent();
            skymap = new Skymap(new Angle(true, 90, 0, 0), new Angle(0), new SkyObjectCollection(), 1, picBox_skymap.Width, picBox_skymap.Height);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            updateView();
        }

        private void button_addObj_Click(object sender, EventArgs e)
        {
            Coordinates coords = new Coordinates(TelescopeState.defaultLat, TelescopeState.defaultLong);
            if (editing)
            {
                skymap.objectCollection.objects[listBox_objects.SelectedIndex].name = textBox_ObjName.Text;
                skymap.objectCollection.objects[listBox_objects.SelectedIndex].trivialName = textBox_secondaryName.Text;
                skymap.objectCollection.objects[listBox_objects.SelectedIndex].magnitude = (double)numericUpDown_magnitude.Value;
                skymap.objectCollection.objects[listBox_objects.SelectedIndex].type = newtype;
                skymap.objectCollection.objects[listBox_objects.SelectedIndex].coordinates.setGlobal(angleInput_dec.getAngle(), angleInput_ra.getAngle(), DateTime.Now);
                listBox_objects.Items[listBox_objects.SelectedIndex] = textBox_ObjName.Text;
                editing = false;
                button_addObj.Text = "Add";
            }
            else
            {
                coords.setGlobal(angleInput_dec.getAngle(), angleInput_ra.getAngle(), DateTime.Now);
                skymap.objectCollection.objects.Add(new SkyObject(textBox_ObjName.Text, textBox_secondaryName.Text, (double)numericUpDown_magnitude.Value, newtype, coords));
                listBox_objects.Items.Add(textBox_ObjName.Text);
            }
            updateView();
            updateObjectList(textBox_objectFilter.Text);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            loadObjectCollection(SkyObjectCollection.FromFile(openFileDialog.FileName));
            updateObjectList(textBox_objectFilter.Text);
        }

        void loadObjectCollection(SkyObjectCollection coll)
        {
            skymap.objectCollection = coll;
            foreach (SkyObject ob in skymap.objectCollection.objects)
                listBox_objects.Items.Add(ob.name);
            updateView();
            updateObjectList(textBox_objectFilter.Text);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
            skymap.objectCollection.Save(saveFileDialog.FileName);
        }

        private void picBox_skymap_SizeChanged(object sender, EventArgs e)
        {
            if (skymap != null)
            {
                skymap.width = picBox_skymap.Width;
                skymap.height = picBox_skymap.Height;
                updateView();
            }
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            int index = listBox_objects.SelectedIndex;
            listBox_objects.Items.RemoveAt(index);
            skymap.objectCollection.objects.Remove(filteredObjectList[index]);
            updateObjectList(textBox_objectFilter.Text);
        }

        private void Starmap_Shown(object sender, EventArgs e)
        {
            updateView();
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                editing = false;
                button_addObj.Text = "Add";
            }
            else
            {
                editing = true;
                button_addObj.Text = "Update";
                textBox_ObjName.Text = filteredObjectList[listBox_objects.SelectedIndex].name;
                textBox_secondaryName.Text = filteredObjectList[listBox_objects.SelectedIndex].trivialName;
                numericUpDown_magnitude.Value = (decimal)filteredObjectList[listBox_objects.SelectedIndex].magnitude;
                rb_star.Checked = false; rb_galaxy.Checked = false; rb_nebula.Checked = false; rb_other.Checked = false;
                switch (filteredObjectList[listBox_objects.SelectedIndex].type)
                {
                    case SkyObjectType.Star:
                        rb_star.Checked = true;
                        break;
                    case SkyObjectType.Galaxy:
                        rb_galaxy.Checked = true;
                        break;
                    case SkyObjectType.Nebula:
                        rb_nebula.Checked = true;
                        break;
                    case SkyObjectType.Other:
                        rb_other.Checked = true;
                        break;
                }
                angleInput_dec.setAngle(filteredObjectList[listBox_objects.SelectedIndex].coordinates.dec);
                angleInput_ra.setAngle(filteredObjectList[listBox_objects.SelectedIndex].coordinates.ra);
            }

        }

        private void rb_star_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_star.Checked) newtype = SkyObjectType.Star;
        }

        private void rb_galaxy_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_galaxy.Checked) newtype = SkyObjectType.Galaxy;
        }

        private void rb_nebula_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_nebula.Checked) newtype = SkyObjectType.Nebula;
        }

        private void rb_other_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_other.Checked) newtype = SkyObjectType.Other;
        }

        private void button_goto_Click(object sender, EventArgs e)
        {
            skymap.makePath(filteredObjectList[listBox_objects.SelectedIndex].coordinates, new Angle(true, 10, 0, 0));
            picBox_skymap.Image = skymap.draw(null, magLimit: (double)numericUpDown_magLimit.Value);
        }

        void updateView()
        {
            picBox_skymap.Image = skymap.draw(null, magLimit: (double)numericUpDown_magLimit.Value);
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (skymap.objectCollection.path == "")
                MessageBox.Show("Not yet saved.");
            skymap.objectCollection.Save(skymap.objectCollection.path);
        }

        private void loadDefaultCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadObjectCollection(SkyObjectCollection.defaultCollection);
        }

        private void textBox_objectFilter_TextChanged(object sender, EventArgs e)
        {
            updateObjectList(textBox_objectFilter.Text);
        }

        private void updateObjectList(string filter)
        {
            filteredObjectList = skymap.objectCollection.getFilteredList(filter);
            listBox_objects.Items.Clear();
            foreach (SkyObject o in filteredObjectList)
            {
                listBox_objects.Items.Add(o.name);
            }
        }

        private void listBox_objects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_objects.SelectedIndex >= 0)
            {
                skymap.placeMarker(filteredObjectList[listBox_objects.SelectedIndex].coordinates);
                updateView();
            }
        }

        private void importDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            for(int i = 0; i<72; i++)
                for (int j = -18; j < 18; j++)
                    if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "DynamicDetail\\dd_" + i.ToString() + "_" + j.ToString() + ".soc"))
                    {
                        SkyObjectCollection coll = new SkyObjectCollection();
                        FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                        StreamReader r = new StreamReader(fs);
                        while (!r.EndOfStream)
                        {
                            string[] l = r.ReadLine().Split('|');
                            
                            string[] coords = l[2].Trim().Replace("  ", " ").Replace("+ ", "").Replace("- ", "-").Split(' ');
                            Angle ra = new Angle(false, Convert.ToInt32(coords[0]), (int)Math.Floor(Convert.ToInt32(coords[1]) / 10D), (int)(Convert.ToInt32(coords[1]) / 10D - Math.Floor(Convert.ToInt32(coords[1]) / 10D)) * 60);
                            Angle dec = new Angle(0);
                            dec.set(Math.Abs(Convert.ToInt32(coords[2])), Convert.ToInt32(coords[1]), 0, sig : Math.Sign(Convert.ToInt32(coords[2])));

                            int centerRA, centerDEC;
                            centerRA = degrifyRA((int)Math.Floor(ra.deg / 5D) * ra.sign);
                            centerDEC = degrifyDEC((int)Math.Floor(dec.deg / 5D) * dec.sign);

                            /*if (j * 5 <= dec.deg * dec.sign && dec.sign * dec.deg < (j + 1) * 5
                                && i * 5 <= ra.deg * ra.sign && ra.sign * ra.deg < (i + 1) * 5)*/
                            if (j == centerDEC && i == centerRA)
                            {
                                string name = "HD " + l[0].Trim();
                                string altname = l[1].Trim();
                                Coordinates c = new Coordinates(TelescopeState.coordinates.lat, TelescopeState.coordinates.lon);
                                c.setGlobal(dec, ra, DateTime.Now);
                                double mag;
                                try { mag = Convert.ToDouble(l[4].Trim().Replace('.', ',')); }
                                catch { mag = 5.0; }

                                SkyObject o = new SkyObject(name, altname, mag, SkyObjectType.Star, c);

                                coll.objects.Add(o);
                            }
                        }

                        r.Close();
                        fs.Close();
                        coll.Save(AppDomain.CurrentDomain.BaseDirectory + "DynamicDetail\\dd_" + i.ToString() + "_" + j.ToString() + ".soc");
                    }
        }
        int degrifyRA(int a)
        {
            if (a < 0) a += 72;
            else if (a >= 72) a -= 72;
            return a;
        }
        int degrifyDEC(int a)
        {
            if (a > 18) a = 18;
            if (a < -18) a = -18;
            return a;
        }
    }

    public class Skymap
    {
        public Angle centerPolar, centerAzimut, fov;
        public SkyObjectCollection objectCollection;
        public DynamicDetailCollection dynamicDetailCollection;
        public double zoom;
        public int width, height;
        PointF[] path;
        Coordinates pathStart;
        Coordinates pathTarget;
        Angle pathStep;
        public Coordinates marker;
        public bool actual = true;
        public DateTime time;

        public Skymap (Angle focusPolar, Angle focusAzimut, SkyObjectCollection objects, double scale, int w, int h)
        {
            centerPolar = focusPolar;
            centerAzimut = focusAzimut;
            objectCollection = objects;
            dynamicDetailCollection = new DynamicDetailCollection();
            setZoom(scale);
            width = w;
            height = h;
        }

        public void setFOV(Angle f)
        {
            fov = f;
            zoom = Math.PI / f.absradians;
        }

        public void setZoom(double z)
        {
            zoom = z;
            fov = new Angle(Math.PI / zoom);
        }

        public void makePath(Coordinates target, Angle stepSize)
        {
            pathTarget = target.clone();
            pathStep = stepSize.clone();
            pathStart = TelescopeState.coordinates.clone();
            updatePath();
        }

        private void updatePath()
        {
            List<PointF> points = new List<PointF>();
            TelescopeState.updateCoords();
            Coordinates c = pathStart;
            points.Add(getImagePosition(c));

            int i = 0;

            if (CoordinateManager.distance2D(c, pathTarget).radians <= TP.anglePrecision.radians) points.Add(getImagePosition(pathTarget));

            while (CoordinateManager.distance2D(c, pathTarget).radians > TP.anglePrecision.radians && i < 100)
            {
                c = CoordinateManager.stepTowards(c, pathTarget, pathStep, actual ? DateTime.Now : time);

                points.Add(getImagePosition(c));
                i++;
            }

            path = points.ToArray();
        }

        public void updateDynamicDetail()
        {
            Coordinates c = new Coordinates(TelescopeState.coordinates.lat, TelescopeState.coordinates.lon);
            c.setLocal(centerAzimut, centerPolar, actual ? DateTime.Now : time);
            dynamicDetailCollection.update(c);
        }

        public void clearPath() { path = null; }

        public Image draw(Image background, bool schematicBackground = true, bool names = false, double magLimit = 100, bool telescope = true, bool grid = false, bool dynamicDetail = false, bool planets = true)
        {
            Bitmap bmp;
            Graphics g;
            int scale = Math.Min(width, height);

            if (background == null)
            {
                bmp = new Bitmap(width, height);
                g = Graphics.FromImage(bmp);
                if (schematicBackground)
                {
                    g.Clear(Color.Black);
                    g.FillEllipse(Brushes.Navy, width / 2 - scale / 2, height / 2 - scale / 2, scale, scale);
                    g.DrawLine(Pens.Red, width / 2, 0, width / 2, height);
                    g.DrawLine(Pens.Red, 0, height / 2, width, height / 2);
                }
                else
                    g.Clear(Color.Navy);
            }
            else
            {
                bmp = (Bitmap)background;
                g = Graphics.FromImage(bmp);
            }

            Coordinates center = new Coordinates(TelescopeState.coordinates.lat, TelescopeState.coordinates.lon);
            center.setLocal(centerAzimut, centerPolar, actual ? DateTime.Now : time);

            if (grid) drawGrid(g);

            if (dynamicDetail)
            //foreach(SkyObjectCollection co in dynamicDetailCollection.collections)
            {
                SkyObjectCollection co = dynamicDetailCollection.collections[4];
                foreach (SkyObject obj in co.objects)
                    if (obj.magnitude < magLimit)
                        if (isVisible(obj, ref center))
                        {
                            PointF pos = getImagePosition(obj.coordinates);
                            obj.draw(ref g, pos, names);
                        }
                g.DrawLine(Pens.Black, getImagePosition(dynamicDetailCollection.rect[0]), getImagePosition(dynamicDetailCollection.rect[1]));
                g.DrawLine(Pens.Black, getImagePosition(dynamicDetailCollection.rect[0]), getImagePosition(dynamicDetailCollection.rect[2]));
                g.DrawLine(Pens.Black, getImagePosition(dynamicDetailCollection.rect[2]), getImagePosition(dynamicDetailCollection.rect[3]));
                g.DrawLine(Pens.Black, getImagePosition(dynamicDetailCollection.rect[1]), getImagePosition(dynamicDetailCollection.rect[3]));
            }
            foreach (SkyObject obj in objectCollection.objects)
            {
                if(obj.magnitude < magLimit)
                    if (isVisible(obj, ref center))
                    {
                        PointF pos = getImagePosition(obj.coordinates);
                        obj.draw(ref g, pos, names);
                    }
            }

            if(planets)
                foreach (SkyObject obj in PlanetaryCollection.instance.collection.objects)
                    if (obj.magnitude < magLimit)
                        if (isVisible(obj, ref center))
                        {
                            PointF pos = getImagePosition(obj.coordinates);
                            obj.draw(ref g, pos, true);
                        }
                

            if (telescope)
            {
                TelescopeState.updateCoords();
                PointF scopePos = getImagePosition(TelescopeState.coordinates);
                g.DrawLine(Pens.LightBlue, scopePos.X, scopePos.Y - 5, scopePos.X, scopePos.Y + 5);
                g.DrawLine(Pens.LightBlue, scopePos.X - 5, scopePos.Y, scopePos.X + 5, scopePos.Y);
            }

            if (path != null)
            {
                updatePath();
                g.DrawLines(Pens.LightBlue, path);
            }

            if (marker != null)
            {
                PointF m = getImagePosition(marker);
                g.DrawLine(Pens.SpringGreen, m.X - 5, m.Y - 5, m.X + 5, m.Y + 5);
                g.DrawLine(Pens.SpringGreen, m.X - 5, m.Y + 5, m.X + 5, m.Y - 5);
            }

            return bmp;
        }

        void drawGrid(Graphics g)
        {
            Coordinates c = new Coordinates(TelescopeState.coordinates.lat, TelescopeState.coordinates.lon);
            Coordinates c2 = new Coordinates(TelescopeState.coordinates.lat, TelescopeState.coordinates.lon);
            Angle phi = new Angle(0);
            Angle the = new Angle(0);
            int incr = TP.fov.amin / 2 + 1;
            Angle degree = new Angle(true, 0, incr, 0);
            Angle centDec = TelescopeState.coordinates.dec.clone();
            Angle centRa = TelescopeState.coordinates.ra.clone();
            centDec.set(centDec.deg, centDec.amin - centDec.amin % incr, 0, sig: centDec.sign);
            centRa.set(centRa.deg, centRa.amin - centRa.amin % incr, 0, sig: centRa.sign);

            for (int p = -2; p < 3; p++)
            {
                for (int t = -2; t < 3; t++)
                {
                    phi.set(centRa.radians + p * degree.radians);
                    the.set(centDec.radians + t * degree.radians);
                    c.setGlobal(the, phi, actual ? DateTime.Now : time);
                    c2.setGlobal(the+degree, phi, actual ? DateTime.Now : time);
                    g.DrawLine(Pens.Gray, getImagePosition(c), getImagePosition(c2));
                    c2.setGlobal(the, phi + degree, actual ? DateTime.Now : time);
                    g.DrawLine(Pens.Gray, getImagePosition(c), getImagePosition(c2));
                }
            }
        }

        bool isVisible(SkyObject obj, ref Coordinates center)
        {
            if(obj.coordinates.polar.radians <= 0D) return false;
            if (CoordinateManager.distance2D(obj.coordinates, center).radians > 2 * fov.radians) return false;
            return true;
        }

        public PointF getImagePosition(Coordinates c)
        {
            c.updateLocal(actual ? DateTime.Now : time);
            double ob_pol = c.polar.radians;
            double ob_azi = c.azimut.radians - centerAzimut.radians;

            int size = Math.Min(width, height);
            double x = Math.Sin(ob_azi) * (Math.PI * 0.5 - ob_pol) * zoom * size / Math.PI + width * 0.5;
            double y = (Math.Cos(ob_azi) * (Math.PI * 0.5 - ob_pol) + centerPolar.radians - Math.PI * 0.5) * zoom * size / Math.PI + height * 0.5;

            return new PointF ((float)x, (float)y);
        }

        public Coordinates coordinatesFromPoint(PointF p)
        {
            p.X -= (float)width / 2; p.Y -= (float)height / 2;
            float size = Math.Min(width, height);
            p.X = p.X * 2 / size / (float)zoom; p.Y = p.Y * 2 / size / (float)zoom;
            p.Y += (float)(Math.PI * 0.5 - centerPolar.radians) / (float)(0.5 * Math.PI);
            double ob_azi = Math.Atan(p.X / p.Y);
            double ob_pol = -p.Y / Math.Cos(ob_azi) * (0.5 * Math.PI) + Math.PI * 0.5;
            Coordinates c = new Coordinates(TelescopeState.coordinates.lat, TelescopeState.coordinates.lon);
            c.setLocal(new Angle(ob_azi + centerAzimut.radians), new Angle(ob_pol), actual ? DateTime.Now : time);
            return c;
        }

        public void calibrate(PointF p, Coordinates c)
        {
            double size = Math.Min(width, height);
            centerAzimut = new Angle(c.azimut.radians - Math.Asin((p.X - width * 0.5) / (zoom * size * (0.5 * Math.PI - c.polar.radians) / Math.PI)));
            centerPolar = new Angle((p.Y - height * 0.5) / (size * zoom) * Math.PI - Math.Cos(c.azimut.radians - centerAzimut.radians) * (0.5 * Math.PI - c.polar.radians) + 0.5 * Math.PI);
        }

        internal void placeMarker(Coordinates coordinates)
        {
            marker = coordinates;
        }

        internal void clearMarker() { marker = null; }
    }

    public class PlanetaryCollection
    {
        public SkyObjectCollection collection;
        public static PlanetaryCollection instance;

        public static void init()
        {
            instance = new PlanetaryCollection();
            instance.updateCoordinates();
        }

        public PlanetaryCollection()
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "default_soc_planets.soc"))
            {
                collection = SkyObjectCollection.FromFile(AppDomain.CurrentDomain.BaseDirectory + "default_soc_planets.soc");
            }
            else
                collection = new SkyObjectCollection();
        }

        public void updateCoordinates()
        {
            string url = "http://ephemeriden.com/planets.py";
            try
            {
                using (WebClient client = new WebClient())
                {
                    string[] htmlCode = client.DownloadString(url).Split('\n');

                    SkyObjectCollection coll = new SkyObjectCollection();
                    Coordinates c = new Coordinates(TelescopeState.coordinates.lat, TelescopeState.coordinates.lon);

                    //Mercury
                    int i = 499;
                    c.setGlobal(getDECfromHTML(htmlCode[i + 35]), getRAfromHTML(htmlCode[i + 5]), DateTime.Now);
                    coll.objects.Add(new SkyObject("Mercury", "", getMagfromHTML(htmlCode[i + 415]), SkyObjectType.Planet, c.clone()));
                    i += 3;

                    //Venus
                    c.setGlobal(getDECfromHTML(htmlCode[i + 35]), getRAfromHTML(htmlCode[i + 5]), DateTime.Now);
                    coll.objects.Add(new SkyObject("Venus", "", getMagfromHTML(htmlCode[i + 415]), SkyObjectType.Planet, c.clone()));
                    i += 3;

                    //Mars
                    c.setGlobal(getDECfromHTML(htmlCode[i + 35]), getRAfromHTML(htmlCode[i + 5]), DateTime.Now);
                    coll.objects.Add(new SkyObject("Mars", "", getMagfromHTML(htmlCode[i + 415]), SkyObjectType.Planet, c.clone()));
                    i += 3;

                    //Jupiter
                    c.setGlobal(getDECfromHTML(htmlCode[i + 35]), getRAfromHTML(htmlCode[i + 5]), DateTime.Now);
                    coll.objects.Add(new SkyObject("Jupiter", "", getMagfromHTML(htmlCode[i + 415]), SkyObjectType.Planet, c.clone()));
                    i += 3;

                    //Saturn
                    c.setGlobal(getDECfromHTML(htmlCode[i + 35]), getRAfromHTML(htmlCode[i + 5]), DateTime.Now);
                    coll.objects.Add(new SkyObject("Saturn", "", getMagfromHTML(htmlCode[i + 415]), SkyObjectType.Planet, c.clone()));
                    i += 3;

                    //Uranus
                    c.setGlobal(getDECfromHTML(htmlCode[i + 35]), getRAfromHTML(htmlCode[i + 5]), DateTime.Now);
                    coll.objects.Add(new SkyObject("Uranus", "", getMagfromHTML(htmlCode[i + 415]), SkyObjectType.Planet, c.clone()));
                    i += 3;

                    //Neptune
                    c.setGlobal(getDECfromHTML(htmlCode[i + 35]), getRAfromHTML(htmlCode[i + 5]), DateTime.Now);
                    coll.objects.Add(new SkyObject("Neptune", "", getMagfromHTML(htmlCode[i + 415]), SkyObjectType.Planet, c.clone()));
                    i += 3;

                    collection = coll;
                }

                collection.Save(AppDomain.CurrentDomain.BaseDirectory + "default_soc_planets.soc");

                mainForm.print("Updated Planetary Coordinates using http://ephemeriden.com/planets.py");
            }
            catch
            {
                mainForm.print("Failed to obtain Planetary Coordinates from Website.");
            }
        }

        double getMagfromHTML(string line)
        {
            line = line.Trim();
            return Convert.ToDouble(line.Split(' ')[0].Replace('.', ',').Trim());
        }

        Angle getRAfromHTML(string line)
        {
            line = line.Trim();
            string[] splits = line.Split('<');
            int h = Convert.ToInt32(splits[0].Trim());
            int m = Convert.ToInt32(splits[2].Substring(splits[2].Length - 2).Trim());
            double s = Convert.ToDouble(splits[4].Substring(splits[4].Length - 2).Trim());

            return new Angle(false, h, m, s);
        }

        Angle getDECfromHTML(string line)
        {
            line = line.Trim();
            string[] splits = line.Split(' ');
            int d = Convert.ToInt32(splits[0].Substring(0, splits[0].Length - 5).Trim());
            int m = Convert.ToInt32(splits[1].Substring(0, splits[1].Length - 1).Trim());
            double s = Convert.ToDouble(splits[2].Substring(0, splits[2].Length - 1).Trim());

            return new Angle(true, d, m, s);
        }
    }

    public class DynamicDetailCollection
    {
        public SkyObjectCollection[] collections;
        public Coordinates[] rect;

        public DynamicDetailCollection()
        {
            collections = new SkyObjectCollection[9];
            for (int i = 0; i < 9; i++)
                collections[i] = SkyObjectCollection.emptyCollection;
            rect = new Coordinates[4];
            for(int i = 0; i<4;i++)
                rect[i] = new Coordinates(TelescopeState.coordinates.lat, TelescopeState.coordinates.lon);

        }

        public void update(Coordinates coords)
        {
            int centerRA, centerDEC;
            centerRA = (int)Math.Floor(coords.ra.deg / 5D) * coords.ra.sign;
            centerDEC = (int)Math.Floor(coords.dec.deg / 5D) * coords.dec.sign;
            /*for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                    collections[3 * (i + 1) + j + 1] = loadQuadeg(degrifyRA(centerRA + i), degrifyDEC(centerDEC + j));*/
            collections[4] = loadQuadeg(degrifyRA(centerRA), degrifyDEC(centerDEC));
            //mainForm.print("quadeg: ra " + centerRA.ToString() + ", dec " + centerDEC.ToString());

            rect[0].setGlobal(new Angle(true, centerDEC * 5, 0, 0), new Angle(true, centerRA * 5, 0, 0), DateTime.Now);
            rect[1].setGlobal(new Angle(true, centerDEC * 5, 0, 0), new Angle(true, (centerRA + 1) * 5, 0, 0), DateTime.Now);
            rect[2].setGlobal(new Angle(true, (centerDEC + 1) * 5, 0, 0), new Angle(true, centerRA * 5, 0, 0), DateTime.Now);
            rect[3].setGlobal(new Angle(true, (centerDEC + 1) * 5, 0, 0), new Angle(true, (centerRA + 1) * 5, 0, 0), DateTime.Now);
        }

        int degrifyRA(int a)
        {
            if (a < 0) a += 72;
            else if (a >= 72) a -= 72;
            return a;
        }
        int degrifyDEC(int a)
        {
            if (a > 18) a = 18;
            if (a < -18) a = -18;
            return a;
        }

        SkyObjectCollection loadQuadeg(int ra, int dec)
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "DynamicDetail\\dd_" + ra.ToString() + "_" + dec.ToString() + ".soc"))
                return SkyObjectCollection.FromFile(AppDomain.CurrentDomain.BaseDirectory + "DynamicDetail\\dd_" + ra.ToString() + "_" + dec.ToString() + ".soc");
            else return SkyObjectCollection.emptyCollection;
        }
    }

    public class SkyObjectCollection
    {
        public static SkyObjectCollection defaultCollection, emptyCollection;
        public List<SkyObject> objects;
        public string path;

        public static void init()
        {
            emptyCollection = new SkyObjectCollection();
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "default_soc.soc"))
            {
                defaultCollection = SkyObjectCollection.FromFile(AppDomain.CurrentDomain.BaseDirectory + "default_soc.soc");
            }
            else defaultCollection = emptyCollection;
        }

        public SkyObjectCollection()
        {
            objects = new List<SkyObject>();
        }

        public static SkyObjectCollection FromFile(string filename)
        {
            SkyObjectCollection coll = new SkyObjectCollection();

            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader r = new StreamReader(fs);
            int version = Convert.ToInt32(r.ReadLine());
            int count;
            switch (version)
            {
                case 1:
                    count = Convert.ToInt32(r.ReadLine());

                    for (int i = 0; i < count; i++)
                    {
                        string n = r.ReadLine();
                        Coordinates coords = new Coordinates(TelescopeState.defaultLat, TelescopeState.defaultLong);
                        Angle dec = new Angle(Convert.ToDouble(r.ReadLine()));
                        Angle ra = new Angle(Convert.ToDouble(r.ReadLine()));
                        coords.setGlobal(dec, ra, DateTime.Now);

                        SkyObject ob = new SkyObject(n, "", 2, SkyObjectType.Star, coords);
                        coll.objects.Add(ob);
                    }
                    break;
                case 2:
                    count = Convert.ToInt32(r.ReadLine());

                    for (int i = 0; i < count; i++)
                    {
                        string n = r.ReadLine();
                        string tn = r.ReadLine();
                        double mag = Convert.ToDouble(r.ReadLine());
                        SkyObjectType t = (SkyObjectType)Convert.ToInt32(r.ReadLine());
                        Coordinates coords = new Coordinates(TelescopeState.defaultLat, TelescopeState.defaultLong);
                        Angle dec = new Angle(Convert.ToDouble(r.ReadLine()));
                        Angle ra = new Angle(Convert.ToDouble(r.ReadLine()));
                        coords.setGlobal(dec, ra, DateTime.Now);
                        
                        SkyObject ob = new SkyObject(n, tn, mag, t, coords);
                        coll.objects.Add(ob);
                    }
                    break;
                default:
                    r.Close();
                    fs.Close();
                    return null;
            }

            r.Close(); fs.Close();
            coll.path = filename;

            return coll;
        }

        public void Save(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Create);
            StreamWriter w = new StreamWriter(fs);

            w.WriteLine("2");
            w.WriteLine(objects.Count.ToString());

            foreach(SkyObject ob in objects)
            {
                w.WriteLine(ob.name);
                w.WriteLine(ob.trivialName);
                w.WriteLine(ob.magnitude.ToString());
                w.WriteLine(((int)(ob.type)).ToString());
                w.WriteLine(ob.coordinates.dec.radians.ToString());
                w.WriteLine(ob.coordinates.ra.radians.ToString());
            }

            w.Close(); fs.Close();
        }

        internal SkyObject[] getFilteredList(string filter)
        {
            filter = filter.ToLower();
            if (filter == "") return objects.ToArray();
            List<SkyObject> list = new List<SkyObject>();
            list.AddRange(objects.Where(o => o.name.ToLower().Contains(filter)));
            list.AddRange(objects.Where(o => o.trivialName.ToLower().Contains(filter)));
            return list.ToArray();
        }
    }

    public class SkyObject
    {
        public Coordinates coordinates;
        public string name, trivialName;
        public double magnitude;
        public SkyObjectType type;

        public SkyObject(string n, string tn, double mag, SkyObjectType t, Coordinates coords)
        {
            name = n;
            trivialName = tn;
            magnitude = mag;
            type = t;
            coordinates = coords;
        }

        public void draw (ref Graphics g, PointF position, bool n)
        {
            switch (type)
            {
                case SkyObjectType.Star:
                    g.DrawEllipse(Pens.White, position.X - 2F, position.Y - 2F, 4F, 4F);
                    break;
                case SkyObjectType.Galaxy:
                    g.FillEllipse(Brushes.Gold, position.X - 3F, position.Y - 3F, 6F, 6F);
                    break;
                case SkyObjectType.Nebula:
                    g.FillEllipse(Brushes.IndianRed, position.X - 2.5F, position.Y - 2.5F, 5F, 5F);
                    break;
                case SkyObjectType.Other:
                    g.DrawEllipse(Pens.ForestGreen, position.X - 2F, position.Y - 2F, 4F, 4F);
                    break;
                case SkyObjectType.Planet:
                    g.DrawEllipse(Pens.DarkOrange, position.X - 4F, position.Y - 4F, 8F, 8F);
                    g.FillEllipse(Brushes.DarkOrange, position.X - 2F, position.Y - 2F, 4F, 4F);
                    break;
            }
            if (n)
                g.DrawString(name, SystemFonts.DefaultFont, Brushes.White, position.X, position.Y + 10);
        }
    }

    public enum SkyObjectType
    {
        Star = 1,
        Galaxy = 2,
        Nebula = 3,
        Other = 4,
        Planet = 5
    }
}
