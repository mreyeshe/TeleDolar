// <copyright file="RemesasRepository.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

namespace Infrastructure.Data.Repositories;

/// <summary>
/// Repository for remesas.
/// </summary>
public class RemesasRepository : RepositoryBase<Remesa>
        , IRemesasRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RemesasRepository"/> class.
    /// Remesas repository.
    /// </summary>
    /// <param name="dbContext">Ef context object.</param>
    public RemesasRepository(EFContext dbContext)
        : base(dbContext)
    {
    }
}