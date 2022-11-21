using AutoMapper;
using FormExDi.Application.Repository;
using FormExDi.Application.UoW;
using FormExDi.Application.Services.Interface;
using FormExDi.Application.Model;
using FormExDi.Core.Model;
using Smartec.Validations;

namespace FormExDi.Application.Services.Implementation;
public class InfracaoService : IInfracaoService
{
    private readonly IUnitOfWork _uow;
    private readonly IInfracaoRepository _infracaoRepository;

    public InfracaoService(
        IUnitOfWork uow,
        IInfracaoRepository infracaoRepository)
    {
        _uow = uow;
        _infracaoRepository = infracaoRepository;
    }

    public async Task<IResultGeneric<InfracaoModel>> AddAsync(InfracaoModel infracao)
    {
        var resultInfracao
            = Infracao.Create(infracao.Renavam, infracao.Ait, infracao.DtInfracao, infracao.Local, infracao.DtValidity);

        if (resultInfracao.HasError)
            return ResultGeneric.Bad<InfracaoModel>(resultInfracao.Messages);

        InfracaoModel modelAdded;
        var infracaoEntity = resultInfracao.GetResult();
        using (await _uow.BeginTransactionAsync())
        {
            if ((await _infracaoRepository.GetByIdAsync(infracaoEntity.Ait)) is not null)
                return ResultGeneric.Conflict<InfracaoModel>();

            modelAdded = await _infracaoRepository.AddAsync(infracaoEntity);

            await _uow.SaveChangesAsync();
        }

        return ResultGeneric.Ok(modelAdded);
    }

    public async Task<IResultGeneric<InfracaoModel>> DeleteAsync(string ait)
    {
        if (string.IsNullOrEmpty(ait))
            return ResultGeneric.Bad<InfracaoModel>("Invalid ait.");

        InfracaoModel modelRemoved;
        using (await _uow.BeginTransactionAsync())
        {
            if ((await _infracaoRepository.GetByIdAsync(ait)) is null)
                return ResultGeneric.NotFound<InfracaoModel>();

            modelRemoved = await _infracaoRepository.DeleteAsync(ait);

            await _uow.SaveChangesAsync();
        }

        return ResultGeneric.Ok(modelRemoved);
    }

    public async Task<IResultGeneric<IEnumerable<InfracaoModel>>> GetAsync()
    {
        using (await _uow.OpenConnectionAsync())
            return ResultGeneric.Ok(await _infracaoRepository.GetAllAsync());
    }

    public async Task<IResultGeneric<InfracaoModel>> GetByRenavamAsync(string ait)
    {
        if (string.IsNullOrEmpty(ait))
            return ResultGeneric.Bad<InfracaoModel>("Invalid ait.");

        InfracaoModel? modelRemoved;

        using (await _uow.OpenConnectionAsync())
            modelRemoved = await _infracaoRepository.GetByIdAsync(ait);
        
        if (modelRemoved is null)
            return ResultGeneric.NotFound<InfracaoModel>();

        return ResultGeneric.Ok(modelRemoved);
    }

    public Task<IResultGeneric<InfracaoModel>> UpdateAsync(string ait, InfracaoModel vehicle)
    {
        throw new NotImplementedException();
    }
}
