using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Armazena o enum Status como string
            modelBuilder.Entity<Tarefa>()
                .Property(t => t.Status)
                .HasConversion<string>();

            // Armazena a Data apenas como date (sem hora)
            modelBuilder.Entity<Tarefa>()
                .Property(t => t.Data)
                .HasColumnType("date");
        }
    }
}
