
namespace Vista
{
    partial class frmFabricarClasico
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
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.lblLente = new System.Windows.Forms.Label();
            this.lblArmazon = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblBifocal = new System.Windows.Forms.Label();
            this.lblBlueRay = new System.Windows.Forms.Label();
            this.lblDesmontable = new System.Windows.Forms.Label();
            this.textBoxSerie = new System.Windows.Forms.TextBox();
            this.numericCantidad = new System.Windows.Forms.NumericUpDown();
            this.cmbBoxLente = new System.Windows.Forms.ComboBox();
            this.cmbBoxArmazon = new System.Windows.Forms.ComboBox();
            this.cmbBoxColor = new System.Windows.Forms.ComboBox();
            this.cmbBoxBiFocal = new System.Windows.Forms.ComboBox();
            this.cmbBoxBlueRay = new System.Windows.Forms.ComboBox();
            this.cmbBoxDesmontable = new System.Windows.Forms.ComboBox();
            this.btnFabricar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(97, 9);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(79, 21);
            this.lblCantidad.TabIndex = 0;
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerie.Location = new System.Drawing.Point(12, 9);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(72, 21);
            this.lblSerie.TabIndex = 1;
            this.lblSerie.Text = "N° Serie";
            // 
            // lblLente
            // 
            this.lblLente.AutoSize = true;
            this.lblLente.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLente.Location = new System.Drawing.Point(201, 9);
            this.lblLente.Name = "lblLente";
            this.lblLente.Size = new System.Drawing.Size(52, 21);
            this.lblLente.TabIndex = 2;
            this.lblLente.Text = "Lente";
            // 
            // lblArmazon
            // 
            this.lblArmazon.AutoSize = true;
            this.lblArmazon.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArmazon.Location = new System.Drawing.Point(275, 9);
            this.lblArmazon.Name = "lblArmazon";
            this.lblArmazon.Size = new System.Drawing.Size(79, 21);
            this.lblArmazon.TabIndex = 3;
            this.lblArmazon.Text = "Armazon";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(373, 9);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(125, 21);
            this.lblColor.TabIndex = 4;
            this.lblColor.Text = "Color Armazon";
            // 
            // lblBifocal
            // 
            this.lblBifocal.AutoSize = true;
            this.lblBifocal.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBifocal.Location = new System.Drawing.Point(517, 9);
            this.lblBifocal.Name = "lblBifocal";
            this.lblBifocal.Size = new System.Drawing.Size(72, 21);
            this.lblBifocal.TabIndex = 5;
            this.lblBifocal.Text = "BiFocal?";
            // 
            // lblBlueRay
            // 
            this.lblBlueRay.AutoSize = true;
            this.lblBlueRay.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlueRay.Location = new System.Drawing.Point(611, 9);
            this.lblBlueRay.Name = "lblBlueRay";
            this.lblBlueRay.Size = new System.Drawing.Size(78, 21);
            this.lblBlueRay.TabIndex = 6;
            this.lblBlueRay.Text = "BlueRay?";
            // 
            // lblDesmontable
            // 
            this.lblDesmontable.AutoSize = true;
            this.lblDesmontable.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesmontable.Location = new System.Drawing.Point(709, 9);
            this.lblDesmontable.Name = "lblDesmontable";
            this.lblDesmontable.Size = new System.Drawing.Size(119, 21);
            this.lblDesmontable.TabIndex = 7;
            this.lblDesmontable.Text = "Desmontable?";
            // 
            // textBoxSerie
            // 
            this.textBoxSerie.Location = new System.Drawing.Point(16, 33);
            this.textBoxSerie.Name = "textBoxSerie";
            this.textBoxSerie.Size = new System.Drawing.Size(65, 20);
            this.textBoxSerie.TabIndex = 8;
            // 
            // numericCantidad
            // 
            this.numericCantidad.Location = new System.Drawing.Point(101, 33);
            this.numericCantidad.Name = "numericCantidad";
            this.numericCantidad.Size = new System.Drawing.Size(75, 20);
            this.numericCantidad.TabIndex = 9;
            // 
            // cmbBoxLente
            // 
            this.cmbBoxLente.FormattingEnabled = true;
            this.cmbBoxLente.Location = new System.Drawing.Point(182, 33);
            this.cmbBoxLente.Name = "cmbBoxLente";
            this.cmbBoxLente.Size = new System.Drawing.Size(84, 21);
            this.cmbBoxLente.TabIndex = 10;
            // 
            // cmbBoxArmazon
            // 
            this.cmbBoxArmazon.FormattingEnabled = true;
            this.cmbBoxArmazon.Location = new System.Drawing.Point(272, 33);
            this.cmbBoxArmazon.Name = "cmbBoxArmazon";
            this.cmbBoxArmazon.Size = new System.Drawing.Size(84, 21);
            this.cmbBoxArmazon.TabIndex = 11;
            // 
            // cmbBoxColor
            // 
            this.cmbBoxColor.FormattingEnabled = true;
            this.cmbBoxColor.Location = new System.Drawing.Point(377, 33);
            this.cmbBoxColor.Name = "cmbBoxColor";
            this.cmbBoxColor.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxColor.TabIndex = 12;
            // 
            // cmbBoxBiFocal
            // 
            this.cmbBoxBiFocal.FormattingEnabled = true;
            this.cmbBoxBiFocal.Location = new System.Drawing.Point(505, 33);
            this.cmbBoxBiFocal.Name = "cmbBoxBiFocal";
            this.cmbBoxBiFocal.Size = new System.Drawing.Size(84, 21);
            this.cmbBoxBiFocal.TabIndex = 13;
            // 
            // cmbBoxBlueRay
            // 
            this.cmbBoxBlueRay.FormattingEnabled = true;
            this.cmbBoxBlueRay.Location = new System.Drawing.Point(605, 33);
            this.cmbBoxBlueRay.Name = "cmbBoxBlueRay";
            this.cmbBoxBlueRay.Size = new System.Drawing.Size(84, 21);
            this.cmbBoxBlueRay.TabIndex = 14;
            // 
            // cmbBoxDesmontable
            // 
            this.cmbBoxDesmontable.FormattingEnabled = true;
            this.cmbBoxDesmontable.Location = new System.Drawing.Point(722, 33);
            this.cmbBoxDesmontable.Name = "cmbBoxDesmontable";
            this.cmbBoxDesmontable.Size = new System.Drawing.Size(84, 21);
            this.cmbBoxDesmontable.TabIndex = 15;
            // 
            // btnFabricar
            // 
            this.btnFabricar.Location = new System.Drawing.Point(182, 98);
            this.btnFabricar.Name = "btnFabricar";
            this.btnFabricar.Size = new System.Drawing.Size(143, 35);
            this.btnFabricar.TabIndex = 16;
            this.btnFabricar.Text = "Fabricar";
            this.btnFabricar.UseVisualStyleBackColor = true;
            this.btnFabricar.Click += new System.EventHandler(this.btnFabricar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(355, 98);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(143, 35);
            this.btnSalir.TabIndex = 17;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmFabricarClasico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 156);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnFabricar);
            this.Controls.Add(this.cmbBoxDesmontable);
            this.Controls.Add(this.cmbBoxBlueRay);
            this.Controls.Add(this.cmbBoxBiFocal);
            this.Controls.Add(this.cmbBoxColor);
            this.Controls.Add(this.cmbBoxArmazon);
            this.Controls.Add(this.cmbBoxLente);
            this.Controls.Add(this.numericCantidad);
            this.Controls.Add(this.textBoxSerie);
            this.Controls.Add(this.lblDesmontable);
            this.Controls.Add(this.lblBlueRay);
            this.Controls.Add(this.lblBifocal);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblArmazon);
            this.Controls.Add(this.lblLente);
            this.Controls.Add(this.lblSerie);
            this.Controls.Add(this.lblCantidad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFabricarClasico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fabricar Clasico";
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.Label lblLente;
        private System.Windows.Forms.Label lblArmazon;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblBifocal;
        private System.Windows.Forms.Label lblBlueRay;
        private System.Windows.Forms.Label lblDesmontable;
        private System.Windows.Forms.TextBox textBoxSerie;
        private System.Windows.Forms.NumericUpDown numericCantidad;
        private System.Windows.Forms.ComboBox cmbBoxLente;
        private System.Windows.Forms.ComboBox cmbBoxArmazon;
        private System.Windows.Forms.ComboBox cmbBoxColor;
        private System.Windows.Forms.ComboBox cmbBoxBiFocal;
        private System.Windows.Forms.ComboBox cmbBoxBlueRay;
        private System.Windows.Forms.ComboBox cmbBoxDesmontable;
        private System.Windows.Forms.Button btnFabricar;
        private System.Windows.Forms.Button btnSalir;
    }
}