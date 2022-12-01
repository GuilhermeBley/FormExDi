using FormExDi.Application.Repository;
using FormExDi.Application.UoW;
using FormExDi.Application.Services.Interface;
using FormExDi.Application.Model;
using FormExDi.Core.Model;
using Smartec.Validations;

namespace FormExDi.Application.Services.Implementation;
public class VehicleService : IVehicleService
{
    private readonly IUnitOfWork _uow;
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleService(
        IUnitOfWork uow,
        IVehicleRepository vehicleRepository)
    {
        _uow = uow;
        _vehicleRepository = vehicleRepository;
    }

    public async Task<IResultGeneric<VehicleModel>> AddAsync(VehicleModel vehicle)
    {
        var resultVehicle
            = Vehicle.Create(vehicle.Renavam, vehicle.Plate, vehicle.Uf);

        if (resultVehicle.HasError)
            return ResultGeneric.Bad<VehicleModel>(resultVehicle.Messages);

        VehicleModel modelAdded;
        var vehicleEntity = resultVehicle.GetResult();
        using (await _uow.BeginTransactionAsync())
        {
            if ((await _vehicleRepository.GetByIdAsync(vehicleEntity.Renavam)) is not null)
                return ResultGeneric.Conflict<VehicleModel>();

            modelAdded = await _vehicleRepository.AddAsync(vehicleEntity);

            await _uow.SaveChangesAsync();
        }

        return ResultGeneric.Ok(modelAdded);
    }

    public async Task<IResultGeneric<VehicleModel>> DeleteAsync(string renavam)
    {
        if (!Valid.IsRenavamBrl(renavam, out string? renavamOut) || renavamOut is null)
            return ResultGeneric.Bad<VehicleModel>("Invalid renavam.");

        VehicleModel modelRemoved;
        using (await _uow.BeginTransactionAsync())
        {
            if ((await _vehicleRepository.GetByIdAsync(renavamOut)) is null)
                return ResultGeneric.NotFound<VehicleModel>();

            modelRemoved = await _vehicleRepository.DeleteAsync(renavamOut);

            await _uow.SaveChangesAsync();
        }

        return ResultGeneric.Ok(modelRemoved);
    }

    public async Task<IResultGeneric<IEnumerable<VehicleModel>>> GetAsync()
    {
        using (await _uow.OpenConnectionAsync())
            return ResultGeneric.Ok(await _vehicleRepository.GetAllAsync());
    }

    public async Task<IResultGeneric<VehicleModel>> GetByRenavamAsync(string renavam)
    {
        if (!Valid.IsRenavamBrl(renavam, out string? renavamOut) || renavamOut is null)
            return ResultGeneric.Bad<VehicleModel>("Invalid renavam.");

        VehicleModel? modelRemoved;

        using (await _uow.OpenConnectionAsync())
            modelRemoved = await _vehicleRepository.GetByIdAsync(renavamOut);
        
        if (modelRemoved is null)
            return ResultGeneric.NotFound<VehicleModel>();

        return ResultGeneric.Ok(modelRemoved);
    }

    public async Task<IEnumerable<VehicleModel>> GetByUf(string uf)
    {
        using (await _uow.OpenConnectionAsync())
            return await _vehicleRepository.GetByUf(uf);
    }

    public Task<IResultGeneric<VehicleModel>> UpdateAsync(string renavam, VehicleModel vehicle)
    {
        throw new NotImplementedException();
    }
}
