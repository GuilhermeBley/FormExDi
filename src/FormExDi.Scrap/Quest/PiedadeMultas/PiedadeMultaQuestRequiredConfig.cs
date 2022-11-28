using BlScraper.DependencyInjection.ConfigureModel;
using FormExDi.Application.Model;
using FormExDi.Application.Repository;
using FormExDi.Application.Args;

namespace FormExDi.Scrap.Quest.PiedadeMultas;

public class PiedadeMultaQuestRequiredConfig : RequiredConfigure<PiedadeMultaQuest, VehicleModel>
{
    public override int initialQuantity => _initArgs.QuantityToRunQuest;

    private readonly IVehicleRepository _vehicleRepository;
    private readonly IInitArgs _initArgs;

    public PiedadeMultaQuestRequiredConfig(IVehicleRepository vehicleRepository, IInitArgs initArgs)
    {
        _vehicleRepository = vehicleRepository;
        _initArgs = initArgs;
    }

    public override async Task<IEnumerable<VehicleModel>> GetData()
    {
        return await _vehicleRepository.GetByUf("SP");
    }
}