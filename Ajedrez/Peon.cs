using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    public class Peon : Pieza
    {
        public Peon(Color color, Posicion posicion, Jugador jugador) : base(color, posicion, jugador)
        {
            Nombre = "Peon";
        }

        public override bool MovimientoValido(Posicion OtraPosicion)
        {
            int currentX = Posicion.ColumnaInt;
            int currentY = Posicion.Fila;
            int newX = OtraPosicion.ColumnaInt;
            int newY = OtraPosicion.Fila;

            // Si se intenta mover el peón a una casilla que ya está ocupada, retorna falso
            if (Tablero.casillas[newX, newY] != null && Tablero.casillas[newX, newY].Color == Color)
            {
                return false;
            }
            //Para piezas blancas
            if ((Tablero.casillas[currentX, currentY]).Color == Color.Blanco)
            {
                // El peón sólo puede avanzar una o dos casillas hacia adelante
                if ((newY == currentY + 1 || (currentY == 1 && newY == 3)) && currentX == newX)
                {
                    // Si la nueva posición está vacía, el movimiento es válido
                    if (Tablero.casillas[newX, newY] == null)
                    {
                        Tablero.casillas[newX, newY] = Tablero.casillas[currentX, currentY];
                        Tablero.casillas[currentX, currentY] = null;
                        //TODO
                        //Poner currentx y currentY con los valores de newx y newy
                        Posicion.ColumnaInt = newY;
                        Posicion.Fila = newX;
                        return true;
                    }
                    else
                    {
                        // Si la nueva posición está ocupada, el movimiento es inválido
                        return false;
                    }
                }
                // El peón sólo puede comer hacia adelante en diagonal
                else if (newY == currentY + 1 && Math.Abs(newX - currentX) == 1)
                {
                    // Si la nueva posición está ocupada por una pieza del otro color, el movimiento es válido, se procede a comer.
                    if (Tablero.casillas[newX, newY] != null && Tablero.casillas[newX, newY].Color != Color)
                    {
                        Console.WriteLine("La pieza: " + Tablero.casillas[newX, newY].Nombre + " " + Tablero.casillas[newX, newY].Color + " fué comida...");
                        //Se carga la pieza comida antes de borrarla.
                        Jugador.AgregarPiezaCapturadaBlanca(Tablero.casillas[newX, newY]);
                        
                        Tablero.casillas[newX, newY] = Tablero.casillas[currentX, currentY];
                        Tablero.casillas[currentX, currentY] = null;
                        //TODO
                        //Poner currentx y currentY con los valores de newx y newy
                        Posicion.ColumnaInt = newY;
                        Posicion.Fila = newX;
                        
                        return true;
                    }
                    else
                    {
                        // Si la nueva posición está vacía o ocupada por una pieza del mismo color, el movimiento es inválido
                        return false;
                    }
                }
                // El peón puede hacer un salto doble al principio del juego si las casillas entre su posición actual y la posición a la que se quiere mover están desocupadas
                else if (currentY == 1 && newY == 3 && currentX == newX && Tablero.casillas[newX, newY] == null && Tablero.casillas[newX, 2] == null)
                {
                    Tablero.casillas[newX, newY] = Tablero.casillas[currentX, currentY];
                    Tablero.casillas[currentX, currentY] = null;
                    //TODO
                    //Poner currentx y currentY con los valores de newx y newy
                    Posicion.ColumnaInt = newY;
                    Posicion.Fila = newX;
                    return true;
                }
                else
                {
                    // Si las coordenadas no cumplen las reglas del movimiento del peón, el movimiento es inválido
                    return false;
                }
                return false;
            }

            //Piezas negras
            if ((Tablero.casillas[currentX, currentY]).Color == Color.Negro)
            {
                // El peón negro puede avanzar una o dos casillas hacia adelante a partir de su séptima fila
                if ((newY == currentY - 1 || (currentY == 6 && newY == 4)) && currentX == newX)
                //if (currentY == 6 && newY == 4 && currentX == newX)
                {
                    // Si la nueva posición está vacía, el movimiento es válido
                    if (Tablero.casillas[newX, newY] == null)
                    {
                        Tablero.casillas[newX, newY] = Tablero.casillas[currentX, currentY];
                        Tablero.casillas[currentX, currentY] = null;
                        //TODO
                        //Poner currentx y currentY con los valores de newx y newy
                        Posicion.ColumnaInt = newY;
                        Posicion.Fila = newX;
                        return true;
                    }
                    else
                    {
                        // Si la nueva posición está ocupada, el movimiento es invalido.
                        return false;
                    }
                }
                
                // El peón negro puede comer una pieza en diagonal
                else 
                 if (newY == currentY + 1 && Math.Abs(newX - currentX) == 1)
                {
                    // Si la nueva posición está ocupada por una pieza del otro color, el movimiento es válido, se procede a comer.
                    if (Tablero.casillas[newX, newY] != null && Tablero.casillas[newX, newY].Color != Color)
                    {
                        Console.WriteLine("La pieza: " + Tablero.casillas[newX, newY].Nombre + " " + Tablero.casillas[newX, newY].Color + " fué comida...");
                        //Se carga la pieza comida antes de borrarla.
                        Jugador.AgregarPiezaCapturadaNegra(Tablero.casillas[newX, newY]);

                        Tablero.casillas[newX, newY] = Tablero.casillas[currentX, currentY];
                        Tablero.casillas[currentX, currentY] = null;
                        //TODO
                        //Poner currentx y currentY con los valores de newx y newy
                        Posicion.ColumnaInt = newY;
                        Posicion.Fila = newX;

                        return true;
                    }
                    else
                    {
                        // Si la nueva posición está vacía o ocupada por una pieza del mismo color, el movimiento es inválido
                        return false;
                    }
                }

            }
            return false;

        }





    }
}
