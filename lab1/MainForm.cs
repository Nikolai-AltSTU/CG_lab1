using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace lab1
{
    public partial class MainForm : Form
    {
        const int FREE_PROJECTION = 1;

        double x0 = 0, y0 = 0, z0 = 0;
        Figure Letter;
        List<Figure> poligons;
        List<Pair<Point3D, Point3D>> edges;
        List<Point3D> points;
        const int rotStep = 1;
        const int moveStep = 2;
        int maxX = 800, maxY = 500;

        protected void init()
        {
            poligons = new List<Figure>();
            edges = new List<Pair<Point3D, Point3D>>();
            Letter = new Figure();
            points = new List<Point3D>();
        }

        protected void makeLetter()
        {
            const int scale = 40;
            Letter.points.Clear();

            // Буква С
            for (double h = -0.5; h <= 0.5; h += 1)
            {
                Letter.points.Add(new Point3D(4, 2, h));
                Letter.points.Add(new Point3D(3, 1, h));
                Letter.points.Add(new Point3D(2, 1, h));
                Letter.points.Add(new Point3D(1, 2, h));
                Letter.points.Add(new Point3D(1, 4, h));
                Letter.points.Add(new Point3D(2, 5, h));
                Letter.points.Add(new Point3D(3, 5, h));
                Letter.points.Add(new Point3D(4, 4, h));

                Letter.points.Add(new Point3D(5, 5, h));
                Letter.points.Add(new Point3D(4, 6, h));
                Letter.points.Add(new Point3D(1, 6, h));
                Letter.points.Add(new Point3D(0, 5, h));
                Letter.points.Add(new Point3D(0, 1, h));
                Letter.points.Add(new Point3D(1, 0, h));
                Letter.points.Add(new Point3D(4, 0, h));
                Letter.points.Add(new Point3D(5, 1, h));
                Letter.points.Add(new Point3D(4, 2, h));
            }

            Letter.edges.Clear();
            int half_of_num_of_points = Letter.points.Count() / 2;

            for (int i = 0; i < half_of_num_of_points; i++)
            {
                Letter.edges.Add(new Pair<Point3D, Point3D>(Letter.points[i], Letter.points[i + half_of_num_of_points]));
                points.Add(Letter.points[i]);
                points.Add(Letter.points[i + half_of_num_of_points]);
                if (i > 0)
                {
                    Letter.edges.Add(new Pair<Point3D, Point3D>(Letter.points[i + half_of_num_of_points - 1], Letter.points[i + half_of_num_of_points]));
                    Letter.edges.Add(new Pair<Point3D, Point3D>(Letter.points[i - 1], Letter.points[i]));
                }
            }

            foreach(var le in Letter.edges)
            {
                edges.Add(le);
            }

            // оси 
            points.Add(new Point3D(0, 0, 0));
            points.Add(new Point3D(0, 0, 0));
            points.Add(new Point3D(0, 0, 0));
            points.Add(new Point3D(3, 0, 0));
            points.Add(new Point3D(0, 3, 0));
            points.Add(new Point3D(0, 0, 3)); 

            for(int i = half_of_num_of_points * 2, k = 0; k < 3; k++)
            {
                edges.Add(new Pair<Point3D, Point3D>(points[i + k], points[i + k + 3]));
            }

            foreach(var p in points)
            {
                p.scale(scale, scale, scale);
            }
        }

        protected void makePoligons()
        {

        }
        protected void points_move(double dx, double dy, double dz)
        {
            Letter.move(dx, dy, dz);
            for (int i = points.Count - 1, k = 0; k < 6 ; k++)
            {
                points[i - k].move(dx, dy, dz);
            }
            x0 += dx;
            y0 += dy;
            z0 += dz;
        }

        public MainForm()
        {
            InitializeComponent();
            init();
            makePoligons();
            //makeLetter();
            //points_move(180, 100, 0);
            timer1.Start();
        }

        void paintPictureBox(List<Pair<Point3D, Point3D>> edges)
        {
            Point3D f, s;
            Graphics myGraphics = pictureBox1.CreateGraphics();
            Pen myPen = new Pen(Color.Black, 2);
            Graphics graphics;
            Pair<Point3D, Point3D> edge;


            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            for(int i = 0; i < edges.Count - 3; i++)
            {
                edge = edges[i];
                graphics = Graphics.FromImage(pictureBox1.Image); 
                if(FREE_PROJECTION == 1)
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


            myPen = new Pen(Color.Red, 2);
            edge = edges[edges.Count - 3]; 
            graphics = Graphics.FromImage(pictureBox1.Image);
            if (FREE_PROJECTION == 1)
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
            
            myPen = new Pen(Color.Green, 2);
            edge = edges[edges.Count - 2]; 
            graphics = Graphics.FromImage(pictureBox1.Image);
            if (FREE_PROJECTION == 1)
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

            myPen = new Pen(Color.Blue, 2);
            edge = edges[edges.Count - 1];
            graphics = Graphics.FromImage(pictureBox1.Image);
            if (FREE_PROJECTION == 1)
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

            pictureBox1.Refresh();
        }

        double continuousMovementX = 0, continuousMovementY = 0, continuousMovementZ = 0;
        double continuousRotationX = 0, continuousRotationY = 0, continuousRotationZ = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            // движение при зажатой клавише
            Letter.move(continuousMovementX, continuousMovementY, continuousMovementZ);
            Letter.rotateX(continuousRotationX * Math.PI / 180);
            Letter.rotateY(continuousRotationY * Math.PI / 180);
            Letter.rotateZ(continuousRotationZ* Math.PI / 180);

            paintPictureBox(edges);
        }


        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerForAnimation.Start();
        }

        private void стопToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerForAnimation.Stop();
        }

        #region movement and rotation buttons
        private void buttonXMinus_Click(object sender, EventArgs e)
        {
            Letter.move(-moveStep, 0, 0);
        }

        private void buttonXPlus_Click(object sender, EventArgs e)
        {
            Letter.move(moveStep, 0, 0);
        }

        private void buttonYMinus_Click(object sender, EventArgs e)
        {
            Letter.move(0, -moveStep, 0);
        }

        private void buttonYPlus_Click(object sender, EventArgs e)
        {
            Letter.move(0, moveStep, 0);
        }

        private void buttonZMinus_Click(object sender, EventArgs e)
        {
            Letter.move(0, 0, -moveStep);
        }

        private void buttonZPlus_Click(object sender, EventArgs e)
        {
            Letter.move(0, 0, moveStep);
        }

       
        private void buttonRolMinX_Click(object sender, EventArgs e)
        {
            Letter.rotateX(-rotStep * Math.PI / 180);
        }

        private void buttonRolMaxX_Click(object sender, EventArgs e)
        {
            Letter.rotateX(rotStep * Math.PI / 180);
        }

        private void buttonRolMinY_Click(object sender, EventArgs e)
        {
            Letter.rotateY(-rotStep * Math.PI / 180);
        }

        private void buttonRolMaxY_Click(object sender, EventArgs e)
        {
            Letter.rotateY(rotStep * Math.PI / 180);
        }

        private void buttonRolMinZ_Click(object sender, EventArgs e)
        {
            Letter.rotateZ(-rotStep * Math.PI / 180);
        }

        private void buttonRolMaxZ_Click(object sender, EventArgs e)
        {
            Letter.rotateZ(rotStep * Math.PI / 180);
        }
        #endregion
        
        private void информацияToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Лаборатораная работа №1 - Афинные преобразования \n Выполнена студентом группы ПИ-81 Стойко Н. И.\n" +
                "  11. Масштабирование относительно произвольной точки" +
                " одновременно по Х и У (коэффициенты задать) в плоскости " +
                " ХОУ с постепенным возвратом к исходному состояниюс замедлением. ", "Информация о работе");
        }

        // 
        double maxSpeedOfAnime = 1.02;
        double minSpeedOfAnime = 0.98;
        double speedOfAnime = 1.0;

        double stepOfSpeedOfAnime = 0.0005;

        bool increase = false;
        private void timerForAnimation_Tick(object sender, EventArgs e)
        {
            int x = 0;
            int.TryParse(maskedTextBoxAnimX.Text, out x);
            int y = 0;
            int.TryParse(maskedTextBoxAnimY.Text, out y);
            int z = 0;
            int.TryParse(maskedTextBoxAnimZ.Text, out z);

            if (speedOfAnime >= maxSpeedOfAnime)
            {
                increase = false;
            }
            else if(speedOfAnime <= minSpeedOfAnime)
            {
                increase = true;
            }
            if(increase)
            {
                speedOfAnime += stepOfSpeedOfAnime;
            }
            else
            {
                speedOfAnime -= stepOfSpeedOfAnime;
            }
            Letter.move(-x, -y, -z);
            Letter.scale(speedOfAnime, speedOfAnime, 1);
            Letter.move(x, y, z);
        }


        #region lab1
        const double speed = 1.5;
        const double rotSpeed = 0.5;
        #region continuous movement and rotation
        private void buttonXMinus_MouseDown(object sender, MouseEventArgs e)
        {
            continuousMovementX = -speed;
        }
        private void buttonXMinus_MouseUp(object sender, MouseEventArgs e)
        {
            continuousMovementX = 0;
        }
        private void buttonXPlus_MouseDown(object sender, MouseEventArgs e)
        {
            continuousMovementX = speed;
        }
        private void buttonXPlus_MouseUp(object sender, MouseEventArgs e)
        {
            continuousMovementX = 0;
        }

        private void buttonYMinus_MouseDown(object sender, MouseEventArgs e)
        {
            continuousMovementY = -speed;
        }
        private void buttonYMinus_MouseUp(object sender, MouseEventArgs e)
        {
            continuousMovementY = 0;
        }
        private void buttonYPlus_MouseDown(object sender, MouseEventArgs e)
        {
            continuousMovementY = speed;
        }
        private void buttonYPlus_MouseUp(object sender, MouseEventArgs e)
        {
            continuousMovementY = 0;
        }

        private void buttonZMinus_MouseDown(object sender, MouseEventArgs e)
        {
            continuousMovementZ = -speed;
        }
        private void buttonZMinus_MouseUp(object sender, MouseEventArgs e)
        {
            continuousMovementZ = 0;
        }
        private void buttonZPlus_MouseDown(object sender, MouseEventArgs e)
        {
            continuousMovementZ = speed;
        }
        private void buttonZPlus_MouseUp(object sender, MouseEventArgs e)
        {
            continuousMovementZ = 0;
        }



        private void buttonRolMinX_MouseDown(object sender, MouseEventArgs e)
        {
            continuousRotationX = -rotSpeed;
        }
        private void buttonRolMinX_MouseUp(object sender, MouseEventArgs e)
        {
            continuousRotationX = 0;
        }
        private void buttonRolMaxX_MouseDown(object sender, MouseEventArgs e)
        {
            continuousRotationX = rotSpeed;
        }
        private void buttonRolMaxX_MouseUp(object sender, MouseEventArgs e)
        {
            continuousRotationX = 0;
        }
                
        private void buttonRolMinY_MouseDown(object sender, MouseEventArgs e)
        {
            continuousRotationY = -rotSpeed;
        }
        private void buttonRolMinY_MouseUp(object sender, MouseEventArgs e)
        {
            continuousRotationY = 0;
        }
        private void buttonRolMaxY_MouseDown(object sender, MouseEventArgs e)
        {
            continuousRotationY = rotSpeed;
        }
        private void buttonRolMaxY_MouseUp(object sender, MouseEventArgs e)
        {
            continuousRotationY = 0;
        }
                
        private void buttonRolMinZ_MouseDown(object sender, MouseEventArgs e)
        {
            continuousRotationZ = -rotSpeed;
        }
        private void buttonRolMinZ_MouseUp(object sender, MouseEventArgs e)
        {
            continuousRotationZ = 0;
        }
        private void buttonRolMaxZ_MouseDown(object sender, MouseEventArgs e)
        {
            continuousRotationZ = rotSpeed;
        }
        private void buttonRolMaxZ_MouseUp(object sender, MouseEventArgs e)
        {
            continuousRotationZ = 0;
        }


        #endregion

        private void buttonMove_Click(object sender, EventArgs e)
        {
            int x = 0;
            int.TryParse(maskedTextBoxAnimX.Text, out x);
            int y = 0;
            int.TryParse(maskedTextBoxAnimY.Text, out y);
            int z = 0;
            int.TryParse(maskedTextBoxAnimZ.Text, out z);
            Letter.move(x, y, z);
        }

        private void buttonRot_Click(object sender, EventArgs e)
        {
            double x = 0;
            double.TryParse(maskedTextBoxRotX.Text, out x);
            x = x * Math.PI / 180;

            double y = 0;
            double.TryParse(maskedTextBoxRotY.Text, out y);
            y = y * Math.PI / 180;

            double z = 0;
            double.TryParse(maskedTextBoxRotZ.Text, out z);
            z = z * Math.PI / 180;

            Letter.rotateX(x);
            Letter.rotateY(y);
            Letter.rotateZ(z);
        }
        #endregion





    }
}
