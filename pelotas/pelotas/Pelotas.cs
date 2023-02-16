using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pelotas
{
    public class Pelotas
    {
        private float x;
        private float y;
        private float radius;
        private float speedX;
        private float speedY;

        


        public Pelotas(float x, float y, float radius, float speedX, float speedY)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
            this.speedX = speedX;
            this.speedY = speedY;
        }

        public void Update(float screenWidth, float screenHeight, Pelotas[] balls, int index)
        {



            // Mover la pelota
            x += speedX;
            y += speedY;

            // Rebotar en los bordes
            if (x - radius < 0 || x + radius > screenWidth)
            {
                speedX = -speedX;
            }
            if (y - radius < 0 || y + radius > screenHeight)
            {
                speedY = -speedY;
            }

            // Comprobar colisión con otras pelotas
            for (int i = 0; i < balls.Length; i++)
            {
                if (i != index)
                {
                    Pelotas other = balls[i];
                    float dx = x - other.x;
                    float dy = y - other.y;
                    float distance = (float)Math.Sqrt(dx * dx + dy * dy);
                    if (distance < radius + other.radius)
                    {
                        // Colisión detectada, invertir las velocidades
                        float tempX = speedX;
                        float tempY = speedY;
                        speedX = other.speedX;
                        speedY = other.speedY;
                        other.speedX = tempX;
                        other.speedY = tempY;
                    }
                }
            }
        }


        public void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Red, x - radius, y - radius, radius * 2, radius * 2);
        }
    }
}
