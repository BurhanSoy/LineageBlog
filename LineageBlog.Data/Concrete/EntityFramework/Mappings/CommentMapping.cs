using LineageBlog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineageBlog.Data.Concrete.EntityFramework.Mappings
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Text).IsRequired();
            builder.Property(c => c.Text).HasMaxLength(1000);
            builder.HasOne<Article>(c => c.Article).WithMany(a => a.Comments).HasForeignKey(c => c.ArticleId);
            builder.Property(c => c.CreatedByName).IsRequired();
            builder.Property(c => c.CreatedByName).HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired();
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.Note).HasMaxLength(500);
            builder.ToTable("Comments");

            builder.HasData(
                new Comment
                {
                    Id= 1,
                    ArticleId = 1,
                    Text = "Lorem Ipsum pasajlarının pek çok varyasyonu mevcuttur, ancak bunların çoğu, biraz olsun inandırıcı görünmeyen mizah ya da rastgele sözcüklerle bir şekilde değişikliğe uğramıştır. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metnin ortasında utandırıcı bir şey gizlenmediğinden emin olmalısınız. İnternetteki tüm Lorem Ipsum üreteçleri, önceden tanımlanmış parçaları gerektiği gibi tekrar etme eğilimindedir, bu da bunu İnternet'teki ilk gerçek oluşturucu yapar. Makul görünen Lorem Ipsum oluşturmak için bir avuç model cümle yapısıyla birleştirilmiş 200'den fazla Latince kelimeden oluşan bir sözlük kullanır. Oluşturulan Lorem Ipsum bu nedenle her zaman tekrardan, mizahtan veya karakteristik olmayan kelimelerden vs. muaftır.",
                    IsActive= true,
                    IsDeleted= false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C# Makale Yorumu"
                },

                new Comment
                {
                    Id = 2,
                    ArticleId = 2,
                    Text = "Lorem Ipsum pasajlarının pek çok varyasyonu mevcuttur, ancak bunların çoğu, biraz olsun inandırıcı görünmeyen mizah ya da rastgele sözcüklerle bir şekilde değişikliğe uğramıştır. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metnin ortasında utandırıcı bir şey gizlenmediğinden emin olmalısınız. İnternetteki tüm Lorem Ipsum üreteçleri, önceden tanımlanmış parçaları gerektiği gibi tekrar etme eğilimindedir, bu da bunu İnternet'teki ilk gerçek oluşturucu yapar. Makul görünen Lorem Ipsum oluşturmak için bir avuç model cümle yapısıyla birleştirilmiş 200'den fazla Latince kelimeden oluşan bir sözlük kullanır. Oluşturulan Lorem Ipsum bu nedenle her zaman tekrardan, mizahtan veya karakteristik olmayan kelimelerden vs. muaftır.",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C++ Makale Yorumu"
                },

                new Comment
                {
                    Id = 3,
                    ArticleId = 3,
                    Text = "Lorem Ipsum pasajlarının pek çok varyasyonu mevcuttur, ancak bunların çoğu, biraz olsun inandırıcı görünmeyen mizah ya da rastgele sözcüklerle bir şekilde değişikliğe uğramıştır. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metnin ortasında utandırıcı bir şey gizlenmediğinden emin olmalısınız. İnternetteki tüm Lorem Ipsum üreteçleri, önceden tanımlanmış parçaları gerektiği gibi tekrar etme eğilimindedir, bu da bunu İnternet'teki ilk gerçek oluşturucu yapar. Makul görünen Lorem Ipsum oluşturmak için bir avuç model cümle yapısıyla birleştirilmiş 200'den fazla Latince kelimeden oluşan bir sözlük kullanır. Oluşturulan Lorem Ipsum bu nedenle her zaman tekrardan, mizahtan veya karakteristik olmayan kelimelerden vs. muaftır.",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "JavaScript Makale Yorumu"
                }
            );
        }
    }
}
