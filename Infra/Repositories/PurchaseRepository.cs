using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories;

[ExcludeFromCodeCoverage]
public class PurchaseRepository : GenericRepository<PurchaseEntity>, IPurchaseRepository
{
    public PurchaseRepository(PurchaseAppDbContext context) : base(context)
    {
    }
}
