using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TodoApp.Api.Models;
using TodoApp.Common.Models;

namespace TodoApp.App
{
    public interface ITodoItemService
    {
        //Task<TodoItemDto[]> GetTodosAsync();
        Task<List<TodoItemDto>> GetTodosAsync();
        Task<TodoItemDto> GetTodosByIdAsync(int todoItemId);
        Task<HttpResponseMessage> AddTodoAsync(TodoItemForCreationDto todoItemForCreation);
        Task<HttpResponseMessage> UpdateTodoAsync(int todoItemId, TodoItemForUpdateDto todoItemForUpdate);
        Task<HttpResponseMessage> DeleteTodoAsync(int todoItemId);
        StringContent GetStringContentFromObject(object obj);
    }
}