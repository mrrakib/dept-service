namespace HrmBaharu.Domain.Events;

public class DepartmentDeletedEvent : BaseEvent
{
    public DepartmentDeletedEvent(Department item)
    {
        Item = item;
    }

    public Department Item { get; }
}
