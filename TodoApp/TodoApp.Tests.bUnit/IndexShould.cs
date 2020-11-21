using Bunit;
using Bunit.TestDoubles;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Net.Http;
using System.Threading.Tasks;
using TodoApp.App;
using TodoApp.App.Pages;
using Xunit;

namespace TodoApp.Tests.bUnit
{
    public class IndexShould : TestContext
    {
        private readonly Mock<ITodoItemService> _mockService = new Mock<ITodoItemService>();
        
        public IndexShould()
        {
            Services.AddMockJSRuntime(); // Needed?
            Services.AddSingleton(_mockService.Object);

            //// Extension method adding services for Blazorise to work (from the internet)
            Services.AddBlazoriseServices();
        }

        [Fact]
        public void CallGetTodosAsyncInTodoServiceOnPageLoad()
        {
            // Arrange
            // see constructor

            // Act
            RenderComponent<Index>();

            // Assert
            _mockService.Verify(x => x.GetTodosAsync(), Times.Once);
        }

        [Fact]
        public async void CallDeleteTodoAsyncInTodoServiceWhenRemoveTodoItem()
        {
            // Arrange
            // see constructor
            
            _mockService.Setup(x => x.DeleteTodoAsync(1)).Returns(Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.NoContent)));
            
            var cut = RenderComponent<Index>();
            
            // Act
            await cut.Instance.RemoveTodoItem(1);

            // Assert
            _mockService.Verify(x => x.DeleteTodoAsync(It.IsAny<int>()), Times.Once);
        }

        //[Fact]
        //public void CallRemoveTodoItemOnButtonClick() 
        //{
        //    // Arrange
        //    // see constructor
        //    var dtoList = new List<TodoItemDto> { new TodoItemDto { Id = 1, Text = "Cleaning", IsDone = false } };
        //    _mockService.Setup(x => x.GetTodosAsync()).Returns(Task.FromResult(dtoList));
        //    _mockService.Setup(x => x.DeleteTodoAsync(1)).Returns(Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.NoContent)));

        //    var cut = RenderComponent<Index>();

        //    // Act
        //    cut.SaveSnapshot();

        //    cut.Find(".remove-btn").Click();

        //    // Assert
        //    var diffs = cut.GetChangesSinceSnapshot();
        //    diffs.ShouldHaveSingleChange()
        //        .ShouldBeRemoval("<div class=\"todo - item\"> <p> Cleaning </p> < button id = " +
        //        "\"0HM4AUJNTH9M6\" type = \"button\" class=\"btn remove-btn\" style =\"\" " +
        //        "blazor:onclick=\"1\" blazor:elementReference=\"62de9a76-ea34-4d7b-96ee-1e5b6f4057f1\" > X </button>");

        //    //.ShouldBeRemoval("<div class=\"todo - item\"> <p> Cleaning </p> < button id = \"0HM4AUJNTH9M6\" type = \"button\" class=\"btn remove-btn\" style =\"\" blazor:onclick=\"1\" blazor:elementReference=\"62de9a76-ea34-4d7b-96ee-1e5b6f4057f1\" > X </button>");
        //}

        //[Fact]
        //public async void ReturnNoContentWhenRemoveTodoItem()
        //{
        //    // Arrange
        //    // see constructor

        //    _mockService.Setup(x => x.DeleteTodoAsync(1)).Returns(Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.NoContent))); ;

        //    var cut = RenderComponent<Index>();

        //    // Act
        //    await cut.Instance.RemoveTodoItem(1);

        //    // Assert
        //    //??????????????????????????????????
        //}

        //[Fact]
        //public async void RemoveTodoItemDivWhenRemoveTodoItem()
        //{
        //    // Arrange
        //    // see constructor

        //    var dtoList = new List<TodoItemDto> {
        //            new TodoItemDto { Id = 1, Text = "Cleaning", IsDone = false },
        //            new TodoItemDto { Id = 2, Text = "Cooking", IsDone = false },
        //            new TodoItemDto { Id = 3, Text = "Shopping", IsDone = false }
        //        };
        //    _mockService.Setup(x => x.GetTodosAsync()).Returns(Task.FromResult(dtoList));
        //    _mockService.Setup(x => x.DeleteTodoAsync(1)).Returns(Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.NoContent))); ;




        //    var cut = RenderComponent<Index>(
        //        /*("TodoItems", new List<TodoItemDto>())*/);
        //    var todoItemDivs = cut.FindAll(".todo-item");
           

        //    // Act
        //    await cut.Instance.RemoveTodoItem(1);

        //    // Assert
        //    //??????????????????????????????????
        //}

    }
}
