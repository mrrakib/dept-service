using HrmBaharu.Application.Common.Models;
using HrmBaharu.Application.Features.Companies.Commands.CreateCompany;
using HrmBaharu.Application.Features.Companies.Commands.DeleteCompany;
using HrmBaharu.Application.Features.Companies.Commands.UpdateCompany;
using HrmBaharu.Application.Features.Companies.Queries.GetCompaniesWithPagination;

namespace HrmBaharu.Web.Endpoints;

public class Companies : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetCompaniesWithPagination)
            .MapPost(CreateCompany)
            .MapPut(UpdateCompany, "{id}")
            .MapDelete(DeleteCompany, "{id}");
    }
    public Task<PaginatedList<CompanyDto>> GetCompaniesWithPagination(ISender sender, [AsParameters] GetCompaniesWithPaginationQuery query)
    {
        return sender.Send(query);
    }
    public Task<int> CreateCompany(ISender sender, CreateCompanyCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateCompany(ISender sender, int id, UpdateCompanyCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }
    public async Task<IResult> DeleteCompany(ISender sender, int id)
    {
        await sender.Send(new DeleteCompanyCommand(id));
        return Results.NoContent();
    }
}
