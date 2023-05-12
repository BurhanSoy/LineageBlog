using LineageBlog.Data.Abstract;
using LineageBlog.Data.Concrete.EntityFramework.Context;
using LineageBlog.Data.Concrete.EntityFramework.Repositories;
using LineageBlog.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineageBlog.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LineageBlogContext _context;
        private EfArticleRepository _articleRepository;
        private EfCategoryRepository _categoryRepository;
        private EfCommentRepository _commentRepository;
        private EfRoleRepository _roleRepository;
        private EfUserRepository _userRepository;

        public UnitOfWork(LineageBlogContext context)
        {
            _context= context;
        }

        /*Ctor içinde DbContext'i DI ile veriyoruz.
         *Sonrasında bu repositorylerin concrete(somut) hallerine (Örn: EfArticleRepository) ihtiyacımız var. 
         *Bunun sebebi ise biz bir interface'i new'leyemediğimiz için return etmemiz mümkün değil. (Abstract(soyut) olan interfaceleri return etmemiz gerekiyor.)
         */
        public IArticleRepository Articles => _articleRepository ?? new EfArticleRepository(_context);

        public ICategoryRepository Categorys => _categoryRepository ?? new EfCategoryRepository(_context);

        public ICommentRepository Comments => _commentRepository ?? new EfCommentRepository(_context);

        public IRoleRepository Roles => _roleRepository ?? new EfRoleRepository(_context);

        public IUserRepository Users => _userRepository ?? new EfUserRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
