using System;
using System.Collections.Generic;
using System.Text;

namespace Practica1
{
    public class Ejercicio1
    {

        public static int[] Arreglo1(int cantidad) {

            int[] arreglo = new int[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"Elemento[{i + 1}]: ");
                int value = int.Parse(Console.ReadLine());
                arreglo[i] = value;
            }
            return arreglo;
        
        }

        public static int[] Arreglo2(int cantidad)
        {

            int[] arreglo = new int[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"Elemento[{i + 1}]: ");
                int value = int.Parse(Console.ReadLine());
                arreglo[i] = value;
            }
            return arreglo;

        }

       
        public void Run()
        {
            int cantidad1;
            int cantidad2;
            do
            {
                Console.Write("Primer arreglo, digite la cantidad de elementos que desea: ");
                cantidad1 = int.Parse(Console.ReadLine());

            } while (cantidad1 <= 0);
            int[] arreglo1 = null;
            arreglo1 = Arreglo1(cantidad1);


            do
            {
                Console.Write("Segundo arreglo, digite la cantidad de elementos que desea: ");
                cantidad2 = int.Parse(Console.ReadLine());
            } while (cantidad2 <= 0);

            int[] arreglo2 = null;
            arreglo2 = Arreglo2(cantidad2);

            Console.Clear();

            Console.WriteLine("El primer arreglo contiene los siguientes elementos: ");
            foreach (var Elem1 in arreglo1)
            {
                Console.Write($"->[{Elem1}]");
    
            }
            Console.WriteLine("\n");

            Console.WriteLine("El segundo arreglo contiene los siguientes elementos: ");
            foreach (var Elem2 in arreglo2)
            {
                Console.Write($"->[{Elem2}]");
                
            }
            Console.WriteLine("\n");


            int[] merge = new int[arreglo1.Length + arreglo2.Length];
            for (int i = 0; i < arreglo1.Length; i++)
            {
                merge[i] = arreglo1[i];
            }
            for (int i = 0; i < arreglo2.Length; i++)
            {
                merge[i + arreglo1.Length] = arreglo2[i];
            }

            Array.Sort(merge);
            Console.WriteLine("El merge de los dos arreglos es: ");
            foreach (int Result in merge)
            {
                Console.Write($"->[{Result}]");
            }
      


        }
    }
}
