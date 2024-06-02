using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Task4.model;

namespace Task4.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Car> cars;
        private ObservableCollection<Mechanic> mechanics;
        private ObservableCollection<Loader> loaders;
        private ICommand startRaceCommand;
        private ICommand addCarCommand;
        private string carName;
        private bool isRaceStarted;
        private string status;
        private string carTiresStatus;
        private string carCollisionStatus;

        public ObservableCollection<Car> Cars
        {
            get => cars;
            set
            {
                cars = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Mechanic> Mechanics
        {
            get => mechanics;
            set
            {
                mechanics = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Loader> Loaders
        {
            get => loaders;
            set
            {
                loaders = value;
                OnPropertyChanged();
            }
        }

        public string CarName
        {
            get => carName;
            set
            {
                carName = value;
                OnPropertyChanged();
            }
        }

        public string Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }

        public string CarTiresStatus
        {
            get => carTiresStatus;
            set
            {
                carTiresStatus = value;
                OnPropertyChanged();
            }
        }

        public string CarCollisionStatus
        {
            get => carCollisionStatus;
            set
            {
                carCollisionStatus = value;
                OnPropertyChanged();
            }
        }

        public bool IsRaceStarted
        {
            get => isRaceStarted;
            set
            {
                isRaceStarted = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsRaceNotStarted));
            }
        }

        public bool IsRaceNotStarted => !IsRaceStarted;

        public ICommand StartRaceCommand
        {
            get
            {
                if (startRaceCommand == null)
                {
                    startRaceCommand = new RelayCommand(
                        param => StartRace(),
                        param => CanStartRace());
                }
                return startRaceCommand;
            }
        }

        public ICommand AddCarCommand
        {
            get
            {
                if (addCarCommand == null)
                {
                    addCarCommand = new RelayCommand(
                        param => AddCar(),
                        param => CanAddCar());
                }
                return addCarCommand;
            }
        }

        public MainWindowViewModel()
        {
            Status = "Waiting to start the race";

            Cars = new ObservableCollection<Car>();
            Mechanics = new ObservableCollection<Mechanic>();
            Loaders = new ObservableCollection<Loader> { new Loader() };
            IsRaceStarted = false;
        }

        public void AddCar()
        {
            Cars.Add(new Car(carName));
            Mechanics.Add(new Mechanic(carName + " " + "mechanic"));
            CarName = string.Empty;
        }

        private void StartRace()
        {
            Status = "Race in progress";

            IsRaceStarted = true;
            foreach (var car in Cars)
            {
                Task.Run(() => SimulateCarRace(car));
            }
        }

        private bool CanStartRace()
        {
            return Cars.Count > 0 && !IsRaceStarted;
        }

        private bool CanAddCar()
        {
            return !IsRaceStarted;
        }

        private void SimulateCarRace(Car car)
        {
            Random random = new Random();

            while (!car.HasCollided && !car.TiresWornOut)
            {
                Thread.Sleep(random.Next(1000));

                if (random.NextDouble() < 0.5)
                {
                    car.TiresWornOut = true;
                    CarTiresStatus = car.TiresCondition();
                    Thread.Sleep(random.Next(1000));

                    var mechanic = Mechanics[0];
                    Status = mechanic.OnTiresWornOut(car);
                }

                if (random.NextDouble() < 0.05)
                {
                    car.HasCollided = true;
                    CarCollisionStatus = car.CollideCondition();

                    var loader = Loaders[0];
                    loader.Arrive();
                    var mechanic = Mechanics[0];
                    Status = mechanic.OnCollision(car);
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
