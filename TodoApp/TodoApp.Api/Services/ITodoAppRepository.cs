using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Api.Entities;

namespace TodoApp.Api.Services
{
    public interface ITodoAppRepository
    {
        Task<IEnumerable<TodoItem>> GetTodoItemsAsync();
        Task<TodoItem> GetTodoItemAsync(int todoItemId);
        void AddTodoItem(TodoItem todoItem);
        void UpdateTodoItem(TodoItem todoItem);
        void RemoveTodoItem(TodoItem todoItem);
        Task<bool> SaveChangesAsync();
    }
}
