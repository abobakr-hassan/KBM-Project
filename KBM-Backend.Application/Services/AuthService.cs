using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using KBM_Backend.Application.DTOs;
using KBM_Backend.Application.Interfaces;
using KBM_Backend.Domain.Entities;

namespace KBM_Backend.Application.Services;

public class AuthService : IAuthService
{
    private readonly IKbmDbContext _context;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtService _jwtService;
    private readonly ILogger<AuthService> _logger;

    public AuthService(
        IKbmDbContext context,
        IPasswordHasher passwordHasher,
        IJwtService jwtService,
        ILogger<AuthService> logger)
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
        _logger = logger;
    }

    public async Task<AuthResponseDto> RegisterAsync(
        RegisterDto dto)
    {
        _logger.LogInformation(
            "Registering user with username {Username}",
            dto.Username);

        var usernameExists = await _context.Users
            .AnyAsync(u => u.Username == dto.Username);

        if (usernameExists)
        {
            _logger.LogWarning(
                "Registration failed. Username {Username} already exists",
                dto.Username);

            throw new InvalidOperationException(
                "Username is already registered.");
        }

        var emailExists = await _context.Users
            .AnyAsync(u => u.Email == dto.Email);

        if (emailExists)
        {
            _logger.LogWarning(
                "Registration failed. Email {Email} already exists",
                dto.Email);

            throw new InvalidOperationException(
                "Email is already registered.");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = dto.Username,
            Email = dto.Email,
            PasswordHash = _passwordHasher.HashPassword(dto.Password),
            Role = "User",
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow
        };

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "User {UserId} registered successfully",
            user.Id);

        var expiration = _jwtService.GetExpirationDate();

        return new AuthResponseDto
        {
            Token = _jwtService.GenerateToken(user),
            ExpiresAt = expiration,
            Username = user.Username,
            Role = user.Role
        };
    }

    public async Task<AuthResponseDto> LoginAsync(
        LoginDto dto)
    {
        _logger.LogInformation(
            "Login attempt for username {Username}",
            dto.Username);

        var user = await _context.Users
            .FirstOrDefaultAsync(
                u => u.Username == dto.Username);

        if (user is null)
        {
            _logger.LogWarning(
                "Login failed for username {Username}",
                dto.Username);

            throw new UnauthorizedAccessException(
                "Invalid username or password.");
        }

        var passwordValid = _passwordHasher.VerifyPassword(
            dto.Password,
            user.PasswordHash);

        if (!passwordValid)
        {
            _logger.LogWarning(
                "Login failed for username {Username}",
                dto.Username);

            throw new UnauthorizedAccessException(
                "Invalid username or password.");
        }

        _logger.LogInformation(
            "User {UserId} logged in successfully",
            user.Id);

        var expiration = _jwtService.GetExpirationDate();

        return new AuthResponseDto
        {
            Token = _jwtService.GenerateToken(user),
            ExpiresAt = expiration,
            Username = user.Username,
            Role = user.Role
        };
    }
}