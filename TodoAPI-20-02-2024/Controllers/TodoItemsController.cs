﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI_20_02_2024.Data;
using TodoAPI_20_02_2024.Dtos;

namespace TodoAPI_20_02_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _todoContext;

        public TodoItemsController(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetItems()
        {
            return _todoContext.TodoItems.OrderBy(x => x.Done).ToList();
        }

        [HttpGet("{id:int}")]
        public ActionResult<TodoItem> GetItem(int id)
        {
            var item = _todoContext.TodoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public ActionResult<TodoItem> PostItem(PostTodoItemDto dto)
        {
            if (ModelState.IsValid)
            {
                var newTodoItem = new TodoItem()

                {
                    Title = dto.Title,
                    Done = dto.Done,
                };
                _todoContext.Add(newTodoItem);
                _todoContext.SaveChanges();

                return CreatedAtAction("GetItem", new { id = newTodoItem.Id }, newTodoItem);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id:int}")]
        public IActionResult PutItem(int id, TodoItem item)
        {
            if ((id != item.Id))
                return BadRequest();



            if (!_todoContext.TodoItems.Any(x => x.Id == id))
                return NotFound();

            _todoContext.Update(item);
            _todoContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _todoContext.TodoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _todoContext.TodoItems.Remove(item);
            _todoContext.SaveChanges();
            return NoContent();
        }
    }
}


