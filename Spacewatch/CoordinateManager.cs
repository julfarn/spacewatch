using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;


namespace Spacewatch
{
    public class Angle
    {
        public double radians;
        public double absradians;
        public int sign = 1;
        
        public int deg, amin;
        public double asec;

        public int h, min;
        public double sec;

        public Angle (double r) { set(r:r); }
        public Angle(bool degrees, int d, int am, double asc) { if (degrees) set(d: d, am: am, asc: asc); else seth(d, am, asc); }

        public void set(double r)
        {
            if (r > 2 * Math.PI) r -= 2*Math.PI;
            
            radians = r; absradians = Math.Abs(radians); sign = Math.Sign(radians); if (sign == 0) sign = 1;

            deg = (int)Math.Floor(absradians / Math.PI * 180D);
            amin = (int)Math.Floor((absradians / Math.PI * 180D - deg) * 60D);
            asec = (((absradians / Math.PI * 180D - deg) * 60D) - amin) * 60D;

            h = (int)Math.Floor(absradians * 12D / Math.PI);
            min = (int)Math.Floor((absradians * 12D / Math.PI - h) * 60D);
            sec = (((absradians * 12D / Math.PI - h) * 60D) - min) * 60D;
        }

        public void set(int d, int am, double asc, int sig = 1)
        {
            deg = d; amin = am; asec = asc; sign = sig;

            radians = sign*(deg + amin / 60D + asec / 3600D) / 180D * Math.PI;
            absradians = Math.Abs(radians);

            h = (int)Math.Floor(absradians * 12D / Math.PI);
            min = (int)Math.Floor((absradians * 12D / Math.PI - h) * 60D);
            sec = (((absradians * 12D / Math.PI - h) * 60D) - min) * 60D;            
        }

        public void seth(int hours, int m, double s, int sig = 1)
        {
            h = hours; min = m; sec = s; sign = sig;

            radians = sign * (h + min / 60D + sec / 3600D) / 12D * Math.PI;
            absradians = Math.Abs(radians);

            deg = (int)Math.Floor(absradians / Math.PI * 180D);
            amin = (int)Math.Floor((absradians / Math.PI * 180D - deg) * 60D);
            asec = (((absradians / Math.PI * 180D - deg) * 60D) - amin) * 60D;
        }

        public static Angle operator +(Angle a1, Angle a2) 
        {
           return new Angle(r: a1.radians + a2.radians);
        }

        public static Angle operator -(Angle a1, Angle a2) 
        {
           return new Angle(r: a1.radians - a2.radians);
        }

        public Angle clone() { return new Angle(radians); }

        public override string ToString() { return deg.ToString() + "°" + amin.ToString() + "´" + asec.ToString() + "´´; " + h.ToString() + "h" + min.ToString() + "m" + sec.ToString() + "s"; }
    }

    public class Coordinates
    {
        public Angle dec, ra, azimut, polar, lat, lon;

        public Coordinates(Angle latitude, Angle longitude)
        {
            dec = new Angle(0D);
            ra = new Angle(0D);
            azimut = new Angle(0D);
            polar = new Angle(0D);
            lat = new Angle(latitude.radians); 
            lon = new Angle(longitude.radians);
        }

        public override string ToString()
        {
            return "dec: " + dec.deg.ToString() + "°" + dec.amin.ToString() + "m" + ((int)dec.asec).ToString() + 
                "s, ra: " + ra.h.ToString() + "h" + ra.min.ToString() + "m" + ((int)ra.sec).ToString() + 
                "s, polar:" + polar.deg.ToString() + "°" + polar.amin.ToString() + "m" + ((int)polar.asec).ToString() + 
                "s, azimut: " + azimut.h.ToString() + "h" + azimut.min.ToString() + "m" + ((int)azimut.sec).ToString() + "s.";
        }

        public void setGlobal(Angle d, Angle r, DateTime time)
        {
            dec.set(d.radians);
            ra.set(r.radians);
            updateLocal(time);
        }

        public double getStringLengths(bool left)
        {
            double a = TP.r1z - TP.r2z - TP.r3z * Math.Cos(polar.radians) + TP.r4y * Math.Sin(polar.radians);
            double b = TP.r1y - Math.Cos(azimut.radians) * (TP.r3y + TP.r4y * Math.Cos(polar.radians) + TP.r4z * Math.Sin(polar.radians));
            double c = (!left) ? 
                TP.r1x + (TP.r3y + TP.r4y * Math.Cos(polar.radians) + TP.r4z * Math.Sin(polar.radians)) * Math.Sin(azimut.radians)
                : -TP.r1x + (TP.r3y + TP.r4y * Math.Cos(polar.radians) + TP.r4z * Math.Sin(polar.radians)) * Math.Sin(azimut.radians);
            return Math.Sqrt(a * a + b * b + c * c);
        }

