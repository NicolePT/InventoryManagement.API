using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.API.Models;

public class Item
{
    public int Id { get; set; }
    [Required]
    public string Code { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public int Quantity { get; set; }
}