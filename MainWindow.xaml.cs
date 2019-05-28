using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace testy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string[] alphabet = { "a", "b", "c", "d", "1", "0" }; //esto por que esta aqui? como volando
        public Queue<String> inputQueue { get; set; }
        public Stack<char> State = new Stack<char>();
        DispatcherTimer dispathcer = new DispatcherTimer();

        private void PDAbutton_Click(object sender, RoutedEventArgs e)
        {
            init();
        }
        private void init()
        {

            string contenido = InputTextBox.Text;
            contenido.Replace(" ", "");
            var inputChain = new Queue(Split(contenido));
            bool verify = VerifyChain(inputChain, alphabet);

            if (!verify)
            {
                //MessageBox.Show("It's not my language");
                TxtFinal.Content = "It's not my language";
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
        private void TransitionPDA(int numState, Queue input, Stack<char> stack)
        {

            if (numState == 1)
            {
                InitialState.Fill = System.Windows.Media.Brushes.Blue;
                MessageBox.Show("Next Step");
                stack.Push('$');
                TransitionPDA(2, input, stack);


            }
            else if (numState == 2)
            {
                string q = input.Dequeue().ToString();
                InitialState.Fill = System.Windows.Media.Brushes.White;
                State2.Fill = System.Windows.Media.Brushes.Blue;
                if (q == "a")
                {
                    stack.Push('a');
                    TransitionPDA(2, input, stack);
                }
                else if (q == "#")
                {
                    TransitionPDA(3, input, stack);
                }
                else if (q == "b")
                {
                    stack.Push('b');
                    TransitionPDA(2, input, stack);
                }
                else if (q == "c")
                {
                    stack.Push('c');
                    TransitionPDA(2, input, stack);
                }
                else if (q == "d")
                {
                    stack.Push('d');
                    TransitionPDA(2, input, stack);
                }
                else if (q == "1")
                {
                    stack.Push('1');
                    TransitionPDA(2, input, stack);
                }
                else if (q == "0")
                {
                    stack.Push('0');
                    TransitionPDA(2, input, stack);
                }
                else
                {
                    MessageBox.Show("Next Step");
                    TransitionPDA(2, input, stack);

                }
               
            }
            else if (numState == 3)
            {
                InitialState.Fill = System.Windows.Media.Brushes.White;
                State2.Fill = System.Windows.Media.Brushes.White;
                State3.Fill = System.Windows.Media.Brushes.Blue;
                //MessageBox.Show("Next Step");
                if (input.Count != 0)
                {
                    string q = input.Dequeue().ToString();
                    char i = stack.Pop();
                    if (i.ToString() == q)
                    {
                        MessageBox.Show("Next Step");
                        TransitionPDA(3, input, stack);
                        
                    }
                    else
                    {
                        TxtFinal.Content = "It's not a palindrome";

                    }
                }
                else
                {
                    if (stack.Count == 1) TransitionPDA(4, input, stack);
                    else TxtFinal.Content = "It's not a palindrome";
                }

            }

            else
            {
                InitialState.Fill = System.Windows.Media.Brushes.White;
                State2.Fill = System.Windows.Media.Brushes.White;
                State3.Fill = System.Windows.Media.Brushes.White;
                FinalState.Fill = System.Windows.Media.Brushes.Blue;
                FinalState2.Fill = System.Windows.Media.Brushes.Blue;
                MessageBox.Show("End");
                stack.Pop();
                TxtFinal.Content = "It is a palindrome";
            }

        }

    }
}
