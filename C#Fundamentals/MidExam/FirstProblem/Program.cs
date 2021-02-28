using System;

namespace FirstProblem
{
    class Program
    {
        static void Main()
        {
            double neededExperience = int.Parse(Console.ReadLine());
            double currentExperience = 0;
            int battleCount = int.Parse(Console.ReadLine());
            int battleFought = 0;
            bool isNewTankUnlock = false;

            for (int i = 1; i <= battleCount; i++)
            {
                int experiencePerBattle = int.Parse(Console.ReadLine());

                currentExperience += experiencePerBattle;
                battleFought++;

                if (i % 3 == 0)
                {
                    currentExperience += experiencePerBattle * 0.15;
                }
                if (i % 5 == 0)
                {
                    currentExperience -= experiencePerBattle * 0.1;
                }
                if (i % 15 == 0)
                {
                    currentExperience += experiencePerBattle * 0.05;
                }

                if (currentExperience >= neededExperience)
                {
                    isNewTankUnlock = true;
                    break;
                }
            }

            if (isNewTankUnlock)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {battleFought} battles.");
            }
            else
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {neededExperience - currentExperience:f2} more needed.");
            }
        }
    }
}
