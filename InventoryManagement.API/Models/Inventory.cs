using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.API.Models;

public class Inventory
{
    public int Id { get; set; }
    [Required]
    public string Code { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string quantity { get; set; }
}