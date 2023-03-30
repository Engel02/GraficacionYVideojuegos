using PHYSICS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace PHYSICS
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        VPoint mousePoint;
        VBody R;
        public bool mouse,dibujar;
        int count;
        bool collision, defeat;
        bool l1,l2,l3,l4,l5,l6,l7;
        bool gravity;
        bool quitar_globo;
        bool pegaSombrero = false;
        bool pegaSombrerov7 = false;
        int mapa;
        int mapa2;
        public Form1()
        {
            InitializeComponent();          
        }

        public void init()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            R = new VBody();
            initEstrellas();
            R.ropeList.Add(new Rope(new VPoint(350, 50), new VPoint(450, 200), 10));
            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2, 50), new VPoint(450, 200), 10));
            R.ropeList.Add(new Rope(new VPoint(700, 0), new VPoint(450, 200), 10));
            R.perso.Add(new Personaje(new VPoint(pictureBox1.Width / 2 + 100, 580), Images.Personaje1, 40));
            R.perso.Add(new Personaje(new VPoint(450, 200), Images.Dulce, 25));

            R.caja.Add(new Caja(new VPoint(pictureBox1.Width / 2 + 100, 655), Images.caja, 120));

            JoinRopes(R.perso[1].persona);

            R.estre.Add(new Personaje(new VPoint(500, 380), Images.estrella, 40));
            R.estre.Add(new Personaje(new VPoint(pictureBox1.Width / 2 + 100, 400), Images.estrella, 40));
            R.estre.Add(new Personaje(new VPoint(720, 500), Images.estrella, 40));
            
        }

        public void init2()
        {
           
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            R = new VBody();
            initEstrellas();
            for (int b = 0; b < 10; b++)
                R.spikeballs.Add(new Personaje(new VPoint(600 + b * 14, (int)(250)), Images.spike,20, true));

            for (int b = 0; b < 10; b++)
                R.spikeballs.Add(new Personaje(new VPoint(600 + b * 14, (int)(420)), Images.spike, 20, true));

            R.ropeList.Add(new Rope(new VPoint(400, 40), new VPoint(450, 150), 10));
            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2, 40), new VPoint(450, 150), 10));
            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2, 150), new VPoint(450, 150), 10));
            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2, 270), new VPoint(450, 200), 8));

            R.perso.Add(new Personaje(new VPoint(pictureBox1.Width / 2+50, 570), Images.Personaje1, 40));
            R.perso.Add(new Personaje(new VPoint(480, 150), Images.Dulce, 25));

            R.caja.Add(new Caja(new VPoint(pictureBox1.Width / 2 + 50, 645), Images.caja, 120));

            JoinRopes(R.perso[1].persona);

            R.estre.Add(new Personaje(new VPoint(390, 320), Images.estrella, 40));
            R.estre.Add(new Personaje(new VPoint(500, 520), Images.estrella, 40));
            R.estre.Add(new Personaje(new VPoint(600, 500), Images.estrella, 40));
            
        }
        public void init3()
        {

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            R = new VBody();
            initEstrellas();

            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2 - 150, 250), new VPoint(pictureBox1.Width / 2 + 50, 180), 6));
            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2 + 150, 250), new VPoint(pictureBox1.Width / 2 - 50, 180), 6));

            R.perso.Add(new Personaje(new VPoint(pictureBox1.Width / 2+150, 570), Images.Personaje1, 40));
            R.perso.Add(new Personaje(new VPoint(pictureBox1.Width / 2, 180), Images.Dulce, 40));

            R.caja.Add(new Caja(new VPoint(pictureBox1.Width / 2 + 150, 645), Images.caja, 120));

            for (int b = 0; b < 15; b++)
                R.spikeballs.Add(new Personaje(new VPoint(pictureBox1.Width / 2 - 300 + b * 16, (int)(300) + b * 4), Images.spike, 25, true));

            for (int b = 0; b < 15; b++)
                R.spikeballs.Add(new Personaje(new VPoint(pictureBox1.Width / 2 + 80 + b * 16, (int)(350) - b * 4), Images.spike, 25, true));

            Vec2 r = new Vec2(0,-1);
            R.perso[1].persona.GRAVITY = r;
            for (int i = 0; i < R.ropeList.Count; i++)
            {
                Rope newRope = R.ropeList[i];
                for (int j = 0; j < newRope.points.Count; j++)
                {
                    newRope.points[j].GRAVITY = r;
                    gravity = true;
                }
            }
            if (gravity)
            {
                R.perso[1].textura = Images.globodulce;
            }

            R.estre.Add(new Personaje(new VPoint(pictureBox1.Width / 2, 300), Images.estrella, 40));
            R.estre.Add(new Personaje(new VPoint(pictureBox1.Width / 2, 400), Images.estrella, 40));
            R.estre.Add(new Personaje(new VPoint(pictureBox1.Width / 2+150, 450), Images.estrella, 40));
            JoinRopes(R.perso[1].persona);

      

        }
        
        public void init4()
        {

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            R = new VBody();
            initEstrellas();
            //R.ropeList.Add(new Rope(new VPoint(650, 425), new VPoint(600, 100), 5));
            //R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2, 50), new VPoint(450, 200), 5));
            //R.ropeList.Add(new Rope(new VPoint(500, 250), new VPoint(550, 300), 5));
            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2 - 250, 250), new VPoint(pictureBox1.Width / 2 - 50, 280), 2));
            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2 - 50, 250), new VPoint(pictureBox1.Width / 2 - 150, 280), 2));
            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2 - 100, 450), new VPoint(pictureBox1.Width / 2 - 100, 380), 2));
            

            R.perso.Add(new Personaje(new VPoint(pictureBox1.Width / 2 + 300, 500), Images.Personaje1, 40));
            R.perso.Add(new Personaje(new VPoint(550, 300), Images.Dulce, 25));

            R.hat.Add(new Sombrero(new VPoint(pictureBox1.Width / 2 + 300, 100), Images.sombreroAbajo, 40));
            R.hat.Add(new Sombrero(new VPoint(pictureBox1.Width / 2 - 50, 600), Images.sombreroIzquierda, 40));

            R.caja.Add(new Caja(new VPoint(pictureBox1.Width / 2 + 300 , 570), Images.caja, 100));


            JoinRopes(R.perso[1].persona);

            R.estre.Add(new Personaje(new VPoint(350, 520), Images.estrella, 40));
            R.estre.Add(new Personaje(new VPoint(pictureBox1.Width / 2 + 300, 300), Images.estrella, 40));
            R.estre.Add(new Personaje(new VPoint(pictureBox1.Width / 2 - 200, 405), Images.estrella, 40));

            mapa = 4;
        }

        public void init4v2()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            R = new VBody();
            initEstrellas();
            //R.ropeList.Add(new Rope(new VPoint(650, 425), new VPoint(600, 100), 5));
            //R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2, 50), new VPoint(450, 200), 5));
            //R.ropeList.Add(new Rope(new VPoint(500, 250), new VPoint(550, 300), 5));
            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2 + 300, 100), new VPoint(pictureBox1.Width / 2 + 300, 175), 2));


            R.perso.Add(new Personaje(new VPoint(pictureBox1.Width / 2 + 300, 500), Images.Personaje1, 40));
            R.perso.Add(new Personaje(new VPoint(pictureBox1.Width / 2 + 300, 175), Images.Dulce, 25));

            R.hat.Add(new Sombrero(new VPoint(pictureBox1.Width / 2 + 300, 100), Images.sombreroAbajo, 40));
            R.hat.Add(new Sombrero(new VPoint(pictureBox1.Width / 2 - 50, 600), Images.sombreroIzquierda, 40));

            R.caja.Add(new Caja(new VPoint(pictureBox1.Width / 2 + 300, 570), Images.caja, 100));


            JoinRopes(R.perso[1].persona);

            
            R.estre.Add(new Personaje(new VPoint(pictureBox1.Width / 2 + 300, 300), Images.estrella, 40));

            R.estrella[0].textura = Images.estrella;
            R.estrella[1].textura = Images.estrella;
            count = 2;
        }

        public void init5()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;


            R = new VBody();
            initEstrellas();

            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2 - 250, 350), new VPoint(pictureBox1.Width / 2 + 50, 180), 6));
            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2 + 400, 350), new VPoint(pictureBox1.Width / 2 - 50, 180), 6));
            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2 - 250, 50), new VPoint(pictureBox1.Width / 2 - 50, 180), 6));

            R.perso.Add(new Personaje(new VPoint(pictureBox1.Width / 2 - 250, 570), Images.Personaje1, 40));
            R.perso.Add(new Personaje(new VPoint(pictureBox1.Width / 2, 180), Images.Dulce, 40));

            R.caja.Add(new Caja(new VPoint(pictureBox1.Width / 2 - 250, 645), Images.caja, 120));

            for (int b = 0; b < 15; b++)
                R.spikeballs.Add(new Personaje(new VPoint(pictureBox1.Width / 2 + b * 16, (int)(300) + b * 4), Images.spike, 25, true));
            
            for (int b = 0; b < 15; b++)
                R.spikeballs.Add(new Personaje(new VPoint(pictureBox1.Width / 2 - 400 + b * 16, (int)(250) - b * 4), Images.spike, 25, true));

            Vec2 r = new Vec2(0, -1);
            R.perso[1].persona.GRAVITY = r;
            for (int i = 0; i < R.ropeList.Count; i++)
            {
                Rope newRope = R.ropeList[i];
                for (int j = 0; j < newRope.points.Count; j++)
                {
                    newRope.points[j].GRAVITY = r;
                    gravity = true;
                }
            }
            if (gravity)
            {
                R.perso[1].textura = Images.globodulce;
            }

            R.estre.Add(new Personaje(new VPoint(pictureBox1.Width / 2 - 270, 20), Images.estrella, 40));
            R.estre.Add(new Personaje(new VPoint(pictureBox1.Width / 2 - 50, 300), Images.estrella, 40));
            R.estre.Add(new Personaje(new VPoint(pictureBox1.Width / 2 - 250, 450), Images.estrella, 40));
            JoinRopes(R.perso[1].persona);
            
        }

        public void init6()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            R = new VBody();
            initEstrellas();
            //R.ropeList.Add(new Rope(new VPoint(650, 425), new VPoint(600, 100), 5));
            //R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2, 50), new VPoint(450, 200), 5));
            //R.ropeList.Add(new Rope(new VPoint(500, 250), new VPoint(550, 300), 5));
            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2 - 150, 450), new VPoint(pictureBox1.Width / 2 + 50, 280), 5));
            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2 + 150, 250), new VPoint(pictureBox1.Width / 2 - 50, 280), 5));
            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2, 450), new VPoint(pictureBox1.Width / 2, 380), 2));
            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2 - 300, 400), new VPoint(pictureBox1.Width / 2, 380), 2));

            R.perso.Add(new Personaje(new VPoint(pictureBox1.Width / 2 - 150, 600), Images.Personaje1, 40));
            R.perso.Add(new Personaje(new VPoint(650, 300), Images.Dulce, 25));

          
            R.caja.Add(new Caja(new VPoint(pictureBox1.Width / 2 - 150 , 670), Images.caja, 100));

            Vec2 r = new Vec2(0, -0.9f);
            R.perso[1].persona.GRAVITY = r;
            for (int i = 0; i < R.ropeList.Count; i++)
            {
                Rope newRope = R.ropeList[i];
                for (int j = 0; j < newRope.points.Count; j++)
                {
                    newRope.points[j].GRAVITY = r;
                    gravity = true;
                }
            }
            if (gravity)
            {
                R.perso[1].textura = Images.globodulce;
            }

            R.estre.Add(new Personaje(new VPoint(pictureBox1.Width / 2 - 150, 500), Images.estrella, 40));
            R.estre.Add(new Personaje(new VPoint(pictureBox1.Width / 2 - 150, 50), Images.estrella, 40));
            R.estre.Add(new Personaje(new VPoint(pictureBox1.Width / 2, 200), Images.estrella, 40));
            JoinRopes(R.perso[1].persona);
        }

        public void init7()
        {

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            R = new VBody();
            initEstrellas();
            //R.ropeList.Add(new Rope(new VPoint(650, 425), new VPoint(600, 100), 5));
            //R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2, 50), new VPoint(450, 200), 5));
            //R.ropeList.Add(new Rope(new VPoint(500, 250), new VPoint(550, 300), 5));
            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2 - 450, 250), new VPoint(pictureBox1.Width / 2 - 150, 280), 6));
            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2 , 250), new VPoint(pictureBox1.Width / 2 - 150, 280), 6));



            R.perso.Add(new Personaje(new VPoint(pictureBox1.Width / 2 - 50, 500), Images.Personaje1, 40));
            R.perso.Add(new Personaje(new VPoint(pictureBox1.Width / 2 - 150, 250), Images.Dulce, 25));

            R.hat.Add(new Sombrero(new VPoint(pictureBox1.Width / 2 - 450, 600), Images.sombreroArriba, 40));
            R.hat.Add(new Sombrero(new VPoint(pictureBox1.Width / 2 + 300, 100), Images.sombreroAbajo, 40));

            R.hat.Add(new Sombrero(new VPoint(pictureBox1.Width / 2 + 300, 600), Images.sombreroArribaVerde, 40));
            R.hat.Add(new Sombrero(new VPoint(pictureBox1.Width / 2 - 50, 100), Images.sombreroAbajoVerde, 40));

            R.caja.Add(new Caja(new VPoint(pictureBox1.Width / 2 - 50, 570), Images.caja, 100));

            Vec2 r = new Vec2(0, -0.9f);
            R.perso[1].persona.GRAVITY = r;
            for (int i = 0; i < R.ropeList.Count; i++)
            {
                Rope newRope = R.ropeList[i];
                for (int j = 0; j < newRope.points.Count; j++)
                {
                    newRope.points[j].GRAVITY = r;
                    gravity = true;
                }
            }
            if (gravity)
            {
                R.perso[1].textura = Images.globodulce;
            }

            JoinRopes(R.perso[1].persona);

            R.estre.Add(new Personaje(new VPoint(pictureBox1.Width / 2 - 450, 35), Images.estrella, 40));
            R.estre.Add(new Personaje(new VPoint(pictureBox1.Width / 2 + 300, 300), Images.estrella, 40));
            R.estre.Add(new Personaje(new VPoint(pictureBox1.Width / 2 - 50, 305), Images.estrella, 40));

            mapa = 7;
        }

        public void init7v2()
        {

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            R = new VBody();
            initEstrellas();
            
            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2 + 300, 100), new VPoint(pictureBox1.Width / 2 + 300, 200), 6));
           
            R.perso.Add(new Personaje(new VPoint(pictureBox1.Width / 2 - 50, 500), Images.Personaje1, 40));
            R.perso.Add(new Personaje(new VPoint(pictureBox1.Width / 2 + 300, 200), Images.Dulce, 25));

            R.hat.Add(new Sombrero(new VPoint(pictureBox1.Width / 2 - 450, 600), Images.sombreroArriba, 40));
            R.hat.Add(new Sombrero(new VPoint(pictureBox1.Width / 2 + 300, 100), Images.sombreroAbajo, 40));

            R.hat.Add(new Sombrero(new VPoint(pictureBox1.Width / 2 + 300, 600), Images.sombreroArribaVerde, 40));
            R.hat.Add(new Sombrero(new VPoint(pictureBox1.Width / 2 - 50, 100), Images.sombreroAbajoVerde, 40));

            R.caja.Add(new Caja(new VPoint(pictureBox1.Width / 2 - 50, 570), Images.caja, 100));


            JoinRopes(R.perso[1].persona);

            
            R.estre.Add(new Personaje(new VPoint(pictureBox1.Width / 2 + 300, 300), Images.estrella, 40));
            R.estre.Add(new Personaje(new VPoint(pictureBox1.Width / 2 - 50, 305), Images.estrella, 40));
            R.estrella[0].textura = Images.estrella;
            
            count = 1;

            mapa2 = 72;
            
        }

        public void init7v3()
        {

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            R = new VBody();
            initEstrellas();

            R.ropeList.Add(new Rope(new VPoint(pictureBox1.Width / 2 - 50, 100), new VPoint(pictureBox1.Width / 2 - 50, 200), 6));

            R.perso.Add(new Personaje(new VPoint(pictureBox1.Width / 2 - 50, 500), Images.Personaje1, 40));
            R.perso.Add(new Personaje(new VPoint(pictureBox1.Width / 2 - 50, 200), Images.Dulce, 25));

            R.hat.Add(new Sombrero(new VPoint(pictureBox1.Width / 2 - 450, 600), Images.sombreroArriba, 40));
            R.hat.Add(new Sombrero(new VPoint(pictureBox1.Width / 2 + 300, 100), Images.sombreroAbajo, 40));

            R.hat.Add(new Sombrero(new VPoint(pictureBox1.Width / 2 + 300, 600), Images.sombreroArribaVerde, 40));
            R.hat.Add(new Sombrero(new VPoint(pictureBox1.Width / 2 - 50, 100), Images.sombreroAbajoVerde, 40));

            R.caja.Add(new Caja(new VPoint(pictureBox1.Width / 2 - 50, 570), Images.caja, 100));


            JoinRopes(R.perso[1].persona);

            
            
            R.estre.Add(new Personaje(new VPoint(pictureBox1.Width / 2 - 50, 305), Images.estrella, 40));
            R.estrella[0].textura = Images.estrella;
            R.estrella[1].textura = Images.estrella;
            count = 2;
            mapa = 73;
        }

        public void nuevoDulceArriba()
        {
            R.perso.Add(new Personaje(new VPoint(pictureBox1.Width / 2, 200), Images.Personaje1, 40));
            R.perso.Add(new Personaje(new VPoint(650, 300), Images.Dulce, 25));

            R.hat.Add(new Sombrero(new VPoint(pictureBox1.Width / 2, 50), Images.sombreroAbajo, 25));
            R.hat.Add(new Sombrero(new VPoint(pictureBox1.Width / 2 + 50, 600), Images.sombreroIzquierda, 25));

            JoinRopes(R.perso[1].persona);
        }

   
        public void initEstrellas()
        {
            R.estrella.Add(new Estrellas(1000, 10, Images.image));
            R.estrella.Add(new Estrellas(1060, 10, Images.image));
            R.estrella.Add(new Estrellas(1120, 10, Images.image));
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            mouse = true;
            collision = false;
            
            g.Clear(Color.Transparent);
            bool win = false;
            
             defeat = false;
            //dibujar ropes
            for (int i = 0; i < R.ropeList.Count; i++)
            {
                R.ropeList[i].Render(g, pictureBox1.Width, pictureBox1.Height);

            }

            //dibujar personajes
            for (int i = 0; i < R.perso.Count; i++)
            {
                R.perso[i].Render(g, pictureBox1.Width, pictureBox1.Height);
            }

            //dibujar Sombrero
            for (int i = 0; i < R.caja.Count; i++)
            {
                R.caja[i].Render(g, pictureBox1.Width, pictureBox1.Height);
            }

            //dibujar Caja
            for (int i = 0; i < R.hat.Count; i++)
            {
                R.hat[i].Render(g, pictureBox1.Width, pictureBox1.Height);
            }

            //dibujar estrellas VPoint
            for (int i = 0; i < R.estre.Count; i++)
            {
                R.estre[i].Render(g, pictureBox1.Width, pictureBox1.Height);
            }

            //dibujar marcador estrellas
            for (int i = 0; i < R.estrella.Count; i++)
            {
                R.estrella[i].Render(g, pictureBox1.Width, pictureBox1.Height);
            }

            //dibujar spikeballs
            for (int i = 0; i < R.spikeballs.Count; i++)
            {
                R.spikeballs[i].Render(g, pictureBox1.Width, pictureBox1.Height);
            }

            if (mouse == true)
            {
                for (int i = 0; i < R.ropeList.Count; i++)
                {
                    for (int j = 1; j < R.ropeList[i].points.Count; j++)
                    {
                        R.ropeList[i].points[j].instance = false;
                    }
                }
            }
       
            win = CheckCollisionPersonajes(win);

            

            count = CheckCollision();
            CheckSpikeCollision();

            pegaSombrero = CheckCollisionPersonajesSombrero(pegaSombrero);


            if (collision)
            {
                if (count==1)
                {
                    R.estrella[0].textura = Images.estrella;
                }
                if (count == 2)
                {
                    R.estrella[1].textura = Images.estrella;
                }
                if (count == 3)
                {
                    R.estrella[2].textura = Images.estrella;
                }
            }

            if (win)
            {
                R.perso[0].textura = Images.Personaje2;
                R.ropeList.Clear();
                DialogResult result = MessageBox.Show("You win! You grabbed "+count+ "/3 stars\nDo you want to restart the game?", "Game Over", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    init();
                    if (l1)
                    {
                        init();
                    }
                    if (l2)
                    {
                        init2();
                    }
                    if (l3)
                    {
                        init3();
                    }
                    if (l4)
                    {
                        init4();
                    }
                    if (l5)
                    {
                        init5();
                    }
                    if (l6)
                    {
                        init6();
                    }
                    if (l7)
                    {
                        init7();
                    }
                    count = 0;
                }
                else
                {
                    Close();
                }
            }

            if (R.perso.Count > 1 && R.perso[1].persona.Pos.Y + R.perso[1].persona.diameter-10 >= pictureBox1.Height)
            {


                //R.perso[0].persona.Pos = R.perso[2].persona.Pos;
                //R.perso[0].textura = Images.Personaje2;
                for (int j = R.perso.Count - 1; j >= 0; j--)
                {        
                    R.perso.RemoveAt(j);               
                    R.ropeList.Clear();
                }

                //R.perso.Add(new Personaje(new VPoint(pictureBox1.Width / 2, 200), Images.triste, 100));
                
                defeat = true;             
            }

            if (defeat)
            {  
                DialogResult result = MessageBox.Show("You Defeat! Do you want to restart the game?", "Game Over", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    init();
                    if (l1)
                    {
                        init();
                    }
                    if (l2)
                    {
                        init2();
                    }
                    if(l3)
                    {
                        init3();
                    }
                    if (l4)
                    {
                        init4();
                    }
                    if (l5)
                    {
                        init5();
                    }
                    if (l6)
                    {
                        init6();
                    }
                    if (l7)
                    {
                        init7();
                    }
                    count = 0;
                }
                else
                {
                    Close();
                }
            }

            if (quitar_globo)
            {
                Vec2 r2 = new Vec2(0, 1);
               quitar_globo= false;
                for (int i = 0; i < R.ropeList.Count; i++)
                {
                    Rope newRope = R.ropeList[i];
                    for (int j = 0; j < newRope.points.Count; j++)
                    {
                        newRope.points[j].GRAVITY = r2;
                        R.perso[1].textura = Images.Dulce;
                        R.perso[1].persona.Radius = 30;
                    }
                }

            }

            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
           
            mousePoint = new VPoint(e.X, e.Y);
            float minDistance = 10;
            int ropeIndex = -1;
            int pointIndex = -1;

            for (int i = 0; i < R.ropeList.Count; i++)
            {
                Rope r = R.ropeList[i];
                for (int j = 1; j < r.points.Count-1; j++)
                {
                    float distance = VPoint.Distance1(mousePoint, r.points[j]);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        ropeIndex = i;
                        pointIndex = j;
                    }
                }
            }
            if (ropeIndex >= 0 && pointIndex >= 0)
            {
                R.ropeList[ropeIndex].RemovePoint(pointIndex);
            }
        }

        public void JoinRopes(VPoint newPoint)
        {
            dibujar = true;
            for (int i = 0; i < R.ropeList.Count; i++)
            {
                Rope NewRope = R.ropeList[i];
                VPoint lastPoint = NewRope.points[NewRope.points.Count -1];
                newPoint.check = true;
                NewRope.points.Add(newPoint);
                NewRope.poles.Add(new VPole(lastPoint, newPoint));         
            }
        }

        public bool CheckCollisionPersonajesSombrero(bool collisionSombrero)
        {
            for (int i = 0; i < R.perso.Count; i++)
            {

                for (int j = 0; j < R.hat.Count; j++)
                {
                    Personaje p1 = R.perso[i];
                    Sombrero p2 = R.hat[j];
                    

                    float distance = VPoint.Distance1(p1.persona, p2.persona);
                    if (distance < (p1.persona.diameter + p2.persona.diameter) / 2)
                    {
                        if (mapa == 4)
                        {
                            collisionSombrero = true;
                            //count++;
                            //R.perso[1].persona.Pos = R.hat[0].persona.Pos;
                            //R.ropeList.Clear();


                            //R.hat.RemoveAt(j);
                            //R.perso.RemoveAt(i);

                            init4v2();
                            //Thread.Sleep(1000);
                            R.ropeList[0].RemovePoint(0);
                        }



                        if (mapa == 7)
                        {
                            init7v2();
                            //Thread.Sleep(1000);
                            R.ropeList[0].RemovePoint(0);
                            
                            
                            mapa = 721;
                            
                        }else if (mapa == 721)
                        {
                            init7v3();
                            R.ropeList[0].RemovePoint(0);
                        }

                    }

                   
                }
            }
            return collisionSombrero;
        }
        

        public bool CheckCollisionPersonajes(bool collision)
        {
            for (int i = 0; i < R.perso.Count; i++)
            {
                for (int j = i + 1; j < R.perso.Count; j++)
                {
                    Personaje p1 = R.perso[i];
                    Personaje p2 = R.perso[j];
                    float distance = VPoint.Distance1(p1.persona, p2.persona);
                    if (distance < (p1.persona.diameter + p2.persona.diameter) / 2)
                    {
                        collision = true;
                        R.perso.RemoveAt(j);
                        
                    }
                }
            }
            return collision;
        }

        public void CheckSpikeCollision()
        {
            for (int i = R.spikeballs.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < R.perso.Count; j++)
                {
                    float distance = VPoint.Distance1(R.spikeballs[i].persona, R.perso[j].persona);
                    if (distance < R.spikeballs[i].persona.radius + R.perso[j].persona.radius)
                    {
                        defeat = true;
                        
                        R.perso.RemoveAt(j);
                    }
                }
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            quitar_globo=true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            init();
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.WindowState = FormWindowState.Maximized;
        }

       

        public int CheckCollision()
        {

            for (int i = 0; i < R.perso.Count; i++)
            {

                for (int j = 0; j < R.estre.Count; j++)
                {
                    Personaje p1 = R.perso[i];
                    Personaje p2 = R.estre[j];

                    float distance = VPoint.Distance1(p1.persona, p2.persona);
                    if (distance < (p1.persona.diameter + p2.persona.diameter) / 2)
                    {
                        collision = true;
                        count++;
                        R.estre.RemoveAt(j);
                    }
                }
            }
            return count;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            l1 = true;
            l2 = false;
            l3 = false;
            l4 = false;
            l5 = false;
            l6 = false;
            l7 = false;
            init();
            count = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            l1 = false;
            l2 = true;
            l3 = false;
            l4 = false;
            l5 = false;
            l6 = false;
            l7 = false;
            init2();
            count = 0;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            l1 = false;
            l2 = false;
            l3 = true;
            l4 = false;
            l5 = false;
            l6 = false;
            l7 = false;
            init3();
            count = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            l1 = false;
            l2 = false;
            l3 = false;
            l4 = true;
            l5 = false;
            l6 = false;
            l7 = false;
            init4();
            count = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            l1 = false;
            l2 = false;
            l3 = false;
            l4 = false;
            l5 = true;
            l6 = false;
            l7 = false;
            init5();
            count = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            l1 = false;
            l2 = false;
            l3 = false;
            l4 = false;
            l5 = false;
            l6 = true;
            l7 = false;
            init6();
            count = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            l1 = false;
            l2 = false;
            l3 = false;
            l4 = false;
            l5 = false;
            l6 = false;
            l7 = true;
            init7();
            count = 0;
        }
    }
}
