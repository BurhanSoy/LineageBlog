using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineageBlog.Data.Abstract
{
    public interface IUnitOfWork:IDisposable
    {
        /*IDisposable (Tek kullanımlık; garbageCollector'a yardımcı olacak)
         *Peki UnitOfWork Design Pattern nedir?
         *1.UnitOfWork'ü kullanarak bütün projemiz içindeki tüm repositoy'leri tek bir yerden yönetebiliyoruz.
         *  Örn: servis katmanında yeni bir kullanıcı eklerken hem userRepository'e hem de roleRepository'e ihtiyacımız olsun,
         *     bizler bunu kullanabilmek için ya orada repository'lerimizi new'leyeceğiz ya da DI ile ctor'da veriyor olacağız.
         *     ancak UnitOfWork design'ını kullanırsak bu repositoryleri ayrı ayrı kullanmak yerine UnitOfWork sınıfı üzerinden bütün repository'lere erişiyor olacağız.
         *     Bu sebeple bir sürü sınıfı new'lemek yerine tek bir UnitOfWork sınıfını new'liyor olacağız.
         *
         *2.UnitOfWork design pattern bize transaction yapısı da sunuyor.
         *Peki Transaction nedir?
         *  Bizim veritabanına gönderdiğimiz verilerin doğrulanması ve yönetilmesidir.
         *  Örn: Bizler veritabanına yeni bir Article(makale) ekliyoruz.
         *     Ancak makaleyi eklemeden önce farklı tablolarda işlem yapmamız gerekebilir.
         *     Transaction yapısı sayesinde bu işlemleri tek tek gönderip SaveChanges ile veritabanına kaydetmek yerine bunların hepsinin bizim verdiğimiz yol üzerinden gitmesini sağlıyoruz.
         *     Örn: User tablosunda bir hata oluşursa ya da Categories tablosunda bir işlem yaparken bağlantımız kopar ve yine hata alırsak, Transaction yapısı sayesinde bunların hepsinin veritabanına kaydedilmeden önce yarıda kesilmesini sağlıyoruz.
         *     Yani SaveChanges işlemini hepsi içinbir kere yapıyoruz ve aynı anda veritabanına kaydolmuş oluyor.
         *     Verilerin veritabanına eksik olarak kaydedilmesinin önüne geçmiş oluyoruz.
         */
        IArticleRepository Articles { get; } //unitofwork.Articles
        ICategoryRepository Categorys { get; }
        ICommentRepository Comments { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; } //_unitOfWork.Users.AddAsync(); (kullanım)
        Task<int> SaveAsync(); //Etkilenen kayıt sayısını almak isteyebiliriz.
        /* Bu örnekte 2 ekleme işlemi yaptıktan sonra tek bir save ile kayıt almış oluyoruz.
         * _unitOfWork.Categories.AddAsync(category);
           _unitOfWork.Users.AddAsync(user);
           _unitOfWork.SaveAsync();
        */
    }
}
