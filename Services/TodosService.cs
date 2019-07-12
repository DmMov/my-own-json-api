using my_own_json_api.Models;
using my_own_json_api.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Todo> GetTodos() => context.Todos;
    }
}
