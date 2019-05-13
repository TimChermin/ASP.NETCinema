using ASPNETCinema;
using ASPNETCinema.Controllers;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTests.Employee.MockContext;
using Xunit;

namespace EmployeeTests
{
    public class GettingEmployeesTest
    {
        EmployeeLogic _employeeLogic;
        IMapper _mapper;
        ThingEqualityComparer comparer = new ThingEqualityComparer();
        List<EmployeeModel> employees = new List<EmployeeModel>();
        List<EmployeeModel> employees2 = new List<EmployeeModel>();

        public GettingEmployeesTest()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = mockMapper.CreateMapper();
            _employeeLogic = new EmployeeLogic(new EmployeeContextMock(), _mapper);
        }

        [Fact]
        public void Should_ReturnTheSameEmployees_WhenGettingEmployees()
        {
            //Arrange
            var employeeLogic = new EmployeeLogic(new EmployeeContextMock(), _mapper);
            employees = employeeLogic.GetEmployees().ToList();
            employees2 = employeeLogic.GetEmployees().ToList();

            //Act
            int matchCount = 0;
            foreach (var employee in employees)
            {
                foreach (var employee2 in employees2)
                {
                    if (comparer.Equals(employee, employee2))
                    {
                        matchCount++;
                    }
                }
            }

            //Assert
            Assert.Equal(employees.Count, matchCount);
        }

        class ThingEqualityComparer : IEqualityComparer<EmployeeModel>
        {
            public bool Equals(EmployeeModel x, EmployeeModel y)
            {
                if (x == null || y == null)
                    return false;

                return (x.Id == y.Id && x.Name == y.Name);
            }

            public int GetHashCode(EmployeeModel obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
