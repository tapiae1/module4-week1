using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using WebApiLab.Console.Models;

HttpClient client = new HttpClient(); 
client.BaseAddress = new Uri("http://localhost:5064"); 

HttpResponseMessage response = await client.GetAsync("/api/people"); 

if (response.IsSuccessStatusCode)
{
    string jsonResponse = await response.Content.ReadAsStringAsync();
    
    var people = JsonSerializer.Deserialize<List<Person>>(
        jsonResponse,
        new JsonSerializerOptions {PropertyNameCaseInsensitive = true}
        );
    
    foreach (var person in people)
    {
        Console.WriteLine($"{person.name} speaks {person.Language}");
    }
}

else
{
    Console.WriteLine($"Error: {response.StatusCode}");
    Console.WriteLine(await response.Content.ReadAsStringAsync());
}