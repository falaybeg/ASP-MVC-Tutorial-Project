using System;
using System.Linq;
using System.Web;
using AutoMapper;
using ExamplesApp.Models;
using ExamplesApp.DTOs;

namespace ExamplesApp.App_Start
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<MemberShipType, MemberShipTypeDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<Rental, RentalDto>();

            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
       
            Mapper.CreateMap<Movie, MovieDto>()
                .ForMember(c => c.Id, opt => opt.Ignore());


        }

    }
}