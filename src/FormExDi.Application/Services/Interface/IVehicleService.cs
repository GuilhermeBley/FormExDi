using FormExDi.Application.Model;

namespace FormExDi.Application.Services.Interface;

public interface IVehicleService
{
    Task<IResultGeneric<VehicleModel>> AddAsync(VehicleModel vehicle);
    Task<IResultGeneric<VehicleModel>> UpdateAsync(string renavam, VehicleModel vehicle);
    Task<IResultGeneric<VehicleModel>> DeleteAsync(string renavam);
    Task<IResultGeneric<IEnumerable<VehicleModel>>> GetAsync();
    Task<IResultGeneric<VehicleModel>> GetByRenavamAsync(string renavam);
    Task<IEnumerable<VehicleModel>> GetByUf(string uf);
}

