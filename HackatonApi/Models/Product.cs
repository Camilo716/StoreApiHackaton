using System.ComponentModel.DataAnnotations;

namespace HackatonApi.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } 
}