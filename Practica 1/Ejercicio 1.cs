using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practica_1
{
    class Ejercicio_1
    {
        public void Play()
        {
            try
            {
                List<int[]> arrayList = new List<int[]>();
                for (int i = 0; i < 2; i++)
                {
                    Console.Write($"Inserte los elementos separados por ',' del arreglo #{i + 1}: ");
                    int[] array = Array.ConvertAll(Console.ReadLine().Split(','), int.Parse);
                    Array.Sort(array);
                    arrayList.Add(array);
                }
                Console.WriteLine("\nArreglos: \n");
                for(int i = 0; i < arrayList.Count; i++)
                {
                    Console.Write($"Arreglo #{i+1}: ");
                    foreach (var item in arrayList[i])
                    {
                        Console.Write($"->{item}");
                    }
                    Console.WriteLine("\n");
                }
                int[] arraySorted = arrayList[0].Concat(arrayList[1]).ToArray();
                Array.Sort(arraySorted);
                Console.WriteLine("Lista de arreglos: ");
                foreach (var item in arraySorted)
                {
                    Console.Write($"->{item}");
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\nInserte solamente numeros enteros");
            }

        }
    }
}
