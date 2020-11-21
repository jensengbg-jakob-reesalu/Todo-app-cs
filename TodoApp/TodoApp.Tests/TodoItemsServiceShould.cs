using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Api.Models;
using TodoApp.App;
using TodoApp.Common.Models;
using Xunit;

namespace TodoApp.Tests
{
    public class TodoItemsServiceShould
    {
        private readonly Mock<IHttpClientFactory> _mockClientFactory;
        private readonly Mock<HttpMessageHandler> _mockHandler;

        public TodoItemsServiceShould()
        {
            _mockClientFactory = new Mock<IHttpClientFactory>();
            _mockHandler = new Mock<HttpMessageHandler>();
        }

        [Fact]
        public async void SendGetRequestAndReturnTodoItemsWhenGetTodosAsync()
        {
            // Arrange
            _mockHandler.Protected()
                        .Setup<Task<HttpResponseMessage>>("SendAsync",
                            ItExpr.IsAny<HttpRequestMessage>(),
                            ItExpr.IsAny<CancellationToken>()
                            )
                        .ReturnsAsync(new HttpResponseMessage
                        {
                            Content = new StringContent(@"[
                            {
                                'id': 1,
                                'text': 'Learn programming',
                                'isDone': false
                            },
                            {
                                'id': 7,
                                'text': 'Shopping',
                                'isDone': false
                            }]")
                        });

            var client = new HttpClient(_mockHandler.Object);
            client.BaseAddress = new Uri("https://localhost:44376");

            _mockClientFactory.Setup(x => x.CreateClient("TodoAppClient")).Returns(client);

            var sut = new TodoItemService(_mockClientFactory.Object);
            
            // Act
            var result = await sut.GetTodosAsync();

            // Assert
            _mockHandler.Protected().Verify(
                "SendAsync", 
                Times.Exactly(1), 
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>());

            Assert.NotNull(result);
            Assert.IsType<List<TodoItemDto>>(result);
        }

        [Fact]
        public async void SendGetRequestAndReturnTodoItemWhenGetTodosByIdAsync()
        {
            // Arrange
            _mockHandler.Protected()
                        .Setup<Task<HttpResponseMessage>>("SendAsync",
                            ItExpr.IsAny<HttpRequestMessage>(),
                            ItExpr.IsAny<CancellationToken>())
                        .ReturnsAsync(new HttpResponseMessage
                        {
                            Content = new StringContent(@"
                            {
                                'id': 1,
                                'text': 'Learn programming',
                                'isDone': false
                            }")
                        });

            var client = new HttpClient(_mockHandler.Object);
            client.BaseAddress = new Uri("https://localhost:44376");

            _mockClientFactory.Setup(x => x.CreateClient("TodoAppClient")).Returns(client);

            var sut = new TodoItemService(_mockClientFactory.Object);
            
            // Act
            var result = await sut.GetTodosByIdAsync(It.IsAny<int>());

            // Assert
            _mockHandler.Protected().Verify(
               "SendAsync",
               Times.Exactly(1),
               ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
               ItExpr.IsAny<CancellationToken>());

            Assert.NotNull(result);
            Assert.IsType<TodoItemDto>(result);
        }

        [Fact]
        public async void SendPostRequestAndReturnOkWhenAddTodoAsync()
        {
            // Arrange
            _mockHandler.Protected()
                        .Setup<Task<HttpResponseMessage>>("SendAsync",
                            ItExpr.IsAny<HttpRequestMessage>(),
                            ItExpr.IsAny<CancellationToken>())
                        .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            var client = new HttpClient(_mockHandler.Object);
            client.BaseAddress = new Uri("https://localhost:44376");

            _mockClientFactory.Setup(x => x.CreateClient("TodoAppClient")).Returns(client);

            var sut = new TodoItemService(_mockClientFactory.Object);

            // Act
            var result = await sut.AddTodoAsync(It.IsAny<TodoItemForCreationDto>());

            // Assert
            _mockHandler.Protected().Verify(
              "SendAsync",
              Times.Exactly(1),
              ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post),
              ItExpr.IsAny<CancellationToken>());

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async void SendPutRequestAndReturnOkWhenUpdateTodoAsync()
        {
            // Arrange
            _mockHandler.Protected()
                        .Setup<Task<HttpResponseMessage>>("SendAsync",
                            ItExpr.IsAny<HttpRequestMessage>(),
                            ItExpr.IsAny<CancellationToken>())
                        .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            var client = new HttpClient(_mockHandler.Object);
            client.BaseAddress = new Uri("https://localhost:44376");

            _mockClientFactory.Setup(x => x.CreateClient("TodoAppClient")).Returns(client);

            var sut = new TodoItemService(_mockClientFactory.Object);

            // Act
            var result = await sut.UpdateTodoAsync(It.IsAny<int>(), It.IsAny<TodoItemForUpdateDto>());

            // Assert
            _mockHandler.Protected().Verify(
              "SendAsync",
              Times.Exactly(1),
              ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Put),
              ItExpr.IsAny<CancellationToken>());

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async void SendDeleteRequestAndReturnNoContentWhenDeleteTodoAsync()
        {
            // Arrange
            _mockHandler.Protected()
                        .Setup<Task<HttpResponseMessage>>("SendAsync",
                            ItExpr.IsAny<HttpRequestMessage>(),
                            ItExpr.IsAny<CancellationToken>())
                        .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            var client = new HttpClient(_mockHandler.Object);
            client.BaseAddress = new Uri("https://localhost:44376");

            _mockClientFactory.Setup(x => x.CreateClient("TodoAppClient")).Returns(client);

            var sut = new TodoItemService(_mockClientFactory.Object);

            // Act
            var result = await sut.DeleteTodoAsync(It.IsAny<int>());

            // Assert
            _mockHandler.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Delete),
                ItExpr.IsAny<CancellationToken>());

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void ReturnStringContentWhenGetStringContentFromObject()
        {
            // Arrange
            var sut = new TodoItemService(_mockClientFactory.Object);
            var objectForTest = new TodoItemForCreationDto { Text = "Testtext", IsDone = false };

            // Act
            var actual = sut.GetStringContentFromObject(objectForTest);

            // Assert
            Assert.IsType<StringContent>(actual);
        }
    }
}
