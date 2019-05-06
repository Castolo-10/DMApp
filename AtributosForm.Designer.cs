namespace DMApp
{
    partial class AtributosForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nombretextBox = new System.Windows.Forms.TextBox();
            this.tipotextBox = new System.Windows.Forms.TextBox();
            this.ertextBox = new System.Windows.Forms.TextBox();
            this.salvarbutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Expresión regular";
            // 
            // nombretextBox
            // 
            this.nombretextBox.Location = new System.Drawing.Point(15, 31);
            this.nombretextBox.Name = "nombretextBox";
            this.nombretextBox.Size = new System.Drawing.Size(113, 20);
            this.nombretextBox.TabIndex = 4;
            this.nombretextBox.TextChanged += new System.EventHandler(this.NombretextBox_TextChanged);
            // 
            // tipotextBox
            // 
            this.tipotextBox.Location = new System.Drawing.Point(15, 84);
            this.tipotextBox.Name = "tipotextBox";
            this.tipotextBox.Size = new System.Drawing.Size(113, 20);
            this.tipotextBox.TabIndex = 5;
            // 
            // ertextBox
            // 
            this.ertextBox.Location = new System.Drawing.Point(15, 135);
            this.ertextBox.Name = "ertextBox";
            this.ertextBox.Size = new System.Drawing.Size(113, 20);
            this.ertextBox.TabIndex = 6;
            // 
            // salvarbutton
            // 
            this.salvarbutton.Location = new System.Drawing.Point(203, 132);
            this.salvarbutton.Name = "salvarbutton";
            this.salvarbutton.Size = new System.Drawing.Size(75, 23);
            this.salvarbutton.TabIndex = 7;
            this.salvarbutton.Text = "Salvar";
            this.salvarbutton.UseVisualStyleBackColor = true;
            this.salvarbutton.Click += new System.EventHandler(this.Salvarbutton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(203, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Eliminar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // AtributosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 184);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.salvarbutton);
            this.Controls.Add(this.ertextBox);
            this.Controls.Add(this.tipotextBox);
            this.Controls.Add(this.nombretextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "AtributosForm";
            this.Text = "Edición de Atributo";
            this.Load += new System.EventHandler(this.AtributosForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nombretextBox;
        private System.Windows.Forms.TextBox tipotextBox;
        private System.Windows.Forms.TextBox ertextBox;
        private System.Windows.Forms.Button salvarbutton;
        private System.Windows.Forms.Button button1;
    }
}