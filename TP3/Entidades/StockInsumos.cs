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
        private static int cantidadLentesMetal;
        private static int cantidadLentesVidrio;
        private static int cantidadArmazonAcero;
        private static int cantidadArmazonAluminio;
        private static int cantidadArmazonPlastico;

        #region Contructor
        static StockInsumos()
        {
            cantidadLentesPlastico = 50;
            cantidadLentesMetal = 50;
            cantidadLentesVidrio = 50;
            cantidadArmazonAcero = 50;
            cantidadArmazonAluminio = 50;
            cantidadArmazonPlastico = 50;
        }
        #endregion

        #region Propiedades

        public static int LentesPlastico { get { return cantidadLentesPlastico; } }
        public static int LentesVidrio { get { return cantidadLentesVidrio; } }
        public static int LentesMetal { get { return cantidadLentesMetal; } }

        public static int ArmazonAcero { get { return cantidadArmazonAcero; } }
        public static int ArmazonAluminio { get { return cantidadArmazonAluminio; } }
        public static int ArmazonPlastico { get { return cantidadArmazonPlastico; } }
        #endregion

        #region Metodos
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



        public static void AgregarLentes(ELente tipo, int cantidad)
        {


            switch (tipo)
            {
                case ELente.Vidrio:
                    cantidadLentesVidrio += cantidad;
                    break;
                case ELente.Metal:
                    cantidadLentesMetal += cantidad;
                    break;
                case ELente.Plastico:
                    cantidadLentesPlastico += cantidad;
                    break;
            }


        }

        public static void DescontarLentes(ELente tipo, int cantidad)
        {
            switch (tipo)
            {
                case ELente.Vidrio:
                    cantidadLentesVidrio -= cantidad;
                    break;
                case ELente.Metal:
                    cantidadLentesMetal -= cantidad;
                    break;
                case ELente.Plastico:
                    cantidadLentesPlastico -= cantidad;
                    break;
            }
        }
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
                case ELente.Metal:
                    if (cantidad <= cantidadLentesMetal)
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



