using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab78.Models;

public class Hero_power
{
    public int? Id { get; set; }
    public int? hero_id { get; set; } 
    public int? power_id { get; set; }
    [ForeignKey("hero_id")]
    public Superhero Superhero { get; set; } = null!;
}