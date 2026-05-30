using MFO_Logistics_API.Data;
using MFO_Logistics_API.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MFO_Logistics_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiptController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReceiptController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetReceiptReport(
            DateTime? createDate,
            DateTime? createDate2,
            string? receiptCode,
            string? depositorName,
            string? logisticName)
        {
            var query = _context.ReceiptSearchs.AsQueryable();

            if (createDate.HasValue)
                query = query.Where(x => x.CreateDate >= createDate.Value);

            if (createDate2.HasValue)
                query = query.Where(x => x.CreateDate <= createDate2.Value);

            if (!string.IsNullOrWhiteSpace(receiptCode))
                query = query.Where(x => x.ReceiptCode.Contains(receiptCode));

            if (!string.IsNullOrWhiteSpace(depositorName))
                query = query.Where(x => x.DepositorName == depositorName);

            if (!string.IsNullOrWhiteSpace(logisticName))
                query = query.Where(x => x.LogisticName == logisticName);

            var data = await query
                .Select(x => new ReceiptSearchDTO
                {
                    ReceiptCode = x.ReceiptCode,
                    CreateDate = x.CreateDate,
                    DepositorName = x.DepositorName,
                    LogisticName = x.LogisticName,
                    CreateUser = x.CreateUser,
                    ReceiptStatusName = x.ReceiptStatusName,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate
                })
                .Take(500).ToListAsync();

            return Ok(data);
        }
    }
}
