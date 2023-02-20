using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motor__Grafico3
{
    public partial class Perspective3D : Form
    {
        Bitmap bmp;
        Graphics graphic;
        Figures cube;
        Scene scene;
        float[,] RotationX, RotationY, RotationZ;
        Vertex[] vertixes = new Vertex[8];

        float angle1 = 0, angle2 = 0, angle3 = 0;

        bool Xrotation = false;
        bool Yrotation = false;
        bool Zrotation = false;
        bool XYZrotation = false;


        public Perspective3D()
        {
            InitializeComponent();

            bmp = new Bitmap(pictureBoxDisplay.Width, pictureBoxDisplay.Height);
            graphic = Graphics.FromImage(bmp);
            pictureBoxDisplay.Image = bmp;
            scene = new Scene(cube);

            vertixes[0] = new Vertex(-50, 50, -50);
            vertixes[1] = new Vertex(50, 50, -50);
            vertixes[2] = new Vertex(50, -50, -50);
            vertixes[3] = new Vertex(-50, -50, -50);
            vertixes[4] = new Vertex(-50, -50, 50);
            vertixes[5] = new Vertex(50, -50, 50);
            vertixes[6] = new Vertex(50, 50, 50);
            vertixes[7] = new Vertex(-50, 50, 50);

            cube = new Figures(vertixes);

        }
        public void Draw(Vertex firsty, Vertex secondy)
        {

            graphic.DrawLine(Pens.Green, 0, pictureBoxDisplay.Height / 2, pictureBoxDisplay.Width, pictureBoxDisplay.Height / 2);
            graphic.DrawLine(Pens.Green, pictureBoxDisplay.Width / 2, 0, pictureBoxDisplay.Width / 2, pictureBoxDisplay.Height);

            PointF first = firsty.ConvertToPointF(firsty.X * 500 / (500 - firsty.Z), firsty.Y * 500 / (500 - firsty.Z));
            PointF second = secondy.ConvertToPointF(secondy.X * 500 / (500 - secondy.Z), secondy.Y * 500 / (500 - secondy.Z));

            PointF first11, second22;

            int sizeX = (pictureBoxDisplay.Width / 2);
            int sizeY = (pictureBoxDisplay.Height / 2);

            first11 = new PointF(sizeX + first.X, sizeY - first.Y);
            second22 = new PointF(sizeX + second.X, sizeY - second.Y);

            graphic.DrawLine(Pens.Green, first11, second22);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void newVeretx()
        {
            vertixes[0] = new Vertex(-50, 50, -50);
            vertixes[1] = new Vertex(50, 50, -50);
            vertixes[2] = new Vertex(50, -50, -50);
            vertixes[3] = new Vertex(-50, -50, -50);
            vertixes[4] = new Vertex(-50, -50, 50);
            vertixes[5] = new Vertex(50, -50, 50);
            vertixes[6] = new Vertex(50, 50, 50);
            vertixes[7] = new Vertex(-50, 50, 50);
        }

        private void buttonRotarX_Click(object sender, EventArgs e)
        {
            newVeretx();

            Xrotation = true;
            Yrotation = false;
            Zrotation = false;
            XYZrotation = false;  
        }
        private void buttonRotarY_Click(object sender, EventArgs e)
        {
            newVeretx();

            Xrotation = false;
            Yrotation = true;
            Zrotation = false;
            XYZrotation = false;

        }
        private void buttonRotarZ_Click(object sender, EventArgs e)
        {
            newVeretx();

            Xrotation = false;
            Yrotation = false;
            Zrotation = true;
            XYZrotation = false;
        }

        private void buttonRotarXYZ_Click(object sender, EventArgs e)
        {
            newVeretx();
            
            Xrotation = false;
            Yrotation = false;
            Zrotation = false;
            XYZrotation = true;
        }

        private void timer1_Tick(object sender, EventArgs j)
        {
            if (angle1 == 0 & angle2 == 0 & angle3 == 0)
            {
                angle1 += 1f / 57.2958f;
                angle2 += 1f / 57.2958f;
                angle3 += 1f / 57.2958f;
            }

            if (Xrotation == true)
            {

                RotationX = Matrix.RotationX(angle1);


                for (int i = 0; i < cube.Vertex.Length; i++)
                {
                    Vertex vertexX = cube.Vertex[i];

                    vertexX = Matrix.verMatrix(vertexX, RotationX);
                    cube.Vertex[i] = vertexX;

                }
                graphic.Clear(Color.Transparent);
            }


            if (Yrotation == true)
            {

                RotationY = Matrix.RotationY(angle1);

                for (int i = 0; i < cube.Vertex.Length; i++)
                {
                    Vertex vertexY = cube.Vertex[i];

                    vertexY = Matrix.verMatrix(vertexY, RotationY);
                    cube.Vertex[i] = vertexY;

                }
                graphic.Clear(Color.Transparent);
            }

            if (Zrotation == true)
            {

                RotationZ = Matrix.RotationZ(angle1);

                for (int i = 0; i < cube.Vertex.Length; i++)
                {
                    Vertex vertexZ = cube.Vertex[i];

                    vertexZ = Matrix.verMatrix(vertexZ, RotationZ);
                    cube.Vertex[i] = vertexZ;
                }
                graphic.Clear(Color.Transparent);

            }

            if (XYZrotation == true)
            {

                RotationX = Matrix.RotationX(angle1);
                RotationY = Matrix.RotationY(angle2);
                RotationZ = Matrix.RotationZ(angle3);

                for (int i = 0; i < cube.Vertex.Length; i++)

                {
                    Vertex vertexY = cube.Vertex[i];
                    Vertex vertexX = cube.Vertex[i];
                    Vertex vertexZ = cube.Vertex[i];

                    vertexX = Matrix.get3DMatrix(vertexX, RotationX);
                    vertexY = Matrix.get3DMatrix(vertexY, RotationY);
                    vertexZ = Matrix.get3DMatrix(vertexZ, RotationZ);

                    cube.Vertex[i].X = vertexX.X;
                    cube.Vertex[i].Y = vertexY.Y;
                    cube.Vertex[i].Z = vertexZ.Z;

                }
            }

            graphic.Clear(Color.Transparent);

            Draw(cube.Vertex[0], cube.Vertex[1]);
            Draw(cube.Vertex[1], cube.Vertex[2]);
            Draw(cube.Vertex[2], cube.Vertex[3]);
            Draw(cube.Vertex[3], cube.Vertex[0]);
            Draw(cube.Vertex[4], cube.Vertex[5]);
            Draw(cube.Vertex[5], cube.Vertex[6]);
            Draw(cube.Vertex[6], cube.Vertex[7]);
            Draw(cube.Vertex[7], cube.Vertex[4]);
            Draw(cube.Vertex[7], cube.Vertex[0]);
            Draw(cube.Vertex[6], cube.Vertex[1]);
            Draw(cube.Vertex[5], cube.Vertex[2]);
            Draw(cube.Vertex[4], cube.Vertex[3]);

            pictureBoxDisplay.Invalidate();
        }
    }
}
