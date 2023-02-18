using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    public class Posicion
    {
        public int Columna{  get; set; }
        public int Fila { get; set; }

        public Posicion(int columna, int fila) 
        { 
            Columna = columna;
            Fila = fila;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
