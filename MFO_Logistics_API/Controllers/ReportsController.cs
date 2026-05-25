using MFO_Logistics_API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MFO_Logistics_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReportsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("Receipt")]
        public async Task<IActionResult> GetReceiptReport()
        {
            var data = await _context.ReceiptReports
                .OrderByDescending(x => x.CreateDate)
                .ToListAsync();

            return Ok(data);
        }

    }
}
