namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region atributos
        /// <summary>
        /// Atributo
        /// </summary>
        private int legajo;
        #endregion

        #region constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universitario() : base()
        {
            this.legajo = 1;
        }

        /// <summary>
        /// Constructor sobrecargado
        /// </summary>
        /// <param name="legajo">Recibe el legajo</param>
        /// <param name="nombre">Recibe el nombre</param>
        /// <param name="apellido">Recibe el apellido</param>
        /// <param name="dni">Recibe el dni</param>
        /// <param name="nacionalidad">Recibe la nacionalidad</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Método abstracto que indica las clases en las que participa el Universitario
        /// </summary>
        /// <returns>Retorna la información de la clase</returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Método que muestra los datos del Universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            return base.ToString() + "\n\nLEGAJO NÚMERO: " + this.legajo;
        }

        /// <summary>
        /// Sobreescritura del método Equals
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>Retorna true si son iguales</returns>
        public override bool Equals(object obj)
        {
            bool aux = false;
            if (obj is Universitario)
            {
                if (this == (Universitario)obj)
                {
                    aux = true;
                }

            }
            return aux;
        }
        #endregion

        #region sobrecargas de operadores
        /// <summary>
        /// Sobrecarga del operador ==
        /// Dos universitarios son iguales si son del mismo tipo y tienen el mismo dni o legajo
        /// </summary>
        /// <param name="pg1">Recibe un Universitario</param>
        /// <param name="pg2">Recibe un Universitario</param>
        /// <returns>Retorna true si son iguales</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool aux = false;
            if (pg1.GetType() == pg2.GetType() && (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo))
            {
                aux = true;
            }
            return aux;
        }

        /// <summary>
        /// Sobreescritura del operador !=
        /// Dos universitarios son distintos si no son iguales
        /// </summary>
        /// <param name="pg1">Recibe un Universitario</param>
        /// <param name="pg2">Recibe un Universitario</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
