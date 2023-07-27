// <copyright file="BaseService.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

namespace API.Services;

/// <summary>
/// Base Service Class.
/// </summary>
public class BaseService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseService"/> class.
    /// </summary>
    /// <param name="unitOfWork">Unit of Work.</param>
    public BaseService(IUnitOfWork unitOfWork)
    {
        this.UnitOfWork = unitOfWork;
    }

    /// <summary>
    /// Gets Unit of Work interface.
    /// </summary>
    protected internal IUnitOfWork UnitOfWork { get; }
}