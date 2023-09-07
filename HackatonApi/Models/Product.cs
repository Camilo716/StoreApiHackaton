using System.ComponentModel.DataAnnotations;

namespace HackatonApi.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    public string IUP_code { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    public DateTime EntryDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string? ReturnReason { get; set; }

    [Required]
    public double Volume_cm3 { get; set; }
    public string Zone { get; set; }
    public string? state { get; set; }
}