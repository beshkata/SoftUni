using MilitaryElite.Contracts;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<ISoldier> soldiers = new List<ISoldier>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string id = tokens[1];
                string firstName = tokens[2];
                string lastName = tokens[3];

                if (command == "Private")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    ISoldier soldier = new Private(id, firstName, lastName, salary);
                    soldiers.Add(soldier);
                }
                else if (command == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    List<IPrivate> privates = new List<IPrivate>();
                    for (int i = 5; i < tokens.Length; i++)
                    {
                        string currentId = tokens[i];
                        IPrivate @private = (IPrivate)soldiers.FirstOrDefault(x => x.Id == currentId);
                        if (@private == null)
                        {
                            continue;
                        }
                        privates.Add(@private);
                    }
                    ISoldier lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                    soldiers.Add(lieutenantGeneral);
                }
                else if (command == "Engineer")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    string corps = tokens[5];
                    if (corps != "Airforces" && corps != "Marines")
                    {
                        continue;
                    }
                    List<IRepair> repairs = new List<IRepair>();

                    for (int i = 6; i < tokens.Length; i+=2)
                    {
                        string partName = tokens[i];
                        int hoursWorked = int.Parse(tokens[i + 1]);
                        IRepair repair = new Repair(partName, hoursWorked);
                        repairs.Add(repair);
                    }
                    ISoldier engineer = new Engineer(id, firstName, lastName, salary, corps, repairs);
                    soldiers.Add(engineer);
                }
                else if (command == "Commando")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    string corps = tokens[5];
                    if (corps != "Airforces" && corps != "Marines")
                    {
                        continue;
                    }
                    List<IMission> missions = new List<IMission>();

                    for (int i = 6; i < tokens.Length; i += 2)
                    {
                        string codeName = tokens[i];
                        string state = tokens[i + 1];
                        if (state != "inProgress" && state != "Finished")
                        {
                            continue;
                        }
                        IMission mission = new Mission(codeName, state);
                        missions.Add(mission);
                    }
                    ISoldier commando = new Commando(id, firstName, lastName, salary, corps, missions);
                    soldiers.Add(commando);

                }
                else if (command == "Spy")
                {
                    int codeNumber = int.Parse(tokens[4]);

                    ISoldier spy = new Spy(id, firstName, lastName, codeNumber);
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
