namespace product.Models;

public class Rate
{
    public Guid Id { get; set; }
    
    public Product Product { get; set; }
}