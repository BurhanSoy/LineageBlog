using LineageBlog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineageBlog.Data.Concrete.EntityFramework.Context
{
    public class LineageBlogContext:DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public LineageBlogContext(DbContextOptions<DbContext> options)
            : base(options)
        {

        }
    }
}
