using AutoMapper;
using TodoApp.Api.Entities;
using TodoApp.Api.Models;
using TodoApp.Common.Models;

namespace TodoApp.Api.Profiles
{
    public class TodoItemsProfile : Profile
    {
        public TodoItemsProfile()
        {
            CreateMap<TodoItem, TodoItemDto>();
            CreateMap<TodoItem, TodoItemDto>().ReverseMap();
            CreateMap<TodoItemForCreationDto, TodoItem>();
            CreateMap<TodoItemForUpdateDto, TodoItem>();
        }
    }
}
