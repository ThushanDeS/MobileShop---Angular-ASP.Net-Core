using Microsoft.AspNetCore.Mvc;
using MobileShopERP.API.DTOs;
using MobileShopERP.API.Helpers;
using MobileShopERP.API.Models;
using MobileShopERP.API.Repositories;
using System;
using System.Threading.Tasks;

namespace MobileShopERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly JwtHelper _jwtHelper;

        public AuthController(IRepository<User> userRepository, JwtHelper jwtHelper)
        {
            _userRepository = userRepository;
            _jwtHelper = jwtHelper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                var user = await _userRepository.SingleOrDefaultAsync(u => u.Username == loginDto.Username);
                
                if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                {
                    return Unauthorized(new { message = "Invalid username or password" });
                }

                if (!user.IsActive)
                {
                    return Unauthorized(new { message = "Account is deactivated" });
                }

                // Update last login
                user.LastLoginAt = DateTime.Now;
                _userRepository.Update(user);
                await _userRepository.SaveChangesAsync();

                var token = _jwtHelper.GenerateToken(user);

                return Ok(new LoginResponseDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    FullName = user.FullName,
                    Role = user.Role,
                    Token = token,
                    Expiration = DateTime.UtcNow.AddMinutes(60)
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred during login", error = ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            try
            {
                // Check if username already exists
                var existingUser = await _userRepository.SingleOrDefaultAsync(u => u.Username == registerDto.Username);
                if (existingUser != null)
                {
                    return BadRequest(new { message = "Username already exists" });
                }

                var user = new User
                {
                    Username = registerDto.Username,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                    FullName = registerDto.FullName,
                    Email = registerDto.Email,
                    Phone = registerDto.Phone,
                    Role = registerDto.Role,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };

                await _userRepository.AddAsync(user);
                await _userRepository.SaveChangesAsync();

                return Ok(new { message = "User registered successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred during registration", error = ex.Message });
            }
        }
    }
}