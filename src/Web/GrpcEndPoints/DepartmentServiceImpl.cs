using DepartmentProto;
using Grpc.Core;
using HrmBaharu.Application.Features.Departments.Queries;

namespace HrmBaharu.Web.GrpcEndPoints;

public class DepartmentServiceImpl : DepartmentService.DepartmentServiceBase
{
    private readonly ISender _sender;

    public DepartmentServiceImpl(ISender sender)
    {
        _sender = sender;
    }

    public override async Task<DepartmentReply> GetDepartmentById(DepartmentRequest request, ServerCallContext context)
    {
        var result = await _sender.Send(new GetDepartmentByIdQuery(request.Id));
        return result;
    }

    public override async Task<DepartmentListReply> GetAllDepartments(Empty request, ServerCallContext context)
    {
        var result = await _sender.Send(new GetAllDepartmentsQuery());
        return result;
    }
}
