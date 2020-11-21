using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Api.Entities;
using TodoApp.Api.Models;
using TodoApp.Api.Services;
using TodoApp.Common.Models;


namespace TodoApp.Api.Controllers
{
    [Route("api/TodoItems")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoAppRepository _repo;
        private readonly IMapper _mapper;

        public TodoItemsController(ITodoAppRepository repo, IMapper mapper)
        {
            _repo = repo ??
                throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetTodoItems()
        {
            var todoItemEntities = await _repo.GetTodoItemsAsync();
            if (todoItemEntities.Count() ==  0)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<TodoItemDto>>(todoItemEntities));
        }
        
        [HttpGet]
        [Route("{todoItemId}", Name = "GetTodoItem")]
        public async Task<ActionResult<TodoItemDto>> GetTodoItem([FromRoute]int todoItemId)
        {
            var todoItemEntity = await _repo.GetTodoItemAsync(todoItemId);
            
            if (todoItemEntity == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<TodoItemDto>(todoItemEntity));
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> CreateTodoItem([FromBody]TodoItemForCreationDto todoItemForCreation)
        {
            var todoItemEntity = _mapper.Map<TodoItem>(todoItemForCreation);

            _repo.AddTodoItem(todoItemEntity);
            
            await _repo.SaveChangesAsync();

            var todoItemDto = _mapper.Map<TodoItemDto>(todoItemEntity);

            return CreatedAtRoute("GetTodoItem", new { todoItemId = todoItemEntity.Id }, todoItemDto);
        }

        [HttpPut("{todoItemId}")]
        public async Task<ActionResult> UpdateTodoItem([FromRoute]int todoItemId, 
            [FromBody]TodoItemForUpdateDto todoItemForUpdate)
        {
            var todoItemEntity = await _repo.GetTodoItemAsync(todoItemId);
            
            if (todoItemEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(todoItemForUpdate, todoItemEntity);

            await _repo.SaveChangesAsync();

            return Ok(_mapper.Map<TodoItemDto>(todoItemEntity));
        }

        [HttpDelete("{todoItemId}")]
        public async Task<ActionResult> DeleteTodoItem([FromRoute]int todoItemId)
        {
            var todoItemForDeletion = await _repo.GetTodoItemAsync(todoItemId);
           
            if (todoItemForDeletion == null)
            {
                return NotFound();
            }

            _repo.RemoveTodoItem(todoItemForDeletion);

            await _repo.SaveChangesAsync();

            return NoContent();
        }
    }
}
