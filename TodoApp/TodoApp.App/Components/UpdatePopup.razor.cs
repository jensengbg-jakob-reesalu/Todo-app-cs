using Blazorise;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using TodoApp.Api.Models;
using TodoApp.Common.Models;

namespace TodoApp.App.Components
{
    public partial class UpdatePopup
    {
        private Modal modalRef;
        [Inject] ITodoItemService TodoService { get; set; }
        [Parameter] public string UpdateTextInput { get; set; } = "";
        [Parameter] public string PlaceHolderText { get; set; } = "Enter updated todo...";
        [Parameter] public EventCallback<bool> OnTodoItemUpdated { get; set; }
        [Parameter] public TodoItemDto TodoItemForUpdate { get; set; }


        public void ShowModal(TodoItemDto todoItemDto)
        {
            TodoItemForUpdate = todoItemDto;

            UpdateTextInput = "";

            PlaceHolderText = todoItemDto.Text;

            modalRef.Show();
        }

        private void HideModal()
        {
            modalRef.Hide();
        }

        public async Task UpdateTodoItem()
        {
            if (String.IsNullOrWhiteSpace(UpdateTextInput))
            {
                PlaceHolderText = "MUST ENTER SOMETHING!";
                return;
            }
            var todoItemForUpdateDto = new TodoItemForUpdateDto { Text = UpdateTextInput };

            var response = await TodoService.UpdateTodoAsync(TodoItemForUpdate.Id, todoItemForUpdateDto);
         
            HideModal(); 

            await OnTodoItemUpdated.InvokeAsync(true);
        }
    }
}
