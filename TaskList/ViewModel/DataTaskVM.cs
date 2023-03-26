using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TaskList.Models;

namespace TaskList.ViewModel
{
    public class DataTaskVM
    {
        public ObservableCollection<Task> AllTasks { get; set; } = DataTask.GetAllTasks();
        public string? NewTextTask { get; set; }


        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(obj =>
                    {
                        DataTask.CreateTask(false, NewTextTask);
                        AllTasks.Clear();
                        foreach (Task task in DataTask.GetAllTasks())
                        {
                            AllTasks.Add(task);
                        }

                    }));
            }
        }


        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ??
                    (_deleteCommand = new RelayCommand(obj =>
                    {
                        foreach (Task task in AllTasks)
                        {
                            if (task.IsDone == true)
                            {
                                DataTask.DeleteTask(task);
                            }
                        }

                        AllTasks.Clear();

                        foreach (Task task in DataTask.GetAllTasks())
                        {
                            AllTasks.Add(task);
                        }
                    }));
            }
        }
    }
}
