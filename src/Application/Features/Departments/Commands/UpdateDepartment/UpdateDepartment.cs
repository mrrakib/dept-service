using HrmBaharu.Application.Common.Interfaces;

namespace HrmBaharu.Application.Features.Departments.Commands.UpdateDepartment;

public record UpdateDepartmentCommand : IRequest
{
    public int Id { get; init; }

    public string? Name { get; init; }
    public string? Location { get; init; }
}

public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Departments
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;
        entity.Location = request.Location;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
