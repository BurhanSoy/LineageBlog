using LineageBlog.Data.Abstract;
using LineageBlog.Entities.Concrete;
using LineageBlog.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LineageBlog.Data.Concrete
{
    public class ArticleRepository :EfEntityRepositoryBase<Article> ,IArticleRepository
    {
        public ArticleRepository(DbContext context):base(context)
        {

        }
    }
}
