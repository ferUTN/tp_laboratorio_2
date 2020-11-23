using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    /// <summary>
    /// Clase genérica para la serialización en XML
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Xml<T> : IArchivoXml<T>
    {
        /// <summary>
        /// Implementación del método Guardar para archivos XML
        /// </summary>
        /// <param name="archivo">La ruta del archivo</param>
        /// <param name="datos">Los datos a guardar</param>
        /// <returns>Retorna true si se pudo guardar</returns>
        public bool Guardar(string archivo, T datos)
        {
            if (archivo == null)
            {
                throw new ArchivosException(new Exception("Error en el archivo XML a guardar."));
            }

            if (datos == null)
            {
                throw new ArchivosException(new Exception("Error en los datos a guardar en el archivo XML."));
            }

            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(writer, datos);
                    return true;
                }

            }
            catch (Exception e)
            {
                throw new ArchivosException(new Exception("No se pudo escribir en el archivo XML."));
            }
        }

        /// <summary>
        /// Implementación del método Leer para archivos XML
        /// </summary>
        /// <param name="archivo">La ruta del archivo</param>
        /// <param name="datos">Los datos leidos</param>
        /// <returns>Retorna true si se pudo leer</returns>
        public bool Leer(string archivo, out T datos)
        {
            if (archivo == null)
            {
                throw new ArchivosException(new Exception("Error en el archivo XML a leer."));
            }

            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = (T)ser.Deserialize(reader);
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(new Exception("No se pudo leer el archivo XML."));
            }
        }
    }
}
