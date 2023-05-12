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
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.HasIndex(u => u.Email).IsUnique(); //Bir email adresi ile bir defa kayıt olunabilir.
            builder.Property(u => u.UserName).IsRequired();
            builder.Property(u => u.UserName).HasMaxLength(20);
            builder.HasIndex(u => u.UserName).IsUnique();
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnType("VARBINARY(500)"); //500 değerini belirtmemize gerek yok (md5). İleriye dönük şifreleme yöntemi değişirse diye 500 olarak belirttim.
            builder.Property(u => u.Description).HasMaxLength(500); // zorunlu olmamakla birlikte kullanıcı kendisine göre bir açıklama değeri verebilir. Çünkü anonim olarak paylaşım yapabilir.                                                                   
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.FirstName).HasMaxLength(30);
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(30);
            builder.Property(u => u.Picture).IsRequired();
            builder.Property(u => u.Picture).HasMaxLength(250);
            builder.HasOne(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);
            builder.Property(u => u.CreatedByName).IsRequired();
            builder.Property(u => u.CreatedByName).HasMaxLength(50);
            builder.Property(u => u.ModifiedByName).IsRequired();
            builder.Property(u => u.ModifiedByName).HasMaxLength(50);
            builder.Property(u => u.CreatedDate).IsRequired();
            builder.Property(u => u.ModifiedDate).IsRequired();
            builder.Property(u => u.IsActive).IsRequired();
            builder.Property(u => u.IsDeleted).IsRequired();
            builder.Property(u => u.Note).HasMaxLength(500);
            /*
             * DatabaseFirst yaklaşımında bir proje geliştirecek olursak;
             * Veritabanında belki tablonun adı farklı olabilir (Örn: Email)
             * builder.Property(u => u.Email).HasColumnType("USER_EMAİL");
             * Üstteki şekilde Email kolonu adını değiştirerek veritabanında map etmiş oluyorum.
             */
            builder.ToTable("Users");
        }
    }
}
