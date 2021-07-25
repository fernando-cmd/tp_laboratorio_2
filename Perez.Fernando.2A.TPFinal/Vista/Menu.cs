using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.Data.SqlClient;
using System.Threading;

namespace Vista
{
    public delegate void Delegado(PictureBox pB, string nombre);
    public partial class Menu : Form
    {
        #region Propiedades
        protected DepositoFabrica<Anteojo> deposito;
        private SqlConnection conexion;
        private SqlDataAdapter da;
        private DataTable dt;

        private Thread hiloAnteojos;
        public event Delegado eventoImagen;
        #endregion

        #region Constructor
        public Menu()
        {
            InitializeComponent();
            this.deposito = new DepositoFabrica<Anteojo>("Fabrica");
            this.deposito.DireccionXml = AppDomain.CurrentDomain.BaseDirectory + "AnteojosProducidos.xml";

            this.conexion = new SqlConnection(@"Data Source = DESKTOP-ILTUKAA\SQLEXPRESS; Initial Catalog = dbAnteojosTP4; Integrated Security = True");
            this.Configurardtable();
            this.eventoImagen += this.MostrarImagen;            
            this.hiloAnteojos = new Thread(this.CambiarImagen);

            if (!this.hiloAnteojos.IsAlive)
            {
                this.hiloAnteojos.Start(); 
            }

            this.dtable.DataSource = this.dt;
        }
        #endregion

