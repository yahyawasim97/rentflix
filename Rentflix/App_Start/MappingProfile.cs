using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Rentflix.Dtos;
using Rentflix.Models;

namespace Rentflix.App_Start
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore()); ;
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}