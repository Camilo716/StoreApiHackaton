using System.ComponentModel.DataAnnotations;

namespace HackatonApi.DTOs;

public class ProductCreationDTO
{
    [Required]
    public string IUP_code { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public double Volume_cm3 { get; set; }
    public string Zone { get; set; }
}