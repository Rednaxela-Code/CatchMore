using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
    public string? Description { get; set; }

    [ValidateNever]
    public string? Image { get; set; }
    public int? SessionId { get; set; }
    [ForeignKey("SessionId")]
    public Session? Session { get; set; }
    public string ApplicationUserId { get; set; }
    [ForeignKey("ApplicationUserId")]
    public ApplicationUser ApplicationUser { get; set; }
}