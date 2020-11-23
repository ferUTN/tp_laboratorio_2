using System;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Excepción de alumno repetido
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido.")
        {

        }
    }
}
