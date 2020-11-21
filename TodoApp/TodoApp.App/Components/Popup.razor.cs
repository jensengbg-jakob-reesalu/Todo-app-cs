using Blazorise;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using TodoApp.Common.Models;
using System;

namespace TodoApp.App.Components
{
    public partial class Popup
    {
        private Modal modalRef;
        [Inject] ITodoItemService TodoService { get; set; }
        [Parameter] public string TodoItemTextInput { get; set; } = "";
        [Parameter] public string PlaceHolderText { get; set; } = "Enter a todo...";
        [Parameter] public EventCallback<bool> OnTodoItemAdded { get; set; }

        private void ShowModal()
        {
            TodoItemTextInput = "";

            PlaceHolderText = "Enter a todo...";

            modalRef.Show();
        }

        private void HideModal()
        {
            modalRef.Hide();
        }

        public async Task AddTodoItem()
        {
            var todoItemForCreation = new TodoItemForCreationDto { Text = TodoItemTextInput };

            if (String.IsNullOrWhiteSpace(todoItemForCreation.Text))
            {
                PlaceHolderText = "MUST ENTER SOME TEXT";
                return;
            }

            HideModal();

            await TodoService.AddTodoAsync(todoItemForCreation);

            await OnTodoItemAdded.InvokeAsync(true);
        }
    }
}
