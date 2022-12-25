using Microsoft.EntityFrameworkCore;
using ToDo.Context.Map;
using ToDo.Models;

namespace ToDo.Context
{
    public class ToDoContext :DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }

        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TasksMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
