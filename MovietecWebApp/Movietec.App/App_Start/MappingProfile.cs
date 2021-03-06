﻿using AutoMapper;
using Movietec.Models.DbModels;
using Movietec.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movietec.App.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Customer, CustomerDto>();
            this.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());

            this.CreateMap<Movie, MovieDto>();
            this.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}