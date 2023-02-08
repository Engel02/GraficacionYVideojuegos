namespace MASH_UP_2D
{
    partial class FormAnimacionDeFiguras
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.treeFiguras = new System.Windows.Forms.TreeView();
            this.scrollRotacion = new System.Windows.Forms.TrackBar();
            this.botonNuevaFigura = new System.Windows.Forms.Button();
            this.buttonReproducir = new System.Windows.Forms.Button();
            this.temporizador = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.scrollEscala = new System.Windows.Forms.TrackBar();
            this.labelRotacion = new System.Windows.Forms.Label();
            this.labelEscala = new System.Windows.Forms.Label();
            this.buttonGuardarFrame = new System.Windows.Forms.Button();
            this.scrollAnimacion = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.checkAnimarFiguras = new System.Windows.Forms.CheckBox();
            this.checkReverse = new System.Windows.Forms.CheckBox();
            this.labelFrames = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollRotacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollEscala)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollAnimacion)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.canvas.Location = new System.Drawing.Point(209, 66);
            this.canvas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(684, 394);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
            this.canvas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDoubleClick);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // treeFiguras
            // 
            this.treeFiguras.BackColor = System.Drawing.Color.LightGray;
            this.treeFiguras.Location = new System.Drawing.Point(36, 66);
            this.treeFiguras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeFiguras.Name = "treeFiguras";
            this.treeFiguras.Size = new System.Drawing.Size(152, 245);
            this.treeFiguras.TabIndex = 1;
            this.treeFiguras.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFiguras_AfterSelect);
            // 
            // scrollRotacion
            // 
            this.scrollRotacion.BackColor = System.Drawing.Color.Black;
            this.scrollRotacion.Location = new System.Drawing.Point(209, 452);
            this.scrollRotacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.scrollRotacion.Maximum = 18;
            this.scrollRotacion.Minimum = -18;
            this.scrollRotacion.Name = "scrollRotacion";
            this.scrollRotacion.RightToLeftLayout = true;
            this.scrollRotacion.Size = new System.Drawing.Size(684, 56);
            this.scrollRotacion.TabIndex = 2;
            this.scrollRotacion.TickFrequency = 6;
            this.scrollRotacion.TickStyle = System.Windows.Forms.TickStyle.None;
            this.scrollRotacion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scrollRotacion_MouseDown);
            this.scrollRotacion.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scrollRotacion_MouseMove);
            this.scrollRotacion.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scrollRotacion_MouseUp);
            // 
            // botonNuevaFigura
            // 
            this.botonNuevaFigura.Location = new System.Drawing.Point(60, 347);
            this.botonNuevaFigura.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botonNuevaFigura.Name = "botonNuevaFigura";
            this.botonNuevaFigura.Size = new System.Drawing.Size(81, 38);
            this.botonNuevaFigura.TabIndex = 3;
            this.botonNuevaFigura.Text = "AÑADIR";
            this.botonNuevaFigura.UseVisualStyleBackColor = true;
            this.botonNuevaFigura.Click += new System.EventHandler(this.botonNuevaFigura_Click);
            // 
            // buttonReproducir
            // 
            this.buttonReproducir.Location = new System.Drawing.Point(60, 437);
            this.buttonReproducir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonReproducir.Name = "buttonReproducir";
            this.buttonReproducir.Size = new System.Drawing.Size(81, 43);
            this.buttonReproducir.TabIndex = 4;
            this.buttonReproducir.Text = "PLAY";
            this.buttonReproducir.UseVisualStyleBackColor = true;
            this.buttonReproducir.Click += new System.EventHandler(this.buttonReproducir_Click);
            // 
            // temporizador
            // 
            this.temporizador.Enabled = true;
            this.temporizador.Interval = 40;
            this.temporizador.Tick += new System.EventHandler(this.temporizador_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(608, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 5;
            // 
            // scrollEscala
            // 
            this.scrollEscala.BackColor = System.Drawing.Color.Black;
            this.scrollEscala.Location = new System.Drawing.Point(888, 66);
            this.scrollEscala.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.scrollEscala.Maximum = 20;
            this.scrollEscala.Minimum = -20;
            this.scrollEscala.Name = "scrollEscala";
            this.scrollEscala.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.scrollEscala.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.scrollEscala.Size = new System.Drawing.Size(56, 394);
            this.scrollEscala.TabIndex = 6;
            this.scrollEscala.TickFrequency = 4;
            this.scrollEscala.TickStyle = System.Windows.Forms.TickStyle.None;
            this.scrollEscala.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scrollEscala_MouseDown);
            this.scrollEscala.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scrollEscala_MouseMove);
            this.scrollEscala.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scrollEscala_MouseUp);
            // 
            // labelRotacion
            // 
            this.labelRotacion.AutoSize = true;
            this.labelRotacion.BackColor = System.Drawing.Color.Black;
            this.labelRotacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelRotacion.ForeColor = System.Drawing.Color.White;
            this.labelRotacion.Location = new System.Drawing.Point(511, 479);
            this.labelRotacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRotacion.Name = "labelRotacion";
            this.labelRotacion.Size = new System.Drawing.Size(109, 24);
            this.labelRotacion.TabIndex = 7;
            this.labelRotacion.Text = "ROTACIÓN";
            // 
            // labelEscala
            // 
            this.labelEscala.AutoSize = true;
            this.labelEscala.BackColor = System.Drawing.Color.Black;
            this.labelEscala.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelEscala.ForeColor = System.Drawing.SystemColors.Control;
            this.labelEscala.Location = new System.Drawing.Point(916, 207);
            this.labelEscala.Name = "labelEscala";
            this.labelEscala.Size = new System.Drawing.Size(23, 144);
            this.labelEscala.TabIndex = 8;
            this.labelEscala.Text = "E\r\nS\r\nC\r\nA\r\nL\r\nA";
            // 
            // buttonGuardarFrame
            // 
            this.buttonGuardarFrame.Location = new System.Drawing.Point(60, 390);
            this.buttonGuardarFrame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGuardarFrame.Name = "buttonGuardarFrame";
            this.buttonGuardarFrame.Size = new System.Drawing.Size(81, 42);
            this.buttonGuardarFrame.TabIndex = 9;
            this.buttonGuardarFrame.Text = "NUEVO FRAME";
            this.buttonGuardarFrame.UseVisualStyleBackColor = true;
            this.buttonGuardarFrame.Click += new System.EventHandler(this.buttonGuardarFrame_Click);
            // 
            // scrollAnimacion
            // 
            this.scrollAnimacion.Location = new System.Drawing.Point(209, 10);
            this.scrollAnimacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.scrollAnimacion.Maximum = 500;
            this.scrollAnimacion.Name = "scrollAnimacion";
            this.scrollAnimacion.Size = new System.Drawing.Size(740, 56);
            this.scrollAnimacion.TabIndex = 10;
            this.scrollAnimacion.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.scrollAnimacion.Scroll += new System.EventHandler(this.scrollAnimacion_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(557, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 11;
            // 
            // checkAnimarFiguras
            // 
            this.checkAnimarFiguras.AutoSize = true;
            this.checkAnimarFiguras.Location = new System.Drawing.Point(36, 319);
            this.checkAnimarFiguras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkAnimarFiguras.Name = "checkAnimarFiguras";
            this.checkAnimarFiguras.Size = new System.Drawing.Size(131, 20);
            this.checkAnimarFiguras.TabIndex = 12;
            this.checkAnimarFiguras.Text = "ANIMAR TODAS";
            this.checkAnimarFiguras.UseVisualStyleBackColor = true;
            // 
            // checkReverse
            // 
            this.checkReverse.AutoSize = true;
            this.checkReverse.Location = new System.Drawing.Point(16, 486);
            this.checkReverse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkReverse.Name = "checkReverse";
            this.checkReverse.Size = new System.Drawing.Size(171, 20);
            this.checkReverse.TabIndex = 13;
            this.checkReverse.Text = "ANIMACION REVERSA";
            this.checkReverse.UseVisualStyleBackColor = true;
            // 
            // labelFrames
            // 
            this.labelFrames.AutoSize = true;
            this.labelFrames.Location = new System.Drawing.Point(479, 42);
            this.labelFrames.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFrames.Name = "labelFrames";
            this.labelFrames.Size = new System.Drawing.Size(66, 16);
            this.labelFrames.TabIndex = 14;
            this.labelFrames.Text = "FRAMES:";
            // 
            // FormAnimacionDeFiguras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(999, 575);
            this.Controls.Add(this.labelFrames);
            this.Controls.Add(this.checkReverse);
            this.Controls.Add(this.checkAnimarFiguras);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.scrollAnimacion);
            this.Controls.Add(this.buttonGuardarFrame);
            this.Controls.Add(this.labelEscala);
            this.Controls.Add(this.labelRotacion);
            this.Controls.Add(this.scrollEscala);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonReproducir);
            this.Controls.Add(this.botonNuevaFigura);
            this.Controls.Add(this.scrollRotacion);
            this.Controls.Add(this.treeFiguras);
            this.Controls.Add(this.canvas);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormAnimacionDeFiguras";
            this.Text = "FormAnimacionDeFiguras";
            this.Load += new System.EventHandler(this.FormAnimacionDeFiguras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollRotacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollEscala)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollAnimacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.TreeView treeFiguras;
        private System.Windows.Forms.TrackBar scrollRotacion;
        private System.Windows.Forms.Button botonNuevaFigura;
        private System.Windows.Forms.Button buttonReproducir;
        private System.Windows.Forms.Timer temporizador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar scrollEscala;
        private System.Windows.Forms.Label labelRotacion;
        private System.Windows.Forms.Label labelEscala;
        private System.Windows.Forms.Button buttonGuardarFrame;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkAnimarFiguras;
        public System.Windows.Forms.TrackBar scrollAnimacion;
        private System.Windows.Forms.CheckBox checkReverse;
        private System.Windows.Forms.Label labelFrames;
    }
}

