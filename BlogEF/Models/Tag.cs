using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEF.Models;

[Table("tag")]
public class Tag
{
    [Key]
    public int Id { get; set; }
    [Column("name")][MaxLength(80)] public required string Name { get; set; }
    [Column("slug")][MaxLength(80)] public required string Slug { get; set; }
}  
