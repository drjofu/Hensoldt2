using Shared;
using System.Xml.Linq;

namespace MondialBeispielWebApi.BL
{
  public class World
  {
    string path;

    public World(IConfiguration configuration)
    {
      path = configuration["Mondial:Url"];
    }

    public IEnumerable<Continent> GetContinents()
    {
      return XDocument.Load(path)
        .Root
        .Elements("continent")
        .Select(xContinent => new Continent
        {
          Name = xContinent.Element("name").Value,
          Area = (int)xContinent.Element("area"),
          Id = xContinent.Attribute("id").Value
        })
        .ToList();
    }

    public IEnumerable<Country> GetCountriesOnContinent(string continentId)
    {
      return XDocument.Load(path)
        .Root
        .Elements("country")
        .Where(xCountry => xCountry.Element("encompassed").Attribute("continent").Value == continentId)
        .Select(xCountry => new Country
        {
          Name = xCountry.Element("name").Value,
          Area = (double)xCountry.Attribute("area"),
          CarCode = xCountry.Attribute("car_code").Value,
          Population = (int)xCountry.Element("population")
        })
        .ToList();

    }
  }
}
