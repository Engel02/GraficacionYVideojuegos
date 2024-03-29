﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data.SqlTypes;

namespace Pelotas
{
    public class Pelota
    {
        int index;
        Size space;
        public Color c;
        // Variables de posición
        public float x;
        public float y;

        // Variables de velocidad
        private float vx;
        private float vy;

        // Variable de radio
        public float radio;
        public float radio2;
        public float colorRand;
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
        public Pelota(Random rand,Size size, int index)
        {
            
            this.radio  = rand.Next(2, 5);
            this.radio2= rand.Next(99, 100);
            this.colorRand =  rand.Next(253, 254);
            //this.enX = rand.Next(1,2);
            //this.enY = rand.Next(1,2);
            this.x = rand.Next((int)radio2); //rand.Next((int)radio , size.Width - (int)radio );
            this.y = rand.Next((int)radio); //, size.Height - (int)radio );
            c = Color.FromArgb(rand.Next((int)colorRand), 0, 0);
            //Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            // Velocidades iniciales
            this.vx = 1;//rand.Next((int)-radio, (int)radio);
            this.vy = 1;//rand.Next((int)-radio, (int)radio);

            this.index = index;
            space = size;
        }

     

        // Método para actualizar la posición de la pelota en función de su velocidad
        public void Update(float deltaTime, List<Pelota> balls)
        {
            for (int b = index + 1; b < balls.Count; b++)
            {
                Collision(balls[b]);
            }

            if ((x - radio) <= 0 || (x + radio) >= space.Width)
            {
                if (x - radio <= 0)
                    x = radio + 3;
                else
                    x = 120;//space.Width - radio-3;
                y = 50;

                vx = 0.5f;//-.5f;
                vy = 0.5f;//.75f;
            }

            if ((y - radio) <= 0 || (y + radio) >= space.Height)
            {
                if (y - radio<=  0)
                    y = radio + 3;
                else
                    x = space.Height - radio-3;

                vx *=  .75f;
                vy *= -.55f;
            }

            this.x += this.vx * deltaTime;
            this.y += this.vy * deltaTime;
        }

        // Método para manejar colisiones entre pelotas
        public void Collision(Pelota otraPelota)
        {
            float distancia = (float)Math.Sqrt(Math.Pow((otraPelota.x - this.x), 2) + Math.Pow((otraPelota.y - this.y), 2));

            if (distancia < (this.radio + otraPelota.radio))//ESTO SIGNIFICA COLISIÓN...
            {
                // Calculamos las velocidades finales de cada pelota en función de su masa y velocidad inicial
                float masaTotal = this.radio + otraPelota.radio;
                float masaRelativa = this.radio / masaTotal;

                float v1fx = this.vx - masaRelativa * (this.vx - otraPelota.vx) / 100;
                float v1fy = this.vy - masaRelativa * (this.vy - otraPelota.vy) / 100;

                float v2fx = otraPelota.vx - masaRelativa * (otraPelota.vx - this.vx) / 100;
                float v2fy = otraPelota.vy - masaRelativa * (otraPelota.vy - this.vy) / 100;

                // Actualizamos las velocidades de las pelotas
                this.vx = v1fx;     // -----AQUI CAMBIAMOS EL ANGULO---------
                this.vy = v1fy;     // -----AQUI CAMBIAMOS EL ANGULO--------------

                otraPelota.vx = v2fx;//-----AQUI CAMBIAMOS EL ANGULO----------------------
                otraPelota.vy = v2fy;//-----AQUI CAMBIAMOS EL ANGULO----------------------

                // Movemos las pelotas para evitar que se superpongan
                float distanciaOverlap = (this.radio + otraPelota.radio) - distancia;
                float dx = (this.x - otraPelota.x) / distancia;
                float dy = (this.y - otraPelota.y) / distancia;

                this.x += dx * distanciaOverlap / 2f;
                this.y += dy * distanciaOverlap / 2f;

                otraPelota.x -= dx * distanciaOverlap / 2f;
                otraPelota.y -= dy * distanciaOverlap / 2f;
            }
        }

    }

}
