using Todo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Todo.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

       public DbSet<TodoItem> ToDos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().Property(x => x.Id);
            modelBuilder.Entity<TodoItem>().Property(x => x.User).HasMaxLength(120);
            modelBuilder.Entity<TodoItem>().Property(x => x.Title).HasMaxLength(160);
            modelBuilder.Entity<TodoItem>().Property(x => x.Done);
            modelBuilder.Entity<TodoItem>().Property(x => x.Date);
            modelBuilder.Entity<TodoItem>().Property(x => x.User);
        }
    }
}
