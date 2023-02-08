using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MASH_UP_2D
{
    public partial class FormAnimacionDeFiguras : Form
    {
        
        //Base
        Figure figure;
        Canvas c;     
        Escena escena;

        //Posiciones de Mouse
        bool mouseDown = false;
        bool mouseDownY = false;
        bool ButtonPress = false;
        Point ptX, ptY, mouse;

        //Cambios
        float deltaX = 0;
        float deltaY = 1;

        //Animacion
        private bool play = false;

        public FormAnimacionDeFiguras()
        {
            InitializeComponent();
            escena = new Escena();
            c = new Canvas(canvas);
            mouseDown = false;

            labelFrames.Text = "FRAME: " + scrollAnimacion.Value + "/" + scrollAnimacion.Maximum;
        }


      
        private void botonNuevaFigura_Click(object sender, EventArgs e)
        {
            NuevaFigura();
        }
        private void treeFiguras_AfterSelect(object sender, TreeViewEventArgs e)
        {
            figure = (Figure)treeFiguras.SelectedNode.Tag;
            botonNuevaFigura.Select();
        }

        private void NuevaFigura()
        {
            figure = new Figure(this);
            escena.Figures.Add(figure);
            TreeNode node = new TreeNode("Fig" + (treeFiguras.Nodes.Count + 1));
            node.Tag = figure;
            treeFiguras.Nodes.Add(node);
            treeFiguras.SelectedNode = node;
        }
        

        //Canvas
        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                figure.UpdateCentroid(e.Location.X, e.Location.Y);
            }
        }

        private void canvas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (figure == null)
                NuevaFigura();

            figure.AddFigure(new PointF(e.X, e.Y));
                
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = e.Location;
            mouseDown = true;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown && figure != null)
            {
                mouse.X -= e.X;
                mouse.Y -= e.Y;
                figure.TranslatePoints(new Point(-mouse.X, -mouse.Y));
                figure.UpdateAttributes(); 
                mouse = e.Location;
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            canvas.Select();
        }


        //-----------TRANSFOMRACIONES
        //Escala
        private void scrollEscala_MouseDown(object sender, MouseEventArgs e)
        {
            ptY = e.Location;
            mouseDownY = true;
        }

        private void scrollEscala_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownY && scrollEscala.Value <= scrollEscala.Maximum - 1 && scrollEscala.Value >= scrollEscala.Minimum + 1) //Deja de funcionar si pasas por afuera de la barra con el mouse
            {
                deltaY += (float)(ptY.Y - e.Location.Y) / 300;//------------------ //Si quieres una escala mas potente modifica ese 300 entre mas pequeño mas crece
                ptY.Y = e.Location.Y;
            }
        }

        private void scrollEscala_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownY = false;
            scrollEscala.Value = 0; //Regresa al centor cuando lo soltemos
        }

        //Rotacion
        private void scrollRotacion_MouseDown(object sender, MouseEventArgs e)
        {
            ptX = e.Location;
            mouseDown = true;

        }

        private void scrollRotacion_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown && scrollRotacion.Value <= scrollRotacion.Maximum - 1 && scrollRotacion.Value >= scrollRotacion.Minimum + 1)//Deja de funcionar si pasas por afuera de la barra con el mouse
            {
                deltaX += (float)(e.Location.X - ptX.X) / 1;//------------------
                figure.rotacionActual += (float)(e.Location.X - ptX.X) / 1; 
                ptX.X = e.Location.X;
            }

        }

        private void scrollRotacion_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            scrollRotacion.Value = 0; 
        }


        //-----------Animación

        //Acutalizaciones
        private void temporizador_Tick(object sender, EventArgs e)
        {
            if (figure != null) 
            {
                figure.TranslateToOrigin();
                figure.Scale(deltaY);
                figure.RotatePuntos(deltaX);
                figure.TranslatePoints(figure.centroid);

                figure.escalaActual *= deltaY; 
            }

            deltaX = 0;
            deltaY = 1;

            if (ButtonPress)
            {
                c.showcanvas(escena);

            }

            c.drawPolygon(escena);

            ButtonPress = false;

            if(play)
            {
                if (scrollAnimacion.Value < scrollAnimacion.Maximum && !checkReverse.Checked)
                {
                    scrollAnimacion.Value++;
                    ObtenerAnimacion();
                }

                else if (scrollAnimacion.Value > 0 && checkReverse.Checked)
                {
                    scrollAnimacion.Value--;
                    ObtenerAnimacion(); 
                }

                else
                    checkReverse.Checked = !checkReverse.Checked;
            }
        }

        private void actualizacionContinua(Figure figuraSeleccionada, float x, float y) 
        {

            if (figuraSeleccionada != null)
            {
                figuraSeleccionada.TranslateToOrigin();
                figuraSeleccionada.Scale(1 / figuraSeleccionada.escalaActual); 
                figuraSeleccionada.escalaActual *= 1 / figuraSeleccionada.escalaActual;
                figuraSeleccionada.Scale(y); 
                figuraSeleccionada.RotatePuntos(-figuraSeleccionada.rotacionActual + x); 
                figuraSeleccionada.rotacionActual = x; 
                figuraSeleccionada.escalaActual = y; 
                figuraSeleccionada.TranslatePoints(figuraSeleccionada.centroid);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (figure == null)
                return false;

            if (keyData == Keys.Space)
            {
                figure.UpdateAttributes();
            }
            canvas.Select();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //Scroll Animacion
        private void scrollAnimacion_Scroll(object sender, EventArgs e)
        {
            ObtenerAnimacion(); //Lo mismo que el play pero cuando movamos manualmente la animación
        }

        private void ObtenerAnimacion()
        {
            labelFrames.Text = "FRAME: " + scrollAnimacion.Value + "/" + scrollAnimacion.Maximum;
            if (checkAnimarFiguras.Checked) //Si queremos ver todas las animaciones de las figuras a la vez
                AnimarTodas();

            else //O ver una por una, solo la figura seleccionada
                AnimarFigura(figure);
        }

        private void AnimarTodas()
        {
            foreach (Figure figuraIndividual in escena.Figures) //para cada figura existente
            {
                AnimarFigura(figuraIndividual); //La misma función cada figura
            }
        }

        private void AnimarFigura(Figure figuraSeleccionada)
        {
            int inicio = -1; //Guardaremos el primer frame que tenga algo guardado
            int final = -1; //Guardaremos el ultimo frame que tenga algo guardado
            float valor; //La posicion en la que estamos entre el inicial y el final, del 0 al 1 (algo asi como un porcentaje)

            float rotationAngle; //Cuanto va a rotar este frame
            float scaleFactor; //Cuanto va a escalar

            if (escena.Figures.Count == 0) 
                return;

            if (figuraSeleccionada.animFramesGuardados[scrollAnimacion.Value]) 
                return;

            else
            {
                for (int i = scrollAnimacion.Value; i >= 0; i--) //Recorreremos todos los frames desde el que estamos hacia atras a ver cual es el que se encuentra guardado mas cercano
                {
                    if (figuraSeleccionada.animFramesGuardados[i])
                    {
                        inicio = i;

                        break;
                    }
                }

                for (int i = scrollAnimacion.Value; i <= figuraSeleccionada.animPosiciones.Length - 1; i++) //Recorreremos todos los frames desde el que estamos hacia adeltabe a ver cual es el que se encuentra guardado mas cercano
                {
                    if (figuraSeleccionada.animFramesGuardados[i])
                    {
                        final = i;
                        break;
                    }
                }
            }

            if (inicio != -1 && final != -1) //Ya que verifiquemos que hay uno inicial y un final
            {
                
                valor = ((float)scrollAnimacion.Value - inicio) / (final - inicio); //obtenemos el porcentaje de en que posicion me encuentro del inicio al final

                rotationAngle = ((figuraSeleccionada.animRotaciones[final] - figuraSeleccionada.animRotaciones[inicio]) * valor) + figuraSeleccionada.animRotaciones[inicio]; //la rotacion guardada en el frame siguiente (guardado), menos la rotacion del frame anterior (guardado) podemos obtener cuantos grados hay entre ellos. Luego obtejemos el valor del punto en el que estamos con el porcentaje. Finalmente le sumamos los grados del inicio para poder obtener la rotacion inicial
                scaleFactor = ((figuraSeleccionada.animEscalas[final] - figuraSeleccionada.animEscalas[inicio]) * valor) + figuraSeleccionada.animEscalas[inicio];

                figuraSeleccionada.Follow(figuraSeleccionada.animPosiciones[inicio], figuraSeleccionada.animPosiciones[final], valor); //Para seguir al punto que sigue (Código de tu profesor)
                actualizacionContinua(figuraSeleccionada, rotationAngle, scaleFactor); //En vez de esperar al tick, guardamos nuestros valores manualmente
            }
        }

        private void FormAnimacionDeFiguras_Load(object sender, EventArgs e)
        {

        }



        //-----------Guardado y reproducción
        private void buttonGuardarFrame_Click(object sender, EventArgs e)
        {
            //Guarda toda la información en Arrays
            figure.animFramesGuardados[scrollAnimacion.Value] = true;
            figure.animPosiciones[scrollAnimacion.Value] = figure.centroid;
            figure.animRotaciones[scrollAnimacion.Value] = figure.rotacionActual;
            figure.animEscalas[scrollAnimacion.Value] = figure.escalaActual;
        }

        private void buttonReproducir_Click(object sender, EventArgs e)
        {
            //Cambia si reproducir o no
            play = !play;

            if (play)
                buttonReproducir.Text = "PAUSA";

            else
                buttonReproducir.Text = "PLAY";
        }
    }
}
