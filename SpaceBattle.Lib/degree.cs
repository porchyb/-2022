using System;

namespace SpaceBattle.Lib
{
    public class degree
    {
        public double deg;

        public degree(double angle)
        {
            deg = angle;
        }
        public static degree operator +(degree a, float b)
        {
            if (Math.Abs(a.deg + b) > 360)
            {
                a.deg = (a.deg + b) % 360;
                return a;
            }
            a.deg = a.deg + b;
            return a;
        }
        public static degree operator +(float b, degree a)
        {
            if (Math.Abs(a.deg + b) > 360)
            {
                a.deg = (a.deg + b) % 360;
                return a;
            }
            a.deg = a.deg + b;
            return a;
        }

        public static degree operator -(degree a, float b)
        {
            if (Math.Abs(a.deg - b) > 360)
            {
                a.deg = -(Math.Abs(a.deg - b) % 360);
                return a;
            }
            a.deg = a.deg - b;
            return a;
        }
        public static degree operator -(float b, degree a)
        {
            if (Math.Abs(a.deg - b) > 360)
            {
                a.deg = -(Math.Abs(a.deg - b) % 360);
                return a;
            }
            a.deg = a.deg - b;
            return a;
        }
        public static bool operator ==(degree a, degree b)
        {
            if (a.deg != b.deg) { return false; }
            return true;
        }
        public static bool operator !=(degree a, degree b)
        {
            if (a.deg != b.deg) { return true; }
            return false;
        }
        public override bool Equals(object? obj) => obj is degree v && deg==v.deg;
        public override int GetHashCode()
        {
            return String.Join("", deg.ToString()).GetHashCode();
        }
    }
}