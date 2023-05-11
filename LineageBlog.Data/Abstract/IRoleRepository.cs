using LineageBlog.Entities.Concrete;
using LineageBlog.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineageBlog.Data.Abstract
{
    public interface IRoleRepository:IEntityRepository<Role>
    {
    }
}
