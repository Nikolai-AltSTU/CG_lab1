using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace lab1
{
    // плоская фигура в пространстве
    class Flat : Figure
    {
        const double EPS = 1E-9;
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

        #region functions and structions for find intersections
        struct pt
        {
            public double x, y;

            public pt(Point3D p3d)
            {
                x = p3d.X;
                y = p3d.Y;
            }
            public static bool operator >(pt a, pt p)
            {
                return !(a.x < p.x - EPS || Math.Abs(a.x - p.x) < EPS && a.y < p.y - EPS);
            }
            public static bool operator <(pt a, pt p)
            {
                return (a.x < p.x - EPS || Math.Abs(a.x - p.x) < EPS && a.y < p.y - EPS);
            }
        };

        struct line
        {
            public double a, b, c;
            public line(pt p, pt q)
            {
                a = p.y - q.y;
                b = q.x - p.x;
                c = -a * p.x - b * p.y;
                norm();
            }
            public void norm()
            {
                double z = Math.Sqrt(a * a + b * b);
                if (Math.Abs(z) > EPS)
                {
                    a /= z; b /= z; c /= z;
                }
            }

            public double dist(pt p)
            {
                return a * p.x + b * p.y + c;
            }
        };


        bool intersect_1(double a, double b, double c, double d)
        {
            double buf = 0;
            if (a > b)
            {
                buf = a; a = b; b = buf;
            };
            if (c > d)
            {
                buf = c; c = d; d = buf;
            };
            return Math.Max(a, c) <= Math.Min(b, d);
        }

        double det(double a, double b, double c, double d)
        {
            return (a * d - b * c);
        }

        bool betw(double l, double r, double x)
        {
            return Math.Min(l, r) <= x + EPS && x <= Math.Max(l, r) + EPS;
        }

        bool intersect(pt a, pt b, pt c, pt d, out pt left, out pt right)
        {
            left = new pt();
            right = new pt();
            if (!intersect_1(a.x, b.x, c.x, d.x) || !intersect_1(a.y, b.y, c.y, d.y))
                return false;
            line m = new line(a, b);
            line n = new line(c, d);
            double zn = det(m.a, m.b, n.a, n.b);
            if (Math.Abs(zn) < EPS)
            {
                if (Math.Abs(m.dist(c)) > EPS || Math.Abs(n.dist(a)) > EPS)
                    return false;
                if (b < a)
                {
                    pt buf;
                    buf = a; a = b; b = buf;
                }
                if (d < c)
                {
                    pt buf;
                    buf = c; c = d; d = buf;
                }

                if (a < c)
                {
                    left = c;
                }
                else
                {
                    left = a;
                }
                if (b < d)
                {
                    right = b;
                }
                else
                {
                    right = d;
                }
                return true;
            }
            else
            {
                left.x = right.x = -det(m.c, m.b, n.c, n.b) / zn;
                left.y = right.y = -det(m.a, m.c, n.a, n.c) / zn;
                return betw(a.x, b.x, left.x)
                    && betw(a.y, b.y, left.y)
                    && betw(c.x, d.x, left.x)
                    && betw(c.y, d.y, left.y);
            }
        }

        #endregion
        public List<Point> intersections(Point3D aPoint, Point3D bPoint)  // поиск пересечений с горизонтальной прямой
        {
            List<Point> intersectoinsPoint = new List<Point>();
            for (int i = 0; i < edges.Count; i++)
            {
                pt left, right;
                if (intersect(new pt(aPoint), new pt(bPoint), new pt(edges[i].First), new pt(edges[i].Second), out left, out right))
                {
                    if (left.x == right.x && left.y == right.y)
                    {
                        intersectoinsPoint.RemoveAll(x => x.X == (int)Math.Round(left.x));
                        intersectoinsPoint.Add(new Point((int)Math.Round(left.x), (int)Math.Round(left.y)));
                    }
                    else
                    {
                        intersectoinsPoint.Add(new Point((int)Math.Round(left.x), (int)Math.Round(left.y)));
                        intersectoinsPoint.Add(new Point((int)Math.Round(right.x), (int)Math.Round(right.y)));
                    }
                }
            }

            intersectoinsPoint.Sort((a, b) => a.X - b.X);

            //
            if (intersectoinsPoint.Count % 2 == 1)
            {
                intersectoinsPoint.RemoveAt(0);
                //intersectoinsPoint.RemoveAll(x => x.Y != aPoint.Y);
            }
            return intersectoinsPoint;
        }
    }
}
