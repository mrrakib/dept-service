using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentProto;
using HrmBaharu.Application.Common.Interfaces;
using HrmBaharu.Domain.Entities;

namespace HrmBaharu.Application.Features.Departments.Queries
{
    public record GetAllDepartmentsQuery() : IRequest<DepartmentListReply>;

    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, DepartmentListReply>
    {
        private readonly IApplicationDbContext _dbContext;
        
        public GetAllDepartmentsQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DepartmentListReply> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = await _dbContext.Departments
                .Select(d => new DepartmentReply
                {
                    Id = d.Id,
                    Name = d.Name,
                    Location = d.Location ?? ""
                })
                .ToListAsync(cancellationToken);

            return new DepartmentListReply
            {
                Departments = { departments }
            };
        }
    }

}
