using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineageBlog.Shared.Entities.Abstract
{
    public abstract class EntityBase
    {
        //Verdiğimiz base değerlerin diğer sınıflarda değişikliğe (override) uğramasını isteyebileceğimiz için abstract

        public virtual int Id { get; set; }
        public virtual DateTime CretedDate { get; set; } = DateTime.Now; //Bu değerlerin override edilmesini istiyorsak virtual olmak zorunda
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual bool IsDeleted { get; set; } = false; // Bu makale ya da kullanıcı silindi mi?
        public virtual bool IsActive { get; set; } = true; //Bu makale ya da bu kullanıcı aktif mi?
        public virtual string CreatedByName { get; set; } = "Admin"; // Blogda kayıt ol kısmı olmayacağı için üye olmayan kullanıcı beğeni veya yorum atması için string
        public virtual string ModifiedByName { get; set; } = "Admin";
    }
}
