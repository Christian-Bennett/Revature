using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MovieWorld.Client.Attributes
{
  public class GenreAttribute : ValidationAttribute
  {
    public override bool IsValid(object value)
    {
      var regex = new Regex("[a-zA-Z]+");

      return regex.IsMatch(value.ToString());
    }
  }
}