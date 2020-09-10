namespace Entidades
{
    /// <summary>
    /// Clase estática Calculadora, contiene la lógica para realizar las operaciones
    /// </summary>
    
    public static class Calculadora
    {

        /// <summary>
        /// Método que valida el operador
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>Devuelve el operador validado (en caso de error devuelve el operador '+')</returns>
        private static string ValidarOperador(char operador)
        {
            string retorno = "+";
            if( (operador == '-') || (operador == '/') || (operador == '*')) {
                retorno= operador.ToString();
            }
            return retorno;
        }


        /// <summary>
        /// Método que realiza la operación
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <param name="operador">Operación a realizar</param>
        /// <returns>Devuelve el resultado de la operación</returns>
        
        
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;
            operador = ValidarOperador(char.Parse(operador));
            
            switch (operador)
            {
                case "+":
                    retorno = num1 + num2;
                    break;
                case "-":
                    retorno = num1 - num2;
                    break;
                case "*":
                    retorno = num1 * num2;
                    break;
                case "/":
                    retorno = num1 / num2;
                    break;
            }
            return retorno;
        }
    }
}