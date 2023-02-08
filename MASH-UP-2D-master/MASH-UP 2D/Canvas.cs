using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Resources.ResXFileRef;

namespace MASH_UP_2D
{
    public class Canvas
    {
        static Bitmap bmp,img;
        static Graphics g;
        PictureBox lienzo, newlienzo;
        public byte[] bits;


        public Canvas(PictureBox lienzo) 
        {
            this.lienzo = lienzo;
            bmp = new Bitmap(lienzo.Width, lienzo.Height);
            Init();
        }

        private void Init()
        {
            g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            lienzo.Image = bmp;
            lienzo.Invalidate();
        }

        public void Copycanvas()
        {
            newlienzo= new PictureBox();
            img = new Bitmap(lienzo.Width, lienzo.Height);
            Graphics h = Graphics.FromImage(img);
            newlienzo.Image= img;
            newlienzo.Image = (Image)lienzo.Image.Clone();
            h.Dispose();

        }

        public void showcanvas(Escena escena)
        {
            

            lienzo = new PictureBox();
            //bmp = new Bitmap(lienzo.Width, lienzo.Height);
            //Init();
            //lienzo.Image = bmp;
            //lienzo.Invalidate();


           // g.DrawImage(newlienzo.Image, 0, 0);

        }


        public void UpdateCanvas(Escena escena)
        {

            escena.Figures = new List<Figure>();


            for (int f = 0; f < escena.FiguresGuardadas.Count; f++)
            {
                escena.Figures.Add(escena.FiguresGuardadas[f]);
            }


            for (int f = 0; f < escena.Figures.Count; f++)
            {
                if (escena.Figures[f].puntos.Count > 1)
                {
                    g.FillPolygon(Brushes.Gray, escena.Figures[f].puntos.ToArray());
                    g.DrawPolygon(Pens.White, escena.Figures[f].puntos.ToArray());
                    g.FillEllipse(Brushes.Red,escena.Figures[f].puntos[escena.Figures[f].puntos.Count - 1].X - 3, escena.Figures[f].puntos[escena.Figures[f].puntos.Count - 1].Y - 3, 6, 6);
                    g.FillEllipse(Brushes.Blue, escena.Figures[f].centroid.X - 3, escena.Figures[f].centroid.Y - 3, 6, 6);
                }
            }
            lienzo.Invalidate();
        }

        private void FastClear()
        {
           unsafe
           {
                BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                Parallel.For(0, heightInPixels, y =>
                {
                    byte* bits = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        bits[x + 0] = 0;// (byte)oldBlue;
                        bits[x + 1] = 0;// (byte)oldGreen;
                        bits[x + 2] = 0;// (byte)oldRed;
                        bits[x + 3] = 0;// (byte)oldRed;
                    }
                });
                bmp.UnlockBits(bitmapData);
            }
            lienzo.Invalidate();
        }

        public void drawPolygon(Escena escena)
        {

            FastClear();

            for (int f = 0; f < escena.Figures.Count; f++)
            {
                if (escena.Figures[f].puntos.Count > 1)
                {
                    g.FillPolygon(Brushes.Gray, escena.Figures[f].puntos.ToArray());
                    g.DrawPolygon(Pens.White, escena.Figures[f].puntos.ToArray());
                    g.FillEllipse(Brushes.Red, escena.Figures[f].puntos[escena.Figures[f].puntos.Count - 1].X - 3, escena.Figures[f].puntos[escena.Figures[f].puntos.Count - 1].Y - 3, 6, 6);
                    g.FillEllipse(Brushes.Blue, escena.Figures[f].centroid.X - 3, escena.Figures[f].centroid.Y - 3, 6, 6);//*/
                }
            }
            lienzo.Invalidate();
             

        }

    }
}
