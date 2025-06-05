using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEF.Models;

public class Post
{
    [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [ForeignKey("CategoryId")] //por padrao busca os padroes('Category' 'Id')
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    [ForeignKey("AuthorId")]
    public int AuthorId { get; set; }
    public User Author { get; set; }
    
    public required string Title { get; set; }
    public required string Summary { get; set; }
    public required string Body { get; set; }
    public required string Slug { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
}
