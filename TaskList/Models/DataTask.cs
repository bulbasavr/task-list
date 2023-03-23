using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskList.Models
{
    public static class DataTask
    {
        public static List<Task> GetAllTasks()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Task.ToList();
                return result;
            }
        }

        public static void CreateTask(DateTime someData, bool isDone, string textTask)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Task.Any(el => el.SomeData == someData && el.IsDone == isDone && el.TextTask == textTask);
                if (!checkIsExist)
                {
                    Task newTask = new Task()
                    {
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

        public static void EditTask(Task oldTask, string newTextTask)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Task task = db.Task.FirstOrDefault(el => el.Id == oldTask.Id);
                task.TextTask = newTextTask;
                db.Task.Remove(task);
                db.SaveChanges();
            }
        }
    }
}
