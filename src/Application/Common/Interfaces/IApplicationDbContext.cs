using HrmBaharu.Domain.Entities;

namespace HrmBaharu.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<Department> Departments { get; }
    DbSet<Company> Companies { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
