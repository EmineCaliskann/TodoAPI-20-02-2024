using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI_20_02_2024.Data;

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
            return _todoContext.TodoItems.OrderBy(x=>x.Done).ToList();
        }    
    }
}
