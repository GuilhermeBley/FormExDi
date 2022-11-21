using AutoMapper;
using FormExDi.Application.Model;
using FormExDi.Core.Model;

namespace FormExDi.Infrastructure.Repository;

public class InfracaoRepository : BaseRepository, IInfracaoRepository
{
    public InfracaoRepository(IDbSession dbSession, IMapper mapper) : base(dbSession, mapper)
    {
    }

    public async Task<InfracaoModel> AddAsync(Infracao entity)
    {
        return
            await _dbConnection.QueryFirstAsync<InfracaoModel>(
                "INSERT INTO vehicle.Infracao (Ait, Renavam, DtInfracao, Local, DtValidity) VALUES (@Ait, @Renavam, @DtInfracao, @Local, @DtValidity);" +
                "SELECT Ait, Renavam, DtInfracao, Local, DtValidity FROM vehicle.Infracao WHERE Ait=@Ait;",
                _mapper.Map<InfracaoModel>(entity),
                _dbTransaction
            );
    }

    public async Task<InfracaoModel> DeleteAsync(string id)
    {
        return
            await _dbConnection.QueryFirstAsync<InfracaoModel>(
                "SELECT Ait, Renavam, DtInfracao, Local, DtValidity FROM vehicle.Infracao WHERE Ait=@Ait;" +
                "DELETE FROM Customers WHERE Ait=@Ait;",
                new { Ait = id },
                _dbTransaction
            );
    }

    public async Task<IEnumerable<InfracaoModel>> GetAllAsync()
    {
        return
            await _dbConnection.QueryAsync<InfracaoModel>(
                "SELECT Ait, Renavam, DtInfracao, Local, DtValidity FROM vehicle.Infracao;",
                _dbTransaction
            );
    }

    public async Task<InfracaoModel?> GetByIdAsync(string id)
    {
        return
            await _dbConnection.QueryFirstAsync<InfracaoModel?>(
                "SELECT Ait, Renavam, DtInfracao, Local, DtValidity FROM vehicle.Infracao WHERE Ait=@Ait;",
                new { Ait = id },
                _dbTransaction
            );
    }

    public async Task<InfracaoModel> UpdateAsync(Infracao entity)
    {

        return
            await _dbConnection.QueryFirstAsync<InfracaoModel>(
                @"UPDATE vehicle.Infracao
                SET Renavam = @Renavam, DtInfracao = @DtInfracao, Local = @Local, DtValidity = @DtValidity
                WHERE Ait=@Ait;" +
                "SELECT Ait, Renavam, DtInfracao, Local, DtValidity FROM vehicle.Infracao WHERE Ait=@Id;",
                _mapper.Map<InfracaoModel>(entity),
                _dbTransaction
            );
    }
}
