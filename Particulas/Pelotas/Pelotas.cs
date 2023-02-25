using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Pelotas
{
    public partial class Pelotas : Form
    {
        static List<Pelota> balls;
        static List<Particulas2> ballsP;
        static Bitmap bmp;
        static Graphics g;
        static Random rand = new Random();
        static float deltaTime;

        int counter = 0;

        public Pelotas()
        {
            InitializeComponent();
        }

        private void Init()
        {
            if (PCT_CANVAS.Width == 0)
                return;

            balls       = new List<Pelota>();
            ballsP      = new List<Particulas2>(); 
            bmp         = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
            g           = Graphics.FromImage(bmp);
            deltaTime   = 1;
            PCT_CANVAS.Image = bmp;

            for (int b = 0; b < 200; b++)
                balls.Add(new Pelota(rand, PCT_CANVAS.Size, b));
        }

        private void Pelotas_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Pelotas_SizeChanged(object sender, EventArgs e)
        {
            Init();
        }

        public int counter2()
        {
            int counter2 = 0;

            return counter2;
        }
        

        private void TIMER_Tick(object sender, EventArgs e)
        {
            TIMER.Interval = 1;
            TIMER.Enabled = true;

            if (counter2() >= 200)
            {
                // Exit loop code.  
                //TIMER.Enabled = false;

                //Init();

                
                
                for (int c = 0; c < 100; c++)
                    ballsP.Add(new Particulas2(rand, PCT_CANVAS.Size, c));

                counter = 0;


            }
            else
            {


                g.Clear(Color.Black);


                Parallel.For(0, balls.Count, b =>//ACTUALIZAMOS EN PARALELO
                {
                    Pelota P;
                    balls[b].Update(deltaTime, balls);
                    P = balls[b];
                });

                Pelota p;
                for (int b = 0; b < balls.Count; b++)//PINTAMOS EN SECUENCIA
                {
                    p = balls[b];
                    g.FillEllipse(new SolidBrush(p.c), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
                }

                PCT_CANVAS.Invalidate();
                deltaTime += .1f;
                counter = counter + 1;
            }
        }
    }
}
