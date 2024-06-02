using System.ComponentModel;

namespace Task4.model
{
    public class Mechanic : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }

        public Mechanic(string name)
        {
            Name = name;
        }

        public string OnTiresWornOut(Car car)
        {
            if (car.TiresWornOut)
            {
                car.TiresWornOut = false;
                OnPropertyChanged(nameof(car.TiresWornOut));
                return $"Mechanic: {car.Name} changed tires.";
            }
            else
            {
                return $"Mechanic: {car.Name} tires are already worn out.";
            }
        }

        public string OnCollision(Car car)
        {
            if (car.HasCollided)
            {
                car.HasCollided = false;
                OnPropertyChanged(nameof(car.HasCollided));
                return $"Mechanic: {car.Name} repaired.";
            }
            else
            {
                return $"Mechanic: {car.Name} has no collision damage.";
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
