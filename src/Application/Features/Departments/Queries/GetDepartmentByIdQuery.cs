using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentProto;
using Grpc.Core;
using HrmBaharu.Application.Common.Interfaces;

namespace HrmBaharu.Application.Features.Departments.Queries;

public record GetDepartmentByIdQuery(int Id) : IRequest<DepartmentReply>;

public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentReply>
{
    private readonly IApplicationDbContext _dbContext;

    public GetDepartmentByIdQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<DepartmentReply> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
    {
        var department = await _dbContext.Departments
            .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);

        if (department == null)
            throw new RpcException(new Status(StatusCode.NotFound, "Department not found"));

        return new DepartmentReply
        {
            Id = department.Id,
            Name = department.Name,
            Location = department.Location??""
        };
    }
}
