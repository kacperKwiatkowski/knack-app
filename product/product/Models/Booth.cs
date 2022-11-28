using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace product.Models;

public class Booth
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }

    public ICollection <Product> Products { get; set; }
}