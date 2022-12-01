namespace product.Dto;

public class ProductDto
{
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<Guid> StocksIdList { get; set; }
    public ICollection<Guid> RatesIdList { get; set; }
}