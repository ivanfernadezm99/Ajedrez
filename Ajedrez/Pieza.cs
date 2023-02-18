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
        //public Posicion Posicion { get; set; }
    }
    public enum Color
    {
        Blanco,
        Negro
    }

    //protected Pieza(Color color, Posicion posicion)
    //{
    //    Color = color;
    //    posicion = posicion;
    //}



}
