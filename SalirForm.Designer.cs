namespace DMApp
{
    partial class SalirForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Nobutton = new System.Windows.Forms.Button();
            this.Guardarbutton = new System.Windows.Forms.Button();
            this.Guardarcomobutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Deseas conservar los últimos cambios?";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // Nobutton
            // 
            this.Nobutton.Location = new System.Drawing.Point(12, 82);
            this.Nobutton.Name = "Nobutton";
            this.Nobutton.Size = new System.Drawing.Size(96, 24);
            this.Nobutton.TabIndex = 1;
            this.Nobutton.Text = "Salir sin guardar";
            this.Nobutton.UseVisualStyleBackColor = true;
            this.Nobutton.Click += new System.EventHandler(this.Nobutton_Click);
            // 
            // Guardarbutton
            // 
            this.Guardarbutton.Location = new System.Drawing.Point(169, 82);
            this.Guardarbutton.Name = "Guardarbutton";
            this.Guardarbutton.Size = new System.Drawing.Size(68, 24);
            this.Guardarbutton.TabIndex = 2;
            this.Guardarbutton.Text = "Guardar";
            this.Guardarbutton.UseVisualStyleBackColor = true;
            this.Guardarbutton.Click += new System.EventHandler(this.Guardarbutton_Click);
            // 
            // Guardarcomobutton
            // 
            this.Guardarcomobutton.Location = new System.Drawing.Point(291, 82);
            this.Guardarcomobutton.Name = "Guardarcomobutton";
            this.Guardarcomobutton.Size = new System.Drawing.Size(96, 24);
            this.Guardarcomobutton.TabIndex = 3;
            this.Guardarcomobutton.Text = "Guardar como";
            this.Guardarcomobutton.UseVisualStyleBackColor = true;
            this.Guardarcomobutton.Click += new System.EventHandler(this.Guardarcomobutton_Click);
            // 
            // SalirForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 136);
            this.Controls.Add(this.Guardarcomobutton);
            this.Controls.Add(this.Guardarbutton);
            this.Controls.Add(this.Nobutton);
            this.Controls.Add(this.label1);
            this.Name = "SalirForm";
            this.Text = "SalirForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Nobutton;
        private System.Windows.Forms.Button Guardarbutton;
        private System.Windows.Forms.Button Guardarcomobutton;
    }
}