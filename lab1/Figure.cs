using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lab1
{
    class Figure
    {
        protected double x0 = 0, y0 = 0, z0 = 0;
        public List<Pair<Point3D, Point3D>> edges;
        public List<Point3D> points;
        public Color color = Color.DarkGoldenrod;

        public Figure()
        {
            edges = new List<Pair<Point3D, Point3D>>();
            points = new List<Point3D>();
        }
            
        public Figure(List<Point3D> points, List<Pair<Point3D, Point3D>> edges)
        {
            this.points = points;
            this.edges = edges;
        }

        public Figure(List<Point3D> points)
        {
            this.points = points;
            this.edges = new List<Pair<Point3D, Point3D>>();
        }

        public void makeCircleEdges()
        {
            edges.Clear();
            for (int i = 0; i < points.Count; i++)
            {
                edges.Add(new Pair<Point3D, Point3D>(points[i], points[(i + 1) % points.Count]));
            }
        }

        public int paintEdges(PictureBox pictureBox, Color color, int typeOfProjection = 1)
        {
            Point3D f, s;
            Pen myPen = new Pen(color, 1);
            Graphics graphics = Graphics.FromImage(pictureBox.Image);
            Pair<Point3D, Point3D> edge;

            for (int i = 0; i < edges.Count; i++)
            {
                edge = edges[i];
                graphics = Graphics.FromImage(pictureBox.Image);
                if (typeOfProjection == 1)
                {
                    f = edge.First.freeProjectionXOY();
                    s = edge.Second.freeProjectionXOY();
                }
                else
                {
                    f = edge.First.projectionXOYwithRot();
                    s = edge.Second.projectionXOYwithRot();
                }
                using (Graphics graph = graphics)
                    graph.DrawLine(myPen, new Point(f.X, f.Y), new Point(s.X, s.Y));
            }
            return 0;
        }

        #region affins
        public void move(double dx, double dy, double dz)
        {
            for (int i = points.Count - 1; i >= 0; i--)
            {
                points[i].move(dx, dy, dz);
            }
            x0 += dx;
            y0 += dy;
            z0 += dz;
        }
        public void rotateX(double da)
        {
            for (int i = points.Count - 1; i >= 0; i--)
            {
                points[i].move(-x0, -y0, -z0);
                points[i].rotateX(da);
                points[i].move(x0, y0, z0);
            }
        }
        public void rotateY(double da)
        {
            for (int i = points.Count - 1; i >= 0; i--)
            {
                points[i].move(-x0, -y0, -z0);
                points[i].rotateY(da);
                points[i].move(x0, y0, z0);
            }
        }
        public void rotateZ(double da)
        {
            for (int i = points.Count - 1; i >= 0; i--)
            {
                points[i].move(-x0, -y0, -z0);
                points[i].rotateZ(da);
                points[i].move(x0, y0, z0);
            }
        }
        public void scale(double sx, double sy, double sz)
        {
            for (int i = points.Count - 1; i >= 0; i--)
            {
                points[i].scale(sx, sy, sz);
            }
        }
        #endregion
    }
}
