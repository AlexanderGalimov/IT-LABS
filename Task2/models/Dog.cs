namespace Task2.models
{
    public class Dog : Creature
    {
        public Dog(int maxSpeed) : base(maxSpeed)
        {
            Speed = 0;
        }

        public string Bark()
        {
            return "Dog barks";
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
