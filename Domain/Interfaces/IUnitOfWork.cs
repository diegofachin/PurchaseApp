using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IAppRepository AppRepository { get; }
    ITransactionRepository TransactionRepository { get; }

    int Commit();
}
