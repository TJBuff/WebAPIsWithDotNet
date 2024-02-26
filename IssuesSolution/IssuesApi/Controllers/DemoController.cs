namespace IssuesApi.Controllers;


/// <summary>
/// In IssuesApi.http
/// </summary>
public class DemoController : Controller //Extends the Controller Class from AspNetCore.Mvc which allows us to access its libraries
{
    /// <summary>
    /// Action Result is a Base Class which returns an IActionResult
    /// 
    /// GET /demo
    /// </summary>
    /// <returns></returns>


    //If a GET request is sent to the below address, then do this...
    [HttpGet("/demo")]
    public ActionResult<DemoResponse> GetTheDemo()
    {
        //Create an instance of the DemoResponse object we want to send for this Request
        var response = new DemoResponse("Request was Successful", DateTimeOffset.Now);
        return Ok(response);
    }

    [HttpGet("/employees")]
    public ActionResult GetEmployees([FromQuery] string department = "ALL")
    {
        //Create an instance of the EmployeeResponse object we want to send for this Request
        var employees = new List<EmployeeResponse>
        {
            new EmployeeResponse(Guid.NewGuid(), "Hans Soletick", "Contractor"),
            new EmployeeResponse(Guid.NewGuid(), "Meg Ricardobluff", "DEV"),
            new EmployeeResponse(Guid.NewGuid(), "Dr. Mantis Toboggan", "Medical"),
            new EmployeeResponse(Guid.NewGuid(), "Lou Dorchen", "Laundry")
        };

        if (department == "ALL")
        {
            var response = new CollectionResponse<EmployeeResponse>(employees);
            return Ok(response);

        }
        else
        {
            var filteredEmployees = employees.Where(e => e.Department == department).ToList();
            var response = new CollectionResponse<EmployeeResponse>(employees);
            return Ok(response);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="employeeId">Directly links to the parameter being passed through the GET</param>
    /// <returns></returns>

    [HttpGet("/employees/{employeeId}")]
    public ActionResult GetAnEmployee(int employeeId)
    {
        //Create an instance of the EmployeeResponse object we want to send for this Request
        var employees = new List<EmployeeResponse>
        {
            new EmployeeResponse(Guid.NewGuid(), "Hans Soletick", "Contractor"),
            new EmployeeResponse(Guid.NewGuid(), "Meg Ricardobluff", "DEV"),
            new EmployeeResponse(Guid.NewGuid(), "Dr. Mantis Toboggan", "Medical"),
            new EmployeeResponse(Guid.NewGuid(), "Lou Dorchen", "Laundry")
        };

        if (employeeId % 2 == 0)
        {
            //var filteredEmployees = employees.Where(e => e.Id == employeeId).ToList();
            //var response = new CollectionResponse<EmployeeResponse>(employees);
            return Ok(new EmployeeResponse(Guid.NewGuid(), "Hans Soletick", "Contractor"));

        }
        else
        {
            return NotFound();
        }
    }
}


[HttpPost("/employees")]
public ActionResult HireAnEmployee([FromBody] EmployeeHireRequest request)
{


}








/// <summary>
/// Creating a public record of the Response to send 
/// </summary>
/// <param name="message"></param>
/// <param name="createdAt"></param>
public record DemoResponse(string message, DateTimeOffset createdAt);

public record EmployeeResponse(Guid Id, string Name, string Department);

public record CollectionResponse<T>(List<T> Data);
public record EmployeeHireRequest(string Name, string Department);
