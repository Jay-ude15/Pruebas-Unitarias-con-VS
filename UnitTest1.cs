using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Jugadores;

namespace TestJugador
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Verificar_AsignarNombreCorrectamente_AlCrearJugador()
        {
            // Preparación
            Jugador jugador = new Jugador("Ash");

            // Assert
            Assert.AreEqual("Ash", jugador.Nombre);
        }        

        [TestMethod]
        public void Comprobar_AnyadirOro_SeIncrementaElValor()
        {
            // Preparación
            Jugador jugador = new Jugador("Ash");
            double oroInicial = jugador.Oro;

            // Acción
            jugador.AnyadirOro(50);

            // Verificar
            Assert.AreEqual(oroInicial + 50, jugador.Oro);
        }

        [TestMethod]
        public void Comprobar_QuitarVida_SeReduceCorrectamente()
        {
            // Preparación
            Jugador jugador = new Jugador("Ash");
            int vidaInicial = jugador.Vida;

            // Acción
            jugador.QuitarVida(20);

            // Verificar
            Assert.AreEqual(vidaInicial - 20, jugador.Vida);
        }

        [TestMethod]
        public void Verificar_NPCEsFalse()
        {
            // Preparación
            Jugador jugador = new Jugador("Ash");

            // Verificar
            Assert.IsFalse(jugador.Npc);
        }

        [TestMethod]
        public void Comprobar_AlAsignarNPC_DevuelveTrue()
        {
            //Preparación
            Jugador jugador = new Jugador("Ash");

            // Acción
            jugador.AsignarNPC();

            // Verificar
            Assert.IsTrue(jugador.Npc);
        }

        [TestMethod]
        public void Comprobar_AlDesAsignarNPC_DevuelveFalse()
        {
            // Preparación
            Jugador jugador = new Jugador("Ash");

            // Acción
            jugador.AsignarNPC();
            jugador.DesAsignarNPC();

            // Verificar
            Assert.IsFalse(jugador.Npc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void QuitarOro_MasDelDisponible_LanzaExcepcion()
        {
            // Preparación
            Jugador jugador = new Jugador("Ash");
            jugador.AnyadirOro(50);

            // Act
            jugador.QuitarOro(100);

            // la afirmación es manejado por el atributo ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void QuitarResistencia_CuandoNoEsPosible_LanzaExcepcion()
        {
            // Preparación 
            // La resistencia inicializa a 50 por defecto.
            Jugador jugador = new Jugador("Ash");

            // Quitar varias veces hasta llegar a 0
            jugador.QuitarResistencia(); // 40
            jugador.QuitarResistencia(); // 30
            jugador.QuitarResistencia(); // 20
            jugador.QuitarResistencia(); // 10
            jugador.QuitarResistencia(); // 0

            // Una más para lanzar Excepción
            jugador.QuitarResistencia();

            // la afirmación es manejado por el atributo ExpectedException

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CambiarNombreANull_LanzaExcepcion()
        {
            // Preparación
            var jugador = new Jugador("Ash");

            // Acción
            jugador.CambiarNombre(null);

            // la afirmación es manejado por el atributo ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CrearJugador_NombreNull_LanzaExcepcion()
        {
            // Acción
            var jugador = new Jugador(null);

            // la afirmación es manejado por el atributo ExpectedException

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AnyadirResistencia_ConNPC_LanzaExcepcion()
        {
            // Preparación
            Jugador jugador = new Jugador("Ash");
            jugador.AsignarNPC();


            // Acción
            jugador.AnyadirResistencia();

            // la afirmación es manejado por el atributo ExpectedException
        }

    }
}
