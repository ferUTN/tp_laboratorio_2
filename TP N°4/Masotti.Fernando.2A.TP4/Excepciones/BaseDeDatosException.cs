using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class BaseDeDatosException : Exception
    {
        /// <summary>
        /// Excepción de error en la lectura o escritura de la base de datos
        /// </summary>
        /// <param name="innerException"></param>
        public BaseDeDatosException(Exception innerException) : base("Error de lectura/escritura de la base de datos", innerException)
        {

        }
    }
}
