using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    public class Alfil : Pieza
    {
        public Alfil(Color color, Posicion posicion, Jugador jugador) : base(color, posicion, jugador) 
        {
            Nombre = "Alfil";
        }

        public override bool MovimientoValido(Posicion nuevaPosicion)
        {
            // Verificar si la nueva posición está dentro del tablero
            if (!nuevaPosicion.PosicionDentroDelTablero())
            {
                return false;
            }

            // Verificar si la nueva posición está en una diagonal con respecto a la posición actual
            int difFilas = Math.Abs(nuevaPosicion.Fila - Posicion.Fila);
            int difColumnas = Math.Abs(nuevaPosicion.ColumnaInt - Posicion.ColumnaInt);

            if (difFilas != difColumnas)
            {
                return false;
            }

            // Verificar si hay alguna pieza en el camino hacia la nueva posición
            int colInicio = Math.Min(Posicion.ColumnaInt, nuevaPosicion.ColumnaInt);
            int filaInicio = Math.Min(Posicion.Fila, nuevaPosicion.Fila);
            int colFin = Math.Max(Posicion.ColumnaInt, nuevaPosicion.ColumnaInt);
            int filaFin = Math.Max(Posicion.Fila, nuevaPosicion.Fila);

            for (int fila = filaInicio + 1, col = colInicio + 1; fila < filaFin && col < colFin; fila++, col++)
            {
                if (Tablero.casillas[fila, col] != null)
                {
                    return false;
                }
            }
            Pieza piezaNuevaPosicion = Tablero.ObtenerPiezaEnPosicion(nuevaPosicion);
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
