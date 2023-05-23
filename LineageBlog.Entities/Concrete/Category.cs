using LineageBlog.Shared.Entities.Abstract;
using LineageBlog.Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineageBlog.Entities.Concrete
{
    public class Category : EntityBase,IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Article> Articles { get; set; } //Bir kategori birden fazla makaleye(post'a) sahip olabilir.
    }
}
