using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace lab1
{
    class Point3D
    {
        protected double[] x = new double[4];

        public int X { get { return (int)(x[0] / x[3] + 0.5); } set { x[0] = value; } }
        public int Y { get { return (int)(x[1] / x[3] + 0.5); } set { x[1] = value; } }
        public int Z { get { return (int)(x[2] / x[3] + 0.5); } set { x[2] = value; } }

        public Point3D(double x, double y, double z)
        {
            this.x[0] = x;
            this.x[1] = y;
            this.x[2] = z;
            this.x[3] = 1;
        }

        protected Point3D(double x, double y, double z, double h)
        {
            this.x[0] = x;
            this.x[1] = y;
            this.x[2] = z;
            this.x[3] = h;
        }

        public Point3D(Point3D p)
        {
            p.x.CopyTo(this.x, 0);
        }

        public void rotateX(double angle)
        {
            double cosA = Math.Cos(angle);
            double sinA = Math.Sin(angle);
            Matrix RotX = new Matrix(
            new double[][]
        {
            new double[] {1, 0, 0, 0},
            new double[] {0, cosA, sinA, 0},
            new double[] {0, -sinA, cosA, 0},
            new double[] {0, 0, 0, 1}
        });
            x = x * RotX;
        }

        public void rotateY(double angle)
        {
            double cosA = Math.Cos(angle);
            double sinA = Math.Sin(angle);
            Matrix RotY = new Matrix(
            new double[][]
                {
                    new double[] {cosA, 0, -sinA, 0},
                    new double[] {0, 1, 0 , 0},
                    new double[] {sinA, 0, cosA, 0},
                    new double[] {0, 0, 0, 1}
                });
            x = x * RotY;
        }
        public void rotateZ(double angle)
        {
            double cosA = Math.Cos(angle);
            double sinA = Math.Sin(angle);
            Matrix RotZ = new Matrix(
            new double[][]
                {
                    new double[] {cosA, sinA, 0, 0},
                    new double[] {-sinA, cosA, 0 , 0},
                    new double[] {0, 0, 1, 0},
                    new double[] {0, 0, 0, 1}
                });
            x = x * RotZ;
        }

        public void scale(double ax, double ay, double az) 
        {
            Matrix ScaleM = new Matrix(
            new double[][]
                {
                    new double[] {ax, 0, 0, 0},
                    new double[] {0, ay, 0 , 0},
                    new double[] {0, 0, az, 0},
                    new double[] {0, 0, 0, 1}
                });
            x = x * ScaleM;
        }

        public void move(double ax, double ay, double az)
        {
            Matrix  moveM = new Matrix(
            new double[][]
                {
                    new double[] {1, 0, 0, 0},
                    new double[] {0, 1, 0 , 0},
                    new double[] {0, 0, 1, 0},
                    new double[] {ax, ay, az, 1}
                });
            x = x * moveM;
        }

        public Point3D projectionXOYwithRot(double angleX = 0, double angleY = 0)
        {
            Point point;
            double cosX = Math.Cos(angleX);
            double sinX = Math.Sin(angleX);
            double cosY = Math.Cos(angleY);
            double sinY = Math.Sin(angleY);
            Matrix projectionM = new Matrix(
            new double[][]
                {
                    new double[] {cosY, sinX * sinY, 0, 0},
                    new double[] {0, cosY, 0 , 0},
                    new double[] {sinY, -sinY * cosX, 0, 0},
                    new double[] {0, 0, 0, 1}
                });
            
            double[] res = x * projectionM;
            return new Point3D(res[0], res[1], res[2], res[3]);
        }
        
        public Point3D freeProjectionXOY(double angle = Math.PI / 4)
        {
            Point point;
            double cosA = Math.Cos(angle);
            Matrix projectionM = new Matrix(
            new double[][]
                {
                    new double[] {1, 0, 0, 0},
                    new double[] {0, 1, 0 , 0},
                    new double[] { cosA, -cosA, 0, 0},
                    new double[] {0, 0, 0, 1}
                });
            
            double[] res = x * projectionM;
            return new Point3D(res[0], res[1], res[2], res[3]);
        }
    }
}
