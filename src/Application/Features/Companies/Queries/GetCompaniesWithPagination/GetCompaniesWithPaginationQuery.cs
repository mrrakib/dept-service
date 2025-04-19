using HrmBaharu.Application.Common.Interfaces;
using HrmBaharu.Application.Common.Mappings;
using HrmBaharu.Application.Common.Models;

namespace HrmBaharu.Application.Features.Companies.Queries.GetCompaniesWithPagination
{
    public record GetCompaniesWithPaginationQuery : IRequest<PaginatedList<CompanyDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }

    public class GetCompaniesWithPaginationQueryHandler : IRequestHandler<GetCompaniesWithPaginationQuery, PaginatedList<CompanyDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCompaniesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CompanyDto>> Handle(GetCompaniesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Companies
                .OrderBy(x => x.Name)
                .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
