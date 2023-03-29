using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;



namespace TaskList.Models
{
    public class Task : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public DateTime SomeData { get; set; } = DateTime.Now;
        public bool _isDone;

        public bool IsDone
        {
            get { return _isDone; }
            set
            {
                _isDone = value;
                OnPropertyChanged();
            }
        }

        public string? TextTask { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
