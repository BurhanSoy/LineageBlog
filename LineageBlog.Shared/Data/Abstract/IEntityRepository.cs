using LineageBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LineageBlog.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        /*
         * Tüm entity'ler için DAL class'larında kullanılabilecek metodları oluşturdum.
         * Generic bir yapı oluşturduğumuz için abstract class ya da interface gönderilmesini istemediğimiz için (where T:class) filtreleme yapıyoruz.
         * Veritabanı nesnesi olmasını istediğimiz için IEntity olmasını istiyoruz.
         */
        /*
         * Expression<Func<T,bool>> predicate --> Id'si 15 ve 1 olan makaleyi getirmek istiyoruz.
            var kullanici = repository.GetAsync(k=>k.Id==15)
            var kullanici = repository.GetAsync(k=>k.Id==1)
         * Adı "Burhan" olan kullanıcıyı getirmek istiyoruz.
            var kullanici = repository.GetAsync(k=>k.FirstName=="Burhan")
         
           !!! Bizim vereceğimiz lambda expression'lar filtre, yani predicate'dir. 
         */
        Task<T> GetAsync(Expression<Func<T,bool>> predicate,params Expression<Func<T, object>>[] includeProperties);
        /*
         * Birden fazla entity istersek bu listeye ihtiyaç duyarız. (User,Category vs.)
         * Id'si 1 olan makaleye ait tüm yorumları getirmek istiyoruz. (repository.GetAllAsync(y => y.ArticleId==1))
         * c# kategorisine ait tüm makaleleri getirmek istiyoruz. (repository.GetAllAsync(m => m.CategoryName=="C#", m=> m.Category))
         */
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate=null,
            params Expression<Func<T, object>>[] includeProperties);
        /*
         * Kategori eklemek için --> _categoryRepository.AddAsync(Category category);
         * Kullanıcı görüntülemek için --> _userRepository.UpdateAsync(User user);
         * Yorum silmek için --> _commentRepository.DeleteAsync(Comment comment);
         */
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        /*
         * Burhan isminde bir kullanıcı var mı? --> var result = _userRepository.AnyAsync(u=>u.FirstName=="Burhan");
         * işlemlerin sonunda true ya da false dönecek.
         * var count = _articleRepository.CountAsync(); --> Tüm makalelerin sayısını dönecek.
         */
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    }
}
