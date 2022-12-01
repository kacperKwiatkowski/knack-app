using product.Enums;

namespace product.Dto;

public class StockDto
{
    public Guid Id { get; set; }
    
    public SizeEnum Size { get; set; }
    
    public GenderEnum Gender { get; set; }
    
    public DepartmentEnum Department { get; set; }
    
    public CategoryEnum Category { get; set; }
    
    public double Price { get; set; }
    
    public int Quantity { get; set; }
    
    public string ProductId { get; set; }
}