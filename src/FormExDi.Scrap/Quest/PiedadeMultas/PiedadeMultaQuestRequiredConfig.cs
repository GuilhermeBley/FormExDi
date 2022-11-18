using BlScraper.DependencyInjection.ConfigureModel;
using FormExDi.Application.Model;
using FormExDi.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormExDi.Scrap.Quest.PiedadeMultas;

public class PiedadeMultaQuestRequiredConfig : RequiredConfigure<PiedadeMultaQuest, VehicleModel>
{
    public override int initialQuantity => throw new NotImplementedException();

    private readonly IVehicleRepository _vehicleRepository;

    public PiedadeMultaQuestRequiredConfig(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public override Task<IEnumerable<VehicleModel>> GetData()
    {
        throw new NotImplementedException();
    }
}

