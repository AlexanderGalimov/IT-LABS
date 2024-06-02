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

        public override string Move()
        {
            if (Speed < _maxSpeed)
            {
                Speed += 1;
            }

            return "Pather's speed: " + Speed;
        }

        public override string Stand()
        {
            if (Speed != 0)
            {
                Speed -= 1;
            }
            return "Panter's speed: " + Speed;
        }
    }
}
