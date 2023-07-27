// <copyright file="RemesaConfiguration.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

internal class RemesaConfiguration : IEntityTypeConfiguration<Remesa>
{
    public void Configure(EntityTypeBuilder<Remesa> builder)
    {
        builder.Ignore(x=>x.Events);
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique();
        builder.HasIndex(x => x.NombreRemitente);
        builder.HasIndex(x => x.NombreBeneficiario);
    }
}