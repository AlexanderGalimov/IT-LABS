namespace Task2.models
{
    public class Panther : Creature
    {
        public Panther(int maxSpeed) : base(maxSpeed)
        {
            Speed = 0;
        }

        public string Roar()
        {
            return "Panther roars!";
        }

        public string ClimbTree()
        {
            return "Panther climbs a tree!";
        }

        public override void Move()
        {
            if (Speed < _maxSpeed)
            {
                Speed += 1;
            }
        }

        public override void Stand()
        {
            if (Speed != 0)
            {
                Speed -= 1;
            }
        }
    }
}
