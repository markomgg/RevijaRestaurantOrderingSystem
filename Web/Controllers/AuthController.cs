using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Revija.Infrastructure.Data;
using Revija.Domain.Entities;

namespace Revija.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly RevijaDbContext _db;

    public AuthController(RevijaDbContext db)
    {
        _db = db;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest req)
    {
        if (req is null || string.IsNullOrWhiteSpace(req.Username) || string.IsNullOrWhiteSpace(req.Password))
            return BadRequest();

        var user = _db.Users.FirstOrDefault(u => u.Username == req.Username);
        if (user == null)
            return Unauthorized();

        var hash = ComputeHash(req.Password!);
        if (hash != user.PasswordHash)
            return Unauthorized();

        return Ok(new { token = "demo-token", username = user.Username });
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest req)
    {
        if (req is null || string.IsNullOrWhiteSpace(req.Username) || string.IsNullOrWhiteSpace(req.Password))
            return BadRequest();

        var exists = _db.Users.Any(u => u.Username == req.Username);
        if (exists)
            return Conflict(new { message = "Username already exists" });

        var user = new User
        {
            Username = req.Username!,
            PasswordHash = ComputeHash(req.Password!)
        };

        _db.Users.Add(user);
        _db.SaveChanges();

        return Ok(new { message = "User registered", username = user.Username });
    }

    public class LoginRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    public class RegisterRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    private static string ComputeHash(string input)
    {
        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(input);
        var hash = sha.ComputeHash(bytes);
        return Convert.ToHexString(hash);
    }
}
