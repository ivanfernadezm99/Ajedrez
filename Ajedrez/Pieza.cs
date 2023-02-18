using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    public abstract class Pieza
    {
        public Color Color { get; }
        public Posicion Posicion { get; }

        //*TODO:1_INI
        internal Pieza(Color color, Posicion posicion)
        {
            Color = color;
            posicion = posicion;
        }

        /*TODO:1_END*/

        public abstract bool MovimientoValido(Posicion OtraPosicion);
       
    }
    public enum Color
    {
        Blanco,
        Negro
    }

    

}
