using taskManagerJr.Models;


namespace taskManagerJr.Interfaces
{
    public interface ITaskRepository
    {
        Task <IEnumerable<Tarefa>> GetAllAsync();
        Task <Tarefa> GetTarefaById(int id);    
        Task AddTarefaAsync (Tarefa tarefa);
        Task UpdateTarefaAsync (Tarefa tarefa);
        Task DeleteTarefaAsync (int id);
    }
}
