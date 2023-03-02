using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    public class Tablero
    {
        //Es el tablero completo con todas las casillas
        //public static Pieza[,] casillas = new Pieza[8, 8];
        public static Pieza[,] casillas = new Pieza[8, 8];

        Jugador JB;
        Jugador JN;

        //Con esto podríamos obtener el valor del casillero, si contiene pieza o no
        public Pieza this[int fila, int columna]
        {
            get { return casillas[fila,columna]; }
            set { casillas[fila, columna] = value; }
        }

        public Tablero(Jugador JBlanco, Jugador JNegro) 
        {
            JB = JBlanco;
            JN = JNegro;
        }

        public Posicion PosicionReyBlanco { get; set; }

        public Posicion PosicionReyNegro { get; set; }

        public void Inicializar()
        {
            // Inicializa el tablero con las piezas en su posición inicial
            //*TODO:1_INI

            // Piezas blancas
            this[0, 0] = new Torre(Color.Blanco, new Posicion(0, 0),JB);
            this[1, 0] = new Caballo(Color.Blanco, new Posicion(1, 0), JB);
            this[2, 0] = new Alfil(Color.Blanco, new Posicion(2, 0), JB);
            this[3, 0] = new Reina(Color.Blanco, new Posicion(3, 0), JB);
            this[4, 0] = new Rey(Color.Blanco, new Posicion(4, 0), JB);
            PosicionReyBlanco = this[4, 0].Posicion;
            this[5, 0] = new Alfil(Color.Blanco, new Posicion(5, 0), JB);
            this[6, 0] = new Caballo(Color.Blanco, new Posicion(6, 0), JB);
            this[7, 0] = new Torre(Color.Blanco, new Posicion(7, 0), JB);
            for (int i = 0; i < 8; i++)
            {
                this[i, 1] = new Peon(Color.Blanco, new Posicion(i, 1), JB);
            }

            // Piezas negras
            this[0, 7] = new Torre(Color.Negro, new Posicion(0, 7),JN);
            this[1, 7] = new Caballo(Color.Negro, new Posicion(1, 7), JN);
            this[2, 7] = new Alfil(Color.Negro, new Posicion(2, 7), JN);
            this[3, 7] = new Reina(Color.Negro, new Posicion(3, 7), JN);
            this[4, 7] = new Rey(Color.Negro, new Posicion(4, 7), JN);
            PosicionReyNegro = this[4, 7].Posicion;
            this[5, 7] = new Alfil(Color.Negro, new Posicion(5, 7), JN);
            this[6, 7] = new Caballo(Color.Negro, new Posicion(6, 7), JN);
            this[7, 7] = new Torre(Color.Negro, new Posicion(7, 7), JN);
            for (int i = 0; i < 8; i++)
            {
                this[i, 6] = new Peon(Color.Negro, new Posicion(i, 6), JN);
            }

            /*TODO:1_END*/
        }
        //Lo uso para tomar la pieza que esta en la posicion dada.
        public static Pieza ObtenerPiezaEnPosicion(Posicion posicion)
        {
            if (posicion == null)
            {
                throw new ArgumentNullException(nameof(posicion), "La posición no puede ser nula.");
            }

            if (!posicion.PosicionDentroDelTablero())
            {
                throw new ArgumentException("La posición está fuera del tablero, no hay ninguna pieza en ella.", nameof(posicion));
            }

            return casillas[posicion.ColumnaInt, posicion.Fila];
        }

        public bool Jaque()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (this[x, y] != null)
                    {
                        if (this[x, y].MovimientoValido(PosicionReyBlanco))
                            return true;
                        if (this[x, y].MovimientoValido(PosicionReyNegro))
                            return true;
                    }
                }
            }
            return false;
        }
        public Pieza JuegoTerminado()
        {
            
            foreach (Pieza item in Jugador.CantPiezasCapturadasBlancas)
            {
                if (item.Nombre == "Rey")
                    return item;
            }
            foreach (Pieza item in Jugador.CantPiezasCapturadasNegras)
            {
                if (item.Nombre == "Rey")
                    return item;
            }

            return null;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("    a   b   c   d   e   f   g   h  ");
            sb.AppendLine("  +-------------------------------+");

            for (int fila = 7; fila >= 0; fila--)
            {
                sb.Append($"{fila + 1} |");

                for (int columna = 0; columna < 8; columna++)
                {
                    sb.Append(" ");

                    if (this[columna, fila] == null)
                    {
                        sb.Append(" ");
                    }
                    else
                    {
                        string piezaUnicode = "";

                        switch (this[columna, fila].Color)
                        {
                            case Color.Blanco:
                                switch (this[columna, fila].GetType().Name)
                                {
                                    case "Rey":
                                        piezaUnicode = "♔";
                                        break;
                                    case "Reina":
                                        piezaUnicode = "♕";
                                        break;
                                    case "Torre":
                                        piezaUnicode = "♖";
                                        break;
                                    case "Alfil":
                                        piezaUnicode = "♗";
                                        break;
                                    case "Caballo":
                                        piezaUnicode = "♘";
                                        break;
                                    case "Peon":
                                        piezaUnicode = "♙";
                                        break;
                                }
                                break;

                            case Color.Negro:
                                switch (this[columna, fila].GetType().Name)
                                {
                                    case "Rey":
                                        piezaUnicode = "♚";
                                        break;
                                    case "Reina":
                                        piezaUnicode = "♛";
                                        break;
                                    case "Torre":
                                        piezaUnicode = "♜";
                                        break;
                                    case "Alfil":
                                        piezaUnicode = "♝";
                                        break;
                                    case "Caballo":
                                        piezaUnicode = "♞";
                                        break;
                                    case "Peon":
                                        piezaUnicode = "♙";
                                        break;
                                }
                                break;
                        }

                        sb.Append(piezaUnicode);
                    }

                    sb.Append(" |");
                }

                sb.AppendLine($" {fila + 1}");
                sb.AppendLine("  +-------------------------------+");

            }
            sb.AppendLine("    a   b   c   d   e   f   g   h  ");
            return sb.ToString();
        }









    }
}
