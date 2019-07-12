using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_own_json_api.Models
{
    public class Todo
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
