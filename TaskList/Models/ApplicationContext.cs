using Microsoft.EntityFrameworkCore;

namespace TaskList.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Task> Task { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=tasklistdb;Trusted_Connection=True;");
        }

    }
}
