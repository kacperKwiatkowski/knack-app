namespace product.Models;

public class RateEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    
    public int Grade { get; set; }
    
    public string CommentTitle { get; set; }
    
    public string CommentBody { get; set; }

    public ProductEntity Product { get; set; }
}