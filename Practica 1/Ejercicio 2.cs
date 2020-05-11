using System;
using System.Collections.Generic;

namespace Practica_1
{
    class Ejercicio_2
    {
        public void play()
        {
            Stack<string> stack = new Stack<string>();
            string[] array;
            while (true)
            {
                Console.Clear();
                Console.Write("Inserte los valores separados por ',': ");
                array = Console.ReadLine().Split(',');

                if (array.Length % 2 == 0)
                {
                    foreach (var item in array)
                    {
                        stack.Push(item);
                    }
                    var lists = Divide(stack);
                    var matching = Matching(lists);
                    int x = matching.Count;
                    for(int i = 0; i < x;i++)
                    {
                        Console.Write($"{matching.Pop()}, ");
                    }
                    Console.ReadKey();
                    break;

                }
                else
                {
                    Console.WriteLine("Inserte valores parejos, para N tornillos, N tuercas.");
                    Console.ReadKey();
                }
            }
        }
        private List<Stack<string>> Divide(Stack<string> stack)
        {
            List<Stack<string>> Lists = new List<Stack<string>>();
            int midsize = stack.Count / 2;
            for(int i = 0; i < 2;i++)
            {
                Stack<string> tempStack = new Stack<string>();
                Lists.Add(tempStack);

                for (int x = 0; x < midsize; x++)
                {
                    Lists[i].Push(stack.Pop());
                }
            }
            return Lists;
        }
        private Stack<string> Matching(List<Stack<string>> stack)
        {
            int size = stack[0].Count;
            Stack<string> returnedStack = new Stack<string>();
            List<Stack<string>> tempStack = new List<Stack<string>> { new Stack<string>(), new Stack<string>()};
           
            for (int a = 0; a < size;a++)
            {
                for(int b = 0; b < size; b++)
                {
                    if (stack[0].Count > 0 && stack[1].Count > 0)
                    {
                        if (stack[0].Peek() == stack[1].Peek())
                        {
                            returnedStack.Push(stack[0].Pop());
                            returnedStack.Push(stack[1].Pop());
                            break;
                        }
                        else
                        {
                            tempStack[1].Push(stack[1].Pop());
                        }
                    }
                    else
                        break;
                }
                if(tempStack[1].Count > 0)
                {
                    int tempSize = tempStack[1].Count;
                    for(int c = 0; c < tempSize; c++)
                    {
                        stack[1].Push(tempStack[1].Pop());
                    }
                }
            }
            for(int i = 0; i < 2; i++)
            {
                tempStack[i] = SelfSearch(stack[i]);
                int tempSize = tempStack[i].Count;
                for(int x = 0; x < tempSize; x++)
                {
                    returnedStack.Push(tempStack[i].Pop());
                }
            }
            return returnedStack;
        }
        private Stack<string> SelfSearch(Stack<string> stack)
        {
            Stack<string> returnedStack = new Stack<string>();
            Stack<string> tempStack = new Stack<string>();
            while (stack.Count > 0)
            {
                string find = stack.Pop();
                int size = stack.Count;
                for (int i = 0; i < size; i++)
                {
                    if (find == stack.Peek())
                    {
                        returnedStack.Push(find);
                        returnedStack.Push(stack.Pop());
                        break;
                    }
                    else
                    {
                        tempStack.Push(stack.Pop());
                    }
                }
                if (tempStack.Count > 0)
                {
                    int tempSize = tempStack.Count;
                    for (int i = 0; i < tempSize; i++)
                    {
                        stack.Push(tempStack.Pop());
                    }
                }
            }
            return returnedStack;
        }
    }
}
 