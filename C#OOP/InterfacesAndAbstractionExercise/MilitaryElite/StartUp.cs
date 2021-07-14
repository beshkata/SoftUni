using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main()
        {
            List<ISoldier> soldiers = new List<ISoldier>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] tokens = input.Split();

                string type = tokens[0];
                string id = tokens[1];
                string firstName = tokens[2];
                string lastName = tokens[3];

                if (type == nameof(Private))
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    Private @private = new Private(id, firstName, lastName, salary);
                    soldiers.Add(@private);
                }
                else if (type == nameof(LieutenantGeneral))
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);
                    for (int i = 5; i < tokens.Length; i++)
                    {
                        string privateId = tokens[i];
                        IPrivate @private = (IPrivate)soldiers.FirstOrDefault(x => x.Id == privateId);
                        if (@private != null)
                        {
                            lieutenantGeneral.AddPrivate(@private);
                        }
                    }
                    soldiers.Add(lieutenantGeneral);
                }
                else if (type == nameof(Engineer))
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    bool isCorpsValid = Enum.TryParse(tokens[5], out Corps corps);

                    if(!isCorpsValid)
                    {
                        continue;
                    }
                    Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < tokens.Length; i+=2)
                    {
                        string partName = tokens[i];
                        int hoursWorked = int.Parse(tokens[i + 1]);
                        Repair repair = new Repair(partName, hoursWorked);
                        engineer.AddRepair(repair);
                    }
                    soldiers.Add(engineer);
                }
                else if (type == nameof(Commando))
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    bool isCorpsValid = Enum.TryParse(tokens[5], out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }
                    Commando commando = new Commando(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < tokens.Length; i += 2)
                    {
                        string codeName = tokens[i];
                        bool isMissionStateValid = Enum.TryParse(tokens[i + 1], out MissionState state);
                        if (!isMissionStateValid)
                        {
                            continue;
                        }
                        Mission mission = new Mission(codeName, state);
                        commando.AddMission(mission);
                    }
                    soldiers.Add(commando);

                }
                else if (type == nameof(Spy))
                {
                    int codeNumber = int.Parse(tokens[4]);
                    Spy spy = new Spy(id, firstName, lastName, codeNumber);
                    soldiers.Add(spy);
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}
