using System;
using System.Collections.Generic;
using System.Text;
using Excepciones;
using Archivos;
using System.Linq;

namespace Entidades
{
    public class Universidad
    {
        #region enumerados
        /// <summary>
        /// Enumerado de las posibles clases que se dictan en la universidad
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        /// <summary>
        /// Atributos
        /// </summary>
        #region atributos y propiedades
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        /// <summary>
        /// Propiedad de lectura y escritura de la lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de la lista de profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de la lista de jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        #endregion

        #region indexador
        /// <summary>
        /// Indexador de la jornada
        /// Permite acceder a una jornada específica a través de un indice
        /// </summary>
        /// <param name="i">Recibe el indice en donde leer o asignar la jornada</param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.jornada.Count)
                {
                    return this.jornada[i];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    this.Jornadas[i] = value;
                }
            }
        }
        #endregion

        #region constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region metodos
        /// <summary>
        /// Método estático Guardar
        /// Guarda una universidad en el archivo XML datosUniversidad.xml
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>Retorna true si se pudo guardar</returns>
        public static bool Guardar(Universidad uni)
        {
            try
            {
                Xml<Universidad> datosUniversidad = new Xml<Universidad>();
                datosUniversidad.Guardar("datosUniversidad.xml", uni);
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Método estático Leer
        /// Lee los datos del archivo XML datosUniversidad.xml
        /// </summary>
        /// <returns>Retorna un objeto universidad con los datos leidos del archivo</returns>
        public static Universidad Leer()
        {
            Universidad universidad= null;
            try
            {
                Xml<Universidad> datosUniversidad = new Xml<Universidad>();
                datosUniversidad.Leer("datosUniversidad.xml", out universidad);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return universidad;
        }

        /// <summary>
        /// Muestra los datos de la universidad
        /// </summary>
        /// <param name="uni">Retorna los datos de la universidad</param>
        /// <returns></returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            foreach (Jornada item in this.Jornadas)
            {
                sb.AppendFormat("{0}", item.ToString());
                sb.AppendLine("<------------------------------------------------------------------------------------>");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Sobreescritura del método ToString
        /// </summary>
        /// <returns>Retorna los datos de la universidad</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region sobrecarga de operadores
        /// <summary>
        /// Sobrecarga del operador ==
        /// Una universidad es igual a un alumno si ese alumno está en la lista de alumnos de la universidad
        /// </summary>
        /// <param name="g">Recibe una universidad</param>
        /// <param name="a">Recibe un alumno</param>
        /// <returns>Retorna true si son iguales</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool aux = false;
            foreach (Alumno item in g.alumnos)
            {
                if (item == a)
                {
                    aux = true;
                    break;
                }
            }
            return aux;
        }

        /// <summary>
        /// Sobreescritura del método !=
        /// </summary>
        /// <param name="g">Recibe una universidad</param>
        /// <param name="a">Recive un alumno</param>
        /// <returns>Retorna true si son distintos</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Sobreescritura del método ==
        /// Una universidad es igual a un profesor si ese profesor está en la lista de profesores de la universidad
        /// </summary>
        /// <param name="g">Recibe una universidad</param>
        /// <param name="i">Recibe un profesor</param>
        /// <returns>Retorna true si son iguales</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool aux = false;
            foreach (Profesor item in g.profesores)
            {
                if (item == i)
                {
                    aux = true;
                    break;
                }
            }
            return aux;
        }

        /// <summary>
        /// Sobrecarga del método !=
        /// </summary>
        /// <param name="g">Recibe una universidad</param>
        /// <param name="i">Recibe un profesor</param>
        /// <returns>Retorna true si son distintos</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Sobrecarga del operador ==
        /// Una universidad y una clase son iguales si esa clase la puede dictar un profesor de la lista de profesores
        /// de la universidad.
        /// </summary>
        /// <param name="u">Recibe una universidad</param>
        /// <param name="clase">Recibe una clase</param>
        /// <returns>Retorna el primer profesor que pueda dictar la clase o lanzará una excepción si nadie puede</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor prof = null; ;
            bool aux = false;
            foreach (Profesor item in u.profesores)
            {
                if (item == clase)
                {
                    prof = item;
                    aux = true;
                    break;
                }
            }
            if (!aux)
            {
                throw new SinProfesorException();
            }
            return prof;
        }

        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="u">Recibe una universidad</param>
        /// <param name="clase">Recibe una clase</param>
        /// <returns>Retorna el primer profesor que no pueda dictar la clase</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor prof = null;
            foreach (Profesor item in u.profesores)
            {
                if (item != clase)
                {
                    prof = item;
                    break;
                }
            }
            return prof;
        }

        /// <summary>
        /// Sobrecarga del operador +
        /// Agrega un profesor a la lista de profesores de la universidad
        /// </summary>
        /// <param name="u">Recibe la universidad</param>
        /// <param name="i">Recibe el profesor</param>
        /// <returns>Retorna la universidad</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u!= i)
            {
                u.profesores.Add(i);
            }
            return u;
        }

        /// <summary>
        /// Sobrecarga del operador +
        /// Agrega una nueva jornada de la clase a la universidad, asigna un profesor que la pueda dictar y agrega
        /// alumnos a la jornada
        /// </summary>
        /// <param name="g">Recibe una universidad</param>
        /// <param name="clase">Recibe una clase</param>
        /// <returns>Retorna la universidad</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada nuevaJornada = new Jornada(clase, (g == clase));
            foreach (Alumno item in g.alumnos)
            {
                if(item == clase)
                {
                    nuevaJornada.Alumnos.Add(item); 
                }
            }
            g.jornada.Add(nuevaJornada);
            return g;
        }

        /// <summary>
        /// Sobrecarga del operador +
        /// Agrega alumnos a la lista de alumnos de la universidad
        /// </summary>
        /// <param name="u">Recibe una universidad</param>
        /// <param name="a">Recibe un alumno</param>
        /// <returns>Retorna la universidad</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u!= a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }
        #endregion
    }
}