        #region Botones
        private void btnFabricarClasico_Click(object sender, EventArgs e)
        {
            frmFabricarClasico frmClasico = new frmFabricarClasico();
            this.Hide();
            if (frmClasico.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.deposito += (Anteojo)frmClasico.Anteojo;
                    MessageBox.Show("Fabricacion exitosa!");
                    this.AgregarADataT((Anteojo)frmClasico.Anteojo);
                }
                catch (ProduccionRepetidaException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.Show();
        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            if (deposito.Lista.Count > 0)
            {
                frmDeposito frmDeposito = new frmDeposito(deposito);
                frmDeposito.Show();
            }
            else
            {
                MessageBox.Show("No fabrico ningun anteojo hasta el momento");
            }
        }

        private void btnFabricarSol_Click(object sender, EventArgs e)
        {

            frmFabricarSol frmSol = new frmFabricarSol();

            this.Hide();
            if (frmSol.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.deposito += (Anteojo)frmSol.Anteojo;
                    MessageBox.Show("Fabricacion exitosa!");
                    this.AgregarADataT((Anteojo)frmSol.Anteojo);
                }
                catch (ProduccionRepetidaException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.Show();
        }

        private void btnFabricarGraduable_Click(object sender, EventArgs e)
        {
            frmFabricarGraduable frmGraduable = new frmFabricarGraduable();

            this.Hide();
            if (frmGraduable.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.deposito += (Anteojo)frmGraduable.Anteojo;
                    MessageBox.Show("Fabricacion exitosa!");
                    this.AgregarADataT((Anteojo)frmGraduable.Anteojo);
                }
                catch (ProduccionRepetidaException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.deposito.Lista.Count > 0)
            {
                Archivos<Anteojo>.GuardarFabrica(this.deposito);
                MessageBox.Show("Se guardaron los datos correctamente");
            }
            else
            {
                MessageBox.Show("No se han producido anteojos hasta el momento");
            }
        }

        private void btnCargarBD_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            if (File.Exists(deposito.DireccionXml))
            {
                DialogResult Confirmacion;

                Confirmacion = MessageBox.Show("Si carga los datos XML de los anteojos fabricados, se sobreescribiran los datos actuales", "AVISO", MessageBoxButtons.OKCancel);

                if (Confirmacion == DialogResult.OK)
                {
                    this.deposito = Archivos<Anteojo>.CargarFabrica(deposito);
                    this.dt.Rows.Clear();
                    foreach (Anteojo item in this.deposito.Lista)
                    {
                        this.AgregarADataT(item);
                    }
                    MessageBox.Show("Se cargaron los datos del XML", "Cargado correctamente");
                }
            }
            else
            {
                MessageBox.Show("No existe el archivo", "Error al cargar el XML");
            }

        }

        private void btnGuardarBD_Click(object sender, EventArgs e)
        {
            SqlCommand agregarGraduable = new SqlCommand("INSERT INTO TablaAnteojos (Tipo, NroSerie, Cantidad, Armazon, Lente, Color, BiFocal, BlueRay, Desmontable, GraduacionOI, GraduacionOD)" +
                                                            "VALUES (@tipo, @nroSerie, @cantidad, @armazon, @lente, @color, @biFocal, @blueRay, @desmontable, @graduacionOI, @graduacionOD)", this.conexion);
            SqlCommand agregarClasico = new SqlCommand("INSERT INTO TablaAnteojos (Tipo, NroSerie, Cantidad, Armazon, Lente, Color, BiFocal, BlueRay, Desmontable)" +
                                                            "VALUES (@tipo, @nroSerie, @cantidad, @armazon, @lente, @color, @biFocal, @blueRay, @desmontable)", this.conexion);
            SqlCommand agregarSol = new SqlCommand("INSERT INTO TablaAnteojos (Tipo, NroSerie, Cantidad, Armazon, Lente, Color, BiFocal, BlueRay, Polarizado)" +
                                                            "VALUES (@tipo, @nroSerie, @cantidad, @armazon, @lente, @color, @biFocal, @blueRay, @polarizado)", this.conexion);
            this.conexion.Open();
            try
            {
                foreach (Anteojo item in this.deposito.Lista)
                {                   

                    switch (item.Tipo)
                    {
                        case "Graduables":
                            agregarGraduable.Parameters.Clear();
                            agregarGraduable.Parameters.AddWithValue("@tipo", item.Tipo);
                            agregarGraduable.Parameters.AddWithValue("@nroSerie", item.NUMERO_SERIE);
                            agregarGraduable.Parameters.AddWithValue("@cantidad", item.Cantidad);
                            agregarGraduable.Parameters.AddWithValue("@armazon", item.ARMAZON.ToString());
                            agregarGraduable.Parameters.AddWithValue("@lente", item.LENTE.ToString());
                            agregarGraduable.Parameters.AddWithValue("@color", item.COLOR.ToString());
                            agregarGraduable.Parameters.AddWithValue("@biFocal", item.BiFocal.ToString());
                            agregarGraduable.Parameters.AddWithValue("@blueRay", item.BlueRay.ToString());
                            agregarGraduable.Parameters.AddWithValue("@desmontable", ((Graduables)item).Desmontable.ToString());
                            agregarGraduable.Parameters.AddWithValue("@graduacionOI", ((Graduables)item).OjoIzquierdo);
                            agregarGraduable.Parameters.AddWithValue("@graduacionOD", ((Graduables)item).OjoDerecho);
                            agregarGraduable.ExecuteNonQuery();
                            break;
                        case "Clasico":
                            agregarClasico.Parameters.Clear();
                            agregarClasico.Parameters.AddWithValue("@tipo", item.Tipo);
                            agregarClasico.Parameters.AddWithValue("@nroSerie", item.NUMERO_SERIE);
                            agregarClasico.Parameters.AddWithValue("@cantidad", item.Cantidad);
                            agregarClasico.Parameters.AddWithValue("@armazon", item.ARMAZON.ToString());
                            agregarClasico.Parameters.AddWithValue("@lente", item.LENTE.ToString());
                            agregarClasico.Parameters.AddWithValue("@color", item.COLOR.ToString());
                            agregarClasico.Parameters.AddWithValue("@biFocal", item.BiFocal.ToString());
                            agregarClasico.Parameters.AddWithValue("@blueRay", item.BlueRay.ToString());
                            agregarClasico.Parameters.AddWithValue("@desmontable", ((Clasico)item).Desmontable.ToString());
                            agregarClasico.ExecuteNonQuery();
                            break;
                        case "Sol":
                            agregarSol.Parameters.Clear();
                            agregarSol.Parameters.AddWithValue("@tipo", item.Tipo);
                            agregarSol.Parameters.AddWithValue("@nroSerie", item.NUMERO_SERIE);
                            agregarSol.Parameters.AddWithValue("@cantidad", item.Cantidad);
                            agregarSol.Parameters.AddWithValue("@armazon", item.ARMAZON.ToString());
                            agregarSol.Parameters.AddWithValue("@lente", item.LENTE.ToString());
                            agregarSol.Parameters.AddWithValue("@color", item.COLOR.ToString());
                            agregarSol.Parameters.AddWithValue("@biFocal", item.BiFocal.ToString());
                            agregarSol.Parameters.AddWithValue("@blueRay", item.BlueRay.ToString());
                            agregarSol.Parameters.AddWithValue("@polarizado", ((Sol)item).Polarizado.ToString());
                            agregarSol.ExecuteNonQuery();
                            break;

                    }
                }
                MessageBox.Show("Se guardaron los datos en la base de datos correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.conexion.Close();
            }
        }
        #endregion

        #region Metodos

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            DialogResult Confirmacion;

            Confirmacion = MessageBox.Show("¿Estás seguro de que quieres salir?", "Aviso", MessageBoxButtons.OKCancel);

            if (this.hiloAnteojos.IsAlive) 
            {
                this.hiloAnteojos.Abort(); 
            }
            this.Close();
        }
        
        private void MostrarImagen(PictureBox pB, string nombre)
        {
            pB.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + $@"{nombre}";
        }

        private void Configurardtable()
        {
            this.dt = new DataTable("Anteojos");

            this.dt.Columns.Add("Tipo", typeof(string));
            this.dt.Columns.Add("N° De Serie", typeof(int));
            this.dt.Columns.Add("Cantidad", typeof(int));
            this.dt.Columns.Add("Armazon", typeof(EArmazon));
            this.dt.Columns.Add("Lente", typeof(ELente));
            this.dt.Columns.Add("Color", typeof(EColor));
            this.dt.Columns.Add("BiFocal", typeof(string));
            this.dt.Columns.Add("BlueRay", typeof(string));
            this.dt.Columns.Add("Polarizado", typeof(string));
            this.dt.Columns.Add("Desmontable", typeof(string));
            this.dt.Columns.Add("GraduacionOI", typeof(float));
            this.dt.Columns.Add("GraduacionOD", typeof(float));

            this.dt.Columns[0].ReadOnly = true;
            this.dt.Columns[1].ReadOnly = true;
            this.dt.Columns[2].ReadOnly = true;
            this.dt.Columns[3].ReadOnly = true;
            this.dt.Columns[4].ReadOnly = true;
            this.dt.Columns[5].ReadOnly = true;
            this.dt.Columns[6].ReadOnly = true;
            this.dt.Columns[7].ReadOnly = true;
            this.dt.Columns[8].ReadOnly = true;
            this.dt.Columns[9].ReadOnly = true;
            this.dt.Columns[10].ReadOnly = true;
            this.dt.Columns[11].ReadOnly = true;

            this.dtable.AllowUserToAddRows = false;            
        }

        private void AgregarADataT(Anteojo anteojo)
        {
            DataRow fila = this.dt.NewRow();

            fila[0] = anteojo.Tipo;
            fila[1] = anteojo.NUMERO_SERIE;
            fila[2] = anteojo.Cantidad;
            fila[3] = anteojo.ARMAZON;
            fila[4] = anteojo.LENTE;
            fila[5] = anteojo.COLOR;
            fila[6] = anteojo.BiFocal.ToString();
            fila[7] = anteojo.BlueRay.ToString();

            switch (anteojo.Tipo)
            {
                case "Clasico":
                    fila[9] = ((Clasico)anteojo).Desmontable.ToString();
                    break;
                case "Sol":
                    fila[8] = ((Sol)anteojo).Polarizado.ToString();
                    break;
                case "Graduables":
                    fila[9] = ((Clasico)anteojo).Desmontable.ToString();
                    fila[10] = ((Graduables)anteojo).OjoIzquierdo;
                    fila[11] = ((Graduables)anteojo).OjoDerecho;
                    break;
            }

            this.dt.Rows.Add(fila); 
        }

        private void Configurardadapter()
        {
            try
            {
                this.da = new SqlDataAdapter();
                this.conexion.Open();
                this.da.SelectCommand = new SqlCommand($"SELECT * FROM tablaAnteojos", this.conexion);
                this.da.InsertCommand = new SqlCommand($"INSERT INTO tablaAnteojos (tipo, nroSerie, cantidad, armazon, lente, color, biFocal, blueRay, polarizado, desmontable, graduacionOI, graduacionOD) " +
                                                            $"VALUES (@tipo, @nroSerie, @cantidad, @armazon, @lente, @color, @biFocal, @blueRay, @polarizado, @desmontable, @graduacionOI, @graduacionOD)", this.conexion);
                this.da.UpdateCommand = new SqlCommand($"UPDATE tablaAnteojos SET tipo=@tipo, nroSerie=@nroSerie, cantidad=@cantidad, armazon=@armazon, lente=@lente, color=@color, biFocal=@biFocal, blueRay=@blueRay, Polarizado=@Polarizado, graduacionOI=@graduacionOI, graduacionOD=@graduacionOD, desmontable=@desmontable" +
                                                            " WHERE nroSerie=@nroSerie", this.conexion);
                this.da.DeleteCommand = new SqlCommand($"DELETE FROM tablaAnteojos WHERE nroSerie=@nroSerie", this.conexion);

                this.da.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                this.da.InsertCommand.Parameters.Add("@nroSerie", SqlDbType.Int, 10, "nroSerie");
                this.da.InsertCommand.Parameters.Add("@cantidad", SqlDbType.Int, 10, "cantidad");
                this.da.InsertCommand.Parameters.Add("@armazon", SqlDbType.Int, 10, "armazon");
                this.da.InsertCommand.Parameters.Add("@lente", SqlDbType.Int, 10, "lente");
                this.da.InsertCommand.Parameters.Add("@color", SqlDbType.Int, 10, "color");
                this.da.InsertCommand.Parameters.Add("@biFocal", SqlDbType.Bit, 10, "biFocal");
                this.da.InsertCommand.Parameters.Add("@blueRay", SqlDbType.Bit, 10, "blueRay");
                this.da.InsertCommand.Parameters.Add("@polarizado", SqlDbType.Bit, 10, "polarizado");
                this.da.InsertCommand.Parameters.Add("@graduacionOI", SqlDbType.Float, 10, "graduacionOI");
                this.da.InsertCommand.Parameters.Add("@graduacionOD", SqlDbType.Float, 10, "graduacionOD");
                this.da.InsertCommand.Parameters.Add("@desmontable", SqlDbType.Bit, 10, "desmontable");

                this.da.UpdateCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                this.da.UpdateCommand.Parameters.Add("@nroSerie", SqlDbType.Int, 10, "nroSerie");
                this.da.UpdateCommand.Parameters.Add("@cantidad", SqlDbType.Int, 10, "cantidad");
                this.da.UpdateCommand.Parameters.Add("@armazon", SqlDbType.Int, 10, "armazon");
                this.da.UpdateCommand.Parameters.Add("@lente", SqlDbType.Int, 10, "lente");
                this.da.UpdateCommand.Parameters.Add("@color", SqlDbType.Int, 10, "color");
                this.da.UpdateCommand.Parameters.Add("@biFocal", SqlDbType.Bit, 10, "biFocal");
                this.da.UpdateCommand.Parameters.Add("@blueRay", SqlDbType.Bit, 10, "blueRay");
                this.da.UpdateCommand.Parameters.Add("@polarizado", SqlDbType.Bit, 10, "polarizado");
                this.da.UpdateCommand.Parameters.Add("@graduacionOI", SqlDbType.Float, 10, "graduacionOI");
                this.da.UpdateCommand.Parameters.Add("@graduacionOD", SqlDbType.Float, 10, "graduacionOD");
                this.da.UpdateCommand.Parameters.Add("@desmontable", SqlDbType.Bit, 10, "desmontable");


                this.da.DeleteCommand.Parameters.Add("@nroSerie", SqlDbType.Int, 10, "nroSerie");
                this.conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CambiarImagen()
        {
            do
            {
                this.eventoImagen.Invoke(this.pictureBoxAnteojos1, "anteojo1.png");  //Invoca al evento
                Thread.Sleep(2500);
                this.eventoImagen.Invoke(this.pictureBoxAnteojos1, "anteojo2.png");
                Thread.Sleep(2500);
                this.eventoImagen.Invoke(this.pictureBoxAnteojos1, "anteojo3.png");
                Thread.Sleep(2500);

            } while (true);
        }
        #endregion

    }
}
