using System.Collections.ObjectModel;

namespace Domain.Entities;

public class AppEntity : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Collection<PurchaseEntity> Purchases { get; set; } = new Collection<PurchaseEntity>();
}
