using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, nacionalidad)
        {
            this.legajo = legajo;
        }

        protected abstract string ParticiparEnClase();

        protected virtual string MostrarDatos()
        {
            return base.ToString() + "\n\nLEGAJO NÚMERO: " + this.legajo;
        }


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


        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool aux = false;
            if (((Universitario)pg1 == (Universitario)pg2) && (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo))
            {
                aux = true;
            }
            return aux;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }


    }
}
