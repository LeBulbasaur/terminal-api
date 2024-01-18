using Terminal.Models;
using Terminal.Services;
using Terminal.Methods;
using Microsoft.AspNetCore.Mvc;

namespace Terminal.Controllers;

[ApiController]
[Route("[controller]")]
public class SystemObjectController : ControllerBase
{
    public SystemObjectController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<SystemObject>> GetAll() =>
       SystemObjectService.GetAll();
    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<SystemObject> Get(int id)
    {

        var file = SystemObjectService.Get(id);

        if(file == null)
            return NotFound();

        return file;
    }

    // POST action
    [HttpPost("postdir")]
    public IActionResult CreateDirectory(DirectoryObject file)
    {
        SystemObjectService.AddDirectory(file);
        return CreatedAtAction(nameof(CreateDirectory), new { id = file.Id }, file);
    }

    [HttpPost("posttxt")]
    public IActionResult CreateText(TextFileObject file)
    {
        SystemObjectService.AddTextFile(file);
        return CreatedAtAction(nameof(CreateText), new { id = file.Id }, file);
    }

    // PUT action
    [HttpPut("putdir/{id}")]
    public IActionResult UpdateDIR(int id, DirectoryObject file)
    {
        if (id != file.Id)
        {
            return BadRequest();
        }

        var existingFile = SystemObjectService.Get(id);
        if(existingFile is null)
        {
            return NotFound();
        }

        SystemObjectService.UpdateDIR(file);           

        return NoContent();
    }
    
    [HttpPut("puttxt/{id}")]
    public IActionResult UpdateTXT(int id, TextFileObject file)
    {
        if (id != file.Id)
        {
            return BadRequest();
        }

        var existingFile = SystemObjectService.Get(id);
        if(existingFile is null)
        {
            return NotFound();
        }

        SystemObjectService.UpdateTXT(file);           

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var file = SystemObjectService.Get(id);

        if (file is null)
        {
            return NotFound();
        }

        SystemObjectService.Delete(id);

        return NoContent();
    }
}