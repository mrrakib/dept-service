using HrmBaharu.Domain.Entities;

namespace HrmBaharu.Application.Features.Companies.Queries.GetCompaniesWithPagination;

public class CompanyDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Address { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Company, CompanyDto>();
        }
    }
}

