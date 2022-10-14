using FormExDi.Application.Model;
using FormExDi.Core.Model;

namespace FormExDi.Application.Repository
{
    public interface IVehicleRepository : IRepository<string, Vehicle, VehicleModel>
    {
    }
}
