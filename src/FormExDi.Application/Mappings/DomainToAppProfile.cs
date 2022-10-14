using AutoMapper;
using FormExDi.Application.Model;
using FormExDi.Core.Model;

namespace FormExDi.Application.Mappings
{
    public class DomainToAppProfile : Profile
    {
        public DomainToAppProfile()
        {
            CreateMap<Vehicle, VehicleModel>();
            CreateMap<Infracao, InfracaoModel>();
        }
    }
}
