// Print Hello World
// Console.WriteLine("Hello, World!");

// Do simple mathematic equation
// int a = 42;
// int b = 119;
// int c = a + b;
// Console.WriteLine(c);

// Simple Calculator App
// float num1 = 0;
// float num2 = 0;

// Console.WriteLine("Console Calculator in C#\r");
// Console.WriteLine("------------------------\n");

// Console.WriteLine("Type a number, and then press Enter");
// num1 = Convert.ToInt32(Console.ReadLine());

// Console.WriteLine("Type another number, and then press Enter");
// num2 = Convert.ToInt32(Console.ReadLine());

// Console.WriteLine("Choose an option from the following list:");
// Console.WriteLine("\ta - Add");
// Console.WriteLine("\ts - Subtract");
// Console.WriteLine("\tm - Multiply");
// Console.WriteLine("\td - Divide");
// Console.Write("Your option? ");

// switch (Console.ReadLine()) {
//     case "a":
//         Console.WriteLine($"Your result: {num1} + {num2} = " + (num1 + num2));
//         break;
//     case "s":
//         Console.WriteLine($"Your result: {num1} - {num2} = " + (num1 - num2));
//         break;
//     case "m":
//         Console.WriteLine($"Your result: {num1} * {num2} = " + (num1 * num2));
//         break;
//     case "d":
//         while (num2 == 0) 
//         {
//             Console.WriteLine("Enter a non-zero divisor: ");
//             num2 = Convert.ToInt32(Console.ReadLine());
//         }
//         Console.WriteLine($"Your result: {num1} / {num2} = " + (num1 / num2));
//         break;
// };

// Console.Write("Press any key to close the Calculator console app...");
// Console.ReadKey();

using System;

namespace Calculator
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN;
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                Console.Write("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput1 = Console.ReadLine();
                }

                Console.Write("Type another number, and then press Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput2 = Console.ReadLine();
                }

                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option? ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else 
                    {
                        Console.WriteLine("Your result: {0:0.##}\n", result);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                Console.Write("Press 'n' and Enter to close the app, or press Enter key to continue: ");

                if (Console.ReadLine() == "n") 
                {
                    endApp = true;
                }

                Console.WriteLine("\n");
            }
            return;
        }
    }
}
