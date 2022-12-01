namespace product.Dto;

public class CreateProductDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid BoothId { get; set; }
}