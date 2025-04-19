namespace HrmBaharu.Domain.Events;

public class CompanyDeletedEvent : BaseEvent
{
    public CompanyDeletedEvent(Company item)
    {
        Item = item;
    }

    public Company Item { get; }
}
