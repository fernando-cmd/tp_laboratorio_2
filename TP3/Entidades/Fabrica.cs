using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Fabrica
    {
        private List<Anteojo> lista;
        private string nombre;
        private static Fabrica fabrica;

        #region Propiedades
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public List<Anteojo> Anteojos { get { return this.lista; } }
        private Fabrica()
        {
            lista = new List<Anteojo>();
        }
        #endregion

        #region Constructor
        public Fabrica(string nombre) : this()
        {
            this.nombre = nombre;
        }
        #endregion

        #region Metodos y sobrecargas

        public static Fabrica GetFabrica(string nombre)
        {
            if (fabrica is null)
                return fabrica = new Fabrica(nombre);
            else
            {
                fabrica.nombre = nombre;
                return fabrica;
            }
        }
        public void Agregar(Anteojo anteojo)
        {
            if(StockInsumos.ValidarStockLentes(anteojo.Lente,anteojo.Cantidad) && 
                StockInsumos.ValidarStockArmazon(anteojo.Armazon,anteojo.Cantidad))
            {
                this.lista.Add(anteojo);
            }
            else
            {
                Console.WriteLine("No hay insumos suficientes");
            }
        }  

        public static explicit operator string(Fabrica f)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Anteojo item in f.lista)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        #endregion
    }
}
