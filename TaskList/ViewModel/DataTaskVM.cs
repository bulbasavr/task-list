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
        public ObservableCollection<Task> _allTasks = DataTask.GetAllTasks();
        public ObservableCollection<Task> AllTasks
        {
            get
            {
                return _allTasks;
            }
            set
            {
                _allTasks = value;
            }
        }

        public string? NewTextTask { get; set; }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(obj =>
                    {
                        AllTasks.Add(DataTask.CreateTask(false, NewTextTask));

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
                        ObservableCollection<Task> newList = new ObservableCollection<Task>();
                        List<Task> deleteTask = new List<Task>();
                        foreach (Task task in AllTasks)
                        {
                            if (task.IsDone == true)
                            {
                                deleteTask.Add(task);
                            }
                            else
                            {
                                newList.Add(task);
                            }
                        }

                        foreach (Task task in deleteTask)
                        {
                            DataTask.DeleteTask(task);
                        }

                        AllTasks.Clear();

                        foreach (Task task in newList)
                        {
                            AllTasks.Add(task);
                        }
                    }));
            }
        }
    }
}
