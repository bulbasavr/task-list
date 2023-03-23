using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TaskList.Models;
using TaskList.Views;

namespace TaskList.ViewModel
{
    public class DataTaskVM : INotifyPropertyChanged
    {
        public ObservableCollection<Task> AllTasks { get; set; } = DataTask.GetAllTasks();
        public string? NewTextTask { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(obj =>
                    {
                        DataTask.CreateTask(false, NewTextTask);

                        AllTasks.Add(new Task() {SomeData = DateTime.Now, IsDone = false, TextTask = NewTextTask});
                    }));
            }
        }
    }
}
