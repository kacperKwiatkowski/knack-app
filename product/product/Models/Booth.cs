using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace product.Models;

public class Booth
{
    public Booth()
    {
    }

    public Guid Id { get; set; }
}