using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;
using System.Drawing.Imaging;

using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Controls;

namespace Spacewatch
{
    public partial class mainForm : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        public static mainForm form;

        bool resetArea = true;
        Point newAreaStart;
        public Rectangle areaOfInterest;
        Size fullFrameSize;

        bool integrationready = true;
        private bool processingSnapshot = false;

        public Skymap liveSkymap;
        SkyObject[] filteredStarList;
        private bool identifying;
        bool showLiveSkymap = true;
        bool[] keypressed;
        ViewMode viewMode = ViewMode.Camera;
        double environmentViewZoom = 5;
        private double originalZoom;

        enum ViewMode
        {
            Camera = 0,
            Environment = 1,
        }

        public mainForm()
        {
            InitializeComponent();
            form = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            FrameIntegrator.form = this;
            videoSource = new VideoCaptureDevice();

            TelescopeState.init();
            SkyObjectCollection.init();
            PlanetaryCollection.init();
            TP.init();
            keypressed = new bool[6];
            //updateStarPickerList("");

            //prnt("Welcome to Spacewatch! Current local siderial time: " + Coordinates.siderialize(DateTime.Now, TelescopeState.defaultLong).ToString());

            //prnt("String lengths: Left: " + TelescopeState.l1.ToString() + "cm, Right: " + TelescopeState.l2.ToString() + "cm.");


            foreach (FilterInfo device in videoDevices)
            {
                cameraList.Items.Add(device.Name);
            }

            connectTelescope();
        }

        private async void connectTelescope()
        {
            prnt("Trying to connect to Telescope...");

            if (await TelescopeControl.Connect())
            {
                prnt("Successfully Connected on Port " + ArduinoSerial.serialPort.PortName);
            }
            else
                prnt("Could not connect to telescope.");
        }

        public static void print(string txt)
        {

            form.prnt(txt);
        }

        public void prnt(string txt)
        {
            richTextBox1.Text = txt + "\n" + richTextBox1.Text;
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad7 && !keypressed[0])
            {
                TelescopeControl.startMotor(Motor.Right, MotorDirection.Longer);
                keypressed[0] = true;
            }
            if (e.KeyCode == Keys.NumPad4 && !keypressed[1])
            {
                TelescopeControl.startMotor(Motor.Right, MotorDirection.Shorter);
                keypressed[1] = true;
            }
            if (e.KeyCode == Keys.NumPad8 && !keypressed[2])
            {
                TelescopeControl.startMotor(Motor.Left, MotorDirection.Longer);
                keypressed[2] = true;
            }
            if (e.KeyCode == Keys.NumPad5 && !keypressed[3])
            {
                TelescopeControl.startMotor(Motor.Left, MotorDirection.Shorter);
                keypressed[3] = true;
            }
            if (e.KeyCode == Keys.NumPad9 && !keypressed[4])
            {
                TelescopeControl.startMotor(Motor.Focus, MotorDirection.Longer);
                keypressed[4] = true;
            }
            if (e.KeyCode == Keys.NumPad6 && !keypressed[5])
            {
                TelescopeControl.startMotor(Motor.Focus, MotorDirection.Shorter);
                keypressed[5] = true;
            }

            if (e.KeyCode == Keys.Add)
                zoomIn(2);
            if (e.KeyCode == Keys.Subtract)
                zoomOut(0.5);

