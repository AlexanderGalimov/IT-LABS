using System.Windows;

namespace Task2.models
{
    public class Turtle : Creature
    {
        public Turtle(int maxSpeed) : base(maxSpeed)
        {
            Speed = 0;
        }

        public override string Move()
        {
            if (Speed < _maxSpeed)
            {
                Speed += 1;
            }

            return "Turtle's speed: " + Speed;
        }

        public override string Stand()
        {
            if (Speed != 0)
            {
                Speed -= 1;
            }

            return "Turte is standing";
        }

        public string RetractNeck()
        {
            return "Turtle's speed: " + Speed;
        }
    }
}
