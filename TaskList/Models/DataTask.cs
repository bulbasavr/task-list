using System;
using System.ComponentModel;
using System.Linq;

namespace TaskList.Models
{
    public static class DataTask
    {
        public static BindingList<Task> GetAllTasks()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                BindingList<Task> result = new BindingList<Task>();
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

        public static void EditTask(Task oldTask, bool newIsDone)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Task task = db.Task.FirstOrDefault(el => el.Id == oldTask.Id);
                task.IsDone = newIsDone;
                db.SaveChanges();
            }
        }
    }
}
