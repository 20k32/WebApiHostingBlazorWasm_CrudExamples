using Microsoft.AspNetCore.Mvc;
using Models;

namespace AspHost.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesList : ControllerBase
    {
        private static List<Person> Data = new()
        {
            new("Bob", 14),
            new("Alex", 34),
            new("Max", 45),
            new("Rob", 67),
            new("Henry", 89),
            new("OldMan", 120)
        };

        [HttpGet("GetEmployeesList")]
        public JsonResult GetEmployeesList() =>
            new JsonResult(Data);

        [HttpGet("GetEmployee/{id}")]
        public IResult GetEmployee(string Id)
        {
            var person = Data.FirstOrDefault(p => p.Id == Id);
            if (person != null)
            {
                return Results.Json(person);
            }
            return Results.BadRequest($"There is no person with id {Id}.");
        }

        [HttpPut("UpdateData")]
        public IResult UpdatePersonsInfo(Person Employee)
        {
            var person = Data.FirstOrDefault(p => p.Id == Employee.Id);
            if (person != null)
            {
                person.Id = Employee.Id;
                person.Age = Employee.Age;
                person.Name = Employee.Name;

                return Results.Json(person);
            }
            return Results.BadRequest("There is no such person");
        }

        [HttpPost("AddEmployee")]
        public IResult AddNewPerson(Person Employee)
        {
            Employee.Id = Guid.NewGuid().ToString();
            Data.Add(Employee);
            return Results.Ok();
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public IResult DeletePerson(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return Results.BadRequest("The id is null or empty");
            }
            var person = Data.FirstOrDefault(p => p.Id == Id);
            if (person != null)
            {
                Data.Remove(person);
                return Results.Ok();
            }
            return Results.NotFound($"The person with id {Id} not found");
        }
    }
}
