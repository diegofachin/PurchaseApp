using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities;

[ExcludeFromCodeCoverage]
public class PurchaseEntity : BaseEntity
{
    public Guid PersonId { get; set; }

    public Guid AppId { get; set; }

    public Guid TransactionId { get; set; }

    public virtual AppEntity App { get; set; }

    public virtual TransactionEntity Transaction { get; set; }
}
