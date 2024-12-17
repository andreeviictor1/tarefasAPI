using taskManagerJr.Models;

namespace taskManagerJr.Interfaces
{
    public interface ITaskService
    {
        Task <IEnumerable<Tarefa>> GetAllTasks();
        Task<Tarefa> GetTarefaById(int id);
        Task AddTarefaAsync(Tarefa tarefa);

        Task UpdateTarefaAsync(Tarefa tarefa);

        Task DeleteTarefaAsync(int id);

    }
}
