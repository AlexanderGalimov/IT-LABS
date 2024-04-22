using System.Windows;

namespace Task2.models
{
    public class Turtle : Creature
    {
        public Turtle(int maxSpeed) : base(maxSpeed)
        {
            Speed = 0;
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

        public string RetractNeck()
        {
            return "Neck retracted";
        }
    }
}
