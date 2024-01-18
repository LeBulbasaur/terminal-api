using Terminal.Models;
using Terminal.Methods;
using Microsoft.AspNetCore.Mvc;

namespace Terminal.Controllers;

[ApiController]
[Route("[controller]")]
public class APIController : ControllerBase
{
    public APIController()
    {
    }
    [HttpGet("scrape")]
    public async Task<IActionResult> Scrape()
    {
        List<RepositoryModel> result = await ScrapeGit.Scrape();
        if (result == null)
        {
            result = new List<RepositoryModel>();
            Console.WriteLine("No repos found");
        }
        return Ok(result);
    }
}