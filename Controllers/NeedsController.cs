using Microsoft.AspNetCore.Mvc;
using CareBridgeAPI.Data;
using CareBridgeAPI.Models;

namespace CareBridgeAPI.Controllers
{
    [ApiController]
    [Route("api/needs")]
    public class NeedsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NeedsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Needs.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _context.Needs.Find(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create(Need model)
        {
            model.CreatedAt = DateTime.UtcNow;
            model.UpdatedAt = DateTime.UtcNow;

            _context.Needs.Add(model);
            _context.SaveChanges();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Need input)
        {
            var data = _context.Needs.Find(id);
            if (data == null) return NotFound();

            data.ItemName = input.ItemName;
            data.Description = input.Description;
            data.TargetAmount = input.TargetAmount;
            data.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _context.Needs.Find(id);
            if (data == null) return NotFound();

            _context.Needs.Remove(data);
            _context.SaveChanges();

            return Ok();
        }
    }
}