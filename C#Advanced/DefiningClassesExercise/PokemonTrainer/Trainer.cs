using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    //    •	Name
    //•	Number of badges
    //•	A collection of pokemon

    public class Trainer
    {
        private string name;
        private int badges;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
            pokemons = new List<Pokemon>();
        }

        public string Name { get => name; set => name = value; }
        public int Badges { get => badges; set => badges = value; }
        public List<Pokemon> Pokemons { get => pokemons; set => pokemons = value; }
    }
}
