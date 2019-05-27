using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace PDA
{
    public class PDA
    {
        private List<State> states = new List<State>();
        private List<char> word = new List<char>();
        private State currentState;

        private Stack<char> stack = new Stack<char>();
        private char symbol;

        public PDA (List<State> states, List<char> word, char symbol)
        {
            this.states = states;
            this.word = word;
            this.symbol = symbol;
            stack.Push(symbol);
            currentState = states[0];
            start();
            write();

            if (stack.Count == 1 && stack.Peek() == symbol && word.Count == 0)
                Console.WriteLine("Aceptado");
            else
                Console.WriteLine("Rechazado");
        }
        private void start()
        {
            if(currentState != null)
            {
                if(word.Count > 0)
                {
                    write();
                    Transitions t = currentState.apply(word[0], stack.Peek());
                    if (t != null)
                    {
                        if (t.getCommand() == StackC.REMOVE)
                            stack.Pop();
                        else
                            stack.Push(t.getCharToAdd());
                        word.RemoveAt(0);
                        currentState = t.getNextState();
                    }
                    else
                        currentState = null;

                }
            }
        }
        private void write()
        {
            string s = new string(word.ToArray());
            string s2 = new string(stack.ToArray());
            Console.WriteLine(s + "\t STACK: " + s2);
        }
    }
}
