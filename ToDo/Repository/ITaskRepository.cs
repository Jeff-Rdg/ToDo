using ToDo.Models;

namespace ToDo.Repository
{
    public interface ITaskRepository
    {
        Task<Tasks> CreateTasks(Tasks task);
        Task<IEnumerable<Tasks>> GetAllTasks();
        Task<Tasks> GetTasksByTasksId(int id);
        Task<Tasks> GetTasksByTitle(string title);
        Task<Tasks> GetTasksByDate(DateTime date);
        Task<Tasks> GetTasksByStatus(EnumStatusTasks status);
        Task<Tasks> UpdateTask(Tasks task, int id);
        Task<bool> DeleteTask(int id);

    }
}
