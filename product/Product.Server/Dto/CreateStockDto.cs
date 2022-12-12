using System.ComponentModel.DataAnnotations;
using product.Enums;

namespace product.Dto;

public class CreateStockDto
{
    [Required(ErrorMessage = "Size is required")]
    [EnumDataType(typeof(SizeEnum), ErrorMessage = "This size value is not accepted by the system")] 
    public SizeEnum Size { get; set; }
    
    [Required(ErrorMessage = "Gender is required")]
    [EnumDataType(typeof(GenderEnum), ErrorMessage = "This gender value is not accepted by the system")] 
    public GenderEnum Gender { get; set; }
    
    [Required(ErrorMessage = "Department is required")]
    [EnumDataType(typeof(DepartmentEnum), ErrorMessage = "This department value is not accepted by the system")] 
    public DepartmentEnum Department { get; set; }
    
    [Required(ErrorMessage = "Category is required")]
    [EnumDataType(typeof(CategoryEnum), ErrorMessage = "This category value is not accepted by the system")] 
    public CategoryEnum Category { get; set; }
    
    [Required(ErrorMessage = "Price is required")]
    [Range(0, double.MaxValue)]
    public double Price { get; set; }
    
    [Required(ErrorMessage = "Quantity is required")]
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }
    
    [Required(ErrorMessage = "Product.Server id is required")]
    public Guid ProductId { get; set; }
}