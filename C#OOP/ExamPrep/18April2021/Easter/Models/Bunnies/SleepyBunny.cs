namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int InitialEnergy = 50;
        public SleepyBunny(string name)
            : base(name, InitialEnergy)
        {
        }

        public override void Work()
        {
            Energy -= 15;
            if (Energy < 0)
            {
                Energy = 0;
            }
        }
    }
}
