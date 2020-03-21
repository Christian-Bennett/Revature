using System.ComponentModel.DataAnnotations;
using MovieWorld.Client.Attributes;

namespace MovieWorld.Client.Models
{
  public class MovieModel
  {
    [Required]
    [StringLength(150)]
    public string Title { get; set; }
    [Required(ErrorMessage = "Please fill out a Genre")]
    [DataType(DataType.Text)]
    [GenreAttribute(ErrorMessage = "Letters only please")]
    public string Genre { get; set; }
  }
}
