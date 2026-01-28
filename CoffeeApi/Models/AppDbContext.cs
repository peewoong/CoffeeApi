using Microsoft.EntityFrameworkCore;

namespace CoffeeApi.Models
{
    // DbContext를 상속받아야 DB 관리자 역할 가능
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // 만든 coffee 클래스를 DB 테이블로 등록
        // 이제 DB 안에 "Coffee'라는 이름의 테이블이 생김
        public DbSet<Coffee> Coffee { get; set; }
    }
}
