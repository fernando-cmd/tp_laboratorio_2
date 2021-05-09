using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region "Constructores"

        /// <summary>
        /// Constructor sin parametros, asigna el valor 0 al campo numero.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor que recibe un double como parametro
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Consturctor que recibe un string como parametro y lo convierte en double y asigna al campo numero ese valor
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Setea un numero
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = this.ValidarNumero(value);
            }
        }
        #endregion

        #region "Validaciones"
        /// <summary>
        /// Valida que el parametro recibido sea un double y lo retorna,
        /// caso contrario retorna 0.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;
            double numero;
            if (double.TryParse(strNumero, out numero))
            {
                retorno = numero;
            }
            return retorno;
        }

        /// <summary>
        /// Devuelve true si el string pasado es un numero binario,
        /// false en caso contrario
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private bool EsBinario(string binario)
        {
            bool retorno = true;

            foreach (char caracter in binario)
            {
                if (caracter != '0' && caracter != '1')
                {
                    retorno = false;
                }
            }
            return retorno;

        }
        #endregion

        #region "Sobrecarga Operadores"

        /// <summary>
        /// Sobrecarga del operador +
        /// Suma los campos numero de dos objetos del tipo Numero
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator +(Numero num1, Numero num2)
        {
            double retorno = num1.numero + num2.numero;

            return retorno;
        }

        /// <summary>
        /// Sobercarga del operador -
        /// Resta los campos numero de dos objetos
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator -(Numero num1, Numero num2)
        {
            double retorno = num1.numero - num2.numero;

            return retorno;
        }
        /// <summary>
        /// Sobercagar operador *
        /// Multiplica los campo numero de dos objetos
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator *(Numero num1, Numero num2)
        {
            double retorno = num1.numero * num2.numero;

            return retorno;
        }

        /// <summary>
        /// Verifica que el segundo parametro sea igual a 0,
        /// si es igual a 0 retorna un double.MinValue
        /// caso contrario realiza la division 
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator /(Numero num1, Numero num2)
        {
            double retorno;
            if (num2.numero == 0)
            {
                retorno = double.MinValue;
            }
            else
            {
                retorno = num1.numero / num2.numero;
            }

            return retorno;
        }
        #endregion

        #region "Conversores"

        /// <summary>
        /// Valida que se trate de un numero binario
        /// Convierte el numero en decimal en caso que sea posible
        /// caso contrario retornará "Valor inválido".
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            double digito;
            double numDecimal = 0;
            string resultado;
            int potencia = binario.Length - 1;
            int len = binario.Length;
            int i;

            if (EsBinario(binario))
            {
                for (i = 0; i < len; i++)
                {
                    digito = double.Parse(binario[i].ToString());
                    numDecimal = numDecimal + (digito * Math.Pow(2, potencia));
                    potencia--;
                }
                resultado = numDecimal.ToString();
            }
            else
            {
                return "Valor Invalido";
            }
            return resultado;
        }

        /// <summary>
        /// Verifica que el numero ingresado sea mayor a 0
        /// y lo convierte a numero a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            int num = (int)numero;
            string retorno = "";
            if (num > 0)
            {
                while (num > 0)
                {
                    if (num % 2 == 0)
                    {
                        retorno = "0" + retorno;
                    }
                    else
                    {
                        retorno = "1" + retorno;
                    }
                    num = (int)(num / 2);
                }
            }
            else
            {
                retorno = "Valor Invalido";
            }
            return retorno;
        }

        public string DecimalBinario(string numero)
        {
            string retorno = "";
            double numeroDecimal;
            if (double.TryParse(numero, out numeroDecimal))
            {
                retorno = DecimalBinario(numeroDecimal);
            }
            return retorno;
        }

        #endregion
    }
}