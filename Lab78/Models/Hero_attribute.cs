using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab78.Models;

public class Hero_attribute
{
	public int? id { get; set; }
    public int? hero_id { get; set; } 
    public int? attribute_id { get; set; }
    public int? attribute_value { get; set; }
    [ForeignKey("hero_id")]
    public Superhero Superhero { get; set; } = null!;
}