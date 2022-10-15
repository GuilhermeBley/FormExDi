using FormExDi.Application.Model;

namespace FormExDi.Application.Services.Interface;

public interface IInfracaoService
{
    Task<IResultGeneric<InfracaoModel>> AddAsync(InfracaoModel vehicle);
    Task<IResultGeneric<InfracaoModel>> UpdateAsync(string ait, InfracaoModel vehicle);
    Task<IResultGeneric<InfracaoModel>> DeleteAsync(string ait);
    Task<IResultGeneric<IEnumerable<InfracaoModel>>> GetAsync();
    Task<IResultGeneric<InfracaoModel>> GetByRenavamAsync(string ait);
}

