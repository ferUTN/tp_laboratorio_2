using System.Text;
using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region enumerados
        /// <summary>
        /// Enumerado para las posibles nacionalidades de las personas
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region atributos y propiedades
        /// <summary>
        /// Atributos
        /// </summary>
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        /// <summary>
        /// Propiedad de lectura y escritura del atributo apellido con validación de escritura
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo nombre con validación de escritura
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }
        
        /// <summary>
        /// Propiedad de lectura y escritura del atributo nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo dni con validación de escritura según nacionalidad
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad de escritura del atributo dni con validación según nacionalidad.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {            
            this.nombre = "";
            this.apellido = "";
            this.nacionalidad = ENacionalidad.Argentino;
            this.dni = 1;
        }

        /// <summary>
        /// Constructor sobrecargado
        /// </summary>
        /// <param name="nombre">Recibe el nombre</param>
        /// <param name="apellido">Recibe el apellido</param>
        /// <param name="nacionalidad">Recibe la nacionalidad</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad):this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor sobrecargado
        /// </summary>
        /// <param name="nombre">Recibe el nombre</param>
        /// <param name="apellido">Recibe el apellido</param>
        /// <param name="dni">Recine el dni</param>
        /// <param name="nacionalidad">Recibe la nacionalidad</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor sobrecargado
        /// </summary>
        /// <param name="nombre">Recibe el nombre</param>
        /// <param name="apellido">Recibe el apellido</param>
        /// <param name="dni">Recibe el dni</param>
        /// <param name="nacionalidad">Recibe la nacionalidad</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Sobreescritura del método ToString()
        /// </summary>
        /// <returns>Devuelve los datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.apellido, this.nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.nacionalidad);
            return sb.ToString();
        }

        /// <summary>
        /// Método que valida el dni según la nacionalidad
        /// </summary>
        /// <param name="nacionalidad">Recibe la nacionalidad</param>
        /// <param name="dato">Recibe el dni</param>
        /// <returns>Retorna el dni validado</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            //switch (nacionalidad)
            //{
            //    case ENacionalidad.Argentino:
            //        if (dato < 1 || dato > 89999999)
            //        {
            //            throw new NacionalidadInvalidaException("Nro de DNI incorrecto para un argentino");
            //        }
            //        break;
            //    case ENacionalidad.Extranjero:
            //        if (dato < 90000000 || dato > 99999999)
            //        {
            //            throw new NacionalidadInvalidaException("Nro de DNI incorrecto para un extranjero");
            //        }
            //        break;
            //}

            if( !((nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999) || 
                 (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)) )
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
            }

            return dato;
        }

        /// <summary>
        /// Método que valida el dni.
        /// Para que un dni sea valido tiene que ser númerico, tener entre 1 y 8 caracteres y corresponder a una nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">Recibe la nacionalidad</param>
        /// <param name="dato">Recibe el dni</param>
        /// <returns>Retorna el dni validado</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            dato = dato.Replace(".", "");
            if (dato.Length < 1 || dato.Length > 8 || !int.TryParse(dato, out dni))
            {
                throw new DniInvalidoException();
            }
            return this.ValidarDni(nacionalidad, dni);
        }

        /// <summary>
        /// Método que valida una cadena correspondiente a un nombre o apellido.
        /// Para que la cadena sea válida, solo puede contener letras y espacios.
        /// Si no se la pudo validar, se reemplaza por una cadena vacía.
        /// </summary>
        /// <param name="dato">Recibe la cadena a validar</param>
        /// <returns>Retorna la cadena validada</returns>
        private string ValidarNombreApellido(string dato)
        {
            string aux = "";
            if (Regex.IsMatch(dato, @"^[a-zA-Z\s]+$"))
            {
                aux = dato;
            }
            return aux;
        }
        #endregion
    }
}
