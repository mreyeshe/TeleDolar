// <copyright file="UnitOfWork.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

namespace Infrastructure.Data;

/// <summary>
/// Unit of Work class.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    /// <summary>
    /// EF Context Class.
    /// </summary>
    private readonly EFContext dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
    /// </summary>
    /// <param name="dbContext">EF Db Context class.</param>
    public UnitOfWork(EFContext dbContext)
    {
        this.dbContext = dbContext;
    }

    /// <summary>
    /// Async repository Abstraction.
    /// </summary>
    /// <typeparam name="T">Tmodel.</typeparam>
    /// <returns>base repo.</returns>
    public IAsyncRepository<T> AsyncRepository<T>()
        where T : BaseEntity
    {
        return new RepositoryBase<T>(this.dbContext);
    }

    /// <summary>
    /// Save changes method.
    /// </summary>
    /// <returns>return status.</returns>
    public Task<int> SaveChangesAsync()
    {
        return this.dbContext.SaveChangesAsync();
    }
}
