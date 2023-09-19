using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Spacewatch
{
    public abstract class BrightnessCurve
    {
        public double floor, top, param;

        public string name;

        public abstract BrightnessCurve clone();

        public abstract int getValue(double inBrightness);

        public void setCurve(double min, double max, double coef) { floor = min; top = max; param = coef; }

        public Image getVisual (int width, int height)
        {
            int res = 50;
            Bitmap bmp = new Bitmap(width, height);

            Graphics g = Graphics.FromImage(bmp);

            for (int i = 0; i < res; i++ )
            {
                g.DrawLine(Pens.Black, x1: (i * width) / res,
                    y1: height-1 - getValue((double)i / (double)res) * height / 256,
                    x2: ((i + 1) * width) / res,
                    y2: height-1-  getValue((double)(i + 1) / (double)res) * height / 256);
            }

            return bmp;
        }
    }

    public class BrightnessCurveLinear : BrightnessCurve
    {
        public static BrightnessCurveLinear defaultCurve;

        static BrightnessCurveLinear()
        {
            defaultCurve = new BrightnessCurveLinear();
            defaultCurve.setCurve(0d, 1d, 0D);
        }

        public override BrightnessCurve clone()
        {
            BrightnessCurve c = new BrightnessCurveLinear();
            c.name = name;
            c.setCurve(floor, top, param);
            return c;
        }

        public override int getValue(double inBrightness)
        {
            if (inBrightness <= floor) return 0;
            if (inBrightness >= top) return 255;

            return (int)Math.Floor(256D * (inBrightness - floor) / (top - floor));
        }
    }

    public class BrightnessCurveRoot : BrightnessCurve
    {
        public static BrightnessCurveRoot defaultCurve;

        static BrightnessCurveRoot()
        {
            defaultCurve = new BrightnessCurveRoot();
            defaultCurve.setCurve(0d, 1d, 0D);
        }

        public override BrightnessCurve clone()
        {
            BrightnessCurve c = new BrightnessCurveRoot();
            c.name = name;
            c.setCurve(floor, top, param);
            return c;
        }

        public override int getValue(double inBrightness)
        {
            if (inBrightness <= floor) return 0;
            if (inBrightness >= top) return 255;

            return (int)Math.Floor(256D * Math.Sqrt((inBrightness - floor) / (top - floor)));
        }
    }

    public class BrightnessCurveExponential : BrightnessCurve
    {
        public static BrightnessCurveExponential defaultCurve;

        static BrightnessCurveExponential()
        {
            defaultCurve = new BrightnessCurveExponential();
            defaultCurve.setCurve(0d, 1d, 0D);
        }

        public override BrightnessCurve clone()
        {
            BrightnessCurve c = new BrightnessCurveExponential();
            c.name = name;
            c.setCurve(floor, top, param);
            return c;
        }

        public override int getValue(double inBrightness)
        {
            if (inBrightness <= floor) return 0;
            if (inBrightness >= top) return 255;

            return (int)Math.Floor(256D * (Math.Exp(-(inBrightness - floor) / (top - floor) / (param + 0.01)) - 1.0) / (Math.Exp(-1.0 / (param + 0.01)) - 1.0));
        }
    }

    public class BrightnessCurveLog : BrightnessCurve
    {
        public static BrightnessCurveLog defaultCurve;

        static BrightnessCurveLog()
        {
            defaultCurve = new BrightnessCurveLog();
            defaultCurve.setCurve(0d, 1d, 0D);
        }

        public override BrightnessCurve clone()
        {
            BrightnessCurve c = new BrightnessCurveLog();
            c.name = name;
            c.setCurve(floor, top, param);
            return c;
        }

        public override int getValue(double inBrightness)
        {
            if (inBrightness <= floor) return 0;
            if (inBrightness >= top) return 255;

            return (int)Math.Floor(256D / Math.Log(2D / (param + 0.01)) * Math.Log(((inBrightness - floor) / (top - floor) + 1.0) / (param + 0.01)));
        }
    }
}
