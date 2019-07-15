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
        public ActionResult<IEnumerable<Todo>> Get()
        {
            IEnumerable<Todo> todos = todosService.GetTodos();
            if (todos.Count() == 0) 
                return NoContent();
            else
                return Ok(new { todos });
        }
        [HttpGet("search/{searched}")]
        public ActionResult<IEnumerable<Todo>> Search(string searched)
        {
            IEnumerable<Todo> todos = todosService.Search(searched);
            if (todos.Count() == 0)
                return NoContent();
            else
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
        public ActionResult<Todo> Put(string id, Todo todo)
        {
            if (todo != null && todo.Id == id)
            {
                todosService.Update(todo);
                return Ok(new { todo });
            }

            return BadRequest(new { message = "element haven't been found" });
        }
        [HttpDelete("{id}")]
        public ActionResult<object> Delete(string id)
        {
            Todo todo = todosService.GetTodo(id);
            if (todo != null)
            {
                todosService.Delete(todo);
                return Ok(new { message = "success" });
            }
            return BadRequest(new { message = "element haven't been found" });
        }
    }
}
