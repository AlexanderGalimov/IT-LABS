using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Task2.ViewModels;

namespace Task2.models
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Creature _selectedCreature;
        public Creature SelectedCreature
        {
            get { return _selectedCreature; }
            set
            {
                if (_selectedCreature != value)
                {
                    _selectedCreature = value;
                    OnPropertyChanged("SelectedCreature");
                }
            }
        }

        private ObservableCollection<Creature> _creatures;
        public ObservableCollection<Creature> Creatures
        {
            get { return _creatures; }
            set
            {
                if (_creatures != value)
                {
                    _creatures = value;
                    OnPropertyChanged("Creatures");
                }
            }
        }

        public ICommand MoveCommand { get; }
        public ICommand StandCommand { get; }
        public ICommand ActionCommand { get; }

        public MainViewModel()
        {
            MoveCommand = new RelayCommand(Move);
            StandCommand = new RelayCommand(Stand);
            ActionCommand = new RelayCommand(Action);

            Creatures = new ObservableCollection<Creature>
            {
                new Panther(30),
                new Dog(8),
                new Turtle(2)
            };
        }

        private void Move()
        {
            SelectedCreature?.Move();
        }

        private void Stand()
        {
            SelectedCreature?.Stand();
        }

        private void Action()
        {
            if (SelectedCreature is Panther)
            {
                MessageBox.Show((SelectedCreature as Panther)?.Roar());
                MessageBox.Show((SelectedCreature as Panther)?.ClimbTree());
            }
            else if (SelectedCreature is Dog)
            {
                MessageBox.Show((SelectedCreature as Dog)?.Bark());
            }
            else if (SelectedCreature is Turtle) {
                MessageBox.Show((SelectedCreature as Turtle)?.RetractNeck());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
