using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pelotas
{
    public class Particulas2
    {
        int index;
        Size space;
        public Color c;
        // Variables de posición
        public float x;
        public float y;

        // Variables de velocidad
        private float vxx;
        private float vyy;

        // Variable de radio
        public float radio;
        public float radio2;
        //public int enX;
        //public int enY;

        /*  public Pelotas(float x, float y, float radius, float speedX, float speedY)
         {
             this.x = x;
             this.y = y;
             this.radius = radius;
             this.speedX = speedX;
             this.speedY = speedY;
         }*/
        // Constructor
        public Particulas2(Random rand, Size size, int index)
        {
            this.radio = rand.Next(2, 5);
            this.radio2 = rand.Next(99, 100);
            //this.enX = rand.Next(1,2);
            //this.enY = rand.Next(1,2);
            this.x = rand.Next((int)radio2); //rand.Next((int)radio , size.Width - (int)radio );
            this.y = rand.Next((int)radio); //, size.Height - (int)radio );
            c = Color.FromArgb(254, 0, 0);
            //Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            // Velocidades iniciales
            this.vxx = 1;//rand.Next((int)-radio, (int)radio);
            this.vyy = 1;//rand.Next((int)-radio, (int)radio);

            this.index = index;
            space = size;
        }



        // Método para actualizar la posición de la pelota en función de su velocidad
        public void Update(float deltaTime, List<Particulas2> ballsP)
        {
            for (int b = index + 1; b < ballsP.Count; b++)
            {
                Collision(ballsP[b]);
            }

            if ((x - radio) <= 0 || (x + radio) >= space.Width)
            {
                if (x - radio <= 0)
                    x = radio + 3;
                else
                    x = 100;//space.Width - radio-3;
                

                vxx = 0.5f;//-.5f;
                vyy = 0.5f;//.75f;
            }

            if ((y - radio) <= 0 || (y + radio) >= space.Height)
            {
                if (y - radio <= 0)
                    y = radio + 3;
                else
                    x = space.Height - radio - 3;

                vxx *= .75f;
                vyy *= -.55f;
            }

            this.x += this.vxx * deltaTime;
            this.y += this.vyy * deltaTime;
        }

        // Método para manejar colisiones entre pelotas
        public void Collision(Particulas2 otraParticula)
        {
            float distancia = (float)Math.Sqrt(Math.Pow((otraParticula.x - this.x), 2) + Math.Pow((otraParticula.y - this.y), 2));

            if (distancia < (this.radio + otraParticula.radio))//ESTO SIGNIFICA COLISIÓN...
            {
                // Calculamos las velocidades finales de cada pelota en función de su masa y velocidad inicial
                float masaTotal = this.radio + otraParticula.radio;
                float masaRelativa = this.radio / masaTotal;

                float v1fx = this.vxx - masaRelativa * (this.vxx - otraParticula.vxx) / 100;
                float v1fy = this.vyy - masaRelativa * (this.vyy - otraParticula.vyy) / 100;

                float v2fx = otraParticula.vxx - masaRelativa * (otraParticula.vxx - this.vxx) / 100;
                float v2fy = otraParticula.vyy - masaRelativa * (otraParticula.vyy - this.vyy) / 100;

                // Actualizamos las velocidades de las pelotas
                this.vxx = v1fx;     // -----AQUI CAMBIAMOS EL ANGULO---------
                this.vyy = v1fy;     // -----AQUI CAMBIAMOS EL ANGULO--------------

                otraParticula.vxx = v2fx;//-----AQUI CAMBIAMOS EL ANGULO----------------------
                otraParticula.vyy = v2fy;//-----AQUI CAMBIAMOS EL ANGULO----------------------

                // Movemos las pelotas para evitar que se superpongan
                float distanciaOverlap = (this.radio + otraParticula.radio) - distancia;
                float dx = (this.x - otraParticula.x) / distancia;
                float dy = (this.y - otraParticula.y) / distancia;

                this.x += dx * distanciaOverlap / 2f;
                this.y += dy * distanciaOverlap / 2f;

                otraParticula.x -= dx * distanciaOverlap / 2f;
                otraParticula.y -= dy * distanciaOverlap / 2f;
            }
        }

    }
}
