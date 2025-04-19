using HrmBaharu.Domain.Entities;

namespace HrmBaharu.Application.Features.Departments.Queries.GetDepartmentsWithPagination;

public class DepartmentDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Location { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Department, DepartmentDto>();
        }
    }
}

