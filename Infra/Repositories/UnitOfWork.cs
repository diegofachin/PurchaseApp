using Domain.Interfaces;
using Infra.Context;

namespace Infra.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly PurchaseAppDbContext _context;
    public IAppRepository AppRepository { get; }
    public ITransactionRepository TransactionRepository { get; }

    public UnitOfWork(PurchaseAppDbContext context, IAppRepository appRepository, ITransactionRepository transactionRepository)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        AppRepository = appRepository ?? throw new ArgumentNullException(nameof(appRepository));
        TransactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(appRepository));
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