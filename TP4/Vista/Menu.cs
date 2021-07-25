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

            ///CAMBIAR 
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



        private void btnLeer_Click(object sender, EventArgs e)
        {
            if (File.Exists(deposito.DireccionXml))
            {
                DialogResult Confirmacion;

                Confirmacion = MessageBox.Show("Si carga los datos XML de los anteojos fabricados, se sobreescribiran los datos actuales", "AVISO", MessageBoxButtons.OKCancel);

                if (Confirmacion == DialogResult.OK)
                {
                    this.deposito.Lista.Clear();
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

        private void btnCargarBD_Click(object sender, EventArgs e)
        {
            Sol anteojoSol;
            Clasico anteojoClasico;
            Graduables anteojoGraduable;


            try
            {
                this.conexion.Open();
                SqlCommand traerTodo = new SqlCommand("SELECT * FROM TablaAnteojos", this.conexion);
                SqlDataReader dtReader = traerTodo.ExecuteReader();
                this.deposito.Lista.Clear();
                this.dt.Rows.Clear();
                while (dtReader.Read() != false)
                {
                    switch (dtReader["Tipo"].ToString())
                    {
                        case "Clasico":
                            anteojoClasico = new Clasico(Convert.ToBoolean(dtReader["Desmontable"].ToString()), Convert.ToInt32(dtReader["Cantidad"]), Convert.ToInt32(dtReader["NroSerie"]), (EArmazon)Enum.Parse(typeof(EArmazon), dtReader["Armazon"].ToString()), (ELente)Enum.Parse(typeof(ELente), dtReader["Lente"].ToString()), (EColor)Enum.Parse(typeof(EColor), dtReader["Color"].ToString()), Convert.ToBoolean(dtReader["BiFocal"].ToString()), Convert.ToBoolean(dtReader["BlueRay"].ToString()));
                            this.deposito += (Anteojo)anteojoClasico;
                            this.AgregarADataT((Anteojo)anteojoClasico);
                            break;
                        case "Sol":
                            anteojoSol = new Sol(Convert.ToBoolean(dtReader["Polarizado"].ToString()), Convert.ToInt32(dtReader["Cantidad"]), Convert.ToInt32(dtReader["NroSerie"]), (EArmazon)Enum.Parse(typeof(EArmazon), dtReader["Armazon"].ToString()), (ELente)Enum.Parse(typeof(ELente), dtReader["Lente"].ToString()), (EColor)Enum.Parse(typeof(EColor), dtReader["Color"].ToString()), Convert.ToBoolean(dtReader["BiFocal"].ToString()), Convert.ToBoolean(dtReader["BlueRay"].ToString()));
                            this.deposito += (Anteojo)anteojoSol;
                            this.AgregarADataT((Anteojo)anteojoSol);
                            break;
                        case "Graduables":
                            anteojoGraduable = new Graduables(float.Parse(dtReader["GraduacionOI"].ToString()), float.Parse(dtReader["GraduacionOD"].ToString()), Convert.ToBoolean(dtReader["Desmontable"].ToString()), Convert.ToInt32(dtReader["Cantidad"]), Convert.ToInt32(dtReader["NroSerie"]), (EArmazon)Enum.Parse(typeof(EArmazon), dtReader["Armazon"].ToString()), (ELente)Enum.Parse(typeof(ELente), dtReader["Lente"].ToString()), (EColor)Enum.Parse(typeof(EColor), dtReader["Color"].ToString()), Convert.ToBoolean(dtReader["BiFocal"].ToString()), Convert.ToBoolean(dtReader["BlueRay"].ToString()));
                            this.deposito += (Anteojo)anteojoGraduable;
                            this.AgregarADataT((Anteojo)anteojoGraduable);
                            break;
                    }
                }
                MessageBox.Show("Se cargaron los datos correctamente");
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.deposito.Lista.Count > 0)
            {
                int i = this.dtable.CurrentRow.Index;
                DialogResult Confirmacion = MessageBox.Show($"{this.deposito.Lista[i].ToString()}", "Esta seguro de despachar la siguiente producción?", MessageBoxButtons.OKCancel);
                if (Confirmacion == DialogResult.OK)
                {
                    try
                    {
                        this.deposito.Lista.RemoveAt(i);
                        int nroSerie = Convert.ToInt32(this.dtable.CurrentRow.Cells["N° De Serie"].Value);
                        this.conexion.Open();
                        SqlCommand eliminar = new SqlCommand($"Delete from TablaAnteojos where NroSerie={nroSerie}", this.conexion);
                        eliminar.ExecuteNonQuery();
                        this.dt.Rows[i].Delete();
                        MessageBox.Show("Se elimino correctamente!", "Desechado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            }
            else
            {
                MessageBox.Show("No se han fabricados o cargados anteojos hasta el momento");
            }
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.deposito.Lista.Count > 0)
            {
                if(this.dtable.CurrentRow.DefaultCellStyle.BackColor == Color.Empty)
                {
                    this.dtable.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                {
                    this.dtable.CurrentRow.DefaultCellStyle.BackColor = Color.Empty;
                }               

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

        private void CambiarImagen()
        {
            do
            {
                this.eventoImagen.Invoke(this.pictureBoxAnteojos1, "anteojo1.png");
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
