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

        public override string Move()
        {
            if (Speed < _maxSpeed)
            {
                Speed += 1;
            }
            return "Dog's speed: " + Speed;
        }

        public override string Stand()
        {
            if (Speed != 0)
            {
                Speed -= 1;
            }
            return "Dog's speed: " + Speed;
        }
    }
}
