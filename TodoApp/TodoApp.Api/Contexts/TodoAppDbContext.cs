using Microsoft.EntityFrameworkCore;
using TodoApp.Api.Entities;

namespace TodoApp.Api.Contexts
{
    public class TodoAppDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public TodoAppDbContext (DbContextOptions<TodoAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TodoItem>().Property("Text").IsRequired();
        }
    }
}
