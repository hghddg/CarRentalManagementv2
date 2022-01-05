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
    public class MakesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MakesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetMakes()
        {

           
          var makes = await _unitOfWork.Makes.GetAll();  
          return Ok(makes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMake(int id)
        {
          var make = await _unitOfWork.Makes.Get(q => q.Id == id);

          if (make == null)
          {
            return NotFound();

          }
          return Ok(make);
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> PutMake(int id, Make make)
        {
            if (id != make.Id)
            {
                return BadRequest();
            }

           
            _unitOfWork.Makes.Update(make);

            try
            {
                
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
               
                if (!await MakeExists(id))
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
         public async Task<IActionResult> PostMake(Make make) {
            await _unitOfWork.Makes.Insert(make);
            await _unitOfWork.Save(HttpContext);
            return CreatedAtAction("GetMake", new { id = make.Id }, make);

         }
         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteMake(int id) { 
            var make = await _unitOfWork.Makes.Get(q => q.Id == id);
            if (make == null) { 
              return NotFound();
            }
            await _unitOfWork.Makes.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
         }
         private async Task<bool> MakeExists(int id)
         {
            var make = await _unitOfWork.Makes.Get(q => q.Id == id);
            return make != null;
         }
  }
  }
//    private readonly ApplicationDbContext _context;

//        public MakesController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Makes
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Make>>> GetMakes()
//        {
//            return await _context.Makes.ToListAsync();
//        }

//        // GET: api/Makes/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Make>> GetMake(int id)
//        {
//            var make = await _context.Makes.FindAsync(id);

//            if (make == null)
//            {
//                return NotFound();
//            }

//            return make;
//        }

//        // PUT: api/Makes/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutMake(int id, Make make)
//        {
//            if (id != make.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(make).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!MakeExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Makes
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<Make>> PostMake(Make make)
//        {
//            _context.Makes.Add(make);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetMake", new { id = make.Id }, make);
//        }

//        // DELETE: api/Makes/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteMake(int id)
//        {
//            var make = await _context.Makes.FindAsync(id);
//            if (make == null)
//            {
//                return NotFound();
//            }

//            _context.Makes.Remove(make);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool MakeExists(int id)
//        {
//            return _context.Makes.Any(e => e.Id == id);
//        }
//    }
//}
