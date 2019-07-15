using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_own_json_api.Models.Context
{
    public class JSONContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public JSONContext(DbContextOptions<JSONContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Todo>().HasData(
                new Todo[]
                {
                    new Todo {
                        Id = Guid.NewGuid().ToString(),
                        Title = "lorem ipsum dolor sit amet",
                        Date = DateTime.Now.ToString("dd-MM-yyyy, hh:mm:ss"),
                        Completed = false
                    },
                    new Todo {
                        Id = Guid.NewGuid().ToString(),
                        Title = "dolor sit amet consectetur adipisicing",
                        Date = DateTime.Now.ToString("dd-MM-yyyy, hh:mm:ss"),
                        Completed = true
                    },
                    new Todo {
                        Id = Guid.NewGuid().ToString(),
                        Title = "iusto modi reiciendis voluptates corrupti minima saepe dolorum",
                        Date = DateTime.Now.ToString("dd-MM-yyyy, hh:mm:ss"),
                        Completed = false
                    }
                }
            );
        }
    }
}
