using System;

namespace BasilAndBasilica
{
    public struct Point : IEquatable<Point>
    {
        public static Point Zero
        {
            get
            {
                return Point._zero;
            }
        }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object other)
        {
            if (other is Point)
            {
                return this.Equals((Point)other);
            }
            return false;
        }

        public bool Equals(Point other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        public override int GetHashCode()
        {
            return this.X.GetHashCode() + this.Y.GetHashCode();
        }

        public static bool operator ==(Point a, Point b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Point a, Point b)
        {
            return !a.Equals(b);
        }

        static Point()
        {
            // Note: this type is marked as 'beforefieldinit'.
            Point._zero = default(Point);
        }

        public int X;

        public int Y;

        private static Point _zero;
    }
}
