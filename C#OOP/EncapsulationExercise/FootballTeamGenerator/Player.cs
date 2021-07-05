using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Player
    {
        private const int MinStatValue = 0;
        private const int MaxStatValue = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                ThrowIfStatIsInvalid(value, nameof(Endurance));
                endurance = value;
            }
        }
        public int Sprint
        {
            get => this.sprint;
            private set
            {
                ThrowIfStatIsInvalid(value, nameof(Sprint));
                sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;
            private set
            {
                ThrowIfStatIsInvalid(value, nameof(Dribble));
                dribble = value;
            }
        }
        public int Passing
        {
            get => passing;
            private set
            {
                ThrowIfStatIsInvalid(value, nameof(Passing));
                passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            private set
            {
                ThrowIfStatIsInvalid(value, nameof(Shooting));
                shooting = value;
            }
        }
        public double SkillLevel
        {
            get
            {
                int[] stats = { Endurance, Sprint, Dribble, Passing, Shooting };
                return stats.Average();
            }
        }
        private void ThrowIfStatIsInvalid(int value, string statName)
        {
            if (value < MinStatValue || value > MaxStatValue)
            {
                throw new ArgumentException($"{statName} should be between {MinStatValue} and {MaxStatValue}.");
            }
        }
    }
}
