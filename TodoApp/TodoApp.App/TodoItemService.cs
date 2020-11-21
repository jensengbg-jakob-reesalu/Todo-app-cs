using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Api.Models;
using TodoApp.Common.Models;

namespace TodoApp.App
{
    public class TodoItemService : ITodoItemService
    {
        private readonly HttpClient _client;

        public TodoItemService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("TodoAppClient");
        }
        
        public async Task<List<TodoItemDto>> GetTodosAsync()
        {
            var json = await _client.GetStringAsync("/api/TodoItems");
            return JsonConvert.DeserializeObject<List<TodoItemDto>>(json);
        }

        public async Task<TodoItemDto> GetTodosByIdAsync(int todoItemId)
        {
            var json = await _client.GetStringAsync($"/api/TodoItems/{todoItemId}");
            return JsonConvert.DeserializeObject<TodoItemDto>(json);
        }

        public async Task<HttpResponseMessage> AddTodoAsync(TodoItemForCreationDto todoItemForCreation)
        {
            return await _client.PostAsync("/api/TodoItems", GetStringContentFromObject(todoItemForCreation));
        }

        public async Task<HttpResponseMessage> UpdateTodoAsync(int todoItemId, TodoItemForUpdateDto todoItemForUpdate)
        {
            return await _client.PutAsync($"/api/TodoItems/{todoItemId}", GetStringContentFromObject(todoItemForUpdate));
        }

        public async Task<HttpResponseMessage> DeleteTodoAsync(int todoItemId)
        {
            return await _client.DeleteAsync($"/api/TodoItems/{todoItemId}");
        }

        public StringContent GetStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }
    }
}
