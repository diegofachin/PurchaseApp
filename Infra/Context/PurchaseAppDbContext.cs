using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Context;

public class PurchaseAppDbContext : DbContext
{
    public PurchaseAppDbContext(DbContextOptions<PurchaseAppDbContext> options) : base(options)
    {

    }

    public DbSet<AppEntity> Apps { get; set; }

    public DbSet<TransactionEntity> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(PurchaseAppDbContext).Assembly);
    }
}
