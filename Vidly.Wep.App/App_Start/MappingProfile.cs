using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Wep.App.DTO;
using Vidly.Wep.App.Models;

namespace Vidly.Wep.App.App_Start
{
    public class MappingProfile : Profile
    {
       
        public MappingProfile()
        {
            //Domain To Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MemberShipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            //Dto To Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            //Mapper.CreateMap<MemberShipTypeDto, MembershipType>()
            //    .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}