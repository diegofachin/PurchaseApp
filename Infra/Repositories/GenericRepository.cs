﻿using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Infra.Repositories;

[ExcludeFromCodeCoverage]
public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly PurchaseAppDbContext _context;

    protected GenericRepository(PurchaseAppDbContext context)
    {
        _context = context;
    }

    public async Task<T> Get(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}
