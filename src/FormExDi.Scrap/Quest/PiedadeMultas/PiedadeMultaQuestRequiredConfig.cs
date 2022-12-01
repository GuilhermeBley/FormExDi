using BlScraper.DependencyInjection.ConfigureModel;
using FormExDi.Application.Model;
using FormExDi.Application.Repository;
using FormExDi.Application.Args;
using FormExDi.Application.Services.Interface;

namespace FormExDi.Scrap.Quest.PiedadeMultas;

public class PiedadeMultaQuestRequiredConfig : RequiredConfigure<PiedadeMultaQuest, VehicleModel>
{
    public override int initialQuantity => _initArgs.QuantityToRunQuest;

    private readonly IVehicleService _vehicleRepository;
    private readonly IInitArgs _initArgs;

    public PiedadeMultaQuestRequiredConfig(IVehicleService vehicleService, IInitArgs initArgs)
    {
        _vehicleRepository = vehicleService;
        _initArgs = initArgs;
    }

    public override async Task<IEnumerable<VehicleModel>> GetData()
    {
        return await _vehicleRepository.GetByUf("SP");
    }
}