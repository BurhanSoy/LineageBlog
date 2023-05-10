using LineageBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineageBlog.Entities.Concrete
{
    public class Article : EntityBase,IEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; } //Önizleme resmini string tutacağım.
        public DateTime Date { get; set; } // Kulanıcı makaleyi(post'u) oluştururken kendi girecek. Arka planda tutulan createdDate'ten farklı olacak.
        public int ViewsCount { get; set; } //Okunma sayısı
        public int CommentCount { get; set; } //Yorum sayısı
        public string SeoAuthor { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTags { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
