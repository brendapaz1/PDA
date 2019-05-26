using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;
namespace PDA
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] alphabet = { "a", "b", "c", "d"};
            Console.WriteLine("Enter a string: ");
            string chain = Console.ReadLine();
            var inputChain = new Queue(SplitString(chain));
            bool verify = VerifyChain(inputChain, alphabet);

        }

        public static String[] SplitString(string chain)
        {
            string pattern = @"";
            String[] charChain = Regex.Split(chain, pattern);
            return charChain;
                
        }

        public static bool VerifyChain(Queue input, string[] alphabet)
        {
            bool equal = alphabet.Intersect(input.ToArray()).Any(); 
            return equal;
        }



    }
}
