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
  public class CustomersController : ControllerBase
  {
    private readonly IUnitOfWork _unitOfWork;

    public CustomersController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }
    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {


      var Customers = await _unitOfWork.Customers.GetAll();
      return Ok(Customers);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(int id)
    {
      var Customer = await _unitOfWork.Customers.Get(q => q.Id == id);

      if (Customer == null)
      {
        return NotFound();

      }
      return Ok(Customer);
    }
    [HttpPut("{id}")]

    public async Task<IActionResult> PutCustomer(int id, Customer Customer)
    {
      if (id != Customer.Id)
      {
        return BadRequest();
      }


      _unitOfWork.Customers.Update(Customer);

      try
      {

        await _unitOfWork.Save(HttpContext);
      }
      catch (DbUpdateConcurrencyException)
      {

        if (!await CustomerExists(id))
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
    public async Task<IActionResult> PostCustomer(Customer Customer)
    {
      await _unitOfWork.Customers.Insert(Customer);
      await _unitOfWork.Save(HttpContext);
      return CreatedAtAction("GetCustomer", new { id = Customer.Id }, Customer);

    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
      var Customer = await _unitOfWork.Customers.Get(q => q.Id == id);
      if (Customer == null)
      {
        return NotFound();
      }
      await _unitOfWork.Customers.Delete(id);
      await _unitOfWork.Save(HttpContext);
      return NoContent();
    }
    private async Task<bool> CustomerExists(int id)
    {
      var Customer = await _unitOfWork.Customers.Get(q => q.Id == id);
      return Customer != null;
    }
  }
}