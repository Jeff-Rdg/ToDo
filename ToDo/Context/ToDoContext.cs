using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace ToDo.Context
{
    public class ToDoContext :DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }

        public DbSet<Tasks> Tasks { get; set; }
    }
}
