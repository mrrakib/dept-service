using HrmBaharu.Application.Common.Interfaces;
using HrmBaharu.Domain.Entities;
using HrmBaharu.Domain.Events;

namespace HrmBaharu.Application.Features.Departments.Commands.CreateDepartment;

public record CreateDepartmentCommand : IRequest<int>
{
    public string? Name { get; init; }
    public string? Location { get; init; }
}

public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Department
        {
            Name = request.Name,
            Location = request.Location,
        };

        entity.AddDomainEvent(new DepartmentCreatedEvent(entity));

        _context.Departments.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
