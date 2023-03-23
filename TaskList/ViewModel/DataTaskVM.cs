﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TaskList.Models;

namespace TaskList.ViewModel
{
    public class DataTaskVM : INotifyPropertyChanged
    {
        //private List<Task> _allTasks = DataTask.GetAllTasks();
        private List<Task> _allTasks = new List<Task>()
            {
                new Task(){IsDone = false, TextTask = "test"},
                new Task(){IsDone = true, TextTask = "test"},
                new Task(){IsDone = false, TextTask = "test"},
                new Task(){IsDone = true, TextTask = "test"},
                new Task(){IsDone = false, TextTask = "test"},
                new Task(){IsDone = true, TextTask = "test"}
            };


        public List<Task> AllTasks
        {
            get { return _allTasks; }
            set
            {
                _allTasks = value;
                OnPropertyChanged("AllTasks");
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
