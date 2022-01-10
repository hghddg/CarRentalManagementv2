using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalManagementv2.Server.Data;
using CarRentalManagementv2.Shared.Domain;
using CarRentalManagement.Server.IRepository;

namespace CarRentalManagementv2.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ColoursController : ControllerBase
  {
    private readonly IUnitOfWork _unitOfWork;

    public ColoursController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }
    [HttpGet]
    public async Task<IActionResult> GetColours()
    {


      var Colours = await _unitOfWork.Colours.GetAll();
      return Ok(Colours);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetColour(int id)
    {
      var Colour = await _unitOfWork.Colours.Get(q => q.Id == id);

      if (Colour == null)
      {
        return NotFound();

      }
      return Ok(Colour);
    }
    [HttpPut("{id}")]

    public async Task<IActionResult> PutColour(int id, Colour Colour)
    {
      if (id != Colour.Id)
      {
        return BadRequest();
      }


      _unitOfWork.Colours.Update(Colour);

      try
      {

        await _unitOfWork.Save(HttpContext);
      }
      catch (DbUpdateConcurrencyException)
      {

        if (!await ColourExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }
    [HttpPost]
    public async Task<IActionResult> PostColour(Colour Colour)
    {
      await _unitOfWork.Colours.Insert(Colour);
      await _unitOfWork.Save(HttpContext);
      return CreatedAtAction("GetColour", new { id = Colour.Id }, Colour);

    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteColour(int id)
    {
      var Colour = await _unitOfWork.Colours.Get(q => q.Id == id);
      if (Colour == null)
      {
        return NotFound();
      }
      await _unitOfWork.Colours.Delete(id);
      await _unitOfWork.Save(HttpContext);
      return NoContent();
    }
    private async Task<bool> ColourExists(int id)
    {
      var Colour = await _unitOfWork.Colours.Get(q => q.Id == id);
      return Colour != null;
    }
  }
}