using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_own_json_api.Models;
using my_own_json_api.Models.UIModels;
using my_own_json_api.Services;

namespace my_own_json_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodosService todosService;
        public TodosController(TodosService todosService)
        {
            this.todosService = todosService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Todo>> Get(int limit, string search)
        {
            IEnumerable<Todo> todos = todosService.GetTodos();

            if (todos.Count() == 0) 
                return NoContent();

            if (search != null && search != "")
                todos = todosService.Search(search, todos);

            if (limit > 0)
                todos = todos.TakeLast(limit);

            return Ok(new { todos });
        }
        [HttpPost]
        public ActionResult<Todo> Post(TodoUI todoUI)
        {
            if (todoUI.Title != null && todoUI.Title != "")
            {
                Todo todo = todosService.Init(todoUI.Title);
                todosService.Save(todo);
                return Ok(new { todo });
            }
            return BadRequest(new { message = "title is null or empty" });
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Todo>> PutAsync(string id, Todo todo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != todo.Id)
                return BadRequest();

            bool updateResult = await todosService.Update(id, todo);

            if (!updateResult)
                return NotFound();

            return Ok(new { todo });
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Todo>> Delete(string id)
        {
            if (id == null || id == "")
                return BadRequest(new { message = "id is empty or null" });

            Todo todo = await todosService.GetTodoAsync(id);

            if (todo == null)
                return NotFound();

            todosService.Delete(todo);

            return Ok(new { message = "success" });
        }
    }
}
