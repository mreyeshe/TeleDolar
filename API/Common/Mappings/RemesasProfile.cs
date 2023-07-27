// <copyright file="RemesasProfile.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

using API.DTOs;
using AutoMapper;

namespace API.Common.Mappings;

/// <summary>
/// Remesas Automaper Profile Class.
/// </summary>
public class RemesasProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RemesasProfile"/> class.
    /// </summary>
    public RemesasProfile()
    {
        this.CreateMap<Remesa, RemesaDto>().ReverseMap();
        this.CreateMap<Remesa, CreateRemesaRequest>().ReverseMap();
    }
}