using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    public class Caballo : Pieza
    {
        public Caballo(Color color, Posicion posicion, Jugador jugador) : base(color, posicion, jugador) 
        { Nombre = "Caballo";
            posicion2 = posicion;
        }

        Posicion posicion2;
        public override bool MovimientoValido(Posicion nuevaPosicion)
        {

            // Verificar si la nueva posición está dentro del tablero
            if (!nuevaPosicion.PosicionDentroDelTablero())
            {
                return false;
            }

            // Verificar si el movimiento es en forma de "L" (2 filas y 1 columna o 1 fila y 2 columnas)
            int difFilas = Math.Abs(nuevaPosicion.Fila - Posicion.Fila);
            int difColumnas = Math.Abs(nuevaPosicion.ColumnaInt - Posicion.ColumnaInt);

            if (!((difFilas == 2 && difColumnas == 1) || (difFilas == 1 && difColumnas == 2)))
            {
                return false;
            }

            // Verificar si hay alguna pieza en la nueva posición
            Pieza piezaNuevaPosicion = Tablero.ObtenerPiezaEnPosicion(nuevaPosicion);

            if (piezaNuevaPosicion != null && piezaNuevaPosicion.Color == Color)
            {
                return false;
            }
            //Comer pieza
            if (piezaNuevaPosicion != null && piezaNuevaPosicion.Color != Color)
            {
                Console.WriteLine("La pieza: " + piezaNuevaPosicion.Nombre + " " + piezaNuevaPosicion.Color + " fué comida...");
                //Se carga la pieza comida antes de borrarla.
                Jugador.AgregarPiezaCapturadaBlanca(Tablero.casillas[piezaNuevaPosicion.Posicion.ColumnaInt, piezaNuevaPosicion.Posicion.Fila]);

                Tablero.casillas[nuevaPosicion.ColumnaInt, nuevaPosicion.Fila] = Tablero.casillas[this.Posicion.ColumnaInt, this.Posicion.Fila];
                Tablero.casillas[this.Posicion.ColumnaInt, this.Posicion.Fila] = null;

                //Poner currentx y currentY con los valores de newx y newy
                Posicion.ColumnaInt = nuevaPosicion.ColumnaInt;
                Posicion.Fila = nuevaPosicion.Fila;
                return true;
            }


            // Avanzar.

            Tablero.casillas[nuevaPosicion.ColumnaInt, nuevaPosicion.Fila] = Tablero.casillas[this.Posicion.ColumnaInt, this.Posicion.Fila];
            Tablero.casillas[this.Posicion.ColumnaInt, this.Posicion.Fila] = null;

            //Poner currentx y currentY con los valores de newx y newy
            Posicion.ColumnaInt = nuevaPosicion.ColumnaInt;
            Posicion.Fila = nuevaPosicion.Fila;
            return true;
        }
    }

}
