using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace PDA
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            for (; ; )
            {
                string[] alphabet = { "a", "b", "c","d","e","r","1","0" };
                Console.WriteLine("Enter a string: ");
                string chain = Console.ReadLine();
                chain = chain.Replace(" ", "");
                var inputChain = new Queue(Split(chain));
                bool verify = VerifyChain(inputChain, alphabet);
                Stack<char> State = new Stack<char>();
                if (!verify)
                {
                    Console.WriteLine("not my language");
                }
                else
                {
                    PDA(1, inputChain, State);
                }
            }


        }

        public static String[] Split(string chain)
        {
            string pattern = @"";
            String[] charChain = Regex.Split(chain, pattern);
            //char[] charChain = chain.ToArray();
            List<string> first = new List<string>();

            for (int i = 0; i < charChain.Length; i++)
            {
                if (i < charChain.Length / 2) first.Add(charChain[i].ToString());
                else if (i == charChain.Length / 2) first.Add("#");
                else first.Add(charChain[i-1].ToString());

            }

            foreach (var s in first)
            {
                Console.WriteLine(s);
            }

            return first.ToArray();

        }

        public static bool VerifyChain(Queue input, string[] alphabet)
        {
            bool equal = alphabet.Intersect(input.ToArray()).Any();
            return equal;
        }

        public static void PDA(int numState, Queue input, Stack<char> stack)
        {
            if (numState == 1)
            {
                stack.Push('$');
                PDA(2, input, stack);
            }
            else if (numState == 2)
            {
                string s = input.Dequeue().ToString();
                if (s == "a")
                {
                    stack.Push('a');
                    PDA(2, input, stack);
                }
                else if (s == "#")
                {

                    PDA(3, input, stack);

                }
                else if (s == "b")
                {
                    stack.Push('b');
                    PDA(2, input, stack);
                }
                else if (s == "c")
                {
                    stack.Push('c');
                    PDA(2, input, stack);
                }
                else if (s == "d")
                {
                    stack.Push('d');
                    PDA(2, input, stack);
                }
                else if (s == "e")
                {
                    stack.Push('e');
                    PDA(2, input, stack);
                }
                else if (s == "r")
                {
                    stack.Push('r');
                    PDA(2, input, stack);
                }
                else if (s == "1")
                {
                    stack.Push('1');
                    PDA(2, input, stack);
                }
                else if (s == "0")
                {
                    stack.Push('0');
                    PDA(2, input, stack);
                }
                else
                {
                    PDA(2, input, stack);
                }


            }
            else if (numState == 3)
            {

                if (input.Count != 0)
                {

                    string s = input.Dequeue().ToString();
                    char i = stack.Pop();


                    if (i.ToString() == s)
                    {
                        PDA(3, input, stack);
                    }
                    else
                    {
                        Console.WriteLine("no");
                    }

                }
                else
                {
                    if (stack.Count == 1) PDA(4, input, stack);
                    else Console.WriteLine("no");


                }
            }
            else
            {
                stack.Pop();
                Console.WriteLine("yes");
            }
            


        }


    }
}
