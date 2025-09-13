using BlogEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogEF.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            // Tabela
            builder.ToTable("post");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.LastUpdateDate)
                .IsRequired()
                .HasColumnName("LastUpdateDate")
                .HasColumnType("SMALLDATETIME")
                .HasMaxLength(60)
                .HasDefaultValueSql("GETDATE()");
            // .HasDefaultValue(DateTime.Now.ToUniversalTime());

            // Índices
            builder
                .HasIndex(x => x.Slug, "IX_post_slug")
                .IsUnique();

            // Relacionamentos
            builder
                .HasOne(x => x.Author)
                .WithMany(x => x.Posts)
                .HasConstraintName("FK_post_author")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Posts)
                .HasConstraintName("FK_post_category")
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamentos
            builder
                .HasMany(x => x.Tags)
                .WithMany(x => x.Posts)
                .UsingEntity<Dictionary<string, object>>(
                    "post_tag",
                    post => post
                        .HasOne<Tag>()
                        .WithMany()
                        .HasForeignKey("post_id")
                        .HasConstraintName("FK_post_role_post_id")
                        .OnDelete(DeleteBehavior.Cascade),
                    tag => tag
                        .HasOne<Post>()
                        .WithMany()
                        .HasForeignKey("tag_id")
                        .HasConstraintName("FK_post_tag_tag_id")
                        .OnDelete(DeleteBehavior.Cascade));
        }
    }
}
