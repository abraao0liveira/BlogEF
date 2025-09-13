using BlogEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogEF.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Tabela
            builder.ToTable("user");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("nvarchar")
                .HasMaxLength(80);

            builder.Property(x => x.Bio);
            builder.Property(x => x.Email);
            builder.Property(x => x.Image);
            builder.Property(x => x.PasswordHash);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName("slug")
                .HasColumnType("varchar")
                .HasMaxLength(80);

            // Índices
            builder
                .HasIndex(x => x.Slug, "IX_user_slug")
                .IsUnique();

            // Relacionamentos
            builder
                .HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "user_role",
                    role => role
                        .HasOne<Role>()
                        .WithMany()
                        .HasForeignKey("role_id")
                        .HasConstraintName("FK_user_role_role_id")
                        .OnDelete(DeleteBehavior.Cascade),
                    user => user
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey("user_id")
                        .HasConstraintName("FK_user_role_user_id")
                        .OnDelete(DeleteBehavior.Cascade));
        }
    }
}
