using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LineageBlog.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "VARBINARY(500)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    SeoAuthor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SeoTags = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(5881), "C# Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(5882), "C#", "C# Blog Kategorisi" },
                    { 2, "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(5885), "C++ Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(5886), "C++", "C++ Blog Kategorisi" },
                    { 3, "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(5889), "JavaScript Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(5889), "JavaScript", "JavaScript Blog Kategorisi" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[] { 1, "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(8756), "Admin rolü, Tüm Haklara Sahiptir.", true, false, "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(8757), "Admin", "Admin Rolüdür." });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedByName", "ModifiedDate", "Note", "PasswordHash", "Picture", "RoleId", "UserName" },
                values: new object[] { 1, "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 307, DateTimeKind.Local).AddTicks(1701), "İlk Admin Kullanıcı", "burhansoy1@gmail.com", "Burhan", true, false, "Soy", "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 307, DateTimeKind.Local).AddTicks(1701), "Admin Kullanıcısı", new byte[] { 48, 49, 57, 50, 48, 50, 51, 97, 55, 98, 98, 100, 55, 51, 50, 53, 48, 53, 49, 54, 102, 48, 54, 57, 100, 102, 49, 56, 98, 53, 48, 48 }, "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU", 1, "burhansoy" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[] { 1, 1, 12, "Lorem Ipsum, basım ve dizgi endüstrisinin basit bir şekilde sahte metnidir. Lorem Ipsum, bilinmeyen bir matbaanın bir tip kadırga alıp onu bir tip numune kitabı yapmak için karıştırdığı 1500'lerden beri endüstrinin standart sahte metni olmuştur. Sadece beş yüz yıl hayatta kalmakla kalmadı, aynı zamanda esasen değişmeden elektronik dizgiye sıçradı. 1960'larda Lorem Ipsum pasajları içeren Letraset yapraklarının yayınlanmasıyla ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımlarıyla popüler oldu.", "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(4655), new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(4654), true, false, "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(4657), "C# 11.0 ve .NET 8 Yenilikleri", "Burhan Soy", "C# 11.0 ve .NET 8 Yenilikleri", "C#, C# 11, .NET8, .NET Framework, .NET Core", "Default.jpg", "C# 11.0 ve .NET 8 Yenilikleri", 1, 100 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[] { 2, 2, 23, "Bir sayfanın düzenine bakıldığında okunabilir içeriğin okuyucunun dikkatini dağıtacağı uzun zamandır bilinen bir gerçektir. Lorem Ipsum'u kullanmanın amacı, 'İçerik burada, içerik burada' seçeneğinin aksine, aşağı yukarı normal bir harf dağılımına sahip olması ve okunabilir bir İngilizce gibi görünmesidir. Birçok masaüstü yayıncılık paketi ve web sayfası düzenleyicisi artık varsayılan model metni olarak Lorem Ipsum'u kullanıyor ve 'lorem ipsum' için yapılan bir arama, henüz emekleme aşamasında olan birçok web sitesini ortaya çıkaracaktır. Yıllar içinde, bazen kazara, bazen kasıtlı olarak (mizah zerresi vb.) çeşitli versiyonlar geliştirilmiştir.", "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(4661), new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(4660), true, false, "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(4662), "C++ 11.0 ve 19.0 Yenilikleri", "Burhan Soy", "C++ 11.0 ve 19.0 Yenilikleri", "C++ 11.0 ve 19.0 Yenilikleri", "Default.jpg", "C++ 11.0 ve 19.0 Yenilikleri", 1, 200 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[] { 3, 3, 11, "Popüler inanışın aksine, Lorem Ipsum rastgele bir metin değildir. Kökleri MÖ 45 yılına ait bir klasik Latin edebiyatına dayanmaktadır ve bu da onu 2000 yıldan daha eski yapmaktadır. Virginia'daki Hampden-Sydney College'da Latince profesörü olan Richard McClintock, bir Lorem Ipsum pasajında ​​geçen ve anlaşılması en güç Latince sözcüklerden biri olan consectetur'a baktı ve kelimenin klasik edebiyattaki örneklerini incelerken kesin kaynağı keşfetti. Lorem Ipsum, Cicero'nun MÖ 45'te yazdığı \"de Finibus Bonorum et Malorum\" (İyinin ve Kötünün Aşırılıkları) kitabının 1.10.32 ve 1.10.33 bölümlerinden gelmektedir. Bu kitap, Rönesans döneminde çok popüler olan etik teorisi üzerine bir incelemedir. Lorem Ipsum'un ilk satırı, \"Lorem ipsum dolor sit amet..\", bölüm 1.10.32'deki bir satırdan gelir.", "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(4666), new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(4665), true, false, "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(4667), "JavaScript ES2022 ve ES2023 Yenilikleri", "Burhan Soy", "JavaScript ES2022 ve ES2023 Yenilikleri", "JavaScript ES2022 ve ES2023 Yenilikleri", "Default.jpg", "JavaScript ES2022 ve ES2023 Yenilikleri", 1, 250 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[] { 1, 1, "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(7712), true, false, "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(7713), "C# Makale Yorumu", "Lorem Ipsum pasajlarının pek çok varyasyonu mevcuttur, ancak bunların çoğu, biraz olsun inandırıcı görünmeyen mizah ya da rastgele sözcüklerle bir şekilde değişikliğe uğramıştır. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metnin ortasında utandırıcı bir şey gizlenmediğinden emin olmalısınız. İnternetteki tüm Lorem Ipsum üreteçleri, önceden tanımlanmış parçaları gerektiği gibi tekrar etme eğilimindedir, bu da bunu İnternet'teki ilk gerçek oluşturucu yapar. Makul görünen Lorem Ipsum oluşturmak için bir avuç model cümle yapısıyla birleştirilmiş 200'den fazla Latince kelimeden oluşan bir sözlük kullanır. Oluşturulan Lorem Ipsum bu nedenle her zaman tekrardan, mizahtan veya karakteristik olmayan kelimelerden vs. muaftır." });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[] { 2, 2, "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(7716), true, false, "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(7717), "C++ Makale Yorumu", "Lorem Ipsum pasajlarının pek çok varyasyonu mevcuttur, ancak bunların çoğu, biraz olsun inandırıcı görünmeyen mizah ya da rastgele sözcüklerle bir şekilde değişikliğe uğramıştır. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metnin ortasında utandırıcı bir şey gizlenmediğinden emin olmalısınız. İnternetteki tüm Lorem Ipsum üreteçleri, önceden tanımlanmış parçaları gerektiği gibi tekrar etme eğilimindedir, bu da bunu İnternet'teki ilk gerçek oluşturucu yapar. Makul görünen Lorem Ipsum oluşturmak için bir avuç model cümle yapısıyla birleştirilmiş 200'den fazla Latince kelimeden oluşan bir sözlük kullanır. Oluşturulan Lorem Ipsum bu nedenle her zaman tekrardan, mizahtan veya karakteristik olmayan kelimelerden vs. muaftır." });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[] { 3, 3, "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(7720), true, false, "InitialCreate", new DateTime(2023, 5, 23, 19, 16, 29, 306, DateTimeKind.Local).AddTicks(7720), "JavaScript Makale Yorumu", "Lorem Ipsum pasajlarının pek çok varyasyonu mevcuttur, ancak bunların çoğu, biraz olsun inandırıcı görünmeyen mizah ya da rastgele sözcüklerle bir şekilde değişikliğe uğramıştır. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metnin ortasında utandırıcı bir şey gizlenmediğinden emin olmalısınız. İnternetteki tüm Lorem Ipsum üreteçleri, önceden tanımlanmış parçaları gerektiği gibi tekrar etme eğilimindedir, bu da bunu İnternet'teki ilk gerçek oluşturucu yapar. Makul görünen Lorem Ipsum oluşturmak için bir avuç model cümle yapısıyla birleştirilmiş 200'den fazla Latince kelimeden oluşan bir sözlük kullanır. Oluşturulan Lorem Ipsum bu nedenle her zaman tekrardan, mizahtan veya karakteristik olmayan kelimelerden vs. muaftır." });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
