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
  public class VehiclesController : ControllerBase
  {
    private readonly IUnitOfWork _unitOfWork;

    public VehiclesController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }
    [HttpGet]
    public async Task<IActionResult> GetVehicles()
    {


      var Vehicles = await _unitOfWork.Vehicles.GetAll();
      return Ok(Vehicles);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetVehicle(int id)
    {
      var Vehicle = await _unitOfWork.Vehicles.Get(q => q.Id == id);

      if (Vehicle == null)
      {
        return NotFound();

      }
      return Ok(Vehicle);
    }
    [HttpPut("{id}")]

    public async Task<IActionResult> PutVehicle(int id, Vehicle Vehicle)
    {
      if (id != Vehicle.Id)
      {
        return BadRequest();
      }


      _unitOfWork.Vehicles.Update(Vehicle);

      try
      {

        await _unitOfWork.Save(HttpContext);
      }
      catch (DbUpdateConcurrencyException)
      {

        if (!await VehicleExists(id))
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
    public async Task<IActionResult> PostVehicle(Vehicle Vehicle)
    {
      await _unitOfWork.Vehicles.Insert(Vehicle);
      await _unitOfWork.Save(HttpContext);
      return CreatedAtAction("GetVehicle", new { id = Vehicle.Id }, Vehicle);

    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehicle(int id)
    {
      var Vehicle = await _unitOfWork.Vehicles.Get(q => q.Id == id);
      if (Vehicle == null)
      {
        return NotFound();
      }
      await _unitOfWork.Vehicles.Delete(id);
      await _unitOfWork.Save(HttpContext);
      return NoContent();
    }
    private async Task<bool> VehicleExists(int id)
    {
      var Vehicle = await _unitOfWork.Vehicles.Get(q => q.Id == id);
      return Vehicle != null;
    }
  }
}