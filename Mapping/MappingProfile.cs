using ASPNETCinema.Models;
using ASPNETCinema.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;


namespace Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<EmployeeViewModel, EmployeeModel>();
            CreateMap<EmployeeModel, EmployeeViewModel>();
        }
    }
}
