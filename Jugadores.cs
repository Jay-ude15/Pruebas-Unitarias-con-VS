using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jugadores
{
    public class Jugador
    {
        //Campos
        private string _nombre;
        private int _vida;
        private double _oro;
        private bool _npc;
        private int _resistencia;

        // Constructor
        public Jugador()
        {

        }

        public Jugador(string nombre, int vida = 100, double oro = 0, int resistencia = 50)
        {
            Nombre = nombre;
            _vida = vida;
            _oro = oro;
            _npc = false;
            _resistencia = resistencia;
        }

        // Propiedades o Métodos Getters
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Nombre));
                }

                _nombre = value;
            }
        }
        public int Vida
        {
            get { return _vida; }
        }
        public double Oro
        {
            get { return _oro; }
        }
        public bool Npc
        {
            get { return _npc; }
        }
        public int Resistencia
        {
            get { return _resistencia; }
        }

        // Métodos
        public void CambiarNombre(string nuevoNombre)
        {
            if (nuevoNombre == null)
            {
                throw new ArgumentNullException(nameof(nuevoNombre), "El nombre no puede ser null o vacío.");
            }

            _nombre = nuevoNombre;
        }

        public void AnyadirOro(int cantidad)
        {
            if (cantidad < 0)
            {
                throw new ArgumentException("La cantidad no puede ser negativa.");
            }

            _oro += cantidad;
        }

        public void QuitarOro(int cantidad)
        {

            if (cantidad < 0)
            {
                throw new ArgumentException("La cantidad no puede ser negativa");
            }
            if (cantidad > _oro)
            {
                throw new ArgumentOutOfRangeException("No hay suficiente oro.");
            }

            _oro -= cantidad;
        }

        public void AsignarNPC()
        {
            _npc = true;
        }
        public void DesAsignarNPC()
        {
            _npc = false;
        }
        public void AnyadirResistencia()
        {
            if (_npc)
            {
                throw new InvalidOperationException("Error de resistencia, este personaje es un npc.");
            }
            _resistencia += 10;
        }
        public void QuitarResistencia()
        {
            if (Resistencia <= 0)
            {
                throw new ArgumentOutOfRangeException("No se puede reducir la resistencia porque es 0 o menor");
            }

            _resistencia -= 10;
        }
        public void QuitarVida(int cantidad)
        {
            _vida -= cantidad;
        }
    }
}
