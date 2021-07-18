using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Cinema_MVC.Models;
using Cinema_MVC.Dtos;

namespace Cinema_MVC.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();
        }
    }
}