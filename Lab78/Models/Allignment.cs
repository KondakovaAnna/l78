using System.ComponentModel.DataAnnotations;

namespace Lab78.Models;

public class Alignment
{
    [Key]
    public int? Id { get; set; }
    public string? alignment { get; set; }
}