            if (e.KeyCode == Keys.NumPad1)
                ArduinoSerial.stepMotor(Motor.Right, MotorDirection.Shorter);
            if (e.KeyCode == Keys.NumPad2)
                ArduinoSerial.stepMotor(Motor.Right, MotorDirection.Longer);
            if (e.KeyCode == Keys.Multiply)
                ArduinoSerial.stepMotor(Motor.Left, MotorDirection.Shorter);
            if (e.KeyCode == Keys.Divide)
                ArduinoSerial.stepMotor(Motor.Left, MotorDirection.Longer);
        }

        private void mainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad7)
            {
                TelescopeControl.stopMotor(Motor.Right, MotorDirection.Longer);
                keypressed[0] = false;
            }
            if (e.KeyCode == Keys.NumPad4)
            {
                TelescopeControl.stopMotor(Motor.Right, MotorDirection.Shorter);
                keypressed[1] = false;
            }
            if (e.KeyCode == Keys.NumPad8)
            {
                TelescopeControl.stopMotor(Motor.Left, MotorDirection.Longer);
                keypressed[2] = false;
            }
            if (e.KeyCode == Keys.NumPad5)
            {
                TelescopeControl.stopMotor(Motor.Left, MotorDirection.Shorter);
                keypressed[3] = false;
            }
            if (e.KeyCode == Keys.NumPad9)
            {
                TelescopeControl.stopMotor(Motor.Focus, MotorDirection.Longer);
                keypressed[4] = false;
            }
            if (e.KeyCode == Keys.NumPad6)
            {
                TelescopeControl.stopMotor(Motor.Focus, MotorDirection.Shorter);
                keypressed[5] = false;
            }
        }

        private void cameraList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
                videoBox.Image = null;
                videoBox.Invalidate();
            }
            videoSource = new VideoCaptureDevice(videoDevices[cameraList.SelectedIndex].MonikerString);
            resetArea = true;
            adaptSettingsToCamera();
            comboBox_configs.Items.Clear();
            foreach (VideoCapabilities cap in videoSource.VideoCapabilities)
            { comboBox_configs.Items.Add(cap.FrameSize.Width + " x " + cap.FrameSize.Height + " (" + cap.MaximumFrameRate + " fps)"); }
            comboBox_configs.SelectedIndex = 0;
            videoSource.NewFrame += videoSource_NewFrame;
            timer_updateDynamicDetail.Enabled = true;
        }

        private void adaptSettingsToCamera()
        {
            int min, max, step, def;
            VideoProcAmpFlags flag;

            //Brightness
            videoSource.GetVideoPropertyRange(VideoProcAmpProperty.Brightness, out min, out max, out step, out def, out flag);
            if (min == max) checkBox_brightness.Checked = false;
            else
            {
                checkBox_brightness.Checked = true;
                trackBar_brightness.Minimum = min; trackBar_brightness.Maximum = max; trackBar_brightness.SmallChange = step;
                videoSource.GetVideoProperty(VideoProcAmpProperty.Brightness, out def, out flag);
                trackBar_brightness.Value = def;
            }

            //Contrast
            videoSource.GetVideoPropertyRange(VideoProcAmpProperty.Contrast, out min, out max, out step, out def, out flag);
            if (min == max) checkBox_contrast.Checked = false;
            else
            {
                checkBox_contrast.Checked = true;
                trackBar_contrast.Minimum = min; trackBar_contrast.Maximum = max; trackBar_contrast.SmallChange = step;
                videoSource.GetVideoProperty(VideoProcAmpProperty.Contrast, out def, out flag);
                trackBar_contrast.Value = def;
            }

            //Saturation
            videoSource.GetVideoPropertyRange(VideoProcAmpProperty.Saturation, out min, out max, out step, out def, out flag);
            if (min == max) checkBox_saturation.Checked = false;
            else
            {
                checkBox_saturation.Checked = true;
                trackBar_saturation.Minimum = min; trackBar_saturation.Maximum = max; trackBar_saturation.SmallChange = step;
                videoSource.GetVideoProperty(VideoProcAmpProperty.Saturation, out def, out flag);
                trackBar_saturation.Value = def;
            }

            CameraControlFlags cflag;
            videoSource.GetCameraPropertyRange(CameraControlProperty.Exposure, out min, out max, out step, out def, out cflag);
            print("Exposure: min: " + min + ", max: " + max + ", step: " + step + ", default: " + def);
            videoSource.SetCameraProperty(CameraControlProperty.Exposure, max, CameraControlFlags.Manual);

            videoSource.GetCameraPropertyRange(CameraControlProperty.Iris, out min, out max, out step, out def, out cflag);
            print("Iris: min: " + min + ", max: " + max + ", step: " + step + ", default: " + def);
            videoSource.SetCameraProperty(CameraControlProperty.Iris, max, CameraControlFlags.Manual);

            videoSource.GetVideoPropertyRange(VideoProcAmpProperty.BacklightCompensation, out min, out max, out step, out def, out flag);
            print("Backlight Compensation: min: " + min + ", max: " + max + ", step: " + step + ", default: " + def);
            videoSource.SetVideoProperty(VideoProcAmpProperty.BacklightCompensation, 0, VideoProcAmpFlags.Manual);
        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            DateTime t1 = DateTime.Now;
            if (resetArea)
            {
                fullFrameSize = eventArgs.Frame.Size;
                areaOfInterest = new Rectangle(new Point(0, 0), fullFrameSize);
                resetArea = false;
                Debug.Print(areaOfInterest.ToString());
            }

            Bitmap image = (Bitmap)eventArgs.Frame.Clone(areaOfInterest, System.Drawing.Imaging.PixelFormat.DontCare);

            if (checkBox_mirrorX.Checked)
            {
                if (checkBox_mirrorY.Checked)

                    image.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                else
                    image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            else if (checkBox_mirrorY.Checked)
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);

            if (processingSnapshot && !TelescopeControl.moving)
            {
                FrameIntegrator.addSnapshotFrame((Bitmap)image.Clone(), checkBox_compMove.Checked);
                FrameIntegrator.sposition++;
                if (FrameIntegrator.sposition >= FrameIntegrator.snapCount)
                {
                    processingSnapshot = false;
                    button_snapshot.Enabled = true;
                    FrameIntegrator.sposition = 0;
                    FrameIntegrator.finishSnapshot();
                }
            }
            drawViewingArea(image);
            int frametime = (DateTime.Now - t1).Milliseconds;
            status_frameTime.Text = "Frame time: " + frametime.ToString() + " ms";
        }

        private void drawViewingArea(Bitmap image)
        {
            switch (viewMode)
            {
                case ViewMode.Camera:
                    if (checkBox_integration.Checked)
                    {
                        if (integrationready)
                        {
                            integrationready = false;
                            FrameIntegrator.addFrame(image);

                            videoBox.Image = addOverlays(FrameIntegrator.getOverlay());
                            integrationready = true;
                        }
                    }
                    else
                    {
                        videoBox.Image = addOverlays(image);
                    }
                    break;
                case ViewMode.Environment:
                    System.Drawing.Image im = liveSkymap.draw(null, schematicBackground: false, names: true, telescope: false, grid: false, dynamicDetail:true);
                    Graphics g = Graphics.FromImage(im);
                    double zr = environmentViewZoom / originalZoom;
                    g.DrawRectangle(Pens.Red, (int)(liveSkymap.width * 0.5 * (1 - zr)), (int)(liveSkymap.height * 0.5 * (1 - zr)), (int)(liveSkymap.width * zr), (int)(liveSkymap.height * zr));
                    videoBox.Image = im;
                    break;
            }
        }

        private System.Drawing.Image addOverlays(System.Drawing.Image frame)
        {
            if (checkBox_histogram.Checked)
            {
                ImageStatistics stats = new ImageStatistics((Bitmap)frame);
                int[] greyValues = new int[stats.Red.Values.Length];
                for (int i = 0; i < greyValues.Length; i++)
                {
                    greyValues[i] += stats.Red.Values[i];
                    greyValues[i] += stats.Green.Values[i];
                    greyValues[i] += stats.Blue.Values[i];
                }
                    histogram.Values = greyValues;
                label7.Text = "Std. Dev: " + ((int)(stats.Blue.StdDev + stats.Red.StdDev + stats.Green.StdDev)).ToString() + "\nMax: " + (stats.Blue.Max + stats.Green.Max + stats.Red.Max).ToString();
            }
            if (showLiveSkymap)
                return liveSkymap.draw(frame, names: true, grid: gridToolStripMenuItem.Checked, dynamicDetail:true);

            else return frame;
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource.IsRunning) videoSource.Stop();
        }

        private void trackBar_brightness_Scroll(object sender, EventArgs e)
        {
            if (checkBox_brightness.Checked)
                videoSource.SetVideoProperty(VideoProcAmpProperty.Brightness, trackBar_brightness.Value, VideoProcAmpFlags.Manual);
        }

        private void trackBar_contrast_Scroll(object sender, EventArgs e)
        {
            if (checkBox_contrast.Checked)
                videoSource.SetVideoProperty(VideoProcAmpProperty.Contrast, trackBar_contrast.Value, VideoProcAmpFlags.Manual);
        }

        private void trackBar_saturation_Scroll(object sender, EventArgs e)
        {
            if (checkBox_saturation.Checked)
                videoSource.SetVideoProperty(VideoProcAmpProperty.Saturation, trackBar_saturation.Value, VideoProcAmpFlags.Manual);
        }

        private void checkBox_brightness_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_brightness.Checked)
            {
                videoSource.SetVideoProperty(VideoProcAmpProperty.Brightness, trackBar_brightness.Value, VideoProcAmpFlags.Manual);
                trackBar_brightness.Enabled = true;
            }
            else
            {
                videoSource.SetVideoProperty(VideoProcAmpProperty.Brightness, trackBar_brightness.Value, VideoProcAmpFlags.Auto);
                trackBar_brightness.Enabled = false;
            }
        }

        private void checkBox_contrast_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_contrast.Checked)
            {
                videoSource.SetVideoProperty(VideoProcAmpProperty.Contrast, trackBar_contrast.Value, VideoProcAmpFlags.Manual);
                trackBar_contrast.Enabled = true;
            }
            else
            {
                videoSource.SetVideoProperty(VideoProcAmpProperty.Contrast, trackBar_contrast.Value, VideoProcAmpFlags.Auto);
                trackBar_contrast.Enabled = false;
            }
        }

        private void checkBox_saturation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_saturation.Checked)
            {
                videoSource.SetVideoProperty(VideoProcAmpProperty.Saturation, trackBar_saturation.Value, VideoProcAmpFlags.Manual);
                trackBar_saturation.Enabled = true;
            }
            else
            {
                videoSource.SetVideoProperty(VideoProcAmpProperty.Saturation, trackBar_saturation.Value, VideoProcAmpFlags.Auto);
                trackBar_saturation.Enabled = false;
            }
        }

        private void videoBox_MouseDown(object sender, MouseEventArgs e)
        {
            newAreaStart = mouseToImageCoords(e.Location);
        }

        private Point mouseToImageCoords(Point cursor)
        {
            Point ret = new Point();
            if (videoBox.Width / (float)videoBox.Height > areaOfInterest.Width / (float)areaOfInterest.Height)
            {
                //Höhe ist passend
                float scale = areaOfInterest.Height / (float)videoBox.Height;
                ret.Y = (int)(cursor.Y * scale);
                ret.X = (int)((cursor.X - (videoBox.Width - areaOfInterest.Width / scale) / 2F) * scale);
            }
            else
            {
                //Breite ist passend
                float scale = areaOfInterest.Width / (float)videoBox.Width;
                ret.X = (int)(cursor.X * scale);
                ret.Y = (int)((cursor.Y - (videoBox.Height - areaOfInterest.Height / scale) / 2F) * scale);
            }
            return new Point(ret.X + areaOfInterest.X, ret.Y + areaOfInterest.Y);
        }

        private void videoBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right) resetArea = true;
            else
            {
                if (identifying)
                {
                    liveSkymap.calibrate(mouseToImageCoords(e.Location), liveSkymap.marker);
                    TelescopeState.setCoords(liveSkymap.centerAzimut, liveSkymap.centerPolar);
                    identifying = false;
                }
                else
                {
                    Size aoi = new Size(mouseToImageCoords(e.Location).X - newAreaStart.X, mouseToImageCoords(e.Location).Y - newAreaStart.Y);
                    if (aoi.Width > 5 && aoi.Height > 5)
                        areaOfInterest = new Rectangle(newAreaStart, aoi);
                    else
                        liveSkymap.placeMarker(liveSkymap.coordinatesFromPoint((PointF)mouseToImageCoords(e.Location)));
                }
            }
        }

        private void checkBox_integration_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_integration.Checked)
            {
                FrameIntegrator.form = this;
                FrameIntegrator.init((int)numericUpDown_integration.Value);
                numericUpDown_integration.Enabled = true;
                numericUpDown_intCorrection.Enabled = true;
            }
            else
            {
                numericUpDown_integration.Enabled = false;
                numericUpDown_intCorrection.Enabled = false;
            }
        }

        private void numericUpDown_integration_ValueChanged(object sender, EventArgs e)
        {
            FrameIntegrator.init((int)numericUpDown_integration.Value);
        }

        private void numericUpDown_intCorrection_ValueChanged(object sender, EventArgs e)
        {
            FrameIntegrator.corection = (float)numericUpDown_intCorrection.Value;
        }

        private void button_snapshot_Click(object sender, EventArgs e)
        {
            FrameIntegrator.sposition = 0;
            processingSnapshot = true;
            button_snapshot.Enabled = false;

            FrameIntegrator.snapCount = (int)numericUpDown_snapshot.Value;
            FrameIntegrator.initSnapshot(videoSource.VideoResolution.FrameSize.Width, videoSource.VideoResolution.FrameSize.Height);
        }

        private void comboBox_configs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoSource.IsRunning)
                videoSource.Stop();
            videoSource.VideoResolution = videoSource.VideoCapabilities[comboBox_configs.SelectedIndex];
            resetArea = true;
            videoSource.Start();
            liveSkymap = new Skymap(TelescopeState.polar, TelescopeState.azimut, SkyObjectCollection.defaultCollection,
                1,
                videoSource.VideoResolution.FrameSize.Width, videoSource.VideoResolution.FrameSize.Height);
            liveSkymap.setFOV(TP.fov);
            updateStarPickerList("");
            timer_updateDynamicDetail.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connectTelescope();
        }

        private void button_imgedit_Click(object sender, EventArgs e)
        {
            ImageEditor imgEdit = new ImageEditor();
            imgEdit.Show();
            imgEdit.setImage(FrameIntegrator.snapshotImage);
        }

        private void button_open_skymap_Click(object sender, EventArgs e)
        {
            Starmap starmap = new Starmap();
            starmap.Show();
        }

        private async void button_goto_Click(object sender, EventArgs e)
        {
            Coordinates c = new Coordinates(TelescopeState.coordinates.lat, TelescopeState.coordinates.lon);
            c.setGlobal(angleInput_dec.getAngle(), angleInput_ra.getAngle(), DateTime.Now);
            button_goto.Text = "Moving...";
            await TelescopeControl.goToIterated(c, TP.defaultStepSize);
            button_goto.Text = "Go To";
        }


        internal static void OnTelescopeMoved()
        {
            form.angleInput_dec.setAngle(TelescopeState.coordinates.dec);
            form.angleInput_ra.setAngle(TelescopeState.coordinates.ra);
            if (form.liveSkymap != null)
            {
                form.liveSkymap.centerAzimut = new Angle(TelescopeState.coordinates.azimut.radians);
                form.liveSkymap.centerPolar = new Angle(TelescopeState.coordinates.polar.radians);
            }
           mainForm.print("String lengths: Left: " + TelescopeState.l1.ToString() + "cm, Right: " + TelescopeState.l2.ToString() + "cm.");
        }

        private void button_set_telescope_Click(object sender, EventArgs e)
        {
            Coordinates c = new Coordinates(TelescopeState.defaultLat, TelescopeState.defaultLong);
            c.setGlobal(angleInput_dec.getAngle(), angleInput_ra.getAngle(), DateTime.Now);
            liveSkymap.placeMarker(c);
        }

        private void comboBox_starPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            angleInput_dec.setAngle(filteredStarList[comboBox_starPicker.SelectedIndex].coordinates.dec);
            angleInput_ra.setAngle(filteredStarList[comboBox_starPicker.SelectedIndex].coordinates.ra);
        }

        private void updateStarPickerList(string filter)
        {
            filteredStarList = liveSkymap.objectCollection.getFilteredList(filter);
            comboBox_starPicker.Items.Clear();
            foreach (SkyObject o in filteredStarList)
            {
                comboBox_starPicker.Items.Add(o.name);
            }
        }

        private void comboBox_starPicker_TextUpdate(object sender, EventArgs e)
        {
            updateStarPickerList(comboBox_starPicker.Text);
            comboBox_starPicker.Select(comboBox_starPicker.Text.Length, 0);
        }

        private void comboBox_starPicker_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void videoBox_MouseMove(object sender, MouseEventArgs e)
        {
            updateStatusBar(e.Location);
        }

        private void updateStatusBar(Point mouseLocation)
        {
            statusLabel_telescope.Text = ArduinoSerial.connected ? "Telescope: Connected!" : "Telescope: Not Connected";
            if (liveSkymap != null)
                statusLabel_mouseCoords.Text = "Mouse Coordinates: " + liveSkymap.coordinatesFromPoint((PointF)mouseToImageCoords(mouseLocation)).ToString();
        }

        private async void navigateToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await TelescopeControl.goToIterated(liveSkymap.marker.clone(), TP.defaultStepSize);
        }

        private void calibrateToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            liveSkymap.marker.updateLocal(DateTime.Now);
            TelescopeState.setCoords(liveSkymap.marker.azimut.clone(), liveSkymap.marker.polar.clone());
        }

        private void button_identify_Click(object sender, EventArgs e)
        {
            identifying = true;
        }

        private void identifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            identifying = true;
        }

        private void showToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            showLiveSkymap = showToolStripMenuItem.Checked;
        }

        public static void initiateProgress(int increments)
        {
            form.toolStripProgressBar1.Maximum = increments;
            form.toolStripProgressBar1.Value = 0;
        }

        public static void increaseProgress()
        {
            if (form.toolStripProgressBar1.Value < form.toolStripProgressBar1.Maximum)
                form.toolStripProgressBar1.Value++;
        }

        private void sestdjkfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelescopeStateDialog.ShowDialog();
        }

        private void checkBox_follow_CheckedChanged(object sender, EventArgs e)
        {
            timer_follow.Enabled = checkBox_follow.Checked;
        }

        private void timer_follow_Tick(object sender, EventArgs e)
        {
            button_goto_Click(sender, e);
        }

        private void timer_loop_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel_moving.Text = TelescopeControl.moving ? "Moving!" : "Idle";
            toolStripStatusLabel_moving.ForeColor = TelescopeControl.moving ? Color.Red : Color.Black;
        }

        private void checkBox_histogram_CheckedChanged(object sender, EventArgs e)
        {
            label7.Visible = checkBox_histogram.Checked; 
            histogram.Visible = checkBox_histogram.Checked;
        }

        //helper function from http://stackoverflow.com/questions/2265910/convert-an-image-to-grayscale
        public static Bitmap MakeGrayscale3(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][] 
                  {
                     new float[] {.3f, .3f, .3f, 0, 0},
                     new float[] {.59f, .59f, .59f, 0, 0},
                     new float[] {.11f, .11f, .11f, 0, 0},
                     new float[] {0, 0, 0, 1, 0},
                     new float[] {0, 0, 0, 0, 1}
                  });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }

        private void checkBox_histLog_CheckedChanged(object sender, EventArgs e)
        {
            histogram.IsLogarithmicView = checkBox_histLog.Checked;
        }

        private void button_zoomOut_Click(object sender, EventArgs e)
        {
            zoomOut(0.5);
        }

        private void button_zoomIn_Click(object sender, EventArgs e)
        {
            zoomIn(2);
        }

        private void setEnvironmentViewZoom(double z)
        {
            environmentViewZoom = z;
            liveSkymap.setZoom(z);
        }

        private void changeViewMode()
        {
            if (liveSkymap != null)
            {
                if (viewMode == ViewMode.Camera)
                {
                    viewMode = ViewMode.Environment;
                    originalZoom = liveSkymap.zoom;
                }
                else
                {
                    viewMode = ViewMode.Camera;
                    liveSkymap.setZoom(originalZoom);
                }
            }
        }

        private void zoomOut(double incr = 0.8)
        {
            if (viewMode == ViewMode.Camera)
            {
                changeViewMode();
                setEnvironmentViewZoom(incr * originalZoom);
            }
            else
            {
                setEnvironmentViewZoom((incr * environmentViewZoom <= 1) ? 1 : incr * environmentViewZoom);
            }
        }
        private void zoomIn(double fac = 1.25)
        {
            if(viewMode == ViewMode.Environment)
            {
                if (environmentViewZoom * fac >= originalZoom)
                    changeViewMode();
                else
                {
                    setEnvironmentViewZoom(fac * environmentViewZoom);
                }
            }
        }

        private void videoBox_MouseEnter(object sender, EventArgs e)
        {
           if(this.Focused) videoBox.Focus();
        }

        private void videoBox_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            double delta = Math.Abs(e.Delta / 120);
            if (e.Delta > 0) zoomIn(Math.Pow(1.25, delta)); else zoomOut(Math.Pow(0.8, delta));
        }

        private void timer_updateDynamicDetail_Tick(object sender, EventArgs e)
        {
            if (liveSkymap != null)
                liveSkymap.updateDynamicDetail();
        }

        private void recalculateStringLengthsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelescopeState.updateStringLengths();
            OnTelescopeMoved();
        }

        private void button_openControlPanel_Click(object sender, EventArgs e)
        {
            ControlPanel controlPanel = new ControlPanel();
            controlPanel.Show();
        }
    }

    public static class TP //Telescope Properties
    {
        public static int pinRightLonger = 2;
        public static int pinRightShorter = 3;
        public static int pinLeftLonger = 5;
        public static int pinLeftShorter = 4;
        public static int pinFocusLonger = 6;
        public static int pinFocusShorter = 7;

        public static double speedShorter = 0.0737/2; //cm per sec
        public static double speedLonger = 0.757/2;
        public static double motorStepSize = 0.03; //0.0283//cm

        public static double r1x = 34.0; //cm
        public static double r1y = 0.0;
        public static double r1z = 9.0;
        public static double r2z = 30.0;
        public static double r3y = 8.0;
        public static double r3z = 7.0;
        public static double r4y = 20.6;
        public static double r4z = -5.8;

        public static double ax = 34.0;
        public static double az = 28.5;
        public static double a = 22.0;

        public static Angle fov;
        public static Angle anglePrecision;
        public static Angle defaultStepSize;

        public static void init()
        {
            fov = new Angle(true, 0, 9, 41.5);
            anglePrecision = new Angle(true, 0, 1, 0);
            defaultStepSize = new Angle(true, 1, 0, 0);
        }

        public static double getSpeed(MotorDirection direction)
        {
            if (direction == MotorDirection.Longer)
                return speedLonger;
            else return speedShorter;
        }

        public static int getPin(Motor motor, MotorDirection direction)
        {
            switch (motor)
            {       
                case Motor.Left:
                    if (direction == MotorDirection.Longer)
                        return pinLeftLonger;
                    else
                        return pinLeftShorter;

                case Motor.Right:
                if (direction == MotorDirection.Longer)
                    return pinRightLonger;
                else
                    return pinRightShorter;

                case Motor.Focus:
                if (direction == MotorDirection.Longer)
                    return pinFocusLonger;
                else
                    return pinFocusShorter;
            }
            return 0;
        }
        public static int getOtherPin(Motor motor, MotorDirection direction)
        {
            switch (motor)
            {
                case Motor.Left:
                    if (direction == MotorDirection.Shorter)
                        return pinLeftLonger;
                    else
                        return pinLeftShorter;

                case Motor.Right:
                    if (direction == MotorDirection.Shorter)
                        return pinRightLonger;
                    else
                        return pinRightShorter;

                case Motor.Focus:
                    if (direction == MotorDirection.Shorter)
                        return pinFocusLonger;
                    else
                        return pinFocusShorter;
            }
            return 0;
        }

    }

    public static class TelescopeState
    {
        public static Angle defaultLat, defaultLong;
        public static Coordinates coordinates;
        public static Angle azimut, polar;
        public static double l1, l2;

        public static void init()
        {
            defaultLat = new Angle(true, d: 53, am: 28, asc: 0.5D);
            defaultLong = new Angle(true, d: 9, am: 52, asc: 34.5D);

            try
            {
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "telescope_state.txt"))
                {
                    FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "telescope_state.txt", FileMode.Open, FileAccess.Read);
                    StreamReader r = new StreamReader(fs);

                    int version = Convert.ToInt32(r.ReadLine());
                    switch (version)
                    {
                        case 1:
                            Angle lat = new Angle(Convert.ToDouble(r.ReadLine()));
                            Angle lon = new Angle(Convert.ToDouble(r.ReadLine()));
                            Angle phi = new Angle(Convert.ToDouble(r.ReadLine()));
                            Angle the = new Angle(Convert.ToDouble(r.ReadLine()));

                            coordinates = new Coordinates(lat, lon);
                            azimut = phi;
                            polar = the;
                            updateCoords();
                            updateStringLengths();

                            l1 = Convert.ToDouble(r.ReadLine());
                            l2 = Convert.ToDouble(r.ReadLine());
                            break;
                    }

                    r.Close();
                    fs.Close();
                }
                else
                {
                    coordinates = new Coordinates(defaultLat, defaultLong);
                    setCoords(new Angle(true, 0, 0, 0), new Angle(true, 0, 0, 0));
                }
            }
            catch
            {
                coordinates = new Coordinates(defaultLat, defaultLong);
                setCoords(new Angle(true, 0, 0, 0), new Angle(true, 0, 0, 0));
            }
            mainForm.OnTelescopeMoved();
        }

        public static void saveFile()
        {
            FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "telescope_state.txt", FileMode.Create);
            StreamWriter w = new StreamWriter(fs);

            w.WriteLine("1");

            w.WriteLine(coordinates.lat.radians.ToString());
            w.WriteLine(coordinates.lon.radians.ToString());
            w.WriteLine(coordinates.azimut.radians.ToString());
            w.WriteLine(coordinates.polar.radians.ToString());

            w.WriteLine(l1.ToString());
            w.WriteLine(l2.ToString());

            w.Close();
            fs.Close();
        }

        public static void setCoords(Angle azi, Angle pol)
        {
            azimut = azi;
            polar = pol;
            updateCoords();
            updateStringLengths();
            saveFile();
            //mainForm.print("Telescope moved to " + coordinates.ToString());
            mainForm.OnTelescopeMoved();
        }

        public static void updateCoords()
        {
            coordinates.setLocal(azimut, polar, DateTime.Now);
        }

        public static void updateStringLengths()
        {
            l1 = coordinates.getStringLengths(left: true);
            l2 = coordinates.getStringLengths(left: false);
        }

        public static void setStringLengths(double left, double right)
        {
            coordinates = Coordinates.FromStringLengths(left, right, coordinates.lat, coordinates.lon, DateTime.Now);
        }
    }

    public static class TelescopeControl
    {
        static int queuePosition = 1;
        static int highestQueuePosition = 0;
        public static bool moving = false;

        static async Task waitTillReady(int thisQueuePos)
        {
            while (thisQueuePos > queuePosition)
                await Task.Delay(10);
        }

        public static async Task<bool> Connect()
        {
            if (await ArduinoSerial.Connect())
            {
                ArduinoSerial.setPinMode(TP.pinRightShorter, PinMode.OUTPUT);
                ArduinoSerial.setPinMode(TP.pinRightLonger, PinMode.OUTPUT);
                ArduinoSerial.setPinMode(TP.pinLeftShorter, PinMode.OUTPUT);
                ArduinoSerial.setPinMode(TP.pinLeftLonger, PinMode.OUTPUT);
                ArduinoSerial.setPinMode(TP.pinFocusShorter, PinMode.OUTPUT);
                ArduinoSerial.setPinMode(TP.pinFocusLonger, PinMode.OUTPUT);
                return true;
            }
            else
                return false;
        }

        static async void runMotor(int pin, int otherpin, int duration)
        {
            startMotor(pin, otherpin);
            await Task.Delay(duration);
            stopMotor(pin, otherpin);
        }
        public static void runMotor(Motor motor, MotorDirection direction, int duration) { runMotor(TP.getPin(motor, direction), TP.getOtherPin(motor, direction), duration); }

        static void startMotor(int pin, int otherpin) { ArduinoSerial.setPinOutput(otherpin, PinVoltage.LOW); ArduinoSerial.setPinOutput(pin, PinVoltage.HIGH); }
        public static void startMotor(Motor motor, MotorDirection direction) { startMotor(TP.getPin(motor, direction), TP.getOtherPin(motor, direction)); }

        static void stopMotor(int pin, int otherpin) { ArduinoSerial.setPinOutput(otherpin, PinVoltage.LOW); ArduinoSerial.setPinOutput(pin, PinVoltage.LOW); }
        public static void stopMotor(Motor motor, MotorDirection direction) { stopMotor(TP.getPin(motor, direction), TP.getOtherPin(motor, direction)); }

        static async Task goToTIME(Coordinates coords)
        {
            moving = true;
            coords.updateLocal(DateTime.Now);
            double diffl = coords.getStringLengths(true) - TelescopeState.l1;
            double diffr = coords.getStringLengths(false) - TelescopeState.l2;

            MotorDirection dirl = diffl > 0 ? MotorDirection.Longer : MotorDirection.Shorter;
            MotorDirection dirr = diffr > 0 ? MotorDirection.Longer : MotorDirection.Shorter;
            

            int timel = (int)(1000d * Math.Abs(diffl) / TP.getSpeed(dirl));
            int timer = (int)(1000d * Math.Abs(diffr) / TP.getSpeed(dirr));

            if (timel > 10)
                runMotor((dirl == MotorDirection.Longer) ? TP.pinLeftLonger : TP.pinLeftShorter,
                    (dirl == MotorDirection.Shorter) ? TP.pinLeftLonger : TP.pinLeftShorter,
                    timel);
            if (timer > 10)
                runMotor((dirr == MotorDirection.Longer) ? TP.pinRightLonger : TP.pinRightShorter,
                    (dirr == MotorDirection.Shorter) ? TP.pinRightLonger : TP.pinRightShorter,
                    timer);

            await Task.Delay(Math.Max(timel, timer) + 10);

            TelescopeState.setCoords(coords.azimut.clone(), coords.polar.clone());
            moving = false;
        }
        public static async Task goToIteratedTIME(Coordinates coords, Angle stepSize)
        {
            highestQueuePosition++;
            int thisQueuePos = highestQueuePosition;
            await waitTillReady(thisQueuePos);

            mainForm.form.liveSkymap.makePath(coords, stepSize);
            mainForm.initiateProgress((int)(CoordinateManager.distance2D(TelescopeState.coordinates, coords).radians / TP.anglePrecision.radians));

            while (CoordinateManager.distance2D(TelescopeState.coordinates, coords).radians > TP.anglePrecision.radians)
            {
                TelescopeState.updateCoords();
                coords.updateLocal(DateTime.Now);

                mainForm.form.liveSkymap.makePath(coords, stepSize);

                Coordinates target = CoordinateManager.stepTowards(TelescopeState.coordinates, coords, stepSize, DateTime.Now);

                await goToTIME(target);
                await Task.Delay(50);
                mainForm.increaseProgress();
            }

            mainForm.form.liveSkymap.clearPath();

            queuePosition++;
        }

        static async Task goTo(Coordinates coords)
        {
            moving = true;
            coords.updateLocal(DateTime.Now);
            double diffl = coords.getStringLengths(true) - TelescopeState.l1;
            double diffr = coords.getStringLengths(false) - TelescopeState.l2;

            MotorDirection dirl = diffl > 0 ? MotorDirection.Longer : MotorDirection.Shorter;
            MotorDirection dirr = diffr > 0 ? MotorDirection.Longer : MotorDirection.Shorter;


            int stepl = (int)Math.Round( Math.Abs(diffl) / TP.motorStepSize);
            int stepr = (int)Math.Round( Math.Abs(diffr) / TP.motorStepSize);

            double newL1 = TelescopeState.l1 + stepl * TP.motorStepSize * ((diffl > 0) ? 1 : -1);
            double newL2 = TelescopeState.l2 + stepr * TP.motorStepSize * ((diffr > 0) ? 1 : -1);

            while(stepl > 0 || stepr>0)
            {
                if (stepl > 0)
                { await ArduinoSerial.stepMotor(Motor.Left, dirl); stepl--; }
                if (stepr > 0)
                { await ArduinoSerial.stepMotor(Motor.Right, dirr); stepr--; }
            }

            await Task.Delay(10);

            TelescopeState.setCoords(coords.azimut.clone(), coords.polar.clone());
            TelescopeState.l1 = newL1;
            TelescopeState.l2 = newL2;
            moving = false;
        }
        public static async Task goToIterated(Coordinates coords, Angle stepSize)
        {
            highestQueuePosition++;
            int thisQueuePos = highestQueuePosition;
            await waitTillReady(thisQueuePos);

            mainForm.form.liveSkymap.makePath(coords, stepSize);
            mainForm.initiateProgress((int)(CoordinateManager.distance2D(TelescopeState.coordinates, coords).radians / TP.anglePrecision.radians));

            while (CoordinateManager.distance2D(TelescopeState.coordinates, coords).radians > TP.anglePrecision.radians)
            {
                TelescopeState.updateCoords();
                coords.updateLocal(DateTime.Now);

                mainForm.form.liveSkymap.makePath(coords, stepSize);

                Coordinates target = CoordinateManager.stepTowards(TelescopeState.coordinates, coords, stepSize, DateTime.Now);

                await goTo(target);
                await Task.Delay(50);
                mainForm.increaseProgress();
            }

            mainForm.form.liveSkymap.clearPath();

            queuePosition++;
        }
    }

    public class FrameIntegrator
    {
        static Bitmap[] frames;
        public static mainForm form;
        public static int position, sposition, snapCount;
        public static float corection = 1.0F;
        public static SW_Image snapshotImage;

        public static void init(int framecount)
        {
            frames = new Bitmap[framecount];
            position = 0;
        }

        public static void addFrame(Bitmap newframe)
        {
            frames[position] = newframe;
            position++;
            if (position >= frames.Length) position = 0;
        }

        public static Bitmap getOverlay()
        {
            Bitmap output = new Bitmap(form.areaOfInterest.Width, form.areaOfInterest.Height);
            float factor = corection / frames.Length;

            for (int i = 0; i < output.Width; i++)
                for (int j = 0; j < output.Height; j++)
                {
                    int r = 0, g = 0, b = 0;
                    foreach (Bitmap frame in frames)
                        if (frame != null)
                        {
                            Color framepix = frame.GetPixel(i,j);
                            r += framepix.R;
                            g += framepix.G;
                            b += framepix.B;
                        }
                    r = (int)(r * factor);
                    g = (int)(g * factor);
                    b = (int)(b * factor);
                    output.SetPixel(i, j, Color.FromArgb((255 < r) ? 255 : r, (255 < g) ? 255 : g, (255 < b) ? 255 : b));
                }
            return output;
        }

        public static void initSnapshot(int width, int height)
        {
            snapshotImage = new SW_Image(width, height,new DateTime( DateTime.Now.Ticks), TelescopeState.coordinates.clone(), TP.fov);
            mainForm.initiateProgress(snapCount);
        }

        public static void addSnapshotFrame(Bitmap frame, bool movementCorection = false)
        {
            snapshotImage.addBitmap(frame, movementCorection);
            mainForm.increaseProgress();
        }
        
        public static void finishSnapshot()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\spacewatch";
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            string filename = folder + "\\snapshot " + snapshotImage.time.ToString().Replace('.', '-').Replace(':', '-');
            snapshotImage.saveRaw(filename + ".swi");
            snapshotImage.getDefaultBitmap(overlay:true).Save(filename + ".jpg");
        }
    }

    public class ArduinoSerial
    {
        public static bool connected = false;
        static int queuePosition = 1;
        static int highestQueuePosition = 0;

        static async Task waitTillReady(int thisQueuePos)
        {
            while (thisQueuePos > queuePosition)
                await Task.Delay(10);
            await Task.Delay(10);
        }

        public static SerialPort serialPort;

        public static async Task<bool> Connect()
        {
            try
            {
                if (serialPort != null) serialPort.Close();
                string[] portNames = SerialPort.GetPortNames();

                foreach (string portName in portNames)
                {
                    serialPort = new SerialPort(portName, 9600);
                    serialPort.DtrEnable = true;

                    serialPort.Open();
                    serialPort.DtrEnable = true;
                    byte[] buff = new byte[1]; buff[0] = 0;
                    serialPort.Write(buff, 0, 1);
                    Debug.WriteLine("Trying to connect on Port " + portName + ". Waiting for Response...");
                    await Task.Delay(100);
                    if (serialPort.BytesToRead > 0)
                    {
                        if (serialPort.ReadByte() == 42)
                        {
                            Debug.WriteLine("Found Arduino!");
                            connected = true;
                            return true;
                        }
                    }
                    else
                        Debug.WriteLine("No response.");
                }
                return false;
            }
            catch { return false; }
        }

        public static void setPinMode(int pin, PinMode pinMode)
        {
            if (!connected) return;
            int message = 1 + pin;
            if (pinMode == PinMode.OUTPUT) message += 14;
            byte[] buff = new byte[1]; buff[0] = Convert.ToByte(message);
            serialPort.Write(buff, 0, 1);
        }

        public static async Task<PinVoltage> readPinInput(int pin)
        {
            if (!connected) return PinVoltage.LOW;
            highestQueuePosition++;
            int thisQueuePos = highestQueuePosition;
            await waitTillReady(thisQueuePos);

            int message = 29 + pin;
            byte[] buff = new byte[1]; buff[0] = Convert.ToByte(message);
            serialPort.Write(buff, 0, 1);
            while (serialPort.BytesToRead == 0)
                await Task.Delay(10);

            int response = Convert.ToInt32(serialPort.ReadByte());
            queuePosition++;
            if (response < 14) return PinVoltage.LOW;
            else
                return PinVoltage.HIGH;
        }

        public static async void setPinOutput(int pin, PinVoltage pinOutput)
        {
            if (!connected) return;

            highestQueuePosition++;
            int thisQueuePos = highestQueuePosition;
            await waitTillReady(thisQueuePos);

            int message = 43 + pin;
            if (pinOutput == PinVoltage.HIGH) message += 14;
            byte[] buff = new byte[1]; buff[0] = Convert.ToByte(message);
            try
            {
                serialPort.Write(buff, 0, 1);
            }
            catch
            {
                mainForm.print("Exception while trying to move!");
            }

            queuePosition++;
        }

        public static async Task stepMotor(Motor motor, MotorDirection direction)
        {
            if (!connected) return;

            highestQueuePosition++;
            int thisQueuePos = highestQueuePosition;
            await waitTillReady(thisQueuePos);

            int message = 79;
            switch(motor)
            {
                case Motor.Left:
                    switch(direction)
                    {
                        case MotorDirection.Longer:
                            message = 82;
                            break;
                        case MotorDirection.Shorter:
                            message = 81;
                            break;
                    }
                    break;
                    case Motor.Right:
                    switch(direction)
                    {
                        case MotorDirection.Longer:
                            message = 79;
                            break;
                        case MotorDirection.Shorter:
                            message = 80;
                            break;
                    }
                    break;
            }
            byte[] buff = new byte[1]; buff[0] = Convert.ToByte(message);
            try
            {
                serialPort.Write(buff, 0, 1);
            }
            catch
            {
                mainForm.print("Exception while trying to move!");
            }

            while (serialPort.BytesToRead == 0)
            { await Task.Delay(10); }
            serialPort.ReadByte();

            queuePosition++;
        }

        public static void addServo(int pin)
        {
            if (!connected) return;
            byte[] buff = new byte[2]; buff[0] = 71; buff[1] = Convert.ToByte(pin);
            serialPort.Write(buff, 0, 2);
        }

        public static void setServo(int pin, int value)
        {
            if (!connected) return;
            byte[] buff = new byte[3]; buff[0] = 72; buff[1] = Convert.ToByte(pin); buff[2] = Convert.ToByte(value);
            serialPort.Write(buff, 0, 3);
        }

        public static async Task<int> readAnalog(int pin)
        {
            if (!connected) return -1;
            highestQueuePosition++;
            int thisQueuePos = highestQueuePosition;
            await waitTillReady(thisQueuePos);

            int message = 73 + pin;
            byte[] buff = new byte[1]; buff[0] = Convert.ToByte(message);
            serialPort.Write(buff, 0, 1);
            int i = 0;
            while (serialPort.BytesToRead == 0 && i <= 100)
            { await Task.Delay(10); i++; }

            Debug.WriteLine("reading Analog. Waited " + (float)i / 100f + " seconds for response.");

            queuePosition++;

            if (i >= 100) return -1;

            int response = Convert.ToInt32(serialPort.ReadByte()) * 10 + Convert.ToInt32(serialPort.ReadByte());

            return response;
        }

        public static void Disconnect()
        {
            serialPort.Close();
            connected = false;
        }
    }

    public enum PinMode
    {
        INPUT = 0,
        OUTPUT = 1
    }
    public enum PinVoltage
    {
        LOW = 0,
        HIGH = 1
    }
    public enum Motor
    {
        Left = 0,
        Right = 1, 
        Focus = 2
    }
    public enum MotorDirection
    {
        Longer = 0,
        Shorter = 1
    }
}
