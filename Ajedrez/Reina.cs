using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    public class Reina : Pieza
    {
        public Reina(Color color, Posicion posicion, Jugador jugador) : base(color, posicion, jugador) 
        {
            Nombre = "Reina";
            jugador1 = jugador;
        }
        Jugador jugador1;
        public override bool MovimientoValido(Posicion nuevaPosicion)
        {
            // Verificar si la nueva posición está dentro del tablero
            if (!nuevaPosicion.PosicionDentroDelTablero())
            {
                return false;
            }

            // Verificar si la nueva posición es horizontal, vertical o diagonalmente alineada con la posición actual
            int difFilas = Math.Abs(nuevaPosicion.Fila - Posicion.Fila);
            int difColumnas = Math.Abs(nuevaPosicion.Columna - Posicion.Columna);

            if (!((difFilas == 0 && difColumnas > 0) || (difFilas > 0 && difColumnas == 0) || (difFilas == difColumnas)))
            {
                return false;
            }

            // Verificar si hay alguna pieza en el camino hacia la nueva posición
            int colInicio = Math.Min(Posicion.Columna, nuevaPosicion.Columna);
            int filaInicio = Math.Min(Posicion.Fila, nuevaPosicion.Fila);
            int colFin = Math.Max(Posicion.Columna, nuevaPosicion.Columna);
            int filaFin = Math.Max(Posicion.Fila, nuevaPosicion.Fila);

            int direccionColumnas = 0;
            int direccionFilas = 0;

            if (colInicio != colFin)
            {
                direccionColumnas = (nuevaPosicion.Columna > Posicion.Columna) ? 1 : -1;
            }

            if (filaInicio != filaFin)
            {
                direccionFilas = (nuevaPosicion.Fila > Posicion.Fila) ? 1 : -1;
            }

            for (int fila = Posicion.Fila + direccionFilas, col = Posicion.Columna + direccionColumnas;
                fila != nuevaPosicion.Fila || col != nuevaPosicion.Columna;
                fila += direccionFilas, col += direccionColumnas)
            {
                if (Tablero.ObtenerPiezaEnPosicion(nuevaPosicion) != null)
                {
                    if (Tablero.ObtenerPiezaEnPosicion(nuevaPosicion) != null && Tablero.ObtenerPiezaEnPosicion(nuevaPosicion).Color != Color)
                    {
                        Console.WriteLine("El jugador: " + jugador1.ColorDePiezas + " Ha comido la pieza: " + Tablero.casillas[nuevaPosicion.ColumnaInt, nuevaPosicion.Fila].Nombre);
                        Tablero.casillas[nuevaPosicion.ColumnaInt, nuevaPosicion.Fila] = Tablero.casillas[Posicion.ColumnaInt, Posicion.Fila];
                        Tablero.casillas[Posicion.ColumnaInt, Posicion.Fila] = null;
                        return true;
                    }
                    return false;
                }
            }

            // Verificar si hay alguna pieza en la nueva posición
            Pieza piezaNuevaPosicion = Tablero.ObtenerPiezaEnPosicion(nuevaPosicion);
            if (piezaNuevaPosicion != null && piezaNuevaPosicion.Color == Color)
            {
                return false;
            }

            

            // Si pasa todas las validaciones anteriores, entonces el movimiento es válido
            Tablero.casillas[nuevaPosicion.ColumnaInt, nuevaPosicion.Fila] = Tablero.casillas[Posicion.ColumnaInt, Posicion.Fila];
            Tablero.casillas[Posicion.ColumnaInt, Posicion.Fila] = null;
            return true;
        }
    }

}
