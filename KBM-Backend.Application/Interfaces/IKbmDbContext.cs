using KBM_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KBM_Backend.Application.Interfaces;

public interface IKbmDbContext
{
    DbSet<Department> Departments { get; }

    DbSet<Function> Functions { get; }

    DbSet<Industry> Industries { get; }

    DbSet<Lesson> Lessons { get; }

    DbSet<DepartmentFunction> DepartmentFunctions { get; }

    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}