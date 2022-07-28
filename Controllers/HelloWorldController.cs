using Microsoft.AspNetCore.Mvc;

namespace curso_api_net.Controllers;

[ApiController]
[Route("api/[controller]")]

public class HelloWorldController : ControllerBase
{
    //se recibe la dependencia del IHelloWorldService quer sera inyectado
    IHelloWorldService helloWorldService;

    //la dependencia se recibe a travez del constructor, se recibe la instancia que el constructor
    //a inyectado
    public HelloWorldController(IHelloWorldService helloWorld)
    {
        helloWorldService = helloWorld;
    }

    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }
}