// See https://aka.ms/new-console-template for more information
// Crear jugadores
using Ajedrez;
using System.ComponentModel.DataAnnotations;

Jugador jugadorBlanco = new Jugador("Jugador Blanco", Color.Blanco);
Jugador jugadorNegro = new Jugador("Jugador Negro", Color.Negro);

// Crear tablero y colocar las piezas iniciales
Tablero tablero = new Tablero(jugadorBlanco,jugadorNegro);
tablero.Inicializar();

// Establecer la codificación de caracteres a UTF-8
Console.OutputEncoding = System.Text.Encoding.UTF8;

//Ajustar tamaño de consola
Console.WindowHeight = Console.LargestWindowHeight - 20;
Console.BufferHeight = Console.WindowHeight;
Console.WindowWidth = Console.LargestWindowWidth - 20;
Console.BufferWidth = Console.WindowWidth;

// Cambiar el tamaño de fuente de la consola
Console.SetWindowSize(80, 30);

Console.SetBufferSize(120, 1000);


// Mostrar el tablero en la consola
Console.WriteLine(tablero.ToString());

// Comenzar el juego
Jugador jugadorActual = jugadorBlanco;



while (true)
{
    try
    {

    
    Console.WriteLine($"{jugadorActual.Nombre} ({jugadorActual.ColorDePiezas}):");

    // Pedir al jugador que ingrese el movimiento
    Console.Write("Posición de la pieza a mover Columna: ");
 
    Console.Write("Ingrese la columna inicial (a-h): ");
    var posicionInicialCol = Console.ReadLine();

    int columnaInicial;
    switch (posicionInicialCol.ToLower())
    {
        case "a":
            columnaInicial = 0;
            break;
        case "b":
            columnaInicial = 1;
            break;
        case "c":
            columnaInicial = 2;
            break;
        case "d":
            columnaInicial = 3;
            break;
        case "e":
            columnaInicial = 4;
            break;
        case "f":
            columnaInicial = 5;
            break;
        case "g":
            columnaInicial = 6;
            break;
        case "h":
            columnaInicial = 7;
            break;
        default:
            Console.WriteLine("La letra ingresada es inválida.");
            continue; // salimos del método si la letra es inválida
    }

    Console.Write("Posición de la pieza a mover Fila: ");
    //Le resto 1 porque la matriz toma desde la posición 0
    int posicionInicialFil =  (Int32.Parse(Console.ReadLine())) - 1;
    Posicion posicionInicial = new Posicion(columnaInicial,posicionInicialFil);

    //Acá obtenemos la pieza elegida, si es null se eligió una casilla vacía.
    Pieza pieza = Tablero.ObtenerPiezaEnPosicion(posicionInicial);
    if (pieza == null)
    {
        Console.WriteLine("En la posición elegida no hay pieza.");
        Console.ReadLine();
        continue;
    }

    if (pieza.Color != jugadorActual.ColorDePiezas)
    {
        Console.WriteLine("La pieza elegida no pertenece a su color");
        continue;
    }

    Console.WriteLine("La pieza elegida es: " + pieza.Nombre + " Color: " + pieza.Color);

    Console.Write("Posición de destino Columna: ");
    var posicionFinalCol = Console.ReadLine();

    int columnaFinal;
    switch (posicionFinalCol.ToLower())
    {
        case "a":
            columnaFinal = 0;
            break;
        case "b":
            columnaFinal = 1;
            break;
        case "c":
            columnaFinal = 2;
            break;
        case "d":
            columnaFinal = 3;
            break;
        case "e":
            columnaFinal = 4;
            break;
        case "f":
            columnaFinal = 5;
            break;
        case "g":
            columnaFinal = 6;
            break;
        case "h":
            columnaFinal = 7;
            break;
        default:
            Console.WriteLine("La letra ingresada es inválida.");
            continue; // salimos del método si la letra es inválida
    }

    
    Console.Write("Posición de destino Fila: ");
    //Le resto uno por la matriz que empieza en 0.
    int posicionFinalFil = (Int32.Parse(Console.ReadLine())) - 1;

    Posicion posicionFinal = new Posicion(columnaFinal,posicionFinalFil);

    // Intentar realizar el movimiento
    bool movimientoValido = jugadorActual.RealizarMovimiento(pieza, posicionFinal);
    if (!movimientoValido)
    {
        Console.WriteLine("Movimiento inválido. Por favor, inténtelo de nuevo.");
        continue;
    }
    else
    {
        // Si el movimiento es válido, mostrar el mensaje y actualizar el tablero
        Console.WriteLine("Movimiento válido.");
        Console.WriteLine(tablero.ToString());

        //Informar la ubicación de los reyes.
        if(pieza.Nombre == "Rey" && pieza.Color == Color.Blanco)
                tablero.PosicionReyBlanco = pieza.Posicion;
        if (pieza.Nombre == "Rey" && pieza.Color == Color.Negro)
                tablero.PosicionReyNegro = pieza.Posicion;

        Console.WriteLine();
            //Ejecutar Jaque en todas las jugadas
        //if (tablero.Jaque())
        //        Console.WriteLine("¡¡¡¡¡¡Es Jaque!!!!!!");

        Console.WriteLine();
        Console.WriteLine("Piezas blancas capturadas: "+ Jugador.CantPiezasCapturadasBlancas.Count());
        foreach (Pieza item in Jugador.CantPiezasCapturadasBlancas)
        {
            Console.Write(item.Nombre + " ");
        }
            Console.WriteLine("");
            Console.WriteLine("Piezas negras capturadas: "+ Jugador.CantPiezasCapturadasNegras.Count());
        foreach (Pieza item in Jugador.CantPiezasCapturadasNegras)
        {
            Console.Write(item.Nombre + " ");
        }

    }

    // Verificar si el juego ha terminado
    Pieza finDeJuego = tablero.JuegoTerminado();
        
    if (finDeJuego != null)
    {
        Console.WriteLine("¡Jaque Mate! Ganaron las "+ finDeJuego.Color);
        break;
    }

    // Si el juego no ha terminado, cambiar el turno al otro jugador
    jugadorActual = (jugadorActual == jugadorBlanco) ? jugadorNegro : jugadorBlanco;

    }
    catch (Exception ex)
    {
        Console.WriteLine("Algo no salió bien, intente introducir las coordenadas correctamente.");
        continue;
        //throw;
    }
}