namespace KBM_Backend.Application.Interfaces;

public interface IPasswordHasher
{
    string HashPassword(string password);

    bool VerifyPassword(
        string password,
        string passwordHash);
}