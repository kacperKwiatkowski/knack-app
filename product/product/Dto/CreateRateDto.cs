using System.ComponentModel.DataAnnotations;

namespace product.Dto;

public class CreateRateDto
{
    [Required(ErrorMessage = "User id is required")]
    public Guid UserId { get; set; }
    
    [Required(ErrorMessage = "Grade is required")]
    [Range(1, 10)]
    public int Grade { get; set; }
    
    [Required(ErrorMessage = "Comment title is required")]
    [MinLength(3), MaxLength(20)]
    public string CommentTitle { get; set; }
    
    [Required(ErrorMessage = "Comment body is required")]
    [MinLength(10), MaxLength(200)]
    public string CommentBody { get; set; }

    [Required(ErrorMessage = "Product id is required")]
    public Guid ProductId { get; set; }
}