using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Api.Controllers;
using TodoApp.Api.Entities;
using TodoApp.Api.Profiles;
using TodoApp.Api.Services;
using TodoApp.Common.Models;
using Xunit;

namespace TodoApp.Tests
{
    public class TodoItemsControllerShould
    {
        private readonly Mock<ITodoAppRepository> _mockRepo;
        private readonly TodoItemsController _sut;

        public TodoItemsControllerShould()
        {
            _mockRepo = new Mock<ITodoAppRepository>();

            var myProfile = new TodoItemsProfile();
            var configuration = new MapperConfiguration(config => config.AddProfile(myProfile));
            var mapper = new Mapper(configuration);

            _sut = new TodoItemsController(_mockRepo.Object, mapper);
        }
        
        
        // GetTodoItems        
        [Fact]
        public async void CallGetTodoItemsAsyncInRepositoryWhenGetTodoItems()
        {
            // Arrange
            // See constructor

            // Act
            var actual = await _sut.GetTodoItems();

            // Assert
            _mockRepo.Verify(x => x.GetTodoItemsAsync(), Times.Once);
        }
        
        [Fact]
        public async void ReturnOkWhenGetTodoItems()
        {
            // Arrange
            // See constructor
            var todoItemsList = new List<TodoItem>
            {
                new TodoItem { Id = 1, Text = "Cleaning"},
                new TodoItem { Id = 2, Text = "Cooking"}
            };

            _mockRepo.Setup(x => x.GetTodoItemsAsync()).Returns(Task.FromResult<IEnumerable<TodoItem>>(todoItemsList));
            
            // Act
            var actual = await _sut.GetTodoItems();

            // Assert
            Assert.IsType<OkObjectResult>(actual.Result);
        }

        [Fact]
        public async void ReturnNotFoundWhenGetTodoItemsCountIsZero()
        {
            // Arrange
            var emptyTodoItemsList = new List<TodoItem>{};

            _mockRepo.Setup(x => x.GetTodoItemsAsync()).Returns(Task.FromResult<IEnumerable<TodoItem>>(emptyTodoItemsList));

            // Act
            var actual = await _sut.GetTodoItems();

            // Assert
            Assert.IsType<NotFoundResult>(actual.Result);
        }


        // GetTodoItem
        [Fact]
        public async void CallGetTodoItemAsyncInRepositoryWhenGetTodoItem()
        {
            // Arrange
            // See constructor

            // Act
            var actual = await _sut.GetTodoItem(1);

            // Assert
            _mockRepo.Verify(x => x.GetTodoItemAsync(1), Times.Once);
        }

        [Fact]
        public async void ReturnNotFoundResultForNonExistentTodoItemOnGetTodoItem()
        {
            // Arrange
            
            // Act
            var actual = await _sut.GetTodoItem(0);

            // Assert
            Assert.IsType<NotFoundResult>(actual.Result);
        }
        
        [Fact]
        public async void ReturnOkWhenGetTodoItem()
        {
            // Arrange
            var todoItem = new TodoItem { Id = 1, Text = "Cleaning" };
            
            _mockRepo.Setup(x => x.GetTodoItemAsync(todoItem.Id)).Returns(Task.FromResult(todoItem));

            // Act
            var actual = await _sut.GetTodoItem(todoItem.Id);

            // Assert
            Assert.IsType<OkObjectResult>(actual.Result);
        }


        // CreateTodoItem
        [Fact]
        public async void CallAddTodoItemAndSaveChangesAsyncInRepositoryWhenCreateTodoItem()
        {
            // Arrange
            // See constructor
            var todoItemForCreationDto = new TodoItemForCreationDto { Text = "Cleaning" };

            // Act
            await _sut.CreateTodoItem(todoItemForCreationDto);

            // Assert
            _mockRepo.Verify(x => x.AddTodoItem(It.IsAny<TodoItem>()), Times.Once);
            _mockRepo.Verify(x => x.SaveChangesAsync(), Times.Once);
        } 
        
        [Fact]
        public async void ReturnCreatedAtRouteWhenCreateTodoItem()
        {
            // Arrange
            // See constructor
            var todoItemForCreationDto = new TodoItemForCreationDto { Text = "Cleaning" };

            // Act
            var actual = await _sut.CreateTodoItem(todoItemForCreationDto);

            // Assert
            Assert.IsType<CreatedAtRouteResult>(actual.Result);
        }


        // UpdateTodoItem
        [Fact]
        public async void CallGetTodoItemAsyncAndSaveChangesAsyncInRepositoryWhenUpdateTodoItem()
        {
            // Arrange
            // See constructor
            var todoItemEntity = new TodoItem 
            { 
                Id = 1, 
                Text = "Cleaning", 
                IsDone = false 
            };

            var todoItemForUpdateDto = new TodoItemForUpdateDto { Text = "Cooking" };

            _mockRepo.Setup(x => x.GetTodoItemAsync(todoItemEntity.Id)).ReturnsAsync(todoItemEntity);

            // Act
            await _sut.UpdateTodoItem(1, todoItemForUpdateDto);

            // Assert
            _mockRepo.Verify(x => x.GetTodoItemAsync(todoItemEntity.Id), Times.Once);
            _mockRepo.Verify(x => x.SaveChangesAsync(), Times.Once());
        }  
        
        [Fact]
        public async void ReturnOkWhenUpdateTodoItem()
        {
            // Arrange
            // See constructor
            var todoItemEntity = new TodoItem 
            { 
                Id = 1, 
                Text = "Cleaning", 
                IsDone = false 
            };

            var todoItemForUpdateDto = new TodoItemForUpdateDto { Text = "Cooking" };

            _mockRepo.Setup(x => x.GetTodoItemAsync(todoItemEntity.Id)).ReturnsAsync(todoItemEntity);

            // Act
            var actual = await _sut.UpdateTodoItem(1, todoItemForUpdateDto);

            // Assert
            Assert.IsType<OkObjectResult>(actual);
        }


        // DeleteTodoItem
        [Fact]
        public async void CallRemoveTodoItemAndSaveChangesInRepositoryWhenDeleteTodoItem()
        {
            // Arrange
            // See constructor
            var todoItem = new TodoItem { Id = 1, Text = "Cleaning" };
            
            _mockRepo.Setup(x => x.GetTodoItemAsync(todoItem.Id)).Returns(Task.FromResult(todoItem));

            // Act
            var actual = await _sut.DeleteTodoItem(todoItem.Id);

            // Assert
            _mockRepo.Verify(x => x.RemoveTodoItem(It.IsAny<TodoItem>()), Times.Once);
            _mockRepo.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async void ReturnNoContentWhenDeleteTodoItem()
        {
            // Arrange
            // See constructor
            var todoItem = new TodoItem { Id = 1, Text = "Cleaning" };

            _mockRepo.Setup(x => x.GetTodoItemAsync(todoItem.Id)).Returns(Task.FromResult(todoItem));

            // Act
            var actual = await _sut.DeleteTodoItem(todoItem.Id);

            // Assert
            Assert.IsType<NoContentResult>(actual);
        }
    }
}
