using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using System.Diagnostics.CodeAnalysis;

namespace Infra.Repositories;

[ExcludeFromCodeCoverage]
public class TransactionRepository : GenericRepository<TransactionEntity>, ITransactionRepository
{
    public TransactionRepository(PurchaseAppDbContext context) : base(context)
    {
    }
}
