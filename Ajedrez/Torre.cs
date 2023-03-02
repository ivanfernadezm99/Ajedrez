using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    public class Torre : Pieza
    {
        public Torre(Color color, Posicion posicion, Jugador jugador) : base(color, posicion, jugador) { Nombre = "Torre"; }

        public override bool MovimientoValido(Posicion nuevaPosicion)
        {
            // Verificar que la nueva posición esté en la misma fila o columna que la posición actual
            if (nuevaPosicion.Fila == Posicion.Fila || nuevaPosicion.ColumnaInt == Posicion.ColumnaInt)
            {
                // Verificar que no haya ninguna otra pieza entre la posición actual y la nueva posición
                int filaInicio = Math.Min(Posicion.Fila, nuevaPosicion.Fila);
                int filaFin = Math.Max(Posicion.Fila, nuevaPosicion.Fila);
                int colInicio = Math.Min(Posicion.ColumnaInt, nuevaPosicion.ColumnaInt);
                int colFin = Math.Max(Posicion.ColumnaInt, nuevaPosicion.ColumnaInt);

                for (int fila = filaInicio; fila <= filaFin; fila++)
                {
                    for (int col = colInicio; col <= colFin; col++)
                    {
                        if (fila == Posicion.Fila && col == Posicion.ColumnaInt)
                        {
                            continue; // saltar la posición actual
                        }

                        Posicion posicionActual = new Posicion(col, fila);
                        Pieza piezaEnPosicion = Tablero.ObtenerPiezaEnPosicion(posicionActual);
                        if (piezaEnPosicion != null && piezaEnPosicion.Color == Color)
                        {
                            return false; // hay otra pieza en el camino
                        }
                        Pieza piezaNuevaPosicion = Tablero.ObtenerPiezaEnPosicion(nuevaPosicion);
                        //Comer pieza
                        if (piezaNuevaPosicion != null && piezaNuevaPosicion.Color != Color)
                        {
                            Console.WriteLine("La pieza: " + piezaNuevaPosicion.Nombre + " " + piezaNuevaPosicion.Color + " fué comida...");
                            //Se carga la pieza comida antes de borrarla.
                            if (piezaNuevaPosicion.Color == Color.Blanco)
                                Jugador.AgregarPiezaCapturadaBlanca(Tablero.casillas[piezaNuevaPosicion.Posicion.ColumnaInt, piezaNuevaPosicion.Posicion.Fila]);
                            else
                                Jugador.AgregarPiezaCapturadaNegra(Tablero.casillas[piezaNuevaPosicion.Posicion.ColumnaInt, piezaNuevaPosicion.Posicion.Fila]);

                            Tablero.casillas[nuevaPosicion.ColumnaInt, nuevaPosicion.Fila] = Tablero.casillas[this.Posicion.ColumnaInt, this.Posicion.Fila];
                            Tablero.casillas[this.Posicion.ColumnaInt, this.Posicion.Fila] = null;

                            //Poner currentx y currentY con los valores de newx y newy
                            Posicion.ColumnaInt = nuevaPosicion.ColumnaInt;
                            Posicion.Fila = nuevaPosicion.Fila;
                            return true;
                        }
                    }
                }


                

                // Avanzar.

                Tablero.casillas[nuevaPosicion.ColumnaInt, nuevaPosicion.Fila] = Tablero.casillas[this.Posicion.ColumnaInt, this.Posicion.Fila];
                Tablero.casillas[this.Posicion.ColumnaInt, this.Posicion.Fila] = null;

                //Poner currentx y currentY con los valores de newx y newy
                Posicion.ColumnaInt = nuevaPosicion.ColumnaInt;
                Posicion.Fila = nuevaPosicion.Fila;
                return true;
            




        }

            // La nueva posición no está en la misma fila ni columna
            return false;
        }
    }
}
