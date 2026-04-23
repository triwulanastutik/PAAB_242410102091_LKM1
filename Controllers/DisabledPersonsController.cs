using Microsoft.AspNetCore.Mvc;
using CareBridgeAPI.Data;
using CareBridgeAPI.Models;

namespace CareBridgeAPI.Controllers
{
    [ApiController]
    [Route("api/disabledpersons")]
    public class DisabledPersonsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DisabledPersonsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.DisabledPersons.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _context.DisabledPersons.Find(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create(DisabledPerson model)
        {
            model.CreatedAt = DateTime.UtcNow;
            model.UpdatedAt = DateTime.UtcNow;

            _context.DisabledPersons.Add(model);
            _context.SaveChanges();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, DisabledPerson input)
        {
            var data = _context.DisabledPersons.Find(id);
            if (data == null) return NotFound();

            data.Name = input.Name;
            data.DisabilityType = input.DisabilityType;
            data.Address = input.Address;
            data.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _context.DisabledPersons.Find(id);

            if (data == null)
                return NotFound(new
                {
                    status = "error",
                    message = "Data not found"
                });

            // ✅ SOFT DELETE (BUKAN REMOVE)
            data.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();

            return Ok(new
            {
                status = "success",
                message = "Data deleted (soft delete)"
            });
        }
    }
}