using System;

namespace _06._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int counter = 1111;

            while (counter <= 9999)
            {
                string str = counter.ToString();
                if (str[0] == '0' || str[1] == '0' || str[2] == '0' || str[3] == '0')
                {
                    counter++;
                    continue;
                }
                else
                {
                    if (num % int.Parse(str[0].ToString()) == 0)
                    {
                        if (num % int.Parse(str[1].ToString()) == 0)
                        {
                            if (num % int.Parse(str[2].ToString()) == 0)
                            {
                                if (num % int.Parse(str[3].ToString()) == 0)
                                {
                                    Console.Write(counter + " ");
                                }
                            }
                        }
                    }

                }
                counter++;
            }
        }
    }
}
