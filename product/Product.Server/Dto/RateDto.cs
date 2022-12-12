using System.ComponentModel.DataAnnotations;

namespace product.Dto;

public class RateDto
{
    [Required(ErrorMessage = "Id is required")]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    
    public int Grade { get; set; }
    
    public string CommentTitle { get; set; }
    
    public string CommentBody { get; set; }
}