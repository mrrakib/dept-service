using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmBaharu.Domain.Entities;
public class Company : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string? Address { get; set; }
}
