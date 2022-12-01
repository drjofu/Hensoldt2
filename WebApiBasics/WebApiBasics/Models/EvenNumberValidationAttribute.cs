using System.ComponentModel.DataAnnotations;

namespace WebApiBasics.Models
{
  [AttributeUsage(AttributeTargets.Property)]
  public class EvenNumberValidationAttribute : ValidationAttribute
  {
    public override bool IsValid(object? value)
    {
      if(value == null) return false;

      int wert = (int)value;

      return wert % 2 == 0;
    }
  }
}
