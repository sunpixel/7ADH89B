using Back;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Back.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        string fileName = "persons";
        string directory = "Assets";

        [HttpGet("persons")]
        public IActionResult GetPersons()
        {
            string json = System.IO.File.ReadAllText($"{directory}/{fileName}.json");
            // Обращение к БД для получения данных
            return Ok(json);
        }

        [HttpPost("persons")]
        public IActionResult AddPerson([FromBody] Person? person)
        {
            string json = System.IO.File.ReadAllText($"{directory}/{fileName}.json");
            List<Person?> persons = JsonConvert.DeserializeObject<List<Person>>(json);

            persons.Add(person);
            string jsonSave = JsonConvert.SerializeObject(persons.ToArray(), Formatting.Indented);
            System.IO.File.WriteAllText($"{directory}/{fileName}.json", jsonSave);


            // Обращение к БД для добавления данных

            return Ok();
        }

        [HttpPut("persons")]
        public IActionResult EditPerson([FromBody] Tuple<string, Person> tuple)
        {
            string json = System.IO.File.ReadAllText($"{directory}/{fileName}.json");
            List<Person?> persons = JsonConvert.DeserializeObject<List<Person>>(json);

            string value2 = tuple.Item2.GetType().GetProperty(tuple.Item1).GetValue(tuple.Item2, null).ToString();
            Person? personToEdit = persons.FirstOrDefault(v => v.GetType().GetProperty(tuple.Item1).GetValue(v, null).ToString() == value2);
            Console.WriteLine(personToEdit);
            if (personToEdit != null)
            {
                personToEdit.Name = tuple.Item2.Name;
                personToEdit.Email = tuple.Item2.Email;
                personToEdit.Phone = tuple.Item2.Phone;

                string jsonSave = JsonConvert.SerializeObject(persons, Formatting.Indented);
                System.IO.File.WriteAllText($"{directory}/{fileName}.json", jsonSave);

                return Ok();
            }

            // Обращение к БД для изменения данных


            return NotFound();
        }
    }
}