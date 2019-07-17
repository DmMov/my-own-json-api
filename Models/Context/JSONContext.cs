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
        public DbSet<BitOfNews> News { get; set; }
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
            builder.Entity<BitOfNews>().HasData(
                new BitOfNews[]
                {
                    new BitOfNews {
                        Id = Guid.NewGuid().ToString(),
                        Title = "commodo enim lorem, at congue leo volutpat quis",
                        Date = DateTime.Now.ToString("dd-MM-yyyy, hh:mm:ss"),
                        ImageUrl = "http://hdwpro.com/wp-content/uploads/2019/01/Beautiful-Awesome-Wallpaper.jpg",
                        Body = "ipsum dolor sit amet, consectetur adipiscing elit. Sed ornare at nisi nec fermentum. Mauris commodo enim lorem, at congue leo volutpat quis. Fusce mollis justo dolor, sed malesuada ligula vehicula sit amet. Cras metus tortor, pharetra mollis nulla a, viverra vestibulum turpis. Quisque ultricies efficitur risus, sit amet laoreet nulla. Fusce auctor sapien in enim consectetur, vel feugiat ipsum varius. Sed non vestibulum risus."
                    },
                    new BitOfNews {
                        Id = Guid.NewGuid().ToString(),
                        Title = "vitae bibendum ipsum augue et risus",
                        Date = DateTime.Now.ToString("dd-MM-yyyy, hh:mm:ss"),
                        ImageUrl = "http://www.photobackgroundhd.com/wp-content/uploads/2018/08/Full-HD-Nature-Images.jpg",
                        Body = "Donec mattis, est eget interdum eleifend, ligula lectus molestie velit, vitae bibendum ipsum augue et risus. Aliquam at erat a massa molestie accumsan id id sapien. Maecenas sagittis leo ac consequat gravida. Donec mattis nunc eget fringilla luctus. Fusce et sem tincidunt, tempor sem nec, pretium eros. Aenean quis finibus enim. Phasellus varius sem nulla, non dictum nisi maximus sed. Praesent porta velit vitae neque imperdiet, at malesuada risus accumsan."
                    },
                    new BitOfNews {
                        Id = Guid.NewGuid().ToString(),
                        Title = "aenean id dictum arcu, at convallis lectus",
                        Date = DateTime.Now.ToString("dd-MM-yyyy, hh:mm:ss"),
                        ImageUrl = "http://hdwpro.com/wp-content/uploads/2016/03/Cloudy-Weather-Full-HD-Wallpaper.jpg",
                        Body = "Sed et ligula non nisi cursus faucibus ut vitae sapien. Aenean id dictum arcu, at convallis lectus. Vestibulum faucibus luctus lectus, ut ultrices dolor sollicitudin nec. Vivamus quam diam, gravida non dui eu, rutrum semper odio. Praesent facilisis lobortis mi. Donec condimentum magna vitae mi pretium congue. Quisque ut fermentum orci, at volutpat nisl. Sed eget erat ac nisi sollicitudin ultrices. Praesent vel odio quam."
                    }
                }
            );
        }
    }
}
