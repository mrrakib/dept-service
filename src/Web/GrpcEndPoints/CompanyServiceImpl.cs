using Grpc.Core;
using HrmBaharu.Application.Features.Companies.Queries;
using HrmBaharu.Application.Features.Departments.Queries;
using HrmBaharu.Application.Services;

namespace HrmBaharu.Web.GrpcEndPoints;

public class CompanyServiceImpl : CompanyService.CompanyServiceBase
{
    private readonly ISender _sender;

    public CompanyServiceImpl(ISender sender)
    {
        _sender = sender;
    }

    public override async Task<CompanyReply> GetCompanyById(CompanyRequest request, ServerCallContext context)
    {
        var result = await _sender.Send(new GetCompanyByIdQuery(request.Id));
        return result;
    }

    public override async Task<CompanyList> GetAllCompanies(Empty request, ServerCallContext context)
    {
        var result = await _sender.Send(new GetAllCompaniesQuery());
        return result;
    }
}
