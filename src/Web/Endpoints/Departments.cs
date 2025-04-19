using HrmBaharu.Application.Common.Models;
using HrmBaharu.Application.Features.Departments.Queries.GetDepartmentsWithPagination;
using HrmBaharu.Application.Features.Departments.Commands.CreateDepartment;
using HrmBaharu.Application.Features.Departments.Commands.DeleteDepartment;
using HrmBaharu.Application.Features.Departments.Commands.UpdateDepartment;

namespace HrmBaharu.Web.Endpoints;

public class Departments : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetDepartmentsWithPagination)
            .MapPost(CreateDepartment)
            .MapPut(UpdateDepartment, "{id}")
            .MapDelete(DeleteDepartment, "{id}");
    }
    public Task<PaginatedList<DepartmentDto>> GetDepartmentsWithPagination(ISender sender, [AsParameters] GetDepartmentsWithPaginationQuery query)
    {
        return sender.Send(query);
    }
    public Task<int> CreateDepartment(ISender sender, CreateDepartmentCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateDepartment(ISender sender, int id, UpdateDepartmentCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }
    public async Task<IResult> DeleteDepartment(ISender sender, int id)
    {
        await sender.Send(new DeleteDepartmentCommand(id));
        return Results.NoContent();
    }
}
