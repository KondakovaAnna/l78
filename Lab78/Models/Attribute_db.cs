using System.ComponentModel.DataAnnotations;

namespace Lab78.Models;

public class Attribute_db
{
    [Key]
    public int? Id { get; set; }
    public string? attribute_name { get; set; }
}