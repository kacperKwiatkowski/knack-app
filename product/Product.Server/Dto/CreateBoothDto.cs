using System.ComponentModel.DataAnnotations;

namespace product.Dto;

public class CreateBoothDto
{
    [Required(ErrorMessage = "Title is required")]
    [MinLength(3), MaxLength(20)]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Description is required")]
    [MinLength(10), MaxLength(200)]
    public string Description { get; set; }
}