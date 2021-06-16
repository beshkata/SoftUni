using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    //•	Model
    //•	Engine
    //•	Weight 
    //•	Color

    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine, int weight = -1, string color = "n/a")
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public string Model { get => model; set => model = value; }
        public Engine Engine { get => engine; set => engine = value; }
        public int Weight { get => weight; set => weight = value; }
        public string Color { get => color; set => color = value; }


        public override string ToString()
        {
            string displacementStr = Engine.Displacement.ToString();
            if (Engine.Displacement == -1)
            {
                displacementStr = "n/a";
            }
            string weightStr = Weight.ToString();
            if (Weight == -1)
            {
                weightStr = "n/a";
            }
            return $"{Model}:\n  {Engine.Model}:\n    Power: {Engine.Power}\n    Displacement: {displacementStr}\n    Efficiency: {Engine.Efficiency}\n  Weight: {weightStr}\n  Color: {Color}";
        }
    }
}
