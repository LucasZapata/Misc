using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static List<int> numberSequence = new List<int>();
        static void Main(string[] args)
        {
            while (true)
            { 
                Console.WriteLine("choose option:");
                Console.WriteLine("1: get root");
                Console.WriteLine("2: enter sequence");
                Console.WriteLine("3: treat sequence");
                Console.WriteLine("0: quit");
                string textInput = Console.ReadLine();
                if (textInput == "0")
                    {
                    System.Environment.Exit(1);
                    }
                switch (textInput)
                {
                    case "1":
                        string res = getUnitaryRoot(getNumber()).ToString();
                        Console.WriteLine("Unitary root: "+res);
                        break;
                    case "2":
                        enterSequence();
                        break;
                    case "3":
                        treatSeaquence();
                        break;
                    default:
                        Console.WriteLine("non valid input");
                        break;
                };
            }
        }
        static void treatSeaquence()
        {
            Console.WriteLine("choose option:");
            Console.WriteLine("1: get root");
            Console.WriteLine("2: split and get roots");
            Console.WriteLine("0: quit");
            string textInput = Console.ReadLine();
            if (textInput == "0")
            {
                return;
            }
            switch (textInput)
            {
                case "1":
                    string res = getSequenceRoot().ToString();
                    Console.WriteLine("Unitary root: " + res);
                    break;
                case "2":
                    splitSequence();
                    break;
                default:
                    Console.WriteLine("non valid input");
                    break;
            }
        }
        static int getNumber(bool escape = false)
        {
            int input;
            string textInput = "";
            Console.WriteLine("Enter number");
            while (true)
            {
                textInput = Console.ReadLine();
                try
                {
                    input = int.Parse(textInput);
                    if (input < 0)
                    {
                        input *= -1;
                    }
                    return input;
                }
                catch
                {
                    Console.WriteLine("Invalid input, retry");
                }
            }
        }
        static int getUnitaryRoot(int number)
        {
            int root = 0;
            while (true)
            {
                root += number % 10;
                number /= 10;
                if (number == 0)
                { 
                    if (root > 9)
                    {
                        number = root;
                        root = 0;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return root;
        }
        static void enterSequence()
        {
            numberSequence.Clear();
            while (true)
            {
                Console.WriteLine("enter new number, or enter to finish");
                string textInput = Console.ReadLine();
                if (textInput == "")
                {
                    break;
                }
                try
                {
                    int number = int.Parse(textInput);
                    if (number < 0)
                    {
                        number *= -1;
                    }
                    numberSequence.Add(number);
                }
                catch
                {
                    Console.WriteLine("Invalid input, retry");
                }
            }
            string sequence = "";
            for (int n = 0; n < numberSequence.Count; n++)
            {
                sequence += numberSequence[n].ToString()+", ";
            }
            Console.WriteLine(sequence);
            return;
        }
        static int getSequenceRoot()
        {
            int number = 0;
            for (int n = 0; n < numberSequence.Count; n++)
            {
                number += numberSequence[n];
            }
            return getUnitaryRoot(number);
        }
        static void splitSequence()
        {
            int range = (1 << numberSequence.Count) - 1;
            for (int i = 0; i <= range; i++)
            {
                int number1 = 0, number2 = 0;
                string group1 = "", group2 = "";
                for (int n = 0; n < numberSequence.Count; n++)
                {
                    if (((i >> n) & 1) == 1)
                    {
                        number1 += numberSequence[n];
                        group1 += numberSequence[n].ToString() + " ";
                    }
                    else
                    {
                        number2 += numberSequence[n];
                        group2 += numberSequence[n].ToString() + " ";
                    }
                }
                Console.WriteLine(group1 + " - " + group2 + " : " + getUnitaryRoot(number1).ToString() + " - " + getUnitaryRoot(number2).ToString());
            }
        }
    }
}
