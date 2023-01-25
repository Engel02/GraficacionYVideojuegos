using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Shapes;
using Color = System.Drawing.Color;


namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {

        static Bitmap bmp;
        static Graphics g;
        private Point a, b, c, d;
                

        public PointF centroid;
        public List<PointF> pts;
        public Form1()
        {
            InitializeComponent();

            

            bmp = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
            g = Graphics.FromImage(bmp);
            PCT_CANVAS.Image = bmp;

            Render();
        }


        private void Render()   
        {
            g.Clear(Color.Transparent);
            g.DrawLine(Pens.Yellow, bmp.Width / 2, 0, bmp.Width / 2, bmp.Height);
            g.DrawLine(Pens.Yellow, 0, bmp.Height / 2, bmp.Width, bmp.Height / 2);
            RenderLine(a, b);
            RenderLine(b, c);
            RenderLine(c, d);
            RenderLine(d, a);//*/
            PCT_CANVAS.Invalidate();
        }

        private PointF Rotate(PointF a)
        {
            double angle = float.Parse(textBox1.Text) / 57.2958f;
            PointF b = new PointF();
            b.X = (float)((a.X * Math.Cos(angle)) - (a.Y * Math.Sin(angle)));
            b.Y = (float)((a.X * Math.Sin(angle)) + (a.Y * Math.Cos(angle)));
            return b;
        }

        private PointF TranslateToCenter(PointF a)
        {
            int Sx = (bmp.Width / 2); // origen central en x
            int Sy = (bmp.Height / 2); // origen central en y
            return new PointF(Sx + a.X, Sy - a.Y);
        }
        private PointF Translate(PointF a, PointF b)
        {
            return new PointF(a.X + b.X, a.Y + b.Y);
        }

        private void RenderLine(PointF a, PointF b)
        {
            a = Translate(a, new PointF(-50, -50)); // centroide
            b = Translate(b, new PointF(-50, -50)); // centroide
            PointF c = Rotate(a);
            PointF d = Rotate(b);//*/
            c = TranslateToCenter(c);
            d = TranslateToCenter(d);
            c = Translate(c, new PointF(50, -50));
            d = Translate(d, new PointF(50, -50));
            g.DrawLine(Pens.Gray, c, d);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
