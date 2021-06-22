using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class StockInsumos
    {
        private static int cantidadLentesPlastico;        
        private static int cantidadLentesVidrio;
        private static int cantidadArmazonAcero;
        private static int cantidadArmazonAluminio;
        private static int cantidadArmazonPlastico;

        #region Contructor

        /// <summary>
        /// Stock por defecto
        /// </summary>
        static StockInsumos()
        {
            cantidadLentesPlastico = 250;            
            cantidadLentesVidrio = 250;
            cantidadArmazonAcero = 250;
            cantidadArmazonAluminio = 250;
            cantidadArmazonPlastico = 250;
        }
        #endregion

        #region Propiedades

        /// <summary>
        /// Retorna la cantidad de lentes plasticos
        /// </summary>
        public static int LentesPlastico { get { return cantidadLentesPlastico; } }

        /// <summary>
        /// Retorna la cantidad de lentes de vidrio
        /// </summary>
        public static int LentesVidrio { get { return cantidadLentesVidrio; } }       
        /// <summary>
        /// Retorna la cantidad de armazones de acero
        /// </summary>
        public static int ArmazonAcero { get { return cantidadArmazonAcero; } }
        /// <summary>
        /// Retorna la cantidad de armazones de aluminio
        /// </summary>
        public static int ArmazonAluminio { get { return cantidadArmazonAluminio; } }
        /// <summary>
        /// Retorna la cantidad de armazones de aluminio
        /// </summary>
        public static int ArmazonPlastico { get { return cantidadArmazonPlastico; } }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que agrega armazones al stock.
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="cantidad"></param>
        public static void AgregarArmazones(EArmazon tipo, int cantidad)
        {

            switch (tipo)
            {
                case EArmazon.Acero:
                    cantidadArmazonAcero += cantidad;
                    break;
                case EArmazon.Aluminio:
                    cantidadArmazonAluminio += cantidad;
                    break;
                case EArmazon.Plastico:
                    cantidadArmazonPlastico += cantidad;
                    break;
            }
        }


        /// <summary>
        /// Metodo que agrega lentes al stock.
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="cantidad"></param>
        public static void AgregarLentes(ELente tipo, int cantidad)
        {
            switch (tipo)
            {
                case ELente.Vidrio:
                    cantidadLentesVidrio += cantidad;
                    break;                
                case ELente.Plastico:
                    cantidadLentesPlastico += cantidad;
                    break;
            }
        }

        /// <summary>
        /// Metodo que descuenta lentes al stock.
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="cantidad"></param>
        public static void DescontarLentes(ELente tipo, int cantidad)
        {
            switch (tipo)
            {
                case ELente.Vidrio:
                    cantidadLentesVidrio -= cantidad;
                    break;                
                case ELente.Plastico:
                    cantidadLentesPlastico -= cantidad;
                    break;
            }
        }

        /// <summary>
        /// Metodo que descuenta armazones al stock.
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="cantidad"></param>
        public static void DescontarArmazones(EArmazon tipo, int cantidad)
        {

            switch (tipo)
            {
                case EArmazon.Acero:
                    cantidadArmazonAcero -= cantidad;
                    break;
                case EArmazon.Aluminio:
                    cantidadArmazonAluminio -= cantidad;
                    break;
                case EArmazon.Plastico:
                    cantidadArmazonPlastico -= cantidad;
                    break;
            }

        }

        /// <summary>
        /// Retorna true en caso que halla la cantidad solicitada de armazones.
        /// </summary>
        /// <param name="tipoArmazon"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public static bool ValidarStockArmazon(EArmazon tipoArmazon, int cantidad)
        {
            bool retorno = false;
            switch (tipoArmazon)
            {
                case EArmazon.Acero:
                    if (cantidad <= cantidadArmazonAcero)
                    {
                        retorno = true;
                    }
                    break;
                case EArmazon.Aluminio:
                    if (cantidad <= cantidadArmazonAluminio)
                    {
                        retorno = true;
                    }
                    break;
                case EArmazon.Plastico:
                    if (cantidad <= cantidadArmazonPlastico)
                    {
                        retorno = true;
                    }
                    break;
            }
            return retorno;
        }
        /// <summary>
        /// Retorna true en caso de que halla en stock la cantidad solicitada de lentes.
        /// </summary>
        /// <param name="tipoLente"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public static bool ValidarStockLentes(ELente tipoLente, int cantidad)
        {
            bool retorno = false;

            switch (tipoLente)
            {
                case ELente.Vidrio:
                    if (cantidad <= cantidadLentesVidrio)
                    {
                        retorno = true;
                    }
                    break;                
                case ELente.Plastico:
                    if (cantidad <= cantidadLentesPlastico)
                    {
                        retorno = true;
                    }
                    break;
            }

            return retorno;
        }
        #endregion
    }
}