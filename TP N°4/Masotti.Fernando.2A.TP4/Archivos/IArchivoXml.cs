using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Interface genérica para el manejo de archivos XML
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IArchivoXml<T>
    {
        /// <summary>
        /// Método abstracto para guardar datos en un archivo
        /// </summary>
        /// <param name="archivo">La ruta del archivo</param>
        /// <param name="datos">Los datos a guardar</param>
        /// <returns>Retorna true si se pudo guardar</returns>
        bool Guardar(string archivo, T datos);


        /// <summary>
        /// Método abstracto para leer los datos de un archivo
        /// </summary>
        /// <param name="archivo">La ruta del archivo</param>
        /// <param name="datos">Los datos leidos</param>
        /// <returns>Retorna true si se pudo leer</returns>
        bool Leer(string archivo, out T datos);
    }
}
