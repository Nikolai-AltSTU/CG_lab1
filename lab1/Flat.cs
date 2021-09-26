using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    // плоская фигура в пространстве
    class Flat : Figure
    {
        protected int xMin = int.MaxValue, xMax = int.MinValue;
        protected int yMin = int.MaxValue, yMax = int.MinValue;
        protected double a = 1, b = 1, c = 1, d = 1;
        public int XMin { get { return xMin; } }
        public int XMax { get { return xMax; } }
        public int YMin { get { return yMin; } }
        public int YMax { get { return yMax; } }

        public Flat(double a, double b, double c, double d) // коэфициенты плоскости
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public double z(int x, int y)
        {
            return -(a * x + b * y + d) / c;
        }

        public void findCoefOfZfunction()
        {
            if (points.Count < 3)
                throw new Exception(" Less than 3 points in the Flat");
            
            Point3D p2Minusp1 = points[1] - points[0];
            Point3D p3Minusp1 = points[2] - points[0];
            a = p2Minusp1.Y * p3Minusp1.Z - p2Minusp1.Z * p3Minusp1.Y;
            b = - p2Minusp1.X * p3Minusp1.Z + p2Minusp1.Z * p3Minusp1.X;
            c = p2Minusp1.X * p3Minusp1.Y - p2Minusp1.Y * p3Minusp1.X;
            d = -points[0].X * a - points[0].Y * b - points[0].Z * c;
        }

        public void addPoint(int x, int y, int z = int.MinValue)
        {
            if(points.Count < 3 && z != int.MinValue)
            {
                points.Add(new Point3D(x, y, z));
            }
            else
            {
                points.Add(new Point3D(x, y, (int)this.z(x, y)));
            }           
        }

        public bool isInFlat(Point3D point)
        {
            bool sign = (edges[0].Second - edges[0].First) * (point - edges[0].First) >= 0;
            for (int i = 1; i < edges.Count; i++)
            {
                if(sign != ((edges[i].Second - edges[i].First) * (point - edges[i].First) >= 0))
                {
                    return false;
                }
            }
            return true;
        }
        public void findMinMaxXY()
        {
            xMin = int.MaxValue; xMax = int.MinValue;
            yMin = int.MaxValue; yMax = int.MinValue;
            foreach(Point3D point in points)
            {
                if (xMax < point.X)
                    xMax = point.X;
                if (xMin > point.X)
                    xMin = point.X;
                if (yMax < point.Y)
                    yMax = point.Y;
                if (yMin > point.Y)
                    yMin = point.Y;
            }
        }
    }
}
