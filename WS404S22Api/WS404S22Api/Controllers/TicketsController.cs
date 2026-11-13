using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WS404S22Api.Data;
using WS404S22Api.DTO;
using WS404S22Api.Models;

namespace WS404S22Api.Controllers
{
    [ApiController]
    [Route("tickets")]
    public class TicketsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TicketsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Buy(BuyRequest request)
        {
            User? user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                return BadRequest(new { error = "User not found." });

            Place? place = await _context.Places.FindAsync(request.PlaceId);
            if (place == null)
                return BadRequest(new { error = "Place not found." });

            if (request.VisitorCount < 1)
                return BadRequest(new { error = "Visitor count must be at least 1." });

            List<Section> sections = await _context.Sections.Where(s => s.PlaceId == request.PlaceId
            && request.SectionIds.Contains(s.SectionId)).ToListAsync();

            if (sections.Count != request.SectionIds.Distinct().Count())
                return BadRequest(new { error = "One or more sections not found." });

            DateTime now = DateTime.Now;

            int inside = _context.Tickets
                .Where(t => t.PlaceId == request.PlaceId && t.ReleaseAt > now)
                .Sum(t => (int?)t.VisitorCount ?? 0);

            int remaining = place.Capacity - inside;

            if (request.VisitorCount > remaining)
                return Conflict(new { error = "Not Enough Capacity " + remaining });


            int free = request.VisitorCount / 3;
            int paid = request.VisitorCount - free;
            int pricePerPesron = place.BasePrice + sections.Sum(s => s.Price);
            int total = pricePerPesron * paid;

            // barcode
            PersianCalendar pc = new();
            int counter = _context.Tickets.Count(t => t.VisitAt.Date == now.Date) + 1;

            string barcode =
                place.Code
                + (pc.GetYear(now) % 100).ToString("00")
                + pc.GetDayOfYear(now).ToString("000")
                + counter.ToString("00000");

            //save
            Ticket ticket = new()
            {
                UserId = request.UserId,
                PlaceId = request.PlaceId,
                VisitorCount = request.VisitorCount,
                FreeCount = free,
                VisitAt = now,
                ReleaseAt = now.AddMinutes(place.VisitorMinutes + 1),
                TotalPrice = total,
                Barcode = barcode
            };
            foreach (Section item in sections)
            {
                ticket.TicketSections.Add(new TicketSection() { SectionId = item.SectionId });
            }

            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return Ok(new BuyRequestResponse()
            {
                id = ticket.TicketId,
                barcode = barcode,
                Price= ticket.TotalPrice
            });
        }

        [HttpGet("{id}/print")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var Ticket = _context.Tickets
                .Include(t => t.User)
                .Include(t => t.TicketSections).ThenInclude(ts => ts.Section)
                .FirstOrDefault(t => t.TicketId == id);

            if (Ticket == null)
                return NotFound();

            Place place = _context.Places.Find(Ticket.PlaceId);
            int paid = Ticket.VisitorCount - Ticket.FreeCount;

            var dto = new PrintDTO()
            {
                PlaceName = place.PlaceName,
                NumberOfTickets = Ticket.VisitorCount,
                Total = Ticket.TotalPrice,
                Barcode = Ticket.Barcode
            };
            foreach (var section in Ticket.TicketSections)
            {
                var sectionDetail = new TicketSectionDetail()
                {
                    SectionName = section.Section.SectionName,
                    Price = section.Section.Price,
                    TotalPrice = section.Section.Price * paid
                };
                dto.SectionDetailss.Add(sectionDetail);
            }

            return Ok(dto);

        }
    }
}
