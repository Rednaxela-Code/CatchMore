using System.ComponentModel.DataAnnotations;

namespace CatchMore.Models;

public class Catch : DataEntity
{
    [Required] 
    public DateTime Date { get; set; }
    [Required]
    public string Species { get; set; }
    public double Length { get; set; }
    public double Weight { get; set; }
}