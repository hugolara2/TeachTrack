using Microsoft.AspNetCore.Mvc;

namespace TeachTrack.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase {

   [HttpGet]
   public string Get() => "Hola mundo";
}