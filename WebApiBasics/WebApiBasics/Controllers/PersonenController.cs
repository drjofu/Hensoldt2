using Microsoft.AspNetCore.Mvc;
using WebApiBasics.Models;

namespace WebApiBasics.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class PersonenController : ControllerBase
  {
    private readonly Personenliste liste;

    public PersonenController(Personenliste liste)
    {
      this.liste = liste;
    }

    //[HttpGet]
    //public Person GetPerson()
    //{
    //  return new() { Vorname = "Marie", Nachname = "Meier", Alter = 33 };
    //}

    [HttpGet("liste")]
    public IEnumerable<Person> GetListe()
    {
      return liste.Values;
    }

    [HttpGet("{id}")]
    public ActionResult<Person> Get(int id)
    {
      //if (liste.TryGetValue(id, out var person))
      //  return new OkObjectResult(person);
      //return new NotFoundResult();

      if (liste.TryGetValue(id, out var person))
        return Ok(person);
      return NotFound($"Person mit Id {id} gibt es nicht");
    }

    [HttpPost()]
    public IActionResult Post(Person person)
    {
      //if (!ModelState.IsValid)
      //  return BadRequest();

      if (person.Id != 0)
        return BadRequest("Id muss 0 sein");

      int id = liste.Keys.Max() + 1;
      person.Id = id;
      if (liste.TryAdd(person.Id, person))
        return Created($"/personen/{person.Id}", person);

      return BadRequest($"Id {person.Id} schon vorhanden");
    }

    [HttpDelete()]
    public IActionResult Delete(int id)
    {
      if (liste.Remove(id, out var _))
        return Ok();

      return NotFound($"Person mit Id {id} gibt es nicht");
    }
  }
}
