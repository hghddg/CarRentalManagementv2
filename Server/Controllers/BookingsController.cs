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
  public class BookingsController : ControllerBase
  {
    private readonly IUnitOfWork _unitOfWork;

    public BookingsController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }
    [HttpGet]
    public async Task<IActionResult> GetBookings()
    {


      var Bookings = await _unitOfWork.Bookings.GetAll();
      return Ok(Bookings);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBooking(int id)
    {
      var Booking = await _unitOfWork.Bookings.Get(q => q.Id == id);

      if (Booking == null)
      {
        return NotFound();

      }
      return Ok(Booking);
    }
    [HttpPut("{id}")]

    public async Task<IActionResult> PutBooking(int id, Booking Booking)
    {
      if (id != Booking.Id)
      {
        return BadRequest();
      }


      _unitOfWork.Bookings.Update(Booking);

      try
      {

        await _unitOfWork.Save(HttpContext);
      }
      catch (DbUpdateConcurrencyException)
      {

        if (!await BookingExists(id))
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
    public async Task<IActionResult> PostBooking(Booking Booking)
    {
      await _unitOfWork.Bookings.Insert(Booking);
      await _unitOfWork.Save(HttpContext);
      return CreatedAtAction("GetBooking", new { id = Booking.Id }, Booking);

    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBooking(int id)
    {
      var Booking = await _unitOfWork.Bookings.Get(q => q.Id == id);
      if (Booking == null)
      {
        return NotFound();
      }
      await _unitOfWork.Bookings.Delete(id);
      await _unitOfWork.Save(HttpContext);
      return NoContent();
    }
    private async Task<bool> BookingExists(int id)
    {
      var Booking = await _unitOfWork.Bookings.Get(q => q.Id == id);
      return Booking != null;
    }
  }
}