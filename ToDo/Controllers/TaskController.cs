using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Models;
using ToDo.Repository;

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet("ObterTodos")]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _taskRepository.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskRepository.GetTasksByTasksId(id);
            if(task == null)
            {
                return NotFound("Tarefa não encontrada");
            }
            else
            {
                return Ok(task);
            }
        }

        [HttpGet("ObterPorTitulo")]
        public async Task<IActionResult> GetTaskBytitle(string title)
        {
            var tasks = await _taskRepository.GetTasksByTitle(title);
            if (tasks == null)
            {
                return NotFound("Tarefa não encontrada");
            }
            else
            {
                return Ok(tasks);
            }
        }

    }
}
