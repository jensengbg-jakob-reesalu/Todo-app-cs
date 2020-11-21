using Bunit;
using Bunit.TestDoubles;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using TodoApp.App;
using TodoApp.App.Components;
using TodoApp.Common.Models;
using Xunit;

namespace TodoApp.Tests.bUnit
{
    public class PopupShould : TestContext 
    {
        private readonly Mock<ITodoItemService> _mockService = new Mock<ITodoItemService>();

        public PopupShould()
        {
            Services.AddMockJSRuntime(); // Needed?
            Services.AddSingleton(_mockService.Object);

            //// Extension method adding services for Blazorise to work (from the internet)
            Services.AddBlazoriseServices();
        }

        [Fact]
        public async void CallAddTodoAsyncInTodoServiceWhenAddItem()
        {
            // Arrange
            // see constructor
            _mockService.Setup(x => x.AddTodoAsync(It.IsAny<TodoItemForCreationDto>()));

            var cut = RenderComponent<Popup>(("TodoItemTextInput", "Hello world"));

            // Act
            await cut.Instance.AddTodoItem();

            // Assert
            _mockService.Verify(x => x.AddTodoAsync(It.IsAny<TodoItemForCreationDto>()), Times.Once);
        }  
        
        [Fact]
        public async void NotCallAddTodoAsyncInTodoServiceWhenAddItemTakesNullOrEmptyInput()
        {
            // Arrange
            // see constructor
            _mockService.Setup(x => x.AddTodoAsync(It.IsAny<TodoItemForCreationDto>()));
            
            var cut = RenderComponent<Popup>(("TodoItemTextInput", null));

            // Act
            await cut.Instance.AddTodoItem();
            
            cut = RenderComponent<Popup>(("TodoItemTextInput", ""));
            await cut.Instance.AddTodoItem();

            // Assert
            _mockService.Verify(x => x.AddTodoAsync(It.IsAny<TodoItemForCreationDto>()), Times.Never);
        }

    }
}
