using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using KBM_Backend.Application.DTOs.Industry;
using KBM_Backend.Application.Interfaces;
using KBM_Backend.Domain.Entities;

namespace KBM_Backend.Application.Services;

public class IndustryService : IIndustryService
{
    private readonly IKbmDbContext _context;
    private readonly ILogger<IndustryService> _logger;

    public IndustryService(
        IKbmDbContext context,
        ILogger<IndustryService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<IndustryDto>> GetAllAsync()
    {
        _logger.LogInformation("Getting all industries");

        var industries = await _context.Industries
            .AsNoTracking()
            .ToListAsync();

        _logger.LogInformation(
            "Retrieved {Count} industries",
            industries.Count);

        return industries.Adapt<IEnumerable<IndustryDto>>();
    }

    public async Task<IndustryDto?> GetByIdAsync(Guid id)
    {
        _logger.LogInformation(
            "Getting industry with ID {IndustryId}",
            id);

        var industry = await _context.Industries
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);

        if (industry is null)
        {
            _logger.LogWarning(
                "Industry with ID {IndustryId} was not found",
                id);

            return null;
        }

        return industry.Adapt<IndustryDto>();
    }

    public async Task<IndustryDto> CreateAsync(
        CreateIndustryDto dto)
    {
        _logger.LogInformation(
            "Creating industry with name {IndustryName}",
            dto.Name);

        var industry = new Industry
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow
        };

        _context.Industries.Add(industry);

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Industry with ID {IndustryId} was created successfully",
            industry.Id);

        return industry.Adapt<IndustryDto>();
    }

    public async Task<bool> UpdateAsync(
        Guid id,
        UpdateIndustryDto dto)
    {
        _logger.LogInformation(
            "Updating industry with ID {IndustryId}",
            id);

        var industry = await _context.Industries
            .FirstOrDefaultAsync(i => i.Id == id);

        if (industry is null)
        {
            _logger.LogWarning(
                "Industry with ID {IndustryId} was not found for update",
                id);

            return false;
        }

        industry.Name = dto.Name;
        industry.ModifiedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Industry with ID {IndustryId} was updated successfully",
            id);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        _logger.LogInformation(
            "Deleting industry with ID {IndustryId}",
            id);

        var industry = await _context.Industries
            .FirstOrDefaultAsync(i => i.Id == id);

        if (industry is null)
        {
            _logger.LogWarning(
                "Industry with ID {IndustryId} was not found for deletion",
                id);

            return false;
        }

        _context.Industries.Remove(industry);

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Industry with ID {IndustryId} was deleted successfully",
            id);

        return true;
    }
}