using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Context;

[ExcludeFromCodeCoverage]
public class PurchaseAppDbContext : DbContext
{
    public PurchaseAppDbContext(DbContextOptions<PurchaseAppDbContext> options) : base(options)
    {

    }

    public DbSet<AppEntity> App { get; set; }

    public DbSet<PurchaseEntity> Purchase { get; set; }

    public DbSet<TransactionEntity> Transaction { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(PurchaseAppDbContext).Assembly);
    }
}
