using HrmBaharu.Application.Common.Interfaces;

namespace HrmBaharu.Application.Features.Companies.Commands.UpdateCompany;

public record UpdateCompanyCommand : IRequest
{
    public int Id { get; init; }

    public string Name { get; init; } = null!;
    public string? Address { get; init; }
}

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCompanyCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Companies
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;
        entity.Address = request.Address;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
