// <copyright file="EFContext.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data;

/// <summary>
/// Ef Contex Class.
/// </summary>
public class EFContext : DbContext
{
    /// <summary>
    /// Gets or sets remesa Object.
    /// </summary>
    public virtual DbSet<Remesa> Remesa { get; set; }

    ///// <summary>
    ///// Gets or sets Base Domain Object.
    ///// </summary>
    //public virtual DbSet<BaseDomainEvent> BaseDomain { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EFContext"/> class.
    /// Constructor db context options.
    /// </summary>
    /// <param name="options">DB EF options.</param>
    public EFContext(DbContextOptions<EFContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFContext).Assembly);
    }
}