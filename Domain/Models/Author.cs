using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Author
{
    public int Id {get; set; }

    [Required]
    [MaxLength(100)]
    public string FullName { get; set; } = null!;

    [MaxLength(100)]
    public string Country { get; set; } = null!;
    
    public int BirthYear { get; set; }
}