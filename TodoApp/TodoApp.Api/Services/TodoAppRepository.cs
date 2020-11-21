using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Api.Contexts;
using TodoApp.Api.Entities;


namespace TodoApp.Api.Services
{
    public class TodoAppRepository : ITodoAppRepository
    {
        private readonly TodoAppDbContext _context;

        public TodoAppRepository(TodoAppDbContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItemsAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }
        
        public async Task<TodoItem> GetTodoItemAsync(int todoItemId)
        {
            return await _context.TodoItems
                .FindAsync(todoItemId);
        }

        public void AddTodoItem(TodoItem todoItem)
        {
            _context.Add(todoItem);
        }

        public void UpdateTodoItem(TodoItem todoItem)
        {
            // No code here. 
        }

        public void RemoveTodoItem(TodoItem todoItem)
        {
            _context.Remove(todoItem);
        }



        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
