using Archivos;
using Entidades;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test_Unitarios
{
    [TestClass]
    public class UnitTests
    {

        /// <summary>
        /// Test que verifica que se lance la excepción de archivos al querer guardar el xml con datos nulos. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void GuardarUniversidadXml_Exception()
        {
            Xml<Universidad> datosUni = new Xml<Universidad>();

            datosUni.Guardar("archivoTest", null);
        }

        /// <summary>
        /// Test que verifica que se lance la excepción ArchivosException al querer leer un archivo nulo.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void LeerUniversidadXml_Exception()
        {
            Xml<Universidad> datosUni = new Xml<Universidad>();
            Universidad universidad = new Universidad();

            datosUni.Leer(null, out universidad);
        }


        /// <summary>
        /// Test que verifica que se instancie la lista de alumnos de la universidad.
        /// </summary>
        [TestMethod]
        public void CrearUniversidad()
        {
            Universidad universidad = new Universidad();

            Assert.IsNotNull(universidad.Alumnos);
        }

        /// <summary>
        /// Test que verifica que se agregue correctamente un alumno a la jornada.
        /// </summary>
        [TestMethod]
        public void CrearJornada()
        {
            Jornada jornada = new Jornada(Universidad.EClases.Laboratorio, new Profesor());
            Alumno alumno = new Alumno();

            jornada += alumno;

            Assert.IsNotNull(jornada.Alumnos);
        }

        /// <summary>
        /// Test que verifica que se lance la excepción SinProfesorException al querer agregar una clase para la cual
        /// la universidad no tiene profesor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void SinProfesor_Exception()
        {
            Universidad universidad = new Universidad();
            Profesor profesorLaboratorioProgramacion = new Profesor();
            universidad += profesorLaboratorioProgramacion;

            universidad += Universidad.EClases.Legislacion;
        }

        /// <summary>
        /// Test que verifica que se pueda agregar correctamente profesores y alumnos a la universidad.
        /// </summary>
        [TestMethod]
        public void AgregarProfesorAlumno()
        {
            Universidad universidad = new Universidad();
            Alumno alumno = new Alumno();
            Profesor profesor = new Profesor();

            try
            {
                universidad += profesor;
                universidad += alumno;                
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
