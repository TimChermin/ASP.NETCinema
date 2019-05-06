using ASPNETCinema.Models;
using ASPNETCinema.ViewModels;
using AutoMapper;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace ASPNETCinema
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<EmployeeViewModel, EmployeeModel>();
            CreateMap<EmployeeModel, EmployeeViewModel>();

            CreateMap<HallViewModel, HallModel>();
            CreateMap<HallModel, HallViewModel>();

            CreateMap<MovieViewModel, MovieModel>();
            CreateMap<MovieModel, MovieViewModel>();
            CreateMap<IMovie, MovieViewModel>();

            CreateMap<ScreeningViewModel, ScreeningModel>();
            CreateMap<ScreeningModel, ScreeningViewModel>();

            CreateMap<TaskViewModel, TaskModel>();
            CreateMap<TaskModel, TaskViewModel>();

            CreateMap<UserViewModel, UserModel>();
            CreateMap<UserModel, UserViewModel>();
        }
    }
}
