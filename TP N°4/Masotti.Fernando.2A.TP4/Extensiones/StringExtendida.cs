using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensiones
{
    public static class StringExtendida
    {
        /// <summary>
        /// Método extendido para la clase string
        /// </summary>
        /// <param name="cadena">Cadena a formatear</param>
        /// <returns>Devuelve la cadena con la primera letra de cada palabra en mayúscula</returns>
        public static string Formatear(this string cadena)
        {
            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(cadena);         
        }
    }
}
