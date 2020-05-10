using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Xml.Serialization;

namespace Practica_1
{
    class Ejercicio_2
    {
        public void play()
        {
            Stack<string> stack = new Stack<string>();
            Stack<string> dummyStack = new Stack<string>();
            List<Stack<string>> stackList = new List<Stack<string>>();
            string[] array;
            while (true) 
            {
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
                        foreach (var item in matching)
                        {
                            Console.Write($"{item}, ");
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

        }

        public bool Validate(Stack<string> stack)
        {
            Stack<string> vstack = new Stack<string>();
            foreach (var item in stack)
            {
                vstack.Push(item);
            }
            var findItem = vstack.Pop();
            int size = vstack.Count;
            int count = 0;
            Stack<string> tempStack = new Stack<string>();
            for(int i = 0; i < size; i++)
            {
                if (vstack.Count > 0)
                {
                    if (findItem == vstack.Peek())
                    {
                        vstack.Pop();
                        if (vstack.Count != 0)
                        {
                            findItem = vstack.Pop();
                        }
                        count++;
                    }
                    else if (vstack.Count == 1)
                    {
                        return false;
                    }
                    else
                    {
                        tempStack.Push(vstack.Pop());
                    }
                }
            }

            if (count >= size / 2)
                return true;
            else
                return false;
        }

        public List<Stack<string>> Divide(Stack<string> stack)
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
        public Stack<string> Matching(List<Stack<string>> stack)
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

        public Stack<string> SelfSearch(Stack<string> stack)
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
 