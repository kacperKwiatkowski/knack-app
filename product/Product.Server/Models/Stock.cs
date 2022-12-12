using product.Enums;

namespace product.Models;

public class Stock
{
    public Guid Id { get; set; }
    
    public SizeEnum Size { get; set; }
    
    public GenderEnum Gender { get; set; }
    
    public DepartmentEnum Department { get; set; }
    
    public CategoryEnum Category { get; set; }
    
    public double Price { get; set; }
    
    public int Quantity { get; set; }
    
    public Product Product { get; set; }
}