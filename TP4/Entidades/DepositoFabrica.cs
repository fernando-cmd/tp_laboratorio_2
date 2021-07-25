using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace Entidades
{
    [Serializable]
    public class DepositoFabrica<T> where T : Anteojo
    {
        private List<T> _lista;
        private string _direccionXml;
        private string _nombreDeposito;

        #region Propiedades
        /// <summary>
        /// Retorna y asigna la lista de anteojos.
        /// </summary>
        public List<T> Lista { get { return this._lista; } set { this._lista = value; } }

        /// <summary>
        /// Retorna y asigna el nombre del deposito.
        /// </summary>
        public string NombreDeposito { get { return this._nombreDeposito; } set { this._nombreDeposito = value; } }

        /// <summary>
        /// Retorna y asigna el directorio para los archivos XML.
        /// </summary>
        public string DireccionXml { get { return this._direccionXml; } set { this._direccionXml = value; } }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor privado que crea la lista de anteojos.
        /// </summary>
        private DepositoFabrica()
        {
            this.Lista = new List<T>();
        }

        /// <summary>
        /// Constructor publico que establece el nombre del deposito.
        /// </summary>
        /// <param name="nombre"></param>
        public DepositoFabrica(string nombre) : this()
        {
            this.NombreDeposito = nombre;
        }

        #endregion

        #region Sobrecarga Operadores
        /// <summary>
        /// Sobrecarga del operador + para agregar una producción de anteojos al deposito.
        /// </summary>
        /// <param name="deposito"></param>
        /// <param name="anteojos"></param>
        /// <returns></returns>
        public static DepositoFabrica<T> operator +(DepositoFabrica<T> deposito, T anteojos)
        {
            if (deposito == anteojos)
            {
                throw new ProduccionRepetidaException();
            }
            else
            {
                deposito.Lista.Add(anteojos);
            }
            return deposito;
        }

        public static bool operator ==(DepositoFabrica<T> deposito, T anteojos)
        {
            bool retorno = false;
            if(deposito.Lista.Count>0)
            {
                foreach(T item in deposito.Lista)
                {
                    if(item.NUMERO_SERIE == anteojos.NUMERO_SERIE)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }

        public static bool operator !=(DepositoFabrica<T> deposito, T anteojos)
        {
            return !(deposito == anteojos);
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Sobrecarga del metodo ToString que devuelve todas las producciones que fueron almacenadas.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                foreach (T item in this.Lista)
                {
                    sb.AppendLine(item.ToString());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return sb.ToString();
        }
        #endregion 
    }
}