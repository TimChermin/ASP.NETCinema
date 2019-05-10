using ASPNETCinema.Models;
using ASPNETCinema.ViewModels;
using AutoMapper;
using DAL.Dtos;
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
            CreateMap<EmployeeModel, EmployeeDto>();
            CreateMap<EmployeeDto, EmployeeModel>();

            CreateMap<HallViewModel, HallModel>();
            CreateMap<HallModel, HallViewModel>();
            CreateMap<HallModel, HallDto>();
            CreateMap<HallDto, HallModel>();

            CreateMap<MovieViewModel, MovieModel>();
            CreateMap<MovieModel, MovieViewModel>();
            CreateMap<MovieModel, MovieDto>();
            CreateMap<MovieDto, MovieModel>();

            CreateMap<ScreeningViewModel, ScreeningModel>();
            CreateMap<ScreeningModel, ScreeningViewModel>();
            CreateMap<ScreeningModel, ScreeningDto>();
            CreateMap<ScreeningDto, ScreeningModel>();

            CreateMap<TaskViewModel, TaskModel>();
            CreateMap<TaskModel, TaskViewModel>();
            CreateMap<TaskModel, TaskDto>();
            CreateMap<TaskDto, TaskModel>();

            CreateMap<UserViewModel, UserModel>();
            CreateMap<UserModel, UserViewModel>();
            CreateMap<UserModel, UserDto>();
            CreateMap<UserDto, UserModel>();
        }
    }
}
