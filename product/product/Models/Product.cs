namespace product.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public Booth Booth { get; set; }
        
    public ICollection<Stock> Stocks { get; set; }
    
    public ICollection<Rate> Rates { get; set; }
}