using System;
namespace PDA
{
    public class Transitions
    {
        private Tuple<Lazy<State>, StackC, char> transition;
        public Transitions(Lazy<State> state, StackC cmd, char addToStack ="#")
        {
            transition = new Tuple<Lazy<State>, StackC, char>(state, cmd, addToStack);
        }
        public State getNextState() 
        {
            return transition.Item1.Value;
        }
        public StackC getCommand()
        {
            return transition.Item2;
        }
        public char  getCharToAdd()
        {
            return transition.Item3;
        }
    }
}
