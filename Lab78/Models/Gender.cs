using System.ComponentModel.DataAnnotations;

namespace Lab78.Models;

public class Gender
{
    [Key]
    public int? Id { get; set; }
    public string? gender { get; set; }
}