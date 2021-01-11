using System;

namespace _06._Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secontNum = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());

            int resultInt = 0;
            double resultDouble = 0.0;
            switch (operation)
            {
                case '+':
                    resultInt = firstNum + secontNum;
                    if (resultInt % 2 == 0)
                    {
                        Console.WriteLine("{0} {1} {2} = {3} - even", firstNum, operation, secontNum, resultInt);
                    }
                    else
                    {
                        Console.WriteLine("{0} {1} {2} = {3} - odd", firstNum, operation, secontNum, resultInt);
                    }
                    break;
                case '-':
                    resultInt = firstNum - secontNum;
                    if (resultInt % 2 == 0)
                    {
                        Console.WriteLine("{0} {1} {2} = {3} - even", firstNum, operation, secontNum, resultInt);
                    }
                    else
                    {
                        Console.WriteLine("{0} {1} {2} = {3} - odd", firstNum, operation, secontNum, resultInt);
                    }
                    break;
                case '*':
                    resultInt = firstNum * secontNum;
                    if (resultInt % 2 == 0)
                    {
                        Console.WriteLine("{0} {1} {2} = {3} - even", firstNum, operation, secontNum, resultInt);
                    }
                    else
                    {
                        Console.WriteLine("{0} {1} {2} = {3} - odd", firstNum, operation, secontNum, resultInt);
                    }
                    break;
                case '/':
                    if (secontNum == 0)
                    {
                        Console.WriteLine("Cannot divide {0} by zero", firstNum);
                    }
                    else
                    {
                        resultDouble = (double)firstNum / secontNum;
                        Console.WriteLine("{0} {1} {2} = {3:f2}", firstNum, operation, secontNum, resultDouble);
                    }
                    break;
                case '%':
                    if (secontNum == 0)
                    {
                        Console.WriteLine("Cannot divide {0} by zero", firstNum);
                    }
                    else
                    {
                        resultInt = firstNum % secontNum;
                        Console.WriteLine("{0} {1} {2} = {3}", firstNum, operation, secontNum, resultInt);
                    }
                    break;
            }
        }
    }
}
