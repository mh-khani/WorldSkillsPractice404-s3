using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using WS404S22Api.Data;
using WS404S22Api.DTO;
using WS404S22Api.Models;

namespace WS404S22Api.Controllers
{
    [ApiController]
    [Route("places")]
    public class PalcesContrller : ControllerBase
    {
        private readonly AppDbContext context;

        public PalcesContrller(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlaces(int page = 1, int size = 10)
        {
            if (size != 10 && size != 20 && size != 50)
                return BadRequest("Size must be 10, 20, or 50.");
            else if (page < 1)
                return BadRequest("Page number must be greater than 0.");

            int total = context.Places.Count();
            int pages = (int)MathF.Ceiling(total / (float)size);
            if (pages < 1) page = 1;
            if (page < 1) page = 1;
            if (page > pages) page = pages;

            List<Place> places = context.Places
                .OrderBy(p => p.PlaceId)
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();

            DateTime now = DateTime.Now;
            List<PlaceDTO> items = new();


            foreach (var place in places)
            {
                // people who are inside 
                int active = context.Tickets
                    .Where(p => place.PlaceId == p.PlaceId && p.ReleaseAt > now)
                    .Sum(t => (int?)t.VisitorCount) ?? 0;

                int sold = context.Tickets
                    .Where(t => t.PlaceId == place.PlaceId && t.VisitAt.Date == now.Date)
                    .Sum(t => (int?)t.VisitorCount) ?? 0;

                var _section = context.Sections.Where(s => s.PlaceId == place.PlaceId).ToList();
                List<SectionDTO> sectionDTOs = new();

                foreach(var section in _section)
                {
                    sectionDTOs.Add( new ()
                    {
                        SectionId = section.SectionId,
                        SectionName = section.SectionName,
                        Price = section.Price
                    });
                }

                PlaceDTO dto = new()
                {
                    Id = place.PlaceId,
                    Name = place.PlaceName,
                    Capacity = place.Capacity,
                    Remaining = place.Capacity - active,
                    Sold = sold,
                    BasePrice = place.BasePrice,
                    Sections = sectionDTOs
                };


                items.Add(dto);
            }

            return Ok(new PlacesRequest()
            {
                size = size,
                pages = pages,
                total = total,
                page = page,
                items = items,
            });
        }
    }
}
