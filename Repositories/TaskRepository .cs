using taskManagerJr.Models;
using taskManagerJr.Interfaces;
using taskManagerJr.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;



namespace taskManagerJr.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _context;

        public TaskRepository(TaskContext context)
        {
            _context = context;
        }
        


        // Metodos
        public async Task <IEnumerable<Tarefa>> GetAllAsync()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task <Tarefa> GetTarefaById(int id)
        {
            return await _context.Tarefas.FindAsync(id);
        }

        public async Task AddTarefaAsync(Tarefa tarefa)
        {
             _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateTarefaAsync(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();

        }


        public async Task DeleteTarefaAsync(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
            }

        }


    }
}
