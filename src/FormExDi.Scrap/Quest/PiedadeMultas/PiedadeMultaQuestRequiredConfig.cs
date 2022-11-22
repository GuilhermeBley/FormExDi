using BlScraper.DependencyInjection.ConfigureModel;
using FormExDi.Application.Model;
using FormExDi.Application.Repository;
using FormExDi.Scrap.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public override Task<IEnumerable<VehicleModel>> GetData()
    {
        throw new NotImplementedException();
    }
}

