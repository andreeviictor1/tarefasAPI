using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using taskManagerJr.Interfaces;
using taskManagerJr.Models;

namespace taskManagerJr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }



        [HttpGet]
        public async Task <ActionResult<IEnumerable<Tarefa>>> GetTasks()
        {
            var tarefas = await _taskService.GetAllTasks();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<Tarefa>> GetTask (int id)
        {
            var tarefa = await _taskService.GetTarefaById(id);
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<Tarefa>> CreateTask (Tarefa tarefa)
        {
            await _taskService.AddTarefaAsync(tarefa);
            return CreatedAtAction(nameof(GetTask), new { id = tarefa.Id }, tarefa);

        }



        [HttpPut("{id}")]
        public async Task <ActionResult<Tarefa>> UpdateTask (int id, Tarefa tarefa)
        {
            if (id != tarefa.Id)
            {
                return BadRequest();
            }

            await _taskService.UpdateTarefaAsync (tarefa);
            return NoContent();

        }
    }
}
