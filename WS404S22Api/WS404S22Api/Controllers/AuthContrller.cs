using Microsoft.AspNetCore.Mvc;
using WS404S22Api.Data;
using WS404S22Api.DTO;

namespace WS404S22Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthContrller : ControllerBase
    {
        private readonly AppDbContext appDb;

        public AuthContrller(AppDbContext appDb)
        {
            this.appDb = appDb;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            bool isValid = request.nationalCode.Length == 10 && request.nationalCode.All(char.IsDigit);

            if(isValid == false)
                return BadRequest("Invalid national code format.");

            var user = appDb.Users.FirstOrDefault(u => u.NationalCode == request.nationalCode && u.Password == request.password);

            if(user == null)
                return Unauthorized("Invalid national code or password.");

            return Ok(user.UserId);
        }
    }
}
