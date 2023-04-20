using Microsoft.AspNetCore.Mvc;
using WebAPIbikegarage.Models;
using WebAPIbikegarage.Services;

namespace WebAPIbikegarage.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiçoController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Serviço>> GetAll() => ServiçoService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Serviço> Get(int id)
    {
        var serviço = ServiçoService.Get(id);
        if (serviço == null) return NotFound();
        return serviço;
    }

   [HttpPost]
   public IActionResult Create(Serviço serviço)
   {
        ServiçoService.Add(serviço);
        return CreatedAtAction(nameof(Get), new { id = serviço.Id }, serviço);
        //return NoContent();
   }

   [HttpDelete("{id}")]
   public IActionResult Delete(int id)
   {
        var serviço = ServiçoService.Get(id);
        if (serviço is null) return NotFound();
        ServiçoService.Delete(id);
        return NoContent();
   }

   [HttpPut("{id}")]
   public IActionResult Update(int id, Serviço serviço)
   {
        if (id != serviço.Id) return BadRequest();
        var existingServiço = ServiçoService.Get(id);
        if (existingServiço is null) return NotFound();
        ServiçoService.Update(serviço);
        return NoContent();
   }
}
