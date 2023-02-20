namespace Motor__Grafico3
{
    partial class Perspective3D
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
            this.pictureBoxDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonRotarX = new System.Windows.Forms.Button();
            this.buttonRotarY = new System.Windows.Forms.Button();
            this.buttonRotarZ = new System.Windows.Forms.Button();
            this.buttonRotarXYZ = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxDisplay
            // 
            this.pictureBoxDisplay.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxDisplay.Location = new System.Drawing.Point(169, 33);
            this.pictureBoxDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxDisplay.Name = "pictureBoxDisplay";
            this.pictureBoxDisplay.Size = new System.Drawing.Size(1093, 507);
            this.pictureBoxDisplay.TabIndex = 1;
            this.pictureBoxDisplay.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonRotarX
            // 
            this.buttonRotarX.BackColor = System.Drawing.Color.Lime;
            this.buttonRotarX.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRotarX.Location = new System.Drawing.Point(451, 586);
            this.buttonRotarX.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRotarX.Name = "buttonRotarX";
            this.buttonRotarX.Size = new System.Drawing.Size(100, 28);
            this.buttonRotarX.TabIndex = 2;
            this.buttonRotarX.Text = "Rotar en X";
            this.buttonRotarX.UseVisualStyleBackColor = false;
            this.buttonRotarX.Click += new System.EventHandler(this.buttonRotarX_Click);
            // 
            // buttonRotarY
            // 
            this.buttonRotarY.BackColor = System.Drawing.Color.Lime;
            this.buttonRotarY.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRotarY.Location = new System.Drawing.Point(664, 586);
            this.buttonRotarY.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRotarY.Name = "buttonRotarY";
            this.buttonRotarY.Size = new System.Drawing.Size(100, 28);
            this.buttonRotarY.TabIndex = 3;
            this.buttonRotarY.Text = "Rotar en Y";
            this.buttonRotarY.UseVisualStyleBackColor = false;
            this.buttonRotarY.Click += new System.EventHandler(this.buttonRotarY_Click);
            // 
            // buttonRotarZ
            // 
            this.buttonRotarZ.BackColor = System.Drawing.Color.Lime;
            this.buttonRotarZ.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRotarZ.Location = new System.Drawing.Point(877, 586);
            this.buttonRotarZ.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRotarZ.Name = "buttonRotarZ";
            this.buttonRotarZ.Size = new System.Drawing.Size(100, 28);
            this.buttonRotarZ.TabIndex = 4;
            this.buttonRotarZ.Text = "Rotar en Z";
            this.buttonRotarZ.UseVisualStyleBackColor = false;
            this.buttonRotarZ.Click += new System.EventHandler(this.buttonRotarZ_Click);
            // 
            // buttonRotarXYZ
            // 
            this.buttonRotarXYZ.BackColor = System.Drawing.Color.Lime;
            this.buttonRotarXYZ.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRotarXYZ.Location = new System.Drawing.Point(649, 637);
            this.buttonRotarXYZ.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRotarXYZ.Name = "buttonRotarXYZ";
            this.buttonRotarXYZ.Size = new System.Drawing.Size(129, 39);
            this.buttonRotarXYZ.TabIndex = 5;
            this.buttonRotarXYZ.Text = "Rotar en XYZ";
            this.buttonRotarXYZ.UseVisualStyleBackColor = false;
            this.buttonRotarXYZ.Click += new System.EventHandler(this.buttonRotarXYZ_Click);
            // 
            // Perspective3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1380, 730);
            this.Controls.Add(this.buttonRotarXYZ);
            this.Controls.Add(this.buttonRotarZ);
            this.Controls.Add(this.buttonRotarY);
            this.Controls.Add(this.buttonRotarX);
            this.Controls.Add(this.pictureBoxDisplay);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Perspective3D";
            this.Text = "3D Perspective";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).EndInit();
            this.ResumeLayout(false);
            //Programmed by Engel
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonRotarX;
        private System.Windows.Forms.Button buttonRotarY;
        private System.Windows.Forms.Button buttonRotarZ;
        private System.Windows.Forms.Button buttonRotarXYZ;
    }
}

