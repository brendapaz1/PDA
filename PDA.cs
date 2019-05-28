using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;



namespace testy
{
    public class PDA
    {
        public string[] alphabet = { "a", "b", "c", "d", "e", "r", "1", "0" };
        public string input { get; set; }
        public Queue<String> inputQueue { get; set; }
        public Stack<char> State = new Stack<char>();
        public PDA(string input)
        {
            this.input = input;
        }

         public void Init()
        {
            input = input.Replace(" ", "");
            var inputChain = new Queue(Split(input));
            bool verify = VerifyChain(inputChain, alphabet);
            if (!verify)
            {
                Message("It's not my language");
            }
            else
            {
                TransitionPDA(1, inputChain, State);
            }
        }

        public static String[] Split(string chain)
        {
            string pattern = @"";
            String[] charChain = Regex.Split(chain, pattern);
            List<string> first = new List<string>();

            for (int i = 0; i < charChain.Length; i++)
            {
                if (i < charChain.Length / 2) first.Add(charChain[i].ToString());
                else if (i == charChain.Length / 2) first.Add("#");
                else first.Add(charChain[i - 1].ToString());
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

        public static void TransitionPDA(int numState, Queue input, Stack<char> stack)
        {
            if (numState == 1)
            {
                stack.Push('$');
                TransitionPDA(2, input, stack);
            }
            else if (numState == 2)
            {
                string s = input.Dequeue().ToString();
                if (s == "a")
                {
                    stack.Push('a');
                    TransitionPDA(2, input, stack);
                }
                else if (s == "#")
                {

                    TransitionPDA(3, input, stack);

                }
                else if (s == "b")
                {
                    stack.Push('b');
                    TransitionPDA(2, input, stack);
                }
                else if (s == "c")
                {
                    stack.Push('c');
                    TransitionPDA(2, input, stack);
                }
                else if (s == "d")
                {
                    stack.Push('d');
                    TransitionPDA(2, input, stack);
                }
                else if (s == "e")
                {
                    stack.Push('e');
                    TransitionPDA(2, input, stack);
                }
                else if (s == "r")
                {
                    stack.Push('r');
                    TransitionPDA(2, input, stack);
                }
                else if (s == "1")
                {
                    stack.Push('1');
                    TransitionPDA(2, input, stack);
                }
                else if (s == "0")
                {
                    stack.Push('0');
                    TransitionPDA(2, input, stack);
                }
                else
                {
                    TransitionPDA(2, input, stack);
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
                        TransitionPDA(3, input, stack);
                    }
                    else
                    {
                        Message("It's not a palindrome");
                    }

                }
                else
                {
                    if (stack.Count == 1) TransitionPDA(4, input, stack);
                    else Message("It's not a palindrome");


                }
            }
            else
            {
                stack.Pop();
                Message("It is a palindrome");
            }



        }

        public static string Message(string message)
        {
            return message;
        }
    }
}
