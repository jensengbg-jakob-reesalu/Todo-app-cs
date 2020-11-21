using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Api.Models;
using TodoApp.App.Components;

namespace TodoApp.App.Pages
{
    public partial class Index
    {
        [Inject] private ITodoItemService TodoService { get; set; }
        
        private List<TodoItemDto> TodoItems { get; set; }
        private UpdatePopup updatePopupRef;

        

        protected override async Task OnInitializedAsync()
        {
            await Load();
        }

        protected async Task Load()
        {
            TodoItems = await TodoService.GetTodosAsync();
        }

        protected async Task UpdateAndLoad()
        {
            //Added InvokeAsync to get test working
            await InvokeAsync(StateHasChanged);

            await Load();
        }
        


        public async Task RemoveTodoItem(int todoItemId)
        {
            var response = await TodoService.DeleteTodoAsync(todoItemId);

            await UpdateAndLoad();

        }

    }
}
