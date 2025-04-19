using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentProto;
using Grpc.Core;
using HrmBaharu.Application.Common.Interfaces;
using HrmBaharu.Application.Services;

namespace HrmBaharu.Application.Features.Companies.Queries;

public record GetCompanyByIdQuery(int Id) : IRequest<CompanyReply>;

public class GetDepartmentByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, CompanyReply>
{
    private readonly IApplicationDbContext _dbContext;

    public GetDepartmentByIdQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CompanyReply> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var company = await _dbContext.Companies
            .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);

        if (company == null)
            throw new RpcException(new Status(StatusCode.NotFound, "Company not found"));

        return new CompanyReply
        {
            Id = company.Id,
            Name = company.Name,
            Address = company.Address
        };
    }
}
