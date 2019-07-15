using my_own_json_api.Models;
using my_own_json_api.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace my_own_json_api.Services
{
    public class TodosService
    {
        private readonly JSONContext context;
        public TodosService(JSONContext context)
        {
            this.context = context;
        }
        public Todo GetTodo(string id) => context.Todos.SingleOrDefault(todo => todo.Id == id);
        public IEnumerable<Todo> GetTodos() => context.Todos;
        public IEnumerable<Todo> Search(string searched) => GetTodos().Where(todo => todo.Title.ToLower().Contains(searched.ToLower()));
        public void Save(Todo todo)
        {
            context.Todos.Add(todo);
            context.SaveChanges();
        }
        public void Update(Todo todo)
        {
            context.Todos.Update(todo);
            context.SaveChanges();
        }
        public void Delete(Todo todo)
        {
            context.Todos.Remove(todo);
            context.SaveChanges();
        }
        public Todo Init(string title) => new Todo
        {
            Id = Guid.NewGuid().ToString(),
            Title = title,
            Date = DateTime.Now.ToString("dd-MM-yyyy, hh:mm:ss"),
            Completed = false
        };
    }
}
