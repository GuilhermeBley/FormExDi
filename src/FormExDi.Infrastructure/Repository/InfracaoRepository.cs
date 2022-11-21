using FormExDi.Application.Model;
using FormExDi.Application.Repository;
using FormExDi.Core.Model;

namespace FormExDi.Infrastructure.Repository
{
    public class InfracaoRepository : BaseRepository, IInfracaoRepository
    {
        public InfracaoRepository(IDbSession dbSession) : base(dbSession)
        {
        }

        public Task<InfracaoModel> AddAsync(Infracao entity)
        {
            throw new NotImplementedException();
        }

        public Task<InfracaoModel> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InfracaoModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<InfracaoModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<InfracaoModel> UpdateAsync(string id, Infracao entity)
        {
            throw new NotImplementedException();
        }
    }
}
