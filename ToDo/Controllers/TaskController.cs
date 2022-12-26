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

        [HttpPost]
        public async Task<IActionResult> CreateTask(Tasks task)
        {
            if (task.DateTask == DateTime.MinValue)
            {
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });
            }
            await _taskRepository.CreateTasks(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);

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
            if (task == null)
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

        [HttpGet("ObterPorData")]
        public async Task<IActionResult> GetTaskByDate(DateTime date)
        {
            var tasks = await _taskRepository.GetTasksByDate(date);
            if (tasks == null)
            {
                return NotFound("Tarefa não encontrada");
            }
            else
            {
                return Ok(tasks);
            }
        }

        [HttpGet("ObterPorStatus")]
        public async Task<IActionResult> GetTaskByStatus(EnumStatusTasks status)
        {
            var tasks = await _taskRepository.GetTasksByStatus(status);
            if (tasks == null)
            {
                return NotFound("Tarefa não encontrada");
            }
            else
            {
                return Ok(tasks);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask(Tasks task, int id)
        {
            if (task.DateTask == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });
            var update = await _taskRepository.UpdateTask(task, id);
            return Ok(update);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskRepository.DeleteTask(id);
            return NoContent();
        }
    }
}
