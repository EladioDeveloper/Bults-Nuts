

using System;

namespace Practica_1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("============================================================");
                Console.WriteLine("|                          MENU                            |");
                Console.WriteLine("============================================================");
                Console.WriteLine("|   1. Organizar arreglos.                                 |");
                Console.WriteLine("|   2. Tuercas y tornillos.                                |");
                Console.WriteLine("|   3. Salir.                                              |");
                Console.WriteLine("============================================================");
                Console.Write("         Respuesta: ");
                int resp = int.Parse(Console.ReadLine());
                switch (resp)
                {
                    case 1:
                        Console.WriteLine("\n\n\n");
                        Ejercicio_1 ejercicio1 = new Ejercicio_1();
                        ejercicio1.Play();
                        break;
                    case 2:
                        Console.WriteLine("\n\n\n");
                        Ejercicio_2 ejercicio2 = new Ejercicio_2();
                        ejercicio2.play();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
