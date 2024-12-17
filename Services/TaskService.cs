using taskManagerJr.Interfaces;
using taskManagerJr.Models;
using taskManagerJr.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace taskManagerJr.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskContext _context;

        // Construtor para injeção de dependência
        public TaskService(TaskContext context)
        {
            _context = context;
        }

        // Método para obter todas as tarefas 
        public async Task<IEnumerable<Tarefa>> GetAllTasks()
        {
            return await _context.Tarefas.ToListAsync();
        }

        // Método para obter uma tarefa por ID
        public async Task<Tarefa> GetTarefaById(int id)
        {
            return await _context.Tarefas.FindAsync(id);
        }

        // Método para adicionar uma tarefa
        public async Task AddTarefaAsync(Tarefa tarefa)
        {
            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();
        }

        // Método para atualizar uma tarefa
        public async Task UpdateTarefaAsync(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
        }

        // Método para deletar uma tarefa
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
