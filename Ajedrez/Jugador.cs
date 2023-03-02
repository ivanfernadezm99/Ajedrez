using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez
{
    public class Jugador
    {
        public Jugador(string nombre, Color colorDePiezas )
        {
            Nombre = nombre;
            ColorDePiezas = colorDePiezas;
            CantPiezasCapturadasBlancas = new List<Pieza>();
            CantPiezasCapturadasNegras = new List<Pieza>();
        }
        public string Nombre { get; set; }
        
        public Color ColorDePiezas { get; set; }

        public static List<Pieza> CantPiezasCapturadasBlancas { get; set; }

        public static List<Pieza> CantPiezasCapturadasNegras { get; set; }

        public Timer TiempoTranscurrido { get; set; }



        Tablero EstadoActualDelJuego()
        {
            throw new NotImplementedException();
        }

        internal bool RealizarMovimiento(Pieza piezaAMover, Posicion lugarAMover)
        {
            if (piezaAMover.Color == ColorDePiezas)
                return piezaAMover.MovimientoValido(lugarAMover);
            else
            {
                Console.WriteLine("La pieza que eligió no pertenece a su color.");
                return false;
            }
        }

        public static List<Pieza> AgregarPiezaCapturadaBlanca(Pieza piezaCapturada)
        {
            
            CantPiezasCapturadasBlancas.Add(piezaCapturada);
            return CantPiezasCapturadasBlancas;
        }

        public static List<Pieza> AgregarPiezaCapturadaNegra(Pieza piezaCapturada)
        {

            CantPiezasCapturadasNegras.Add(piezaCapturada);
            return CantPiezasCapturadasNegras;
        }


    }
}
