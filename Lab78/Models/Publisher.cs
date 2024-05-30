using System.ComponentModel.DataAnnotations;

namespace Lab78.Models;

public class Publisher
{
    [Key]
    public int? Id { get; set; }
    public string? publisher_name { get; set; }
}