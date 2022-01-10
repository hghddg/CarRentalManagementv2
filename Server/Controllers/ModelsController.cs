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
  public class ModelsController : ControllerBase
  {
    private readonly IUnitOfWork _unitOfWork;

    public ModelsController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }
    [HttpGet]
    public async Task<IActionResult> GetModels()
    {


      var Models = await _unitOfWork.Models.GetAll();
      return Ok(Models);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetModel(int id)
    {
      var Model = await _unitOfWork.Models.Get(q => q.Id == id);

      if (Model == null)
      {
        return NotFound();

      }
      return Ok(Model);
    }
    [HttpPut("{id}")]

    public async Task<IActionResult> PutModel(int id, Model Model)
    {
      if (id != Model.Id)
      {
        return BadRequest();
      }


      _unitOfWork.Models.Update(Model);

      try
      {

        await _unitOfWork.Save(HttpContext);
      }
      catch (DbUpdateConcurrencyException)
      {

        if (!await ModelExists(id))
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
    public async Task<IActionResult> PostModel(Model Model)
    {
      await _unitOfWork.Models.Insert(Model);
      await _unitOfWork.Save(HttpContext);
      return CreatedAtAction("GetModel", new { id = Model.Id }, Model);

    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteModel(int id)
    {
      var Model = await _unitOfWork.Models.Get(q => q.Id == id);
      if (Model == null)
      {
        return NotFound();
      }
      await _unitOfWork.Models.Delete(id);
      await _unitOfWork.Save(HttpContext);
      return NoContent();
    }
    private async Task<bool> ModelExists(int id)
    {
      var Model = await _unitOfWork.Models.Get(q => q.Id == id);
      return Model != null;
    }
  }
}