        public static Coordinates FromStringLengths(double b, double c, Angle latitude, Angle longitude, DateTime time)
        {
            throw new Exception("Currently broken.");
            Coordinates coords = new Coordinates(latitude, longitude);

            double a2 = Math.Pow(TP.a, 2.0);
            double ax2 = Math.Pow(TP.ax, 2.0);
            double az2 = Math.Pow(TP.az, 2.0);
            double b2 = Math.Pow(b, 2.0);
            double c2 = Math.Pow(c, 2.0);

            double phi = Math.PI * 0.5 - Math.Atan2(1.0 / (TP.ax * TP.az) * Math.Sqrt(-4.0 * a2 * a2 * ax2
                - 4.0 * ax2 * ax2 * ax2 -
                az2 * Math.Pow(b2 - c2, 2.0)
                + 4.0 * ax2 * ax2 * (-2.0 * az2 + b2 + c2)
                - ax2 * Math.Pow(-2.0 * az2 + b2 + c2, 2.0)
                + 4.0 * a2 * ax2 * (-2.0 * ax2 + 2 * az2 + b2 + c2)), (b2 - c2) / TP.ax);  //holy fucking crap
            double theta = Math.Asin((-2.0 * a2 - 2.0 * ax2 - 2.0 * az2 + b2 + c2) / (4.0 * TP.az * c));

            coords.setLocal(new Angle(phi), new Angle(theta), time);
            return coords;
        }

        public void setLocal(Angle phi, Angle theta, DateTime time)
        {
            azimut.set(phi.radians);
            polar.set(theta.radians);

            double r = siderialize(time, lon).radians - Math.Atan2(Math.Sin(azimut.radians), Math.Sin(lat.radians) * Math.Cos(azimut.radians) + Math.Cos(lat.radians) * Math.Tan(polar.radians));
            if (r < 0) r += 2 * Math.PI;
            dec.set(r: Math.Asin(Math.Sin(lat.radians) * Math.Sin(polar.radians) - Math.Cos(lat.radians) * Math.Cos(polar.radians) * Math.Cos(azimut.radians)));
            ra.set(r: r);
        }

        public void updateLocal(DateTime time)
        {
            Angle aloc = siderialize(time, lon) - ra;
            azimut.set(r: Math.Atan2(Math.Sin(aloc.radians), (Math.Sin(lat.radians) * Math.Cos(aloc.radians) - Math.Cos(lat.radians) * Math.Tan(dec.radians))));
            polar.set(r: Math.Asin(Math.Sin(lat.radians) * Math.Sin(dec.radians) + Math.Cos(lat.radians) * Math.Cos(dec.radians) * Math.Cos(aloc.radians)));
        }

        public static Angle siderialize(DateTime time, Angle longitude)
        {
            double JD = 2451544.5D;
            DateTime utc = time.ToUniversalTime(); DateTime calib = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            JD = JD + ((double)(utc.Date.Ticks - calib.Ticks) / TimeSpan.TicksPerDay);

            double T = (JD - 2451545D) / 36525D;
            double gmst = 100.46061837D + 
                (36000.77053608D * T) + 
                (0.000387933D * T * T) -
                (T * T * T) / 38710000D;
            gmst = gmst + 
                (utc.TimeOfDay.Ticks * 1.00273790935D) / TimeSpan.TicksPerDay * 360D;
            Angle lmst = new Angle(r:(gmst / 180D * Math.PI + longitude.radians)%(2*Math.PI));
            return lmst;
        }

        public Vector3D getVector()
        {
            Vector3D v = new Vector3D();
            v.X = Math.Cos(dec.radians) * Math.Cos(ra.radians);
            v.Y = Math.Cos(dec.radians) * Math.Sin(ra.radians);
            v.Z = Math.Sin(dec.radians);
            return v;
        }

        public static Coordinates FromVector(Vector3D v, DateTime time)
        {
            v.Normalize();
            Coordinates c = new Coordinates(TelescopeState.coordinates.lat, TelescopeState.coordinates.lon);
            c.setGlobal(new Angle(Math.Asin(v.Z)), new Angle(Math.Atan2(v.Y, v.X)),time);
            return c;
        }

        internal Coordinates clone()
        {
            Coordinates c = new Coordinates(lat, lon);
            c.dec = dec.clone();
            c.azimut = azimut.clone();
            c.ra = ra.clone();
            c.polar = polar.clone();
            return c;
        }
    }

    public static class CoordinateManager
    {
        public static Angle distance2D(Coordinates c1, Coordinates c2)
        {
            if (Math.Abs(c1.dec.radians - c2.dec.radians) < 0.0000001 && Math.Abs(c1.ra.radians - c2.ra.radians) < 0.0000001)
                return new Angle(0);
            return new Angle(Math.Acos(Math.Cos(c1.dec.radians) * Math.Cos(c2.dec.radians) * Math.Cos(c1.ra.radians - c2.ra.radians) + Math.Sin(c1.dec.radians) * Math.Sin(c2.dec.radians)));
        }

        public static Coordinates stepTowards(Coordinates c1, Coordinates c2, Angle step, DateTime time)
        {
            if (distance2D(c1, c2).absradians <= step.absradians)
                return c2;

            Vector3D v1 = c1.getVector();
            Vector3D v2 = c2.getVector();
            Vector3D axis = Vector3D.CrossProduct(v1, v2);

            axis.Normalize();

            Vector3D v3 = new Vector3D();
            v3 = Vector3D.Multiply(Vector3D.DotProduct(axis, v1), axis) + 
                Vector3D.Multiply(Math.Cos(step.radians), Vector3D.CrossProduct(Vector3D.CrossProduct(axis, v1), axis)) + 
                Vector3D.Multiply(Math.Sin(step.radians), Vector3D.CrossProduct(axis, v1));

            return Coordinates.FromVector(v3, time);
        }
    }
}
