using System.ComponentModel.DataAnnotations;

namespace Lab78.Models;

public class Colour
{
    [Key]
    public int? Id { get; set; }
    public string? colour { get; set; }
}