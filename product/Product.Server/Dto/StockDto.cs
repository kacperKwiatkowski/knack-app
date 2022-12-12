using System.ComponentModel.DataAnnotations;
using product.Enums;

namespace product.Dto;

public class StockDto
{
    [Required(ErrorMessage = "Id is required")]
    public Guid Id { get; set; }
    
    [EnumDataType(typeof(SizeEnum), ErrorMessage = "This size value is not accepted by the system")]    
    public SizeEnum Size { get; set; }
    
    [EnumDataType(typeof(GenderEnum), ErrorMessage = "This gender value is not accepted by the system")]
    public GenderEnum Gender { get; set; }
    
    [EnumDataType(typeof(DepartmentEnum), ErrorMessage = "This department value is not accepted by the system")]
    public DepartmentEnum Department { get; set; }
    
    [EnumDataType(typeof(CategoryEnum), ErrorMessage = "This category value is not accepted by the system")]
    public CategoryEnum Category { get; set; }
    
    [Range(0, double.MaxValue)]
    public double Price { get; set; }
    
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }
}