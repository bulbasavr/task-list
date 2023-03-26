using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace TaskList.Models
{
    public static class DataTask
    {
        public static ObservableCollection<Task> GetAllTasks()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                ObservableCollection<Task> result = new ObservableCollection<Task>();
                var allTasks = db.Task.ToArray();
                foreach (var task in allTasks)
                {
                    result.Add(task);
                }
                return result;
            }
        }

        public static void CreateTask(bool isDone, string textTask)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Task.Any(el => el.IsDone == isDone && el.TextTask == textTask);
                if (!checkIsExist)
                {
                    Task newTask = new Task()
                    {
                        SomeData = DateTime.Now,
                        IsDone = isDone,
                        TextTask = textTask
                    };
                    db.Task.Add(newTask);
                    db.SaveChanges();
                }
            }
        }

        public static void DeleteTask(Task task)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Task.Remove(task);
                db.SaveChanges();
            }
        }
    }
}
