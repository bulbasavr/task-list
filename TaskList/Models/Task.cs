using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskList.Models;

public class Task
{
    public int Id { get; set; }
    public DateTime SomeData { get; set; } = DateTime.Now;
    public bool IsDone { get; set; }
    public string? TextTask { get; set; }

}
