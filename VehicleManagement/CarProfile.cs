using AutoMapper;
using VehicleManagement.DataAcess.Entities;

namespace VehicleManagement
{
    public class CarProfile: Profile 
    {
        public CarProfile()
        {
            CreateMap<Car, CarViewModel>()
                    .ForMember(dest =>
                        dest.SpecificationId,
                        opt => opt.MapFrom(src => src.Specs.SpecificationId))

                    .ForMember(dest =>
                        dest.BodyType,
                        opt => opt.MapFrom(src => src.Specs.BodyType))
                    .ForMember(dest =>
                        dest.Doors,
                        opt => opt.MapFrom(src => src.Specs.Doors))

                    .ForMember(dest =>
                        dest.Engine,
                        opt => opt.MapFrom(src => src.Specs.Engine))
                    .ForMember(dest =>
                        dest.VehicleType,
                        opt => opt.MapFrom(src => src.Specs.VehicleType)).ReverseMap();
                    
        }
    }
}
