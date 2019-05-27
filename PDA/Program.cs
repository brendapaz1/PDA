using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace PDA
{
    class MainClass
    {
        static char symbol = "#";
        static void Main (string[] args)
        {
            List<char> word = "aabb".ToCharArray().ToList();
            State state1 = null;
            state1 = new State(new char[] { "a", "a", "b" },
                                new char[] { symbol, "a", "b" },
                                new Transitions[]
                                {
                                    new Transitions(new Lazy<State>(() => state1), StackC.ADD, "a"),
                                    new Transitions(new Lazy<State>(() => state1), StackC.ADD, "a"),
                                    new Transitions(new Lazy<State>(() => state1), StackC.REMOVE),
                                });
            PDA pda = new PDA(new List<State>() { state1 }, word, symbol);
            Console.ReadLine();
        }
        //
        //    public static void Main(string[] args)
        //    {
        //string[] alphabet = { "a", "b", "c", "d"};
        //Console.WriteLine("Enter a string: ");
        //string chain = Console.ReadLine();
        //var inputChain = new Queue(SplitString(chain));
        //bool verify = VerifyChain(inputChain, alphabet);

        //}

        //public static String[] SplitString(string chain)
        //   {
        //string pattern = @"";
        //String[] charChain = Regex.Split(chain, pattern);
        //        return charChain;
        //
        //}

        //public static bool VerifyChain(Queue input, string[] alphabet)
        //    {
        //bool equal = alphabet.Intersect(input.ToArray()).Any(); 
        //        return equal;
    }
}
