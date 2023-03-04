using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using System.Diagnostics.CodeAnalysis;

namespace Infra.Repositories;

[ExcludeFromCodeCoverage]
public class AppRepository : GenericRepository<AppEntity>, IAppRepository
{
    public AppRepository(PurchaseAppDbContext context) : base(context)
    {
    }
}
