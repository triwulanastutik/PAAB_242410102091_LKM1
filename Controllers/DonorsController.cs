using Microsoft.AspNetCore.Mvc;
using CareBridgeAPI.Data;
using CareBridgeAPI.Models;

namespace CareBridgeAPI.Controllers
{
    [ApiController]
    [Route("api/donors")]
    public class DonorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DonorsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Donors.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _context.Donors.Find(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create(Donor donor)
        {
            donor.CreatedAt = DateTime.UtcNow;
            donor.UpdatedAt = DateTime.UtcNow;

            _context.Donors.Add(donor);
            _context.SaveChanges();

            return Ok(donor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Donor input)
        {
            var data = _context.Donors.Find(id);
            if (data == null) return NotFound();

            data.Name = input.Name;
            data.Email = input.Email;
            data.Phone = input.Phone;
            data.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _context.Donors.Find(id);
            if (data == null) return NotFound();

            _context.Donors.Remove(data);
            _context.SaveChanges();

            return Ok();
        }
    }
}