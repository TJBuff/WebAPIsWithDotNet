using Microsoft.AspNetCore.Mvc;

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
    public ActionResult GetTheDemo()
    {
        return Ok();
    }

}
