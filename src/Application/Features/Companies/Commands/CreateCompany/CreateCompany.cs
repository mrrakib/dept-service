using HrmBaharu.Application.Common.Interfaces;
using HrmBaharu.Domain.Entities;
using HrmBaharu.Domain.Events;

namespace HrmBaharu.Application.Features.Companies.Commands.CreateCompany;

public record CreateCompanyCommand : IRequest<int>
{
    public string Name { get; init; } = null!;
    public string? Address { get; init; }
}

public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCompanyCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = new Company
        {
            Name = request.Name,
            Address = request.Address,
        };

        entity.AddDomainEvent(new CompanyCreatedEvent(entity));

        _context.Companies.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
