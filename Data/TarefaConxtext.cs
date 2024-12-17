using Microsoft.EntityFrameworkCore;
using taskManagerJr.Models;
using taskManagerJr.Interfaces;
using taskManagerJr.Repositories;






namespace taskManagerJr.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
