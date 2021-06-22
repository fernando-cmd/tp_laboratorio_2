
namespace Vista
{
    partial class frmFabricarSol
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnFabricar = new System.Windows.Forms.Button();
            this.cmbBoxPolarizado = new System.Windows.Forms.ComboBox();
            this.cmbBoxBlueRay = new System.Windows.Forms.ComboBox();
            this.cmbBoxBiFocal = new System.Windows.Forms.ComboBox();
            this.cmbBoxColor = new System.Windows.Forms.ComboBox();
            this.cmbBoxArmazon = new System.Windows.Forms.ComboBox();
            this.cmbBoxLente = new System.Windows.Forms.ComboBox();
            this.numericCantidad = new System.Windows.Forms.NumericUpDown();
            this.textBoxSerie = new System.Windows.Forms.TextBox();
            this.lblPolarizado = new System.Windows.Forms.Label();
            this.lblBlueRay = new System.Windows.Forms.Label();
            this.lblBifocal = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblArmazon = new System.Windows.Forms.Label();
            this.lblLente = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(351, 98);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(143, 35);
            this.btnSalir.TabIndex = 35;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnFabricar
            // 
            this.btnFabricar.Location = new System.Drawing.Point(178, 98);
            this.btnFabricar.Name = "btnFabricar";
            this.btnFabricar.Size = new System.Drawing.Size(143, 35);
            this.btnFabricar.TabIndex = 34;
            this.btnFabricar.Text = "Fabricar";
            this.btnFabricar.UseVisualStyleBackColor = true;
            this.btnFabricar.Click += new System.EventHandler(this.btnFabricar_Click);
            // 
            // cmbBoxPolarizado
            // 
            this.cmbBoxPolarizado.FormattingEnabled = true;
            this.cmbBoxPolarizado.Location = new System.Drawing.Point(718, 33);
            this.cmbBoxPolarizado.Name = "cmbBoxPolarizado";
            this.cmbBoxPolarizado.Size = new System.Drawing.Size(84, 21);
            this.cmbBoxPolarizado.TabIndex = 33;
            // 
            // cmbBoxBlueRay
            // 
            this.cmbBoxBlueRay.FormattingEnabled = true;
            this.cmbBoxBlueRay.Location = new System.Drawing.Point(601, 33);
            this.cmbBoxBlueRay.Name = "cmbBoxBlueRay";
            this.cmbBoxBlueRay.Size = new System.Drawing.Size(84, 21);
            this.cmbBoxBlueRay.TabIndex = 32;
            // 
            // cmbBoxBiFocal
            // 
            this.cmbBoxBiFocal.FormattingEnabled = true;
            this.cmbBoxBiFocal.Location = new System.Drawing.Point(501, 33);
            this.cmbBoxBiFocal.Name = "cmbBoxBiFocal";
            this.cmbBoxBiFocal.Size = new System.Drawing.Size(84, 21);
            this.cmbBoxBiFocal.TabIndex = 31;
            // 
            // cmbBoxColor
            // 
            this.cmbBoxColor.FormattingEnabled = true;
            this.cmbBoxColor.Location = new System.Drawing.Point(373, 33);
            this.cmbBoxColor.Name = "cmbBoxColor";
            this.cmbBoxColor.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxColor.TabIndex = 30;
            // 
            // cmbBoxArmazon
            // 
            this.cmbBoxArmazon.FormattingEnabled = true;
            this.cmbBoxArmazon.Location = new System.Drawing.Point(268, 33);
            this.cmbBoxArmazon.Name = "cmbBoxArmazon";
            this.cmbBoxArmazon.Size = new System.Drawing.Size(84, 21);
            this.cmbBoxArmazon.TabIndex = 29;
            // 
            // cmbBoxLente
            // 
            this.cmbBoxLente.FormattingEnabled = true;
            this.cmbBoxLente.Location = new System.Drawing.Point(178, 33);
            this.cmbBoxLente.Name = "cmbBoxLente";
            this.cmbBoxLente.Size = new System.Drawing.Size(84, 21);
            this.cmbBoxLente.TabIndex = 28;
            // 
            // numericCantidad
            // 
            this.numericCantidad.Location = new System.Drawing.Point(97, 33);
            this.numericCantidad.Name = "numericCantidad";
            this.numericCantidad.Size = new System.Drawing.Size(75, 20);
            this.numericCantidad.TabIndex = 27;
            // 
            // textBoxSerie
            // 
            this.textBoxSerie.Location = new System.Drawing.Point(12, 33);
            this.textBoxSerie.Name = "textBoxSerie";
            this.textBoxSerie.Size = new System.Drawing.Size(65, 20);
            this.textBoxSerie.TabIndex = 26;
            // 
            // lblPolarizado
            // 
            this.lblPolarizado.AutoSize = true;
            this.lblPolarizado.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPolarizado.Location = new System.Drawing.Point(714, 9);
            this.lblPolarizado.Name = "lblPolarizado";
            this.lblPolarizado.Size = new System.Drawing.Size(98, 21);
            this.lblPolarizado.TabIndex = 25;
            this.lblPolarizado.Text = "Polarizado?";
            // 
            // lblBlueRay
            // 
            this.lblBlueRay.AutoSize = true;
            this.lblBlueRay.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlueRay.Location = new System.Drawing.Point(607, 9);
            this.lblBlueRay.Name = "lblBlueRay";
            this.lblBlueRay.Size = new System.Drawing.Size(78, 21);
            this.lblBlueRay.TabIndex = 24;
            this.lblBlueRay.Text = "BlueRay?";
            // 
            // lblBifocal
            // 
            this.lblBifocal.AutoSize = true;
            this.lblBifocal.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBifocal.Location = new System.Drawing.Point(513, 9);
            this.lblBifocal.Name = "lblBifocal";
            this.lblBifocal.Size = new System.Drawing.Size(72, 21);
            this.lblBifocal.TabIndex = 23;
            this.lblBifocal.Text = "BiFocal?";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(369, 9);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(125, 21);
            this.lblColor.TabIndex = 22;
            this.lblColor.Text = "Color Armazon";
            // 
            // lblArmazon
            // 
            this.lblArmazon.AutoSize = true;
            this.lblArmazon.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArmazon.Location = new System.Drawing.Point(271, 9);
            this.lblArmazon.Name = "lblArmazon";
            this.lblArmazon.Size = new System.Drawing.Size(79, 21);
            this.lblArmazon.TabIndex = 21;
            this.lblArmazon.Text = "Armazon";
            // 
            // lblLente
            // 
            this.lblLente.AutoSize = true;
            this.lblLente.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLente.Location = new System.Drawing.Point(197, 9);
            this.lblLente.Name = "lblLente";
            this.lblLente.Size = new System.Drawing.Size(52, 21);
            this.lblLente.TabIndex = 20;
            this.lblLente.Text = "Lente";
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerie.Location = new System.Drawing.Point(8, 9);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(72, 21);
            this.lblSerie.TabIndex = 19;
            this.lblSerie.Text = "N° Serie";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(93, 9);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(79, 21);
            this.lblCantidad.TabIndex = 18;
            this.lblCantidad.Text = "Cantidad";
            // 
            // frmFabricarSol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 149);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnFabricar);
            this.Controls.Add(this.cmbBoxPolarizado);
            this.Controls.Add(this.cmbBoxBlueRay);
            this.Controls.Add(this.cmbBoxBiFocal);
            this.Controls.Add(this.cmbBoxColor);
            this.Controls.Add(this.cmbBoxArmazon);
            this.Controls.Add(this.cmbBoxLente);
            this.Controls.Add(this.numericCantidad);
            this.Controls.Add(this.textBoxSerie);
            this.Controls.Add(this.lblPolarizado);
            this.Controls.Add(this.lblBlueRay);
            this.Controls.Add(this.lblBifocal);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblArmazon);
            this.Controls.Add(this.lblLente);
            this.Controls.Add(this.lblSerie);
            this.Controls.Add(this.lblCantidad);
            this.Name = "frmFabricarSol";
            this.Text = "frmFabricarSol";
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnFabricar;
        private System.Windows.Forms.ComboBox cmbBoxPolarizado;
        private System.Windows.Forms.ComboBox cmbBoxBlueRay;
        private System.Windows.Forms.ComboBox cmbBoxBiFocal;
        private System.Windows.Forms.ComboBox cmbBoxColor;
        private System.Windows.Forms.ComboBox cmbBoxArmazon;
        private System.Windows.Forms.ComboBox cmbBoxLente;
        private System.Windows.Forms.NumericUpDown numericCantidad;
        private System.Windows.Forms.TextBox textBoxSerie;
        private System.Windows.Forms.Label lblPolarizado;
        private System.Windows.Forms.Label lblBlueRay;
        private System.Windows.Forms.Label lblBifocal;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblArmazon;
        private System.Windows.Forms.Label lblLente;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.Label lblCantidad;
    }
}