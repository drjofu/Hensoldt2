using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiBasics.Models
{
  public class Person
  {
    public int Id { get; set; }
    [Required]
    public string? Vorname { get; set; }

    [StringLength(40, MinimumLength =3)]
    public string? Nachname { get; set; }

    [Range(18, 150)]
    [EvenNumberValidation(ErrorMessage ="muss doch gerade sein...")]
    public int Alter { get; set; }

    [JsonIgnore]
    public string Passwort { get; set; } = "ganz geheim";
  }

  public class Personenliste : ConcurrentDictionary<int, Person>
  {
    //public static readonly Personenliste DieInstanz = new Personenliste();

    public Personenliste()
    {
      this.TryAdd(1, new Person { Id = 1, Vorname = "Marie", Nachname = "Schmitz", Alter = 23 });
      this.TryAdd(2, new Person { Id = 2, Vorname = "Uwe", Nachname = "Meier", Alter = 34 });
      this.TryAdd(3, new Person { Id = 3, Vorname = "Karl", Nachname = "Schmitz", Alter = 44 });
      this.TryAdd(4, new Person { Id = 4, Vorname = "Klaus", Nachname = "Müller", Alter = 62 });
      this.TryAdd(5, new Person { Id = 5, Vorname = "Karin", Nachname = "Peters", Alter = 27 });
    }
  }
}
