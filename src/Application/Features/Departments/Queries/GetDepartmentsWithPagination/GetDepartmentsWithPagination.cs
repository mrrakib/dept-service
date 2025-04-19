using HrmBaharu.Application.Common.Interfaces;
using HrmBaharu.Application.Common.Mappings;
using HrmBaharu.Application.Common.Models;

namespace HrmBaharu.Application.Features.Departments.Queries.GetDepartmentsWithPagination
{
    public record GetDepartmentsWithPaginationQuery : IRequest<PaginatedList<DepartmentDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }

    public class GetDepartmentsWithPaginationQueryHandler : IRequestHandler<GetDepartmentsWithPaginationQuery, PaginatedList<DepartmentDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDepartmentsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<DepartmentDto>> Handle(GetDepartmentsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Departments
                .OrderBy(x => x.Name)
                .ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
