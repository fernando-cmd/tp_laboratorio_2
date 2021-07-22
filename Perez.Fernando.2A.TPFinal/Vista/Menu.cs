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

namespace Vista
{
    public partial class Menu : Form
    {
        #region Propiedades
        protected DepositoFabrica<Anteojo> deposito;
        private SqlConnection conexion;        
        private SqlDataAdapter da;
        private DataTable dt;
        #endregion

        #region Constructor
        public Menu()
        {
            InitializeComponent();
            this.deposito = new DepositoFabrica<Anteojo>("Fabrica");
            this.deposito.DireccionXml = AppDomain.CurrentDomain.BaseDirectory + "AnteojosProducidos.xml";

            this.conexion = new SqlConnection(@"Data Source = DESKTOP-ILTUKAA\SQLEXPRESS; Initial Catalog = PerezFernandoTP4; Integrated Security = True");
            this.Configurardtable();
            this.Configurardadapter();

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
                catch(ProduccionRepetidaException ex)
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
            //bool aux;            

            DialogResult confirmacion = MessageBox.Show("Si carga los datos de los anteojos fabricados, se sobreescribiran los datos actuales", "AVISO", MessageBoxButtons.OKCancel);

            if (confirmacion == DialogResult.OK) //Si acepta continua
            {
                try
                {
                    this.deposito.Lista.Clear(); //Borra la lista de la fábrica
                    this.dt.Clear(); //Borra el listado del DataTable

                    this.da.Fill(this.dt); //Obtiene el listado de la base de datos

                    //Agrega el listado de DataTable al listado de la fábrica según el tipo de periférico
                    foreach (DataRow fila in this.dt.Rows)
                    {
                        try
                        {
                            if (fila.RowState != DataRowState.Deleted) //Verifica que la fila no esté marcada como eliminada
                            {
                                if (fila[0].ToString() == "Clasico")
                                {

                                    Clasico anteojo = new Clasico(bool.Parse(fila[9].ToString()), (int)fila[1], (int)fila[2], (EArmazon)fila[3], (ELente)fila[4], (EColor)fila[5], bool.Parse(fila[6].ToString()), bool.Parse(fila[7].ToString()));


                                    this.deposito.Lista.Add(anteojo);
                                }
                                else
                                {
                                    if (fila[0].ToString() == "Sol")
                                    {
                                        //(bool polarizado, int cantidad, int serie, EArmazon armazon, ELente lente, EColor color, bool biFocal, bool blueRay)
                                        Sol anteojo = new Sol(bool.Parse(fila[8].ToString()), (int)fila[1], (int)fila[2], (EArmazon)fila[3], (ELente)fila[4], (EColor)fila[5], bool.Parse(fila[6].ToString()), bool.Parse(fila[7].ToString()));

                                        this.deposito.Lista.Add(anteojo);
                                    }
                                    else
                                    {
                                        ///(double ojoIzquierdo, double ojoDerecho, bool desmontable, int cantidad, int serie, EArmazon armazon, ELente lente, EColor color, bool biFocal, bool blueRay)
                                        Graduables anteojo = new Graduables((float)fila[9], (float)fila[10], bool.Parse(fila[11].ToString()), (int)fila[1], (int)fila[2], (EArmazon)fila[3], (ELente)fila[4], (EColor)fila[5], bool.Parse(fila[6].ToString()), bool.Parse(fila[7].ToString()));



                                        this.deposito.Lista.Add(anteojo);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
            SqlCommand agregar = new SqlCommand("INSERT INTO Table_Anteojos (Tipo, NroSerie, Cantidad, Armazon, Lente, Color) "/*, BiFocal, BlueRay, Polarizado, Desmontable, GraduacionOI, GraduacionOD) */ +
                                                            "VALUES (@tipo, @nroSerie, @cantidad, @armazon, @lente, @color)", this.conexion);/*, @biFocal, @blueRay, @polarizado, @desmontable, @graduacionOI, @graduacionOD)", this.conexion);*/
            this.conexion.Open();
            try
            {
                foreach(DataGridViewRow row in dtable.Rows)
                {
                    agregar.Parameters.Clear();
                    agregar.Parameters.AddWithValue("@tipo", Convert.ToString(row.Cells[0].Value));
                    agregar.Parameters.AddWithValue("@nroSerie", Convert.ToInt32(row.Cells[1].Value));
                    agregar.Parameters.AddWithValue("@cantidad", Convert.ToInt32(row.Cells[2].Value));
                    agregar.Parameters.AddWithValue("@armazon", row.Cells[3].Value);
                    agregar.Parameters.AddWithValue("@lente", Convert.ToString(row.Cells[4].Value));
                    agregar.Parameters.AddWithValue("@color", Convert.ToString(row.Cells[5].Value));
                    /*agregar.Parameters.AddWithValue("@biFocal", Convert.ToBoolean(row.Cells[6].Value));
                    agregar.Parameters.AddWithValue("@blueRay", Convert.ToBoolean(row.Cells[7].Value));
                    agregar.Parameters.AddWithValue("@polarizado", Convert.ToBoolean(row.Cells[8].Value));
                    agregar.Parameters.AddWithValue("@desmontable", Convert.ToBoolean(row.Cells[9].Value));
                    agregar.Parameters.AddWithValue("@graduacionOI", Convert.ToDouble((row.Cells[10].Value)));
                    agregar.Parameters.AddWithValue("@graduacionOD", Convert.ToDouble((row.Cells[11].Value)));*/
                    agregar.ExecuteNonQuery();
                }
                MessageBox.Show("Datos Agregados");                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.conexion.Close();
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
            Application.Exit();
        }        

        /*private void horafecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString();
        protected int _cantidad;
        protected int _numeroSerie;
        protected EArmazon _armazon;
        protected ELente _lente;
        protected EColor _color;
        protected bool _bifocal;
        protected bool _blueRay;
        }*/

        private void Configurardtable()
        {
            this.dt = new DataTable("Anteojos");

            this.dt.Columns.Add("Tipo", typeof(string));
            this.dt.Columns.Add("N° De Serie", typeof(int));
            this.dt.Columns.Add("Cantidad", typeof(int));
            this.dt.Columns.Add("Armazon", typeof(EArmazon));
            this.dt.Columns.Add("Lente", typeof(ELente));
            this.dt.Columns.Add("Color", typeof(EColor));
            this.dt.Columns.Add("BiFocal", typeof(bool));
            this.dt.Columns.Add("BlueRay", typeof(bool));
            this.dt.Columns.Add("Polarizado", typeof(bool));
            this.dt.Columns.Add("Desmontable", typeof(bool));
            this.dt.Columns.Add("GraduacionOI", typeof(float));
            this.dt.Columns.Add("GraduacionOD", typeof(float));

            this.dtable.AllowUserToAddRows = false;
            //NroSerie como primary key
            this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[1] };
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
            fila[6] = anteojo.BiFocal;
            fila[7] = anteojo.BlueRay;

            switch(anteojo.Tipo)
            {
                case "Clasico":
                    fila[9] = ((Clasico)anteojo).Desmontable.ToString();
                    break;
                case "Sol":
                    fila[8] = ((Sol)anteojo).Polarizado.ToString();
                    break;
                case "Graduables":
                    fila[10] = ((Graduables)anteojo).OjoIzquierdo;
                    fila[11] = ((Graduables)anteojo).OjoDerecho;
                    break;
            }
            
            

            this.dt.Rows.Add(fila); //Lo agrega
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
        #endregion

    }
}
