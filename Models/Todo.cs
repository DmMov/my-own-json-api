using my_own_json_api.Models.UIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_own_json_api.Models
{
    public class Todo : TodoUI
    {
        public string Id { get; set; }
    }
}
