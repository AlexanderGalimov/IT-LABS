using System.ComponentModel;
using System.IO;

namespace Task2.models
{
    public abstract class Creature : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string TypeName => GetType().Name;

        protected int _maxSpeed;

        public Creature(int maxSpeed)
        {
            Speed = 0;
            this._maxSpeed = maxSpeed;
        }

        private double _speed;

        public double Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                OnPropertyChanged("Speed");
            }
        }

        public abstract string Move();
        public abstract string Stand();

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
