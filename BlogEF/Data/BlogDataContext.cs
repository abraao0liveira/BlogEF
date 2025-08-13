using BlogEF.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogEF.Data;

public class BlogDataContext : DbContext
{
    //sobrescrita de metodo
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost,1433;Database=blog_balta;User ID=sa;Password=C3rul3@nC@v3_150;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=true;");
    }
}
