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
        const int XOY_PROJECTION = 0;
        const int FREE_PROJECTION = 1;
        protected int typeOfProjection = FREE_PROJECTION;
        //protected int typeOfProjection = XOY_PROJECTION;

        protected double x0 = 0, y0 = 0, z0 = 0;
        Figure Letter;
        List<Figure> poligons;
        List<Figure> axis;

        List<Figure> allFigures;
        const int rotStep = 1;
        const int moveStep = 2;
        int maxX = 800, maxY = 600;

        protected void init()
        {
            poligons = new List<Figure>();
            axis = new List<Figure>();
            Letter = new Figure();
            allFigures = new List<Figure>();
            maxX = pictureBox1.Width;
            maxY = pictureBox1.Height;
        }

        protected void makeAxis()
        {
            // оси 
            axis.Add(new Figure(new List<Point3D>() { new Point3D(0, 0, 0), new Point3D(3, 0, 0) } ));
            axis.Add(new Figure(new List<Point3D>() { new Point3D(0, 0, 0), new Point3D(0, 3, 0) } ));
            axis.Add(new Figure(new List<Point3D>() { new Point3D(0, 0, 0), new Point3D(0, 0, 3) } ));

            foreach(Figure figure in axis)
            {
                figure.makeCircleEdges();
            }
        }

        protected void makeLetter()
        {
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
                if (i > 0)
                {
                    Letter.edges.Add(new Pair<Point3D, Point3D>(Letter.points[i + half_of_num_of_points - 1], Letter.points[i + half_of_num_of_points]));
                    Letter.edges.Add(new Pair<Point3D, Point3D>(Letter.points[i - 1], Letter.points[i]));
                }
            }
            allFigures.Add(Letter);
        }

        protected void makePoligons()
        {
            //   new Point3D( , , )

            //  9 * x + 2 * y + 3 * z + 4 = 0 
            //poligons.Add(new Figure(new List<Point3D>() { new Point3D(2, 3, -5), new Point3D( 11, 5, -5), new Point3D( 4, 11, -5) }));
            poligons.Add(new Flat(1, 2, 12, 24));
            ((Flat)poligons.Last()).addPoint(2, 3);
            ((Flat)poligons.Last()).addPoint(11, 5);
            ((Flat)poligons.Last()).addPoint(4, 11);

            // 10 * x + 4 * y + 8 * z + 2 = 0
            //poligons.Add(new Figure(new List<Point3D>() { new Point3D(8, 3, 5), new Point3D(16, 3, 20), new Point3D(16, 9, 20), new Point3D(8, 9, 5) })); 
            poligons.Add(new Flat(2, 1, 10, 30));
            ((Flat)poligons.Last()).addPoint(8, 3);
            ((Flat)poligons.Last()).addPoint(16, 3);
            ((Flat)poligons.Last()).addPoint(16, 9);
            ((Flat)poligons.Last()).addPoint(8, 9);


            // 10 * x + 4 * y + 8 * z + 2 = 0
            //poligons.Add(new Figure(new List<Point3D>() { new Point3D(8, 3, - 11.75), new Point3D(16, 3, -21.75), new Point3D(16, 9, -24.75), new Point3D(8, 9, -14.75) })); 

            foreach (Figure fig in poligons)
            {
                fig.makeCircleEdges();
                allFigures.Add(fig);
            }
        }

        protected void scaleAllScene(int scaleVal = 40)
        {
            for(int i = 0; i < axis.Count; i++)
            {
                axis[i].scale(scaleVal, scaleVal, scaleVal);
            }
            for(int i = 0; i < allFigures.Count; i++)
            {
                allFigures[i].scale(scaleVal, scaleVal, scaleVal);
            }
        }

        protected void moveAllScene(double dx, double dy, double dz)
        {
            for (int k = 0; k < allFigures.Count ; k++)
            {
                allFigures[k].move(dx, dy, dz);
            }
            for (int k = 0; k < axis.Count ; k++)
            {
                axis[k].move(dx, dy, dz);
            }
            x0 += dx;
            y0 += dy;
            z0 += dz;
        }

        public MainForm()
        {
            InitializeComponent();
            init();

            makeAxis();
            makePoligons();
            makeLetter();

            scaleAllScene(20);
            moveAllScene(200,100, 0);

            timer1.Start();
        }

        void paintPictureBox()
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            foreach (Figure fig in poligons)
            {
                fig.paintEdges(pictureBox1, Color.Aqua, typeOfProjection);
            }
            
            Letter.paintEdges(pictureBox1, Color.Black, typeOfProjection);

            axis[0].paintEdges(pictureBox1, Color.Red, typeOfProjection);
            axis[1].paintEdges(pictureBox1, Color.Green, typeOfProjection);
            axis[2].paintEdges(pictureBox1, Color.Blue, typeOfProjection);

            pictureBox1.Refresh();
        }

        //4.	Построчное сканирование с использованием z-буфера
        protected void lineZbuffer()
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            

            
            axis[0].paintEdges(pictureBox1, Color.Red, typeOfProjection);
            axis[1].paintEdges(pictureBox1, Color.Green, typeOfProjection);
            axis[2].paintEdges(pictureBox1, Color.Blue, typeOfProjection);

            pictureBox1.Refresh();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            // движение при зажатой клавише
            foreach (Figure fig in allFigures)
            {
                if(continuousMovementX != 0 || continuousMovementY != 0 || continuousMovementZ != 0)
                    fig.move(continuousMovementX, continuousMovementY, continuousMovementZ);
                if (continuousRotationX != 0)
                    fig.rotateX(continuousRotationX * Math.PI / 180);
                if (continuousRotationY != 0)
                    fig.rotateY(continuousRotationY * Math.PI / 180);
                if (continuousRotationZ != 0)
                    fig.rotateZ(continuousRotationZ * Math.PI / 180);
            }

            paintPictureBox();
        }

        #region buttons
        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerForAnimation.Start();
        }

        private void стопToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerForAnimation.Stop();
        }

        private void информацияToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Лаборатораная работа №1 - Афинные преобразования \n Выполнена студентом группы ПИ-81 Стойко Н. И.\n" +
                "  11. Масштабирование относительно произвольной точки" +
                " одновременно по Х и У (коэффициенты задать) в плоскости " +
                " ХОУ с постепенным возвратом к исходному состояниюс замедлением. ", "Информация о работе");
        }
        #endregion

        #region lab1

        double continuousMovementX = 0, continuousMovementY = 0, continuousMovementZ = 0;
        double continuousRotationX = 0, continuousRotationY = 0, continuousRotationZ = 0;

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

            foreach(Figure fig in allFigures)
            {
                fig.move(x, y, z);
                fig.scale(speedOfAnime, speedOfAnime, 1);
                fig.move(-x, -y, -z);
            }
        }


        
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
            int.TryParse(maskedTextBoxMoveX.Text, out x);
            int y = 0;
            int.TryParse(maskedTextBoxMoveY.Text, out y);
            int z = 0;
            int.TryParse(maskedTextBoxMoveZ.Text, out z);

            foreach(Figure fig in allFigures)
            {
                fig.move(x, y, z);
            }
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

            foreach (Figure fig in allFigures)
            {
                fig.rotateX(x);
                fig.rotateY(y);
                fig.rotateZ(z);
            }
            
        }
        #endregion

    }
}
