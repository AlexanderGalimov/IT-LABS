using System;
using System.Collections.ObjectModel;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using Task1.models;

namespace Task1.ViewModels
{   
    public class ListVM: BindableBase{
        private String newItem;
        private String insertIndex;
        private String deleteIndex;

        public DelegateCommand AppendCommand { get; private set; }
        public DelegateCommand InsertCommand { get; private set; }
        public DelegateCommand RemoveCommand { get; private set; }
        public DelegateCommand ClearCommand { get; private set; }
        public LinkedList<string> Items { get; private set; } = new LinkedList<string>();

        public ListVM()
        {
            AppendCommand = new DelegateCommand(Append);
            InsertCommand = new DelegateCommand(Insert);
            RemoveCommand = new DelegateCommand(Remove);
            ClearCommand = new DelegateCommand(Clear);
        }

        private void Append()
        {
            if (newItem == "") {
                MessageBox.Show("Введите корректное значение");
                return;
            }
            Items.append(newItem);
        }

        private void Insert()
        {
            int index;
            if (int.TryParse(insertIndex, out index))
            {
                try
                {
                    Items.insert(newItem, index);
                }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show("Индекс вне диапазона.");
                }
            }
            else
            {
                MessageBox.Show("Введите корректный индекс типа integer.");
            }
        }
        private void Remove()
        {
            int index;
            if (int.TryParse(deleteIndex, out index))
            {
                try
                {
                    Items.remove(index);
                }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show("Индекс вне диапазона.");
                }
            }
            else
            {
                MessageBox.Show("Введите корректный индекс.");
            }
        }

        private void Clear()
        {
            Items.Clear();
        }

        public string NewItem
        {
            get => newItem;
            set => SetProperty(ref newItem, value);
        }

        public string InsertIndex
        {
            get => insertIndex;
            set => SetProperty(ref insertIndex, value);
        }

        public string DeleteIndex
        {
            get => deleteIndex;
            set => SetProperty(ref deleteIndex, value);
        }
    }
}

