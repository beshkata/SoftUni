using System;

namespace _08._On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            int examTimeInMin = examHour * 60 + examMinutes;
            int arrivalTimeInMin = arrivalHour * 60 + arrivalMinutes;

            if (examTimeInMin == arrivalTimeInMin)
            {
                Console.WriteLine("On time");
            }
            else if (arrivalTimeInMin < examTimeInMin)
            {
                if (examTimeInMin - arrivalTimeInMin <= 30)
                {
                    Console.WriteLine("On time");
                    Console.WriteLine("{0} minutes before the start", examTimeInMin - arrivalTimeInMin);
                }
                else if (examTimeInMin - arrivalTimeInMin > 30 && examTimeInMin - arrivalTimeInMin < 60)
                {
                    Console.WriteLine("Early");
                    Console.WriteLine("{0} minutes before the start", examTimeInMin - arrivalTimeInMin);
                }
                else
                {
                    Console.WriteLine("Early");
                    if ((examTimeInMin - arrivalTimeInMin) % 60 < 10)
                    {
                        Console.WriteLine("{0}:0{1} hours before the start", (examTimeInMin - arrivalTimeInMin) / 60,
                             (examTimeInMin - arrivalTimeInMin) % 60);
                    }
                    else
                    {
                        Console.WriteLine("{0}:{1} hours before the start", (examTimeInMin - arrivalTimeInMin) / 60,
                            (examTimeInMin - arrivalTimeInMin) % 60);
                    }
                }
            }
            else
            {
                if (arrivalTimeInMin - examTimeInMin < 60)
                {
                    Console.WriteLine("Late");
                    Console.WriteLine("{0} minutes after the start", arrivalTimeInMin - examTimeInMin);
                }
                else
                {
                    Console.WriteLine("Late");
                    if ((arrivalTimeInMin - examTimeInMin) % 60 < 10)
                    {
                        Console.WriteLine("{0}:0{1} hours after the start", (arrivalTimeInMin - examTimeInMin) / 60,
                             (arrivalTimeInMin - examTimeInMin) % 60);
                    }
                    else
                    {
                        Console.WriteLine("{0}:{1} hours after the start", (arrivalTimeInMin - examTimeInMin) / 60,
                            (arrivalTimeInMin - examTimeInMin) % 60);
                    }

                }
            }
        }
    }
}
