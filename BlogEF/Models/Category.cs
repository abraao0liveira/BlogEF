using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEF.Models;

[Table("category")]
public class Category
{
    [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] //informa que a chave é gerada no banco 
    public int Id { get; set; }
    [Required][MaxLength(80)][Column("name", TypeName = "nvarchar")]
    public required string Name { get; set; }
    [Required][MaxLength(80)][Column("name", TypeName = "varchar")]
    public required string Slug { get; set; }
}
