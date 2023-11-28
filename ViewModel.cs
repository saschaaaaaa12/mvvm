using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Windows;
using System.Windows.Input;

namespace qwerty
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Task> items { get; set; }

        public ViewModel()
        {
            items = new ObservableCollection<Task>() {
                new Task{Zagolovok="Задача №1", Opisanie="Что-то сделать", Date="01.01.67", Status=true},
                new Task{Zagolovok="Задача №1", Opisanie="Что-то написать", Date="02.01.78", Status=false},
            };
        }

        private Task selectedItem;
        public Task SelectedItem
        {
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
            get
            {
                return selectedItem;
            }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return new RelayCommand(obj =>
                    {
                        Task t = new Task() { Zagolovok = "Задача №0", Date="00.00.00"};
                        items.Insert(0, t);
                        SelectedItem = t;
                    });

            }
        }

        public RelayCommand  DelCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    items.Remove(SelectedItem);
                    if (items.Count > 0) 
                        SelectedItem = items[0];
                    else 
                        SelectedItem = null;
                }, (obj) => items.Count > 0);

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
