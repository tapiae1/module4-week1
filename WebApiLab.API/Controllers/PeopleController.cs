using System.Text.Json; 
using Microsoft.AspNetCore.Mvc; 
using WebApiLab.API.Models; 

namespace WebApiLab.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private List<Person> People {get;} = new List<Person>(); 

        public PeopleController()
        {
            string jsonFile = System.IO.File.ReadAllText("./Resources/DummyData.json"); 

            var peopleData = JsonSerializer.Deserialize<List<Person>>(
                jsonFile,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true}); 
            
            if (peopleData != null)
            {
                People = peopleData; 
            }
        }

        // GET: api/people
        [HttpGet]
        public ActionResult<List<Person>> GetPeople()
        {
            return Ok(People);
        }
    }
}