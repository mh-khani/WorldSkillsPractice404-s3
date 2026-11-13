using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WS404S22Api.Data;
using WS404S22Api.DTO;

namespace WS404S22Api.Controllers
{
    [ApiController]
    [Route("dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly AppDbContext context;

        public DashboardController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboardData(int userId)
        {
           var user = await context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
                return NotFound("User not found.");

            return Ok(new DashboardRequest() {
                Name = user.FullName,
                Date = Helper.DateTimeHelper.ToShamsiDate(DateTime.Now),
                Time = TimeOnly.FromDateTime(DateTime.Now)
            });
        }
    }
}
