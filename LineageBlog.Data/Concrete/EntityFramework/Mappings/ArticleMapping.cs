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
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd(); //Identy alanımız. Değerler eklendikçe bir bir artmasını sağlar.
            builder.Property(a => a.Title).HasMaxLength(100);
            builder.Property(a => a.Title).IsRequired(true); //Boş geçilemez (Makalenin başlığı olmalı)
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)"); //Maksimum değerde içerik yazılabilmesi için.
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.SeoAuthor).IsRequired();
            builder.Property(a => a.SeoAuthor).HasMaxLength(50);
            builder.Property(a => a.SeoDescription).HasMaxLength(150);
            builder.Property(a => a.SeoDescription).IsRequired();
            builder.Property(a => a.SeoTags).IsRequired();
            builder.Property(a => a.SeoTags).HasMaxLength(70);
            builder.Property(a => a.ViewsCount).IsRequired();
            builder.Property(a => a.ViewsCount).IsRequired();
            builder.Property(a => a.Thumbnail).IsRequired();
            builder.Property(a => a.Thumbnail).HasMaxLength(250);
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);
            /*
             * Aşağıda kurulan ilişki okunabilirlik açısından kolay olması adına aşağıdaki gibi sıralanmıştır:
             * Bir tane kategoriye ihtiyacımız var.
             * Bir kategorinin birden fazla makalesi olabilir.
             * HasForeignKey: ikincil anahtarı var mı? --> Makale tarafında bir foreignKey var. (CategoryId)
             */
            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId);
            builder.HasOne<User>(a => a.User).WithMany(u => u.Articles).HasForeignKey(a => a.UserId);
            builder.ToTable("Articles");

            builder.HasData(
                new Article 
                {
                    Id = 1,
                    CategoryId = 1,
                    Title= "C# 11.0 ve .NET 8 Yenilikleri",
                    Content = "Lorem Ipsum, basım ve dizgi endüstrisinin basit bir şekilde sahte metnidir. Lorem Ipsum, bilinmeyen bir matbaanın bir tip kadırga alıp onu bir tip numune kitabı yapmak için karıştırdığı 1500'lerden beri endüstrinin standart sahte metni olmuştur. Sadece beş yüz yıl hayatta kalmakla kalmadı, aynı zamanda esasen değişmeden elektronik dizgiye sıçradı. 1960'larda Lorem Ipsum pasajları içeren Letraset yapraklarının yayınlanmasıyla ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımlarıyla popüler oldu.",
                    Thumbnail = "Default.jpg",
                    SeoDescription = "C# 11.0 ve .NET 8 Yenilikleri",
                    SeoTags = "C#, C# 11, .NET8, .NET Framework, .NET Core",
                    SeoAuthor = "Burhan Soy",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C# 11.0 ve .NET 8 Yenilikleri",
                    UserId = 1,
                    ViewsCount= 100,
                    CommentCount= 12
                },

                new Article
                {
                    Id = 2,
                    CategoryId = 2,
                    Title = "C++ 11.0 ve 19.0 Yenilikleri",
                    Content = "Bir sayfanın düzenine bakıldığında okunabilir içeriğin okuyucunun dikkatini dağıtacağı uzun zamandır bilinen bir gerçektir. Lorem Ipsum'u kullanmanın amacı, 'İçerik burada, içerik burada' seçeneğinin aksine, aşağı yukarı normal bir harf dağılımına sahip olması ve okunabilir bir İngilizce gibi görünmesidir. Birçok masaüstü yayıncılık paketi ve web sayfası düzenleyicisi artık varsayılan model metni olarak Lorem Ipsum'u kullanıyor ve 'lorem ipsum' için yapılan bir arama, henüz emekleme aşamasında olan birçok web sitesini ortaya çıkaracaktır. Yıllar içinde, bazen kazara, bazen kasıtlı olarak (mizah zerresi vb.) çeşitli versiyonlar geliştirilmiştir.",
                    Thumbnail = "Default.jpg",
                    SeoDescription = "C++ 11.0 ve 19.0 Yenilikleri",
                    SeoTags = "C++ 11.0 ve 19.0 Yenilikleri",
                    SeoAuthor = "Burhan Soy",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C++ 11.0 ve 19.0 Yenilikleri",
                    UserId = 1,
                    ViewsCount = 200,
                    CommentCount = 23
                },

                new Article
                {
                    Id = 3,
                    CategoryId = 3,
                    Title = "JavaScript ES2022 ve ES2023 Yenilikleri",
                    Content = "Popüler inanışın aksine, Lorem Ipsum rastgele bir metin değildir. Kökleri MÖ 45 yılına ait bir klasik Latin edebiyatına dayanmaktadır ve bu da onu 2000 yıldan daha eski yapmaktadır. Virginia'daki Hampden-Sydney College'da Latince profesörü olan Richard McClintock, bir Lorem Ipsum pasajında ​​geçen ve anlaşılması en güç Latince sözcüklerden biri olan consectetur'a baktı ve kelimenin klasik edebiyattaki örneklerini incelerken kesin kaynağı keşfetti. Lorem Ipsum, Cicero'nun MÖ 45'te yazdığı \"de Finibus Bonorum et Malorum\" (İyinin ve Kötünün Aşırılıkları) kitabının 1.10.32 ve 1.10.33 bölümlerinden gelmektedir. Bu kitap, Rönesans döneminde çok popüler olan etik teorisi üzerine bir incelemedir. Lorem Ipsum'un ilk satırı, \"Lorem ipsum dolor sit amet..\", bölüm 1.10.32'deki bir satırdan gelir.",
                    Thumbnail = "Default.jpg",
                    SeoDescription = "JavaScript ES2022 ve ES2023 Yenilikleri",
                    SeoTags = "JavaScript ES2022 ve ES2023 Yenilikleri",
                    SeoAuthor = "Burhan Soy",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "JavaScript ES2022 ve ES2023 Yenilikleri",
                    UserId = 1,
                    ViewsCount = 250,
                    CommentCount = 11
                }
            );
        }
    }
}
