using Domain.Interfaces;
using Infra.Context;
using System.Diagnostics.CodeAnalysis;

namespace Infra.Repositories;

[ExcludeFromCodeCoverage]
public class UnitOfWork : IUnitOfWork
{
    private readonly PurchaseAppDbContext _context;
    public IAppRepository AppRepository { get; }
    public IPurchaseRepository PurchaseRepository { get; }
    public ITransactionRepository TransactionRepository { get; }

    public UnitOfWork(PurchaseAppDbContext context, IAppRepository appRepository, IPurchaseRepository purchaseRepository, ITransactionRepository transactionRepository)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        AppRepository = appRepository ?? throw new ArgumentNullException(nameof(appRepository));
        PurchaseRepository = purchaseRepository ?? throw new ArgumentNullException(nameof(purchaseRepository));
        TransactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
    }

    public int Commit()
    {
        return _context.SaveChanges();
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }
}