using BlogEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogEF.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Tabela
            builder.ToTable("category");

            //Chave primaria
            builder.HasKey(c => c.Id);
            //Identity
            builder.Property(c => c.Id) //indica as propriedades 
                .ValueGeneratedOnAdd() //indica que o valor é gerado automaticamente
                .UseIdentityColumn(); //identity(1,1)

            //Propriedades
            builder.Property(c => c.Name)
                .IsRequired() //indica que é obrigatorio
                .HasColumnName("name") //indica o nome da coluna
                .HasColumnType("nvarchar") //indica o tipo da coluna
                .HasMaxLength(80); //indica o tamanho maximo
            builder.Property(c => c.Slug)
                .IsRequired() //indica que é obrigatorio
                .HasColumnName("slug") //indica o nome da coluna
                .HasColumnType("nvarchar") //indica o tipo da coluna
                .HasMaxLength(80); //indica o tamanho maximo

            //Indices
            builder.HasIndex(s => s.Slug, "ix_category_slug") //cria um indice para a coluna slug
                .IsUnique(); //indica que o indice é unico

        }
    }
}
