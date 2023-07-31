// <copyright file="RemesaService.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

using API.DTOs;
using AutoMapper;
using Core.Remesas;
using System.Reflection;

namespace API.Services.Remesas;

/// <summary>
/// Remesa Service.
/// </summary>
public class RemesaService : BaseService
{
    /// <summary>
    /// Auto Mapper.
    /// </summary>
    private readonly IMapper mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="RemesaService"/> class.
    /// </summary>
    /// <param name="unitOfWork">Unit of Work.</param>
    /// <param name="mapper">Auto Mapper.</param>
    public RemesaService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork)
    {
        this.mapper = mapper;
    }

    /// <summary>
    /// Create remesa async.
    /// </summary>
    /// <param name="model">remesa request model.</param>
    /// <returns>return response from repo model.</returns>
    public async Task<CreateRemesaResponse> CreateAsync(CreateRemesaRequest model)
    {
        // You can you some mapping tools as such as AutoMapper
        var remesa = this.mapper.Map<Remesa>(model);

        var repository = this.UnitOfWork.AsyncRepository<Remesa>();
        await repository.AddAsync(remesa);
        var result = await this.UnitOfWork.SaveChangesAsync();

        var response = new CreateRemesaResponse()
        {
            Id = remesa.Id,
            Message = result == 1 ? "Ok" : "Error",
            Success = result == 1 ? true : false,
            ErrorMessage = result == 1 ? string.Empty : "Ocurrio un error al salvar la información.",
        };

        return response;
    }

    /// <summary>
    /// sdfsdf.
    /// </summary>
    /// <param name="Id">Id Request Remesa.</param>
    /// <returns>return remesa if found.</returns>
    public async Task<RemesaDto> GetAsync(int Id)
    {
        var repository = this.UnitOfWork.AsyncRepository<Remesa>();
        var remesa = await repository.GetAsync(_ => _.Id == Id);

        if (remesa != null)
        {
            return this.mapper.Map<RemesaDto>(remesa);
        }

        return new RemesaDto();
    }
}