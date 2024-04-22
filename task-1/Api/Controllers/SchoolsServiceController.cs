using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SchoolsServiceController : ControllerBase
{
    private readonly SchoolsService _schoolsService;
    public SchoolsServiceController(SchoolsService schoolsService)
    {
        _schoolsService = schoolsService;
    }

    [HttpGet]
    [Route("list")]
    public async Task<IActionResult> List()
    {
        var list = await _schoolsService.List();
        return Ok(list);
    }
}
