using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class DirectoryService : ControllerBase
{
    [HttpGet]
    public void Test()
    {
    }
}