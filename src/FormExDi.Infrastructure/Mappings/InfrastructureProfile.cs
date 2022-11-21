using AutoMapper;
using FormExDi.Application.Model;
using FormExDi.Core.Model;

namespace FormExDi.Infrastructure.Mappings
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<Vehicle, VehicleModel>();
            CreateMap<Infracao, InfracaoModel>();
        }
    }
}
