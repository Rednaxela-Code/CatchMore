using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatchMore.Models;

public class Catch : DataEntity
{
    [Required] 
    public DateTime Date { get; set; }
    [Required]
    public string Species { get; set; }
    public double Length { get; set; }
    public double Weight { get; set; }
    public int SessionId { get; set; }
    [ForeignKey("SessionId")]
    public Session session { get; set; }
    public string ImageUrl { get; set; }
}