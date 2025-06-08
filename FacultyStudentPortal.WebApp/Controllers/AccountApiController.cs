using FacultyStudentPortal.Business.Interfaces;
using FacultyStudentPortal.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FacultyStudentPortal.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountApiController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountApiController(IUserService userService)
        {
            _userService = userService;
        }
        

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User model)
        {
            try
            {
                await _userService.RegisterUserAsync(model);
                return Ok(new { message = "User registered successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid input data", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
            }

            try
            {
                var user = await _userService.LoginAsync(model.Email, model.PasswordHash);

                if (user != null)
                {
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return Ok(new
                    {
                        message = "Login successful",
                        user = new
                        {
                            user.UserId,
                            user.FullName,
                            user.Email,
                            user.Role
                        }
                    });
                }

                return Unauthorized(new { message = "Invalid credentials" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred during login", error = ex.Message });
            }
        }

    }


}
