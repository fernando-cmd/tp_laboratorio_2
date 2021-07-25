using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
namespace Entidades
{
    public static class Sql
    {
        /*public static void agregarGraduable(Graduables anteojo)
        {
            string cadenaConexion = @"Data Source = DESKTOP-ILTUKAA\SQLEXPRESS; Initial Catalog = dbAnteojosTP4; Integrated Security = True";

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = conexion;

                    command.CommandText = $"INSERT INTO tablaAnteojos (tipo, nroSerie, cantidad, armazon, lente, color, biFocal, blueRay, polarizado, desmontable, graduacionOI, graduacionOD) " +
                                                            $"VALUES (@tipo, @nroSerie, @cantidad, @armazon, @lente, @color, @biFocal, @blueRay, @polarizado, @desmontable, @graduacionOI, @graduacionOD)", conexion);


                    command.Parameters.AddWithValue("@tipo", anteojo.Tipo);
                    command.Parameters.AddWithValue("@nroSerie", anteojo.NUMERO_SERIE);
                    command.Parameters.AddWithValue("@cantidad", anteojo.Cantidad);
                    command.Parameters.AddWithValue("@armazon", anteojo.ARMAZON.ToString());
                    command.Parameters.AddWithValue("@lente", anteojo.LENTE.ToString());
                    command.Parameters.AddWithValue("@color", anteojo.COLOR.ToString());
                    command.Parameters.AddWithValue("@biFocal", anteojo.BiFocal.ToString());
                    command.Parameters.AddWithValue("@blueRay", anteojo.BlueRay.ToString());
                    command.Parameters.AddWithValue("@desmontable", anteojo.Desmontable.ToString());
                    command.Parameters.AddWithValue("@graduacionOI", anteojo.OjoIzquierdo);
                    command.Parameters.AddWithValue("@graduacionOD", anteojo.OjoDerecho);

                    command.ExecuteNonQuery();
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }       
        }*/

    }
}
