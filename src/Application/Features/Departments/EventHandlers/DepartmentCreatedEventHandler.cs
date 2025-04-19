using HrmBaharu.Domain.Events;
using Microsoft.Extensions.Logging;

namespace HrmBaharu.Application.Features.Departments.EventHandlers;

public class DepartmentCreatedEventHandler : INotificationHandler<DepartmentCreatedEvent>
{
    private readonly ILogger<DepartmentCreatedEventHandler> _logger;

    public DepartmentCreatedEventHandler(ILogger<DepartmentCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(DepartmentCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("HrmBaharu Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
