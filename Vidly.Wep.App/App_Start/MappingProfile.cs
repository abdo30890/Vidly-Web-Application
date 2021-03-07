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
            
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MovieDto, Movie>();
            Mapper.CreateMap<Movie, MovieDto>();

        }
    }
}