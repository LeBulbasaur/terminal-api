using Terminal.Models;
using Terminal.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

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
        bool isAdded = SystemObjectService.AddDirectory(file);
        if(isAdded){
            return CreatedAtAction(nameof(CreateDirectory), new { id = file.Id }, file);
        }
        return CreatedAtAction(nameof(CreateDirectory), new { error = true });
    }

    [HttpPost("posttxt")]
    public IActionResult CreateText(TextFileObject file)
    {
        bool isAdded = SystemObjectService.AddTextFile(file);
        if(isAdded){
            return CreatedAtAction(nameof(CreateText), new { id = file.Id }, file);
        } 
        return CreatedAtAction(nameof(CreateText), new {error = true});
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

        bool isRemoved = SystemObjectService.Delete(id);
        if (isRemoved){
            return CreatedAtAction(nameof(Delete), new {error = false});
        }
        return CreatedAtAction(nameof(Delete), new {error = true});
    }
}