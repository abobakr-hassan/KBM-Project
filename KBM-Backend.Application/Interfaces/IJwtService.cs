using KBM_Backend.Domain.Entities;

namespace KBM_Backend.Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);

    DateTime GetExpirationDate();
}