using System.ComponentModel.DataAnnotations;

namespace Lab78.Models;

public class Superpower
{
    [Key]
    public int? Id { get; set; }
    public string? power_name { get; set; }
}