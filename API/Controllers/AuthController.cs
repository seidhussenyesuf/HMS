using API.Models;
using DataLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly ILogger<AuthController> _logger;

        public AuthController(AppDbContext context, IPasswordHasher<AppUser> passwordHasher, ILogger<AuthController> logger)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _logger = logger;

            // Create default users immediately
            Task.Run(async () => await CreateDefaultUsersAsync()).Wait();
        }

        private async Task CreateDefaultUsersAsync()
        {
            try
            {
                // Check if admin exists
                if (!await _context.Users.AnyAsync(u => u.UserName == "admin"))
                {
                    var adminUser = new AppUser
                    {
                        UserName = "admin",
                        FullName = "System Administrator",
                        Role = "Admin"
                    };
                    adminUser.PasswordHash = _passwordHasher.HashPassword(adminUser, "Admin@123");
                    _context.Users.Add(adminUser);
                    _logger.LogInformation("Created default admin user");
                }

                // Check if receptionist exists
                if (!await _context.Users.AnyAsync(u => u.UserName == "reception"))
                {
                    var receptionUser = new AppUser
                    {
                        UserName = "reception",
                        FullName = "Reception Desk",
                        Role = "Receptionist"
                    };
                    receptionUser.PasswordHash = _passwordHasher.HashPassword(receptionUser, "Reception@123");
                    _context.Users.Add(receptionUser);
                    _logger.LogInformation("Created default receptionist user");
                }

                await _context.SaveChangesAsync();
                _logger.LogInformation("Default users created successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating default users");
            }
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequest request)
        {
            try
            {
                if (request == null ||
                    string.IsNullOrWhiteSpace(request.UserName) ||
                    string.IsNullOrWhiteSpace(request.Password) ||
                    string.IsNullOrWhiteSpace(request.FullName))
                {
                    return BadRequest(new AuthResponse
                    {
                        Success = false,
                        Message = "UserName, Password, and FullName are required."
                    });
                }

                _logger.LogInformation($"Register request received: UserName={request.UserName}, FullName={request.FullName}");

                var existing = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserName == request.UserName);

                if (existing != null)
                {
                    return BadRequest(new AuthResponse
                    {
                        Success = false,
                        Message = "Username already exists."
                    });
                }

                var user = new AppUser
                {
                    UserName = request.UserName,
                    FullName = request.FullName,
                    Role = "Receptionist"
                };

                user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(new AuthResponse
                {
                    Success = true,
                    Message = "User registered successfully.",
                    FullName = user.FullName,
                    Role = user.Role
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during registration");
                return StatusCode(500, new AuthResponse
                {
                    Success = false,
                    Message = $"Internal server error: {ex.Message}"
                });
            }
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
                {
                    return BadRequest(new AuthResponse
                    {
                        Success = false,
                        Message = "UserName and Password are required."
                    });
                }

                _logger.LogInformation($"Login attempt: UserName={request.UserName}");

                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserName == request.UserName);

                if (user == null)
                {
                    _logger.LogWarning($"Login failed: User '{request.UserName}' not found");
                    return Unauthorized(new AuthResponse
                    {
                        Success = false,
                        Message = "Invalid username or password."
                    });
                }

                var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

                if (result == PasswordVerificationResult.Failed)
                {
                    _logger.LogWarning($"Login failed: Invalid password for user '{request.UserName}'");
                    return Unauthorized(new AuthResponse
                    {
                        Success = false,
                        Message = "Invalid username or password."
                    });
                }

                _logger.LogInformation($"Login successful: UserName={request.UserName}, Role={user.Role}");
                return Ok(new AuthResponse
                {
                    Success = true,
                    Message = "Login successful.",
                    FullName = user.FullName ?? request.UserName,
                    Role = user.Role ?? "Receptionist"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login");
                return StatusCode(500, new AuthResponse
                {
                    Success = false,
                    Message = $"Internal server error: {ex.Message}"
                });
            }
        }

        // POST: api/auth/change-password
        [HttpPost("change-password")]
        public async Task<ActionResult<AuthResponse>> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            try
            {
                if (request == null ||
                    string.IsNullOrWhiteSpace(request.UserName) ||
                    string.IsNullOrWhiteSpace(request.OldPassword) ||
                    string.IsNullOrWhiteSpace(request.NewPassword))
                {
                    return BadRequest(new AuthResponse
                    {
                        Success = false,
                        Message = "UserName, OldPassword, and NewPassword are required."
                    });
                }

                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserName == request.UserName);

                if (user == null)
                {
                    return NotFound(new AuthResponse
                    {
                        Success = false,
                        Message = "User not found."
                    });
                }

                var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.OldPassword);

                if (result == PasswordVerificationResult.Failed)
                {
                    return BadRequest(new AuthResponse
                    {
                        Success = false,
                        Message = "Old password is incorrect."
                    });
                }

                user.PasswordHash = _passwordHasher.HashPassword(user, request.NewPassword);
                await _context.SaveChangesAsync();

                return Ok(new AuthResponse
                {
                    Success = true,
                    Message = "Password changed successfully."
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during password change");
                return StatusCode(500, new AuthResponse
                {
                    Success = false,
                    Message = $"Internal server error: {ex.Message}"
                });
            }
        }
    }
}