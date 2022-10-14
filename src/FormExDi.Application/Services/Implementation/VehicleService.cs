using AutoMapper;
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
    private readonly IMapper _mapper;

    public VehicleService(
        IUnitOfWork uow,
        IVehicleRepository vehicleRepository,
        IMapper mapper)
    {
        _uow = uow;
        _vehicleRepository = vehicleRepository;
        _mapper = mapper;
    }

    public async Task<IResultGeneric<VehicleModel>> AddAsync(VehicleModel vehicle)
    {
        var resultVehicle
            = Vehicle.Create(vehicle.Renavam, vehicle.Plate, vehicle.Uf);

        if (resultVehicle.HasError)
            return ResultGeneric<VehicleModel>.Bad(resultVehicle.Messages);

        VehicleModel modelAdded;
        var vehicleEntity = resultVehicle.GetResult();
        using (await _uow.BeginTransactionAsync())
        {
            if ((await _vehicleRepository.GetByIdAsync(vehicleEntity.Renavam)) is not null)
                return ResultGeneric<VehicleModel>.Conflict();

            modelAdded = await _vehicleRepository.AddAsync(vehicleEntity);

            await _uow.SaveChangesAsync();
        }

        return ResultGeneric<VehicleModel>.Ok(modelAdded);
    }

    public async Task<IResultGeneric<VehicleModel>> DeleteAsync(string renavam)
    {
        if (!Valid.IsRenavamBrl(renavam, out string? renavamOut) || renavamOut is null)
            return ResultGeneric<VehicleModel>.Bad("Invalid renavam.");

        VehicleModel modelRemoved;
        using (await _uow.BeginTransactionAsync())
        {
            if ((await _vehicleRepository.GetByIdAsync(renavamOut)) is null)
                return ResultGeneric.NotFound();

            modelRemoved = await _vehicleRepository.DeleteAsync(renavamOut);

            await _uow.SaveChangesAsync();
        }

        return ResultGeneric<VehicleModel>.Ok(modelRemoved);
    }

    public async Task<IResultGeneric<IEnumerable<VehicleModel>>> GetAsync()
    {
        if (!Valid.IsRenavamBrl(renavam, out string? renavamOut) || renavamOut is null)
            return ResultGeneric<VehicleModel>.Bad("Invalid renavam.");

        VehicleModel? modelRemoved;

        using (await _uow.OpenConnectionAsync())
            modelRemoved = await _vehicleRepository.GetByIdAsync(renavamOut);

        if (modelRemoved is null)
            return ResultGeneric<VehicleModel>.NotFound();

        return ResultGeneric<VehicleModel>.Ok(modelRemoved);
    }

    public async Task<IResultGeneric<VehicleModel>> GetByRenavamAsync(string renavam)
    {
        if (!Valid.IsRenavamBrl(renavam, out string? renavamOut) || renavamOut is null)
            return ResultGeneric<VehicleModel>.Bad("Invalid renavam.");

        VehicleModel? modelRemoved;

        using (await _uow.OpenConnectionAsync())
            modelRemoved = await _vehicleRepository.GetByIdAsync(renavamOut);
        
        if (modelRemoved is null)
            return ResultGeneric<VehicleModel>.NotFound();

        return ResultGeneric<VehicleModel>.Ok(modelRemoved);
    }

    public async Task<IResultGeneric<VehicleModel>> UpdateAsync(string renavam, VehicleModel vehicle)
    {
        throw new NotImplementedException();
    }
}
