using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentProto;
using HrmBaharu.Application.Common.Interfaces;
using HrmBaharu.Application.Services;
using HrmBaharu.Domain.Entities;

namespace HrmBaharu.Application.Features.Companies.Queries
{
    public record GetAllCompaniesQuery() : IRequest<CompanyList>;

    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllCompaniesQuery, CompanyList>
    {
        private readonly IApplicationDbContext _dbContext;
        
        public GetAllDepartmentsQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CompanyList> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _dbContext.Companies
                .Select(d => new CompanyReply
                {
                    Id = d.Id,
                    Name = d.Name,
                    Address = d.Address ?? ""
                })
                .ToListAsync(cancellationToken);

            return new CompanyList
            {
                Companies = { companies }
            };
        }
    }

}
