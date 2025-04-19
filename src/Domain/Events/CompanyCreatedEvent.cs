namespace HrmBaharu.Domain.Events;

public class CompanyCreatedEvent : BaseEvent
{
    public CompanyCreatedEvent(Company item)
    {
        Item = item;
    }

    public Company Item { get; }
}
