using System.ComponentModel.DataAnnotations;

namespace Lab78.Models;

public class Race
{
    [Key]
    public int? Id { get; set; }
    public string? race { get; set; }
}