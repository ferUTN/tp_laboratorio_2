using System;

namespace Entidades
{
    /// <summary>
    /// Clase Numero, define el nuevo tipo de dato "Numero"
    /// </summary>
    public class Numero
    {
        #region atributos y propiedades

        /// <summary>
        /// Atributo para cargar los operandos
        /// </summary>
        private double numero;


        /// <summary>
        /// Property SetNumero, setea al atributo numero previa validación
        /// </summary>
        private string SetNumero
        {
            set{
                this.numero = ValidarNumero(value);
            }
        }
        #endregion


        #region constructores

        /// <summary>
        /// Constructor por defecto, inicializa el atributo numero
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }


        /// <summary>
        /// Constructor sobrecargado
        /// </summary>
        /// <param name="strNumero">Recibe el número a setear en el atributo</param>
        public Numero(string strNumero): this()
        {
            SetNumero = strNumero;
        }


        /// <summary>
        /// Constructor sobrecargado
        /// </summary>
        /// <param name="numero">Recibe el número a setear en formato double</param>
        public Numero(double numero): this()
        {
            SetNumero = numero.ToString();
        }
        #endregion


        #region métodos

        /// <summary>
        /// Método estático que convierte un número binario a decimal
        /// </summary>
        /// <param name="binario">El número binario a convertir</param>
        /// <returns>El número convertido a decimal (si no se puede convertir devuelve "Valor inválido")</returns>
        public static string BinarioDecimal(string binario)
        {
            string retorno = "Valor inválido";

            if ( EsBinario(binario) )
            {
                double numeroConvertido = 0;
                int bit = 0;
                char[] array = binario.ToCharArray();

                for (int i = array.Length - 1; i >= 0; i--)
                {
                        numeroConvertido = numeroConvertido + Math.Pow(2, bit) * (int)Char.GetNumericValue(array[i]);
                        bit++;             
                }
                retorno = Convert.ToString(numeroConvertido);
            }
            return retorno;
        }


        /// <summary>
        /// Método que convierte un double a binario
        /// </summary>
        /// <param name="numero">El número a convertir</param>
        /// <returns>El número convertido a binario (si no se puede convertir devuelve "Valor inválido")</returns>
        public static string DecimalBinario(double numero)
        {
            return DecimalBinario(Convert.ToString(numero));
        }


        /// <summary>
        /// Método estático que convierte un número decimal a binario
        /// </summary>
        /// <param name="numero">El número decimal a convertir</param>
        /// <returns>El número convertido a binario (si no se puede convertir devuelve "Valor inválido")</returns>
        public static string DecimalBinario(string cadena)
        {
            string retorno = "Valor inválido";
            if (double.TryParse(cadena, out double numero))
            {
                numero = Math.Truncate(numero);
                if (numero > 0) {
                    numero = (uint)numero;
                    retorno = "";
                    while(numero > 0) {
                        if(numero % 2 == 0)
                        {
                            retorno = "0" + retorno;
                        }else {
                            retorno = "1" + retorno;
                        }
                        numero = (uint)numero / 2;
                    }
                }else if (numero == 0)
                {
                    retorno = "0";
                }
            }
            return retorno;
        }


        /// <summary>
        /// Método que valida los ceros y unos de una cadena
        /// </summary>
        /// <param name="binario">La cadena a validar</param>
        /// <returns>Devuelve verdadero si la cadena esta formada unicamente por unos y ceros</returns>
        private static bool EsBinario(string binario)
        {
            bool aux = true;
            char[] array = binario.ToCharArray();
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (!(array[i] == '1' || array[i] == '0'))
                {
                    aux = false;
                    break;
                }
            }
            return aux;
        }


        /// <summary>
        /// Método que valida el número a operar
        /// </summary>
        /// <param name="strNumero">El número a validar</param>
        /// <returns>El número validado (devuelve 0 si no se lo pudo validar)</returns>
        private double ValidarNumero(string strNumero)
        {
            if (!double.TryParse(strNumero, out double retorno))
            {
                retorno = 0;
            }
            return retorno;
        }
        #endregion


        #region sobrecarga de operadores

        /// <summary>
        /// Sobrecarga del operador '-'
        /// </summary>
        /// <param name="n1">El primer operando</param>
        /// <param name="n2">El segundo operando</param>
        /// <returns>El resultado de la operación</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }


        /// <summary>
        /// Sobrecarga del operado *
        /// </summary>
        /// <param name="n1">El primer operando</param>
        /// <param name="n2">El segundo operando</param>
        /// <returns>El resultado de la operación</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }


        /// <summary>
        /// Sobrecarga del operador '/'
        /// </summary>
        /// <param name="n1">El primer operando</param>
        /// <param name="n2">El segundo operando</param>
        /// <returns>El resultado de la operación</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = double.MinValue;
            if (n2.numero != 0)
            {
                retorno = n1.numero / n2.numero;
            }
            return retorno;
        }


        /// <summary>
        /// Sobrecarga del operador '+'
        /// </summary>
        /// <param name="n1">El primer operando</param>
        /// <param name="n2">El segundo operando</param>
        /// <returns>El resultado de la operación</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        #endregion
    }
}