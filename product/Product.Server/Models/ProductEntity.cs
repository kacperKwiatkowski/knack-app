namespace product.Models;

public class ProductEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public BoothEntity Booth { get; set; }
        
    public ICollection<StockEntity> Stocks { get; set; }
    
    public ICollection<RateEntity> Rates { get; set; }
}