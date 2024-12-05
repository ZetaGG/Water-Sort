using System;
using System.Collections.Generic;
using System.Linq;

namespace Water_Sort
{
    public class Movimientos
    {
        public int Cantidad { get; set; }
        public List<string> BotellasLlenas { get; set; }

        public Movimientos()
        {
            BotellasLlenas = new List<string>();
        }

        public  static void LimpiarBotellas(List<string> botella1, List<string> botella2, List<string> botella3, List<string> botella4, List<string> botella5, List<string> botella6, List<string> botella7)
        {
            botella1.Clear();
            botella2.Clear();
            botella3.Clear();
            botella4.Clear();
            botella5.Clear();
            botella6.Clear();
            botella7.Clear();
        }
        public static void Imprimir(List<string> botella1, List<string> botella2, List<string> botella3, List<string> botella4, List<string> botella5, List<string> botella6, List<string> botella7)
        {
            var botellas = new List<List<string>> { botella1, botella2, botella3, botella4, botella5, botella6, botella7 };
            int maxAltura = botellas.Max(b => b.Count);

            for (int i = maxAltura - 1; i >= 0; i--)
            {
            foreach (var botella in botellas)
            {
                Console.ForegroundColor= ConsoleColor.White;
                Console.Write("|");
                if (i < botella.Count)
                {
                var color = botella[i];
                Console.ForegroundColor = color switch
                {
                    "rojo" => ConsoleColor.Red,
                    "azul" => ConsoleColor.Blue,
                    "verde" => ConsoleColor.Green,
                    "amarillo" => ConsoleColor.Yellow,
                    "violeta" => ConsoleColor.Magenta,
                    _ => ConsoleColor.White,
                };
                Console.Write(color[0]);
                Console.ForegroundColor= ConsoleColor.White;
                }
                else
                {
                Console.Write(" "); // Print empty space for missing colors
                }
                Console.Write("| "); // Print the initial of the color
            }
            Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < botellas.Count; i++)
            {
            Console.Write(" "+(i + 1) + "  ");
            }
            Console.WriteLine();
        }

        public static void LlenarBotellas(List<string> botella1, List<string> botella2, List<string> botella3, List<string> botella4, List<string> botella5)
        {
            var rand = new Random();
            string[] colores = new string[] { "rojo", "azul", "verde", "amarillo", "violeta" };
            int[] contadorColores = new int[] { 10, 10, 10, 10, 10 };
            var botellas = new List<List<string>> { botella1, botella2, botella3, botella4, botella5 };

            while (contadorColores.Sum() > 0)
            {
                int botellaIndex = rand.Next(botellas.Count);
                if (botellas[botellaIndex].Count < 10)
                {
                    int colorIndex = rand.Next(colores.Length);
                    if (contadorColores[colorIndex] > 0)
                    {
                        botellas[botellaIndex].Add(colores[colorIndex]);
                        contadorColores[colorIndex]--;
                    }
                }
            }
        }


        public static void LlenadoDePrueba(List<string> botella1, List<string> botella2, List<string> botella3, List<string> botella4, List<string> botella5)
        {
             botella1.Add("rojo"); botella1.Add("rojo"); botella1.Add("rojo"); botella1.Add("rojo"); botella1.Add("rojo"); botella1.Add("rojo"); botella1.Add("rojo"); botella1.Add("rojo"); botella1.Add("rojo"); botella1.Add("rojo");
             botella2.Add("azul"); botella2.Add("azul"); botella2.Add("azul"); botella2.Add("azul"); botella2.Add("azul"); botella2.Add("azul"); botella2.Add("azul"); botella2.Add("azul"); botella2.Add("azul"); botella2.Add("azul");
             botella3.Add("verde"); botella3.Add("verde"); botella3.Add("verde"); botella3.Add("verde"); botella3.Add("verde"); botella3.Add("verde"); botella3.Add("verde"); botella3.Add("verde"); botella3.Add("verde"); botella3.Add("verde");
             botella4.Add("amarillo"); botella4.Add("amarillo"); botella4.Add("amarillo"); botella4.Add("amarillo"); botella4.Add("amarillo"); botella4.Add("amarillo"); botella4.Add("amarillo"); botella4.Add("amarillo"); botella4.Add("amarillo"); botella4.Add("amarillo");
             botella5.Add("violeta"); botella5.Add("violeta"); botella5.Add("violeta"); botella5.Add("violeta"); botella5.Add("violeta"); botella5.Add("violeta"); botella5.Add("violeta"); botella5.Add("violeta"); botella5.Add("violeta"); botella5.Add("violeta");
        
        

        }
        public static bool UltimosColoresIguales(List<string> botellaOrigen, List<string> botellaDestino)
        {
            
            return botellaDestino.Count == 0 || botellaOrigen.Count > 0 && botellaOrigen[^1] == botellaDestino[^1];
        }

        public static bool BotellaOrigenVacia(List<string> botellaOrigen)
        {
             if(botellaOrigen.Count == 0) return true; else return false;
        }

        public void CantidadDeColores(List<string> botellaOrigen)
        {
            Cantidad = 0;
            if (botellaOrigen.Count > 0)
            {
                int temp = 1;
                for (int i = botellaOrigen.Count - 1; i > 0; i--)
                {
                    if (botellaOrigen[i] == botellaOrigen[i - 1])
                    {
                        temp++;
                    }
                    else
                    {
                        break;
                    }
                }
                Cantidad = temp;
            }
        }

        public void Mover(List<string> botellaOrigen, List<string> botellaDestino)
        {
            if (UltimosColoresIguales(botellaOrigen, botellaDestino) && !TodosLosColoresIguales(botellaOrigen) )
            {
                CantidadDeColores(botellaOrigen);
                for (int i = 0; i < Cantidad; i++)
                {
                    if (botellaDestino.Count < 10)
                    {
                        botellaDestino.Add(botellaOrigen[^1]);
                        botellaOrigen.RemoveAt(botellaOrigen.Count - 1);
                    }
                }
                Console.WriteLine("Movimiento exitoso");
                Console.ReadKey();
                if (botellaDestino.Count == 6)
                {
                    TodosLosColoresIguales(botellaDestino);
                }
            }
        }

        public bool TodosLosColoresIguales(List<string> botellaDestino)
        {
            bool Iguales= true;

            if(botellaDestino.Count < 10) return false;

            foreach(var i in botellaDestino)
            {
                if(i != botellaDestino[0])
                {
                    Iguales = false;
                    break;
                }
            }

            return Iguales;

        }

        

        public static bool TodasLasBotellasLlenas(List<List<string>> botellas)
        {
            bool todasLLenas = true;

            int coloresTotales = 50;
            for(int i = 0; i < botellas.Count; i++)
            {
                if(botellas[i].Count == 10)
                {
                foreach(var j in botellas[i])
                {
                    if(j == botellas[i][0])
                    {
                        coloresTotales--;
                    }
                }
                    
                }
            }

            if(!(coloresTotales==0))
                todasLLenas = false;
            

            return todasLLenas;
        }
    }
}