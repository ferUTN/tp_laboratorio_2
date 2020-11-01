using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Excepción sin profesor
        /// </summary>
        public SinProfesorException() : base("No hay Profesor para la clase.")
        {

        }
    }
}
