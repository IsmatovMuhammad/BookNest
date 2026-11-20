using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Models;

public class Book 
{
    public int Id { get; set;}

    [MaxLength(100)]
    public string Title {get; set;}
    public int PublishedYear { get; set; }
    public int TotalCopies { get; set; }
}
