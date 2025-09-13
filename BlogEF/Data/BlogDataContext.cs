using BlogEF.Data.Mappings;
using BlogEF.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogEF.Data;

public class BlogDataContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Post> Posts { get; set; }
    // public DbSet<PostTag> PostTags { get; set; }
    // public DbSet<Role> Roles { get; set; }
    // public DbSet<Tag> Tags { get; set; }
    public DbSet<User> Users { get; set; }
    // public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=localhost,1433;Database=blog_balta;User ID = sa; Password=C3rul3 @nC@v3_150;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new CategoryMap());
        //modelBuilder.ApplyConfiguration(new UserMap());
        //modelBuilder.ApplyConfiguration(new PostMap());
    }
}
