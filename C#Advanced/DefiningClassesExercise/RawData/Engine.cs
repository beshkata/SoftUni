using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses123
{
    public class Engine
    {
        private int power;
        private int speed;

        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
        public int Power { get => power; set => power = value; }
        public int Speed { get => speed; set => speed = value; }
    }
}
