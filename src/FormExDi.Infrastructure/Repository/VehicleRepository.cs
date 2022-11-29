using AutoMapper;
using FormExDi.Application.Model;
using FormExDi.Core.Model;

namespace FormExDi.Infrastructure.Repository
{
    internal class VehicleRepository : BaseRepository, IVehicleRepository
    {
        public VehicleRepository(IDbSession dbSession, IMapper mapper) : base(dbSession, mapper)
        {
        }

        public async Task<VehicleModel> AddAsync(Vehicle entity)
        {
            return
                await _dbConnection.QueryFirstAsync<VehicleModel>(
                    "INSERT INTO vehicle.vehicle (Renavam, Plate, Uf) VALUES (@Renavam, @Plate, @Uf);" +
                    "SELECT Renavam, Plate, Uf FROM vehicle.vehicle WHERE Renavam = @Renavam;",
                    _mapper.Map<VehicleModel>(entity),
                    _dbTransaction
                );
        }

        public async Task<VehicleModel> DeleteAsync(string id)
        {
            return
                await _dbConnection.QueryFirstAsync<VehicleModel>(
                    "SELECT Renavam, Plate, Uf FROM vehicle.vehicle WHERE Renavam = @Renavam;" +
                    "DELETE FROM vehicle.vehicle WHERE Renavam = @Renavam;",
                    new { Renavam = id },
                    _dbTransaction
                );
        }

        public async Task<IEnumerable<VehicleModel>> GetAllAsync()
        {
            return
                await _dbConnection.QueryAsync<VehicleModel>(
                    "SELECT Renavam, Plate, Uf FROM vehicle.vehicle;",
                    _dbTransaction
                );
        }

        public async Task<VehicleModel?> GetByIdAsync(string id)
        {
            return
                await _dbConnection.QueryFirstAsync<VehicleModel?>(
                    "SELECT Renavam, Plate, Uf FROM vehicle.vehicle WHERE Renavam = @Renavam;",
                    new { Renavam = id },
                    _dbTransaction
                );
        }

        public async Task<IEnumerable<VehicleModel>> GetByUf(string uf)
        {
            return
                await _dbConnection.QueryAsync<VehicleModel>(
                    "SELECT Renavam, Plate, Uf FROM vehicle.vehicle WHERE Uf = @Uf;",
                    new { Uf = uf },
                    _dbTransaction
                );
        }

        public async Task<VehicleModel> UpdateAsync(Vehicle entity)
        {
            return
               await _dbConnection.QueryFirstAsync<VehicleModel>(
                   @"UPDATE vehicle.vehicle
                    SET Plate = @Plate, Uf = @Uf
                    WHERE Renavam = @Renavam;" +
                   "SELECT Renavam, Plate, Uf FROM vehicle.vehicle WHERE Renavam = @Renavam;",
                   _mapper.Map<VehicleModel>(entity),
                   _dbTransaction
               );
        }
    }
}
