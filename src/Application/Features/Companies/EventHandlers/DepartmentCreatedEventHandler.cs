using HrmBaharu.Domain.Events;
using Microsoft.Extensions.Logging;

namespace HrmBaharu.Application.Features.Companies.EventHandlers;

public class CompanyCreatedEventHandler : INotificationHandler<CompanyCreatedEvent>
{
    private readonly ILogger<CompanyCreatedEventHandler> _logger;

    public CompanyCreatedEventHandler(ILogger<CompanyCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CompanyCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("HrmBaharu Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
