
namespace VistaFabrica
{
    partial class frmFabricarVistaPrevia
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
            this.lblClasico = new System.Windows.Forms.Label();
            this.lblSol = new System.Windows.Forms.Label();
            this.lblGraduacion = new System.Windows.Forms.Label();
            this.btnConAumento = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblClasico
            // 
            this.lblClasico.AutoSize = true;
            this.lblClasico.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClasico.Location = new System.Drawing.Point(75, 211);
            this.lblClasico.Name = "lblClasico";
            this.lblClasico.Size = new System.Drawing.Size(77, 25);
            this.lblClasico.TabIndex = 5;
            this.lblClasico.Text = "Clasico";
            // 
            // lblSol
            // 
            this.lblSol.AutoSize = true;
            this.lblSol.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSol.Location = new System.Drawing.Point(341, 211);
            this.lblSol.Name = "lblSol";
            this.lblSol.Size = new System.Drawing.Size(71, 25);
            this.lblSol.TabIndex = 6;
            this.lblSol.Text = "De Sol";
            // 
            // lblGraduacion
            // 
            this.lblGraduacion.AutoSize = true;
            this.lblGraduacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGraduacion.Location = new System.Drawing.Point(585, 211);
            this.lblGraduacion.Name = "lblGraduacion";
            this.lblGraduacion.Size = new System.Drawing.Size(133, 25);
            this.lblGraduacion.TabIndex = 7;
            this.lblGraduacion.Text = "Con Aumento";
            // 
            // btnConAumento
            // 
            this.btnConAumento.Image = global::VistaFabrica.Properties.Resources.Single_E_Test_Card;
            this.btnConAumento.Location = new System.Drawing.Point(534, 12);
            this.btnConAumento.Name = "btnConAumento";
            this.btnConAumento.Size = new System.Drawing.Size(229, 196);
            this.btnConAumento.TabIndex = 4;
            this.btnConAumento.UseVisualStyleBackColor = true;
            this.btnConAumento.Click += new System.EventHandler(this.btnConAumento_Click);
            // 
            // button1
            // 
            this.button1.Image = global::VistaFabrica.Properties.Resources.DeSol;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(272, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(229, 196);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Image = global::VistaFabrica.Properties.Resources.clasicoo;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(12, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(229, 196);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmFabricarVistaPrevia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 252);
            this.Controls.Add(this.lblGraduacion);
            this.Controls.Add(this.lblSol);
            this.Controls.Add(this.lblClasico);
            this.Controls.Add(this.btnConAumento);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFabricarVistaPrevia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFabricarVistaPrevia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnConAumento;
        private System.Windows.Forms.Label lblClasico;
        private System.Windows.Forms.Label lblSol;
        private System.Windows.Forms.Label lblGraduacion;
    }
}