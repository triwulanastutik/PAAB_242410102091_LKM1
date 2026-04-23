using Microsoft.AspNetCore.Mvc;
using CareBridgeAPI.Data;
using CareBridgeAPI.Models;

namespace CareBridgeAPI.Controllers
{
    [ApiController]
    [Route("api/donations")]
    public class DonationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DonationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _context.Donations.ToList();

            return Ok(new ApiResponse<List<Donation>>
            {
                Status = "success",
                Message = "Donations retrieved successfully",
                Data = data
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _context.Donations.Find(id);

            if (data == null)
                return NotFound(new ApiResponse<object>
                {
                    Status = "error",
                    Message = "Donation not found",
                    Data = null
                });

            return Ok(new ApiResponse<Donation>
            {
                Status = "success",
                Message = "Donation found",
                Data = data
            });
        }

        [HttpPost]
        public IActionResult Create(Donation donation)
        {
            donation.CreatedAt = DateTime.Now;
            donation.UpdatedAt = DateTime.Now;

            _context.Donations.Add(donation);
            _context.SaveChanges();

            return StatusCode(201, new ApiResponse<Donation>
            {
                Status = "success",
                Message = "Donation created successfully",
                Data = donation
            });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Donation donation)
        {
            var data = _context.Donations.Find(id);

            if (data == null)
                return NotFound(new ApiResponse<object>
                {
                    Status = "error",
                    Message = "Donation not found",
                    Data = null
                });

            data.Amount = donation.Amount;
            data.DonationDate = donation.DonationDate;
            data.UpdatedAt = DateTime.Now;

            _context.SaveChanges();

            return Ok(new ApiResponse<Donation>
            {
                Status = "success",
                Message = "Donation updated successfully",
                Data = data
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _context.Donations.Find(id);

            if (data == null)
                return NotFound(new ApiResponse<object>
                {
                    Status = "error",
                    Message = "Donation not found",
                    Data = null
                });

            _context.Donations.Remove(data);
            _context.SaveChanges();

            return Ok(new ApiResponse<object>
            {
                Status = "success",
                Message = "Donation deleted successfully",
                Data = null
            });
        }
    }
}