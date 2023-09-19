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

namespace Spacewatch
{
    public partial class ImageEditor : Form
    {
        BrightnessCurve curve;
        public SW_Image image;
        List<BrightnessCurve> curveList;

        public ImageEditor()
        {
            InitializeComponent();
            curve = BrightnessCurveLinear.defaultCurve;
        }

        public void setImage(SW_Image img) { image = img; }

        private void ImageEditor_Load(object sender, EventArgs e)
        {
            updateCurve();
            curveList = new List<BrightnessCurve>();
            loadCurveList();
            foreach (BrightnessCurve c in curveList)
                comboBox_curves.Items.Add(c.name);
        }

        void loadCurveList()
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "curve_array.scl"))
            {
                FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "curve_array.scl", FileMode.Open, FileAccess.Read);
                StreamReader r = new StreamReader(fs);

                while (!r.EndOfStream)
                {
                    BrightnessCurve c;
                    int t = Convert.ToInt32(r.ReadLine());
                    switch (t)
                    {
                        case 0: c = new BrightnessCurveLinear();
                            break;
                        case 1: c = new BrightnessCurveRoot();
                            break;
                        case 2: c = new BrightnessCurveExponential();
                            break;
                        case 3: c = new BrightnessCurveLog();
                            break;
                        default: c = new BrightnessCurveLinear();
                            break;
                    }
                    double min = Convert.ToDouble(r.ReadLine());
                    double max = Convert.ToDouble(r.ReadLine());
                    double coef = Convert.ToDouble(r.ReadLine());
                    c.setCurve(min, max, coef);
                    c.name = r.ReadLine();
                    curveList.Add(c);
                }

                r.Close();
                fs.Close();
            }
        }

        void saveCurveList()
        {
            FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "curve_array.scl", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter w = new StreamWriter(fs);

            foreach (BrightnessCurve c in curveList)
            {
                Type t = c.GetType();
                if (t == typeof(BrightnessCurveLinear))
                    w.WriteLine("0");
                else if (t == typeof(BrightnessCurveRoot))
                    w.WriteLine("1");
                else if (t == typeof(BrightnessCurveExponential))
                    w.WriteLine("2");
                else if (t == typeof(BrightnessCurveLog))
                    w.WriteLine("3");
                else w.WriteLine("4");

                w.WriteLine(c.floor.ToString());
                w.WriteLine(c.top.ToString());
                w.WriteLine(c.param.ToString());
                w.WriteLine(c.name);
            }

            w.Close();
            fs.Close();
        }

        void updateCurve()
        {
            curve.setCurve((double)valuePicker_min.Value, (double)valuePicker_max.Value, (double)valuePicker_param.Value);
            picBox_Curve.Image = curve.getVisual(picBox_Curve.Width, picBox_Curve.Height);
        }

        private void valuePicker_min_ValueChanged(object sender, EventArgs e)
        { updateCurve(); }
        
        private void valuePicker_max_ValueChanged(object sender, EventArgs e)
        { updateCurve(); }

        private void valuePicker_param_ValueChanged(object sender, EventArgs e)
        { updateCurve(); }

        private void rB_lin_CheckedChanged(object sender, EventArgs e)
        { if (rB_lin.Checked) { curve = new BrightnessCurveLinear(); updateCurve(); } }

        private void rB_exp_CheckedChanged(object sender, EventArgs e)
        { if (rB_exp.Checked) { curve = new BrightnessCurveExponential(); updateCurve(); } }

        private void rB_root_CheckedChanged(object sender, EventArgs e)
        { if (rB_root.Checked) { curve = new BrightnessCurveRoot(); updateCurve(); } }

        private void rB_log_CheckedChanged(object sender, EventArgs e)
        { if (rB_log.Checked) { curve = new BrightnessCurveLog(); updateCurve(); } }

        private void button_apply_Click(object sender, EventArgs e)
        {
            updateView(curve, showOverlayToolStripMenuItem.Checked);
        }

        void updateView (BrightnessCurve c ,bool overlay = false)
        {
            picBox.Image = image.getBitmap(c, overlay);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportDialog.ShowDialog();
            picBox.Image.Save(exportDialog.FileName);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDialog.ShowDialog();
            image.saveRaw(saveDialog.FileName);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDialog.ShowDialog();
            image = SW_Image.FromFile(openDialog.FileName);
        }

        private void substractDarkImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDialog.ShowDialog();
            image.substractImage(SW_Image.FromFile(openDialog.FileName));
        }

        private void showOverlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateView(curve, showOverlayToolStripMenuItem.Checked);
        }

        private void button_saveCurve_Click(object sender, EventArgs e)
        {
            curve.name = textBox_curveName.Text;
            curveList.Add(curve.clone());
            comboBox_curves.Items.Add(curve.name);
            saveCurveList();
        }

        private void comboBox_curves_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            valuePicker_min.Value = (decimal) curveList[comboBox_curves.SelectedIndex].floor;
            valuePicker_max.Value = (decimal) curveList[comboBox_curves.SelectedIndex].top;
            valuePicker_param.Value = (decimal) curveList[comboBox_curves.SelectedIndex].param;

            rB_exp.Checked = false;rB_lin.Checked = false;rB_root.Checked = false;rB_log.Checked = false;
            Type t = curveList[comboBox_curves.SelectedIndex].GetType();
            if (t == typeof(BrightnessCurveLinear))
                rB_lin.Checked = true;
            else if (t == typeof(BrightnessCurveRoot))
                rB_root.Checked = true;
            else if (t == typeof(BrightnessCurveExponential))
                rB_exp.Checked = true;
            else if (t == typeof(BrightnessCurveLog))
                rB_log.Checked = true;
            else rB_lin.Checked = true;

            textBox_curveName.Text = curveList[comboBox_curves.SelectedIndex].name;
        }
    }

    public class SW_Image
    {
        public int width, height;
        public DateTime time;
        double maxbits;
        Skymap skymap;
        Angle fov;

        public Coordinates coordinates;

        public ushort[,] r, g, b;

        public SW_Image(int w, int h, DateTime t, Coordinates c, Angle f)
        {
            width = w; height = h;
            r = new ushort[w, h];
            g = new ushort[w, h];
            b = new ushort[w, h];
            time = t;
            coordinates = c;
            skymap = new Skymap(coordinates.polar.clone(), coordinates.azimut.clone(), SkyObjectCollection.defaultCollection, 1, w, h);
            fov = f;
            skymap.setFOV(fov);
            skymap.actual = false;
            skymap.time = time;
        }

        public void addImage(SW_Image img)
        {
            if (img.width != width || img.height != height)
            {
                MessageBox.Show("Image dimensions don't fit");
                return;
            }

            double correction = maxbits / img.maxbits;
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    r[i, j] += (ushort)(img.r[i, j]*correction);
                    g[i, j] += (ushort)(img.g[i, j] * correction);
                    b[i, j] += (ushort)(img.b[i, j] * correction);
                }
        }

        public void substractImage(SW_Image img)
        {
            if (img.width != width || img.height != height)
            {
                MessageBox.Show("Image dimensions don't fit");
                return;
            }

            double correction = maxbits / img.maxbits;
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    if (r[i, j] > (ushort)(img.r[i, j]*correction))
                        r[i, j] -= (ushort)(img.r[i, j]*correction);
                    else r[i, j] = 0;
                    if (g[i, j] > (ushort)(img.g[i, j]*correction))
                        g[i, j] -= (ushort)(img.g[i, j]*correction);
                    else g[i, j] = 0;
                    if (b[i, j] > (ushort)(img.b[i, j]*correction))
                        b[i, j] -= (ushort)(img.b[i, j]*correction);
                    else b[i, j] = 0;
                }
        }

        public void addBitmap(Bitmap bitmap, bool movementCorection)
        {
            Point offset = new Point();
            if (movementCorection)
            {
                PointF offsetF = new PointF();
                skymap.actual = true;
                
                offsetF = skymap.getImagePosition(coordinates);
                offsetF.X -= width * 0.5f;
                offsetF.Y -= height * 0.5f;
                offset = new Point((int)Math.Round(offsetF.X), (int)Math.Round(offsetF.Y));
                
                skymap.actual = false;
            }

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    Color col;
                    if (movementCorection)
                    {
                        int x = i + offset.X;
                        int y = j + offset.Y;
                        if (x < 0 || y < 0 || x >= width || y >= height)
                            col = Color.Black;
                        else
                            col = bitmap.GetPixel(x, y);
                    }
                    else
                        col = bitmap.GetPixel(i, j);
                    r[i, j] += col.R;
                    g[i, j] += col.G;
                    b[i, j] += col.B;
                }

            maxbits += 256.0;
        }

        public Bitmap getBitmap(BrightnessCurve bCurve, bool overlay = false)
        {
            Bitmap bmp = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    Color col = Color.FromArgb(bCurve.getValue(r[i,j]/maxbits), bCurve.getValue(g[i,j]/maxbits), bCurve.getValue(b[i,j]/maxbits));
                    bmp.SetPixel(i, j, col);
                }
            if (overlay)
                return (Bitmap)skymap.draw(bmp, names: true, telescope:false);
            else
                return bmp;
        }

        public Bitmap getDefaultBitmap(bool overlay = false)
        {
            return getBitmap(BrightnessCurveLinear.defaultCurve, overlay);
        }

        public void saveRaw(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter w = new BinaryWriter(fs);
            if (coordinates == null)
                coordinates = new Coordinates(new Angle(0D), new Angle(0D));

            w.Write((short)1); //version

            w.Write(width);
            w.Write(height);

            w.Write(time.Ticks);

            w.Write(maxbits);

            w.Write(coordinates.lat.radians);
            w.Write(coordinates.lon.radians);

            w.Write(coordinates.dec.radians);
            w.Write(coordinates.ra.radians);

            w.Write(fov.radians);

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    w.Write(r[i, j]);
                    w.Write(g[i, j]);
                    w.Write(b[i, j]);
                }

            w.Close();
            fs.Close();
        }

        public static SW_Image FromFile(string fileName)
        {

            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);

            short version = r.ReadInt16();
            int w = r.ReadInt32(); int h = r.ReadInt32();
            DateTime t = new DateTime(r.ReadInt64());
            double m = r.ReadDouble();

            double lat = r.ReadDouble(); double lon = r.ReadDouble();
            Coordinates c = new Coordinates(new Angle(lat), new Angle(lon));
            double dec = r.ReadDouble(); double ra = r.ReadDouble();
            c.setGlobal(new Angle(dec), new Angle(ra), t);
            Angle f = new Angle(r.ReadDouble());

            SW_Image img = new SW_Image(w, h, t, c, f);
            img.maxbits = m;

            for (int i = 0; i < img.width; i++)
                for (int j = 0; j < img.height; j++)
                {
                    img.r[i, j] = r.ReadUInt16();
                    img.g[i, j] = r.ReadUInt16();
                    img.b[i, j] = r.ReadUInt16();
                }
            r.Close();
            fs.Close();

            return img;
        }
    }
}
