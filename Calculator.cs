using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class Calculator
    {

        double add(double x, double y)
        {
            return x + y;

        }

        double substract(double x, double y)
        {
            return x - y;
        }

        double multiply(double x, double y)
        {
            return x * y;
        }

        double divide(double x, double y)
        {
            return x / y;
        }

        double reminder(double x, double y)
        {
            return (int)x % (int)y;
        }

        double exponent(double x, double y)
        {
            double result = 1;

            for (int i = 0; i < y; i++)
            {
                result *= x;
            }

            return result;
        }

        double squareroot(double x)
        {
            return Math.Sqrt(x);
        }

        public static void Main(string[] args)
        {

            Calculator calc = new Calculator();
            string input = "";
            string signs = "";
            double a = 0;
            double b = 0;
            double temp = 0;
            bool first = true;

            Console.WriteLine("Select one of the following operations and press enter after each input: ");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("+\t -\t /\t *\t %\t ^\t s\t =\t");
            Console.WriteLine("-----------------------------------------------------------");

            while (!input.Equals("q") && !input.Equals("Q"))
            {

                input = Console.ReadLine();

                try
                {

                    if (Regex.IsMatch(input, @"\-?\d*\.?\d+"))
                    {
                        if (first)
                        {
                            a = Convert.ToDouble(input);
                            first = false;
                        }
                        else
                        {
                            b = Convert.ToDouble(input);
                            first = true;
                        }
                    }
                    else
                    {
                        switch (input)
                        {
                            case "+":
                                signs = "+";
                                break;
                            case "-":
                                signs = "-";
                                break;
                            case "/":
                                signs = "/";
                                break;
                            case "*":
                                signs = "*";
                                break;
                            case "%":
                                signs = "%";
                                break;
                            case "^":
                                signs = "^";
                                break;
                            case "s":
                                signs = "s";
                                break;
                            case "=":
                                if (input.Equals("="))
                                {
                                    if (!first)
                                    {
                                        temp = a;
                                        a = b;
                                        b = temp;
                                        first = false;
                                    }
                                    switch (signs)
                                    {
                                        case "+":
                                            a = calc.add(a, b);
                                            first = false;
                                            Console.WriteLine(a);
                                            break;
                                        case "-":
                                            a = calc.substract(a, b);
                                            first = false;
                                            Console.WriteLine(a);
                                            break;
                                        case "*":
                                            a = calc.multiply(a, b);
                                            first = false;
                                            Console.WriteLine(a);
                                            break;
                                        case "/":
                                            if (b == 0)
                                            {
                                                Console.WriteLine("Error: Division by zero!");
                                            }
                                            else
                                            {
                                                a = calc.divide(a, b);
                                                first = false;
                                                Console.WriteLine(a);
                                            }
                                            break;
                                        case "%":
                                            a = calc.reminder(a, b);
                                            first = false;
                                            Console.WriteLine(a);
                                            break;
                                        case "^":
                                            a = calc.exponent(a, b);
                                            first = false;
                                            Console.WriteLine(a);
                                            break;
                                        case "s":
                                            if (b < 0)
                                            {
                                                Console.WriteLine("Can't find square root of negative numbers!");
                                            }
                                            else
                                            {
                                                a = calc.squareroot(b);
                                                first = false;
                                                Console.WriteLine(a);
                                            }
                                            break;
                                        case "":
                                            break;
                                    }
                                }
                                break;
                            case "q":
                                break;
                            case "Q":
                                break;
                            default:
                                Console.WriteLine("Wrong input, program will continue with the last number used.");
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong input, program will continue with the last number used.");
                }
            }
        }
    }
}