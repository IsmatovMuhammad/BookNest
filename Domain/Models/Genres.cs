using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Genres
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;
}