using BlScraper.DependencyInjection.ConfigureModel;
using BlScraper.Model;
using FormExDi.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormExDi.Scrap.Quest.PiedadeMultas;

public class PiedadeMultaQuest : Quest<VehicleModel>
{
    public override QuestResult Execute(VehicleModel data, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}

