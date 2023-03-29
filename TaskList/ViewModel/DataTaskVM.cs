using System.ComponentModel;
using System.Runtime.CompilerServices;
using TaskList.Models;

namespace TaskList.ViewModel
{
    public class DataTaskVM : INotifyPropertyChanged
    {
        public BindingList<Task> AllTasks { get; set; } = DataTask.GetAllTasks();

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

        public DataTaskVM()
        {
            AllTasks.ListChanged += _taskList_ListChanged;

        }

        ~ DataTaskVM()
        {
            AllTasks.ListChanged -= _taskList_ListChanged;

        }

        private void _taskList_ListChanged(object senger, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                BindingList<Task> dbList = DataTask.GetAllTasks();
                for (int i = 0; i < dbList.Count; i++)
                {
                    if (dbList[i].IsDone != AllTasks[i].IsDone)
                    {
                        DataTask.EditTask(dbList[i], AllTasks[i].IsDone);
                    }
                }
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
