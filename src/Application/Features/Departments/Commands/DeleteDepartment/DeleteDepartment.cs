using HrmBaharu.Application.Common.Interfaces;
using HrmBaharu.Domain.Events;

namespace HrmBaharu.Application.Features.Departments.Commands.DeleteDepartment;

public record DeleteDepartmentCommand(int Id) : IRequest;

public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Departments
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Departments.Remove(entity);

        entity.AddDomainEvent(new DepartmentDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
