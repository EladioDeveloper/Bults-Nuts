using System;
using System.Collections.Generic;

namespace Practica_1
{
    class StackDummy
    {
        public void Play()
        {
            Console.Write("Inserte los valores de la pila: ");
            string[] values = Console.ReadLine().Split(',');
            Stack<string> stack = new Stack<string>();
            foreach(var item in values)
            {
                stack.Push(item);
            }

            Stack<string> tempStack = new Stack<string>();
            while(stack.Count > 0)
            {
                int size = stack.Count;
                string find = stack.Pop();
                for (int i = 0; i < size; i++)
                {
                    if (find == stack.Peek())
                    {
                        Console.WriteLine($"{find}, {stack.Pop()}");
                        break;
                    }
                    else
                    {
                        tempStack.Push(stack.Pop());
                    }
                }
                if(tempStack.Count > 0)
                {
                    int tempSize = tempStack.Count;
                    for(int i = 0; i < tempSize;i++)
                    {
                        stack.Push(tempStack.Pop());
                    }
                }
            }
        }
    }
}
