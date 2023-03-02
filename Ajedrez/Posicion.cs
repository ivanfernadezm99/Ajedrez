using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    public class Posicion
    {
        public char Columna{  get; set; }
        public int Fila { get; set; }

        public int ColumnaInt { get; set; }

       
        public Posicion(char columna, int fila) 
        { 
            Columna = columna;
            Fila = fila;
            //Se le resta el caracter 'a' a la columna, de esta forma se obtiene la distancia entre 'a' y el caracter columna en ascII
            ColumnaInt = columna - 'a';
        }

        public Posicion(int columna, int fila)
        {
            //Columna = columna;
            Fila = fila;
            //Se le resta el caracter 'a' a la columna, de esta forma se obtiene la distancia entre 'a' y el caracter columna en ascII
            ColumnaInt = columna;
        }

        // Si la posición a la que se intenta mover no está dentro del tablero, retorna falso
        public bool PosicionDentroDelTablero()
        {
            if (ColumnaInt < 0 || ColumnaInt > 7 || Fila < 0 || Fila > 7)
            {
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            return base.ToString();
        }
       


    }
}
