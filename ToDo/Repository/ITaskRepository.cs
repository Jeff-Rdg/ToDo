using ToDo.Models;

namespace ToDo.Repository
{
    public interface ITaskRepository
    {
        Task<Tasks> CreateTasks(Tasks task);
        Task<IEnumerable<Tasks>> GetAllTasks();
        Task<Tasks> GetTasksByTasksId(int id);
        Task<IEnumerable<Tasks>> GetTasksByTitle(string title);
        Task<IEnumerable<Tasks>> GetTasksByDate(DateTime date);
        Task<IEnumerable<Tasks>> GetTasksByStatus(EnumStatusTasks status);
        Task<Tasks> UpdateTask(Tasks task, int id);
        Task<bool> DeleteTask(int id);

    }
}
