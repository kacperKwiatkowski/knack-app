using System.ComponentModel.DataAnnotations;

namespace product.Dto;

public class ProductDto
{
    [Required(ErrorMessage = "Id is required")]
    public Guid? Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
}