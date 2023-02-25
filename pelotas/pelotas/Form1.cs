using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pelotas
{
    public partial class Form1 : Form
    {
        private Pelotas[] balls;


        public Form1()
        {
            InitializeComponent();

            DoubleBuffered = true;

            balls = new Pelotas[]
            {
            new Pelotas(150, 50, 30, 5, 4),
            new Pelotas(150, 100, 20, -3, 6),
            new Pelotas(200, 150, 25, 7, -5),
            new Pelotas(190, 110, 30, -5, 8),
            new Pelotas(130, 130, 25, 6, -4)
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Borrar la pantalla
            g.Clear(Color.White);

            // Dibujar las pelotas
            foreach (Pelotas ball in balls)
            {
                ball.Draw(g);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            var random3 = new Random();
            var random2 = new Random();
            var random1 = new Random();

            // Agregar una pelota cuando se hace clic en la pantalla
            Pelotas newBall = new Pelotas(100, 100, random1.Next(50), random2.Next(-10, 10), random3.Next(-30, 10));
            Array.Resize(ref balls, balls.Length + 1);
            balls[balls.Length - 1] = newBall;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Timer timer = new Timer();
            timer.Interval = 16;
            timer.Tick += new EventHandler(OnTimerTick);
            timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            // Actualizar la posición de las pelotas
            foreach (Pelotas ball in balls)
            {
                ball.Update(ClientSize.Width, ClientSize.Height, balls, 0);
            }

            // Redibujar la pantalla
            Invalidate();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
