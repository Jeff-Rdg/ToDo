using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using ToDo.Context;
using ToDo.Models;

namespace ToDo.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ToDoContext _context;

        public TaskRepository(ToDoContext context)
        {
            _context = context;
        }

        public async Task<Tasks> CreateTasks(Tasks task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<IEnumerable<Tasks>> GetAllTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return tasks;
        }

        public async Task<Tasks> GetTasksByDate(DateTime date)
        {
            Tasks task = await _context.Tasks.FirstOrDefaultAsync(x => x.DateTask.Date == date.Date);
            if (task == null)
            {
                throw new Exception("Não possuem registros com essa data");
            }
            return task;

        }

        public async Task<Tasks> GetTasksByStatus(EnumStatusTasks status)
        {
            Tasks task = await _context.Tasks.FirstOrDefaultAsync(x => x.Status == status);
            if (task == null)
            {
                throw new Exception("Não possuem registros com essa data");
            }
            return task;
        }

        public async Task<Tasks> GetTasksByTasksId(int id)
        {
            Tasks task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task == null)
            {
                throw new Exception("Não possuem registros com essa data");
            }
            return task;
        }

        public async Task<Tasks> GetTasksByTitle(string title)
        {
            Tasks task = await _context.Tasks.FirstOrDefaultAsync(x => x.Title == title);
            if (task == null)
            {
                throw new Exception("Não possuem registros com essa data");
            }
            return task;
        }

        public async Task<Tasks> UpdateTask(Tasks task, int id)
        {
            Tasks taskId = await GetTasksByTasksId(id);
            if(taskId == null)
            {
                throw new Exception("Não existem registros com esse Id");
            }

            taskId.Title = task.Title;
            taskId.Description = task.Description;
            taskId.Status = task.Status;
            taskId.DateTask = task.DateTask;

            _context.Update(taskId);
            await _context.SaveChangesAsync();

            return taskId;

        }
        public async Task<bool> DeleteTask(int id)
        {
            Tasks taskId = await GetTasksByTasksId(id);
            if (taskId == null)
            {
                throw new Exception("Não existem registros com esse Id");
            }

            _context.Remove(taskId);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
