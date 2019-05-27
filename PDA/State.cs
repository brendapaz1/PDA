using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDA
{
    public class State
    {
        private List<Tuple<char, char, Transitions>> step = new List<Tuple<char, char, Transitions>>();
         
        public State(char[] readLetter, char[] stackChar, Transitions[] transitions)
        {
            if (readLetter != null && transitions != null)
                for (int i = 0; i < readLetter.Length; i++)
                    step.Add(new Tuple<char, char, Transitions>(readLetter[i], stackChar[i], transitions[i]));
        }
        public Transitions apply(char readChar, char stackState)
        {
            Transitions returnTransition = null;
            foreach(Tuple<char,char,Transitions> tp1 in step)
            {
                if(tp1.Item1== readChar && tp1.Item2 == stackState)
                {
                    returnTransition = tp1.Item3;
                    break;
                }
            }
            return returnTransition;
        } 
    }
}
