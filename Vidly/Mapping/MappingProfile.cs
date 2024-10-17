using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>().ForMember(dest => dest.Id, opt => opt.Ignore());
       
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>().ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
