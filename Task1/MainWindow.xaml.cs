using System;
using System.Windows;
using Task1.models;

namespace Task1
{
    public partial class MainWindow : Window
    {
        private LinkedList myList;

        public MainWindow()
        {
            InitializeComponent();
            myList = new LinkedList();
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            listBox.Items.Clear();

            var currentNode = myList.Head;
            while (currentNode != null)
            {
                listBox.Items.Add(currentNode.Data);
                currentNode = currentNode.Next;
            }
        }

        private void btnAppend_Click(object sender, RoutedEventArgs e)
        {
            string newItem = txtInput.Text;
            myList.Append(newItem);
            UpdateDisplay();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            string newItem = txtInput.Text;
            int index;
            if (int.TryParse(txtIndexInsert.Text, out index))
            {
                try
                {
                    myList.Insert(newItem, index);
                    UpdateDisplay();
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

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            int index;
            if (int.TryParse(txtIndexRemove.Text, out index))
            {
                try
                {
                    myList.Remove(index);
                    UpdateDisplay();
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

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            myList.Clear();
            UpdateDisplay();
        }
    }
}
