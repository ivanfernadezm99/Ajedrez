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
        
        public string Nombre { get; set; }
        
        //*TODO:1_INI
        internal Pieza(Color color, Posicion posicion, Jugador jugador)
        {
            Color = color;
            Posicion = posicion;
            //Nombre = nombre;
        }

        /*TODO:1_END*/

        public abstract bool MovimientoValido(Posicion otraPosicion);

        //Establece si alguna vez se movió
        public bool SeMovio
        {
            get; set;
        }
       
    }
    public enum Color
    {
        Blanco,
        Negro
    }

    

    

}
