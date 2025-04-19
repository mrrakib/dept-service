using HrmBaharu.Application.Common.Interfaces;
using HrmBaharu.Domain.Events;

namespace HrmBaharu.Application.Features.Companies.Commands.DeleteCompany;

public record DeleteCompanyCommand(int Id) : IRequest;

public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCompanyCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Companies
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Companies.Remove(entity);

        entity.AddDomainEvent(new CompanyDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
