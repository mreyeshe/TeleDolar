// <copyright file="IUnitOfWork.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

using Core.Base;

namespace Core.Interfaces;

/// <summary>
/// Unit Of Work.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Save changes async.
    /// </summary>
    /// <returns>int of termination.</returns>
    Task<int> SaveChangesAsync();

    /// <summary>
    /// Ascyn operations.
    /// </summary>
    /// <returns>T model.</returns>
    IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity;
}