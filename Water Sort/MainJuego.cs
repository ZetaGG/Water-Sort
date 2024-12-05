namespace Water_Sort{
public class Programa
{
    public static void Main()
    {
        Console.WriteLine("Botella inicio");
        var Botella1 = new List<string>();
        var Botella2 = new List<string>();
        var Botella3 = new List<string>();
        var Botella4 = new List<string>();
        var Botella5 = new List<string>();
        var Botella6 = new List<string>();
        var Botella7 = new List<string>();

        Movimientos movimientos = new Movimientos();

        var botellas = new List<List<string>> { Botella1, Botella2, Botella3, Botella4, Botella5, Botella6, Botella7 };

        Movimientos.LlenarBotellas(Botella1, Botella2, Botella3, Botella4, Botella5);

       

        while(!Movimientos.TodasLasBotellasLlenas(botellas))
        {
            Console.Clear();
            Movimientos.Imprimir(Botella1, Botella2, Botella3, Botella4, Botella5, Botella6, Botella7);

            Console.WriteLine(movimientos.BotellasLlenas.Count + " botellas llenas");
            try
            {
                Console.WriteLine("Ingrese la botella que desea vaciar");
                string Botella = Console.ReadLine();
                if(Botella=="Reiniciar")
                {
                    Movimientos.LimpiarBotellas(Botella1, Botella2, Botella3, Botella4, Botella5, Botella6, Botella7);
                    Movimientos.LlenarBotellas(Botella1, Botella2, Botella3, Botella4, Botella5);
                    continue;
                }
                int BotellaInicio = Convert.ToInt32(Botella);
                Console.WriteLine("Ingrese la botella que desea llenar");
                int BotellaDestino = Convert.ToInt32(Console.ReadLine());
                
                movimientos.Mover(botellas[BotellaInicio-1], botellas[BotellaDestino-1]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            
        }

        Console.WriteLine("Juego terminado Ganaste");
        Console.ReadKey();


        

    }
}}