using System.ComponentModel;

namespace Task4.model
{
    public class Car : INotifyPropertyChanged
    {
        private string name;
        private bool tiresWornOut;
        private bool hasCollided;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public bool TiresWornOut
        {
            get { return tiresWornOut; }
            set
            {
                if (tiresWornOut != value)
                {
                    tiresWornOut = value;
                    OnPropertyChanged("TiresWornOut");
                }
            }
        }

        public bool HasCollided
        {
            get { return hasCollided; }
            set
            {
                if (hasCollided != value)
                {
                    hasCollided = value;
                    OnPropertyChanged("HasCollided");
                }
            }
        }

        public Car(string name)
        {
            Name = name;
            TiresWornOut = false;
            HasCollided = false;
        }

        public string TiresCondition()
        {
            return TiresWornOut ? "Worn out" : "Normal";
        }

        public string CollideCondition()
        {
            return HasCollided ? "Collided" : "Normal";
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
