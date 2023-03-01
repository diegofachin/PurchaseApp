using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;

namespace Infra.Repositories;

public class AppRepository : GenericRepository<AppEntity>, IAppRepository
{
    public AppRepository(PurchaseAppDbContext context) : base(context)
    {
    }
}
