using Microsoft.EntityFrameworkCore;
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
        public async Task<Todo> GetTodoAsync(string id) => await context.Todos.FindAsync(id);
        public IEnumerable<Todo> GetTodos() => context.Todos.OrderBy(todo => todo.Date);
        public IEnumerable<Todo> Search(string search, IEnumerable<Todo> todos) => todos.Where(todo => todo.Title.ToLower().Contains(search));
        public void Save(Todo todo)
        {
            context.Todos.Add(todo);
            context.SaveChanges();
        }
        public bool TodoExists(string id) => context.News.Any(e => e.Id == id);
        public async Task<bool> Update(string id, Todo todo)
        {
            context.Entry(todo).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }
        public void Delete(Todo todo)
        {
            context.Todos.Remove(todo);
            context.SaveChangesAsync();
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
