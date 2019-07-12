using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_own_json_api.Models;
using my_own_json_api.Services;

namespace my_own_json_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodosService todoService;
        public TodosController(TodosService todoService)
        {
            this.todoService = todoService;
        }
        // GET: api/Todo
        [HttpGet]
        public ActionResult<IEnumerable<Todo>> Get()
        {
            IEnumerable<Todo> todos = todoService.GetTodos();
            if (todos.Count() == 0)
                return NoContent();
            else
                return Ok(new { todos });
        }

        // GET: api/Todo/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Todo
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
