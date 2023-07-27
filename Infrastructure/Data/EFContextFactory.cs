// <copyright file="RemesaContextFactory.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data;

/// <summary>
/// Remesa Contex Class.
/// </summary>
public class EFContextFactory : IDesignTimeDbContextFactory<EFContext>
{
    public EFContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EFContext>();
        optionsBuilder.UseSqlServer(@"Data Source=LIBERO\SQLEXPRESS;Trust Server Certificate=true;Initial Catalog=TeleDolar;User ID=sa;Password=D354rr0ll0");

        return new EFContext(optionsBuilder.Options);
    }
}