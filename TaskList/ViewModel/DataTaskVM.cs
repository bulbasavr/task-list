using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TaskList.Models;

namespace TaskList.ViewModel
{
    public class DataTaskVM : INotifyPropertyChanged
    {
        public ObservableCollection<Task> AllTasks { get; set; } = DataTask.GetAllTasks();

        private string _newTextTask;
        public string NewTextTask
        {
            get { return _newTextTask; }
            set
            {
                _newTextTask = value;
                OnPropertyChanged();
            }
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
                        AllTasks.Clear();
                        NewTextTask = "";

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


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
