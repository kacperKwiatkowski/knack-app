namespace product.Models;

public class Rate
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    
    public int Grade { get; set; }
    
    public string CommentTitle { get; set; }
    
    public string CommentBody { get; set; }

    public Product Product { get; set; }
}