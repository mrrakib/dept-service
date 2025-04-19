namespace HrmBaharu.Domain.Entities
{
    public class Department : BaseAuditableEntity
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
    }
}
