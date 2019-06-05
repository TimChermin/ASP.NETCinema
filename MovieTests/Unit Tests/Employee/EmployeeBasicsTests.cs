using ASPNETCinema;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTests.Employee.MockContext;
using Xunit;

namespace EmployeeTests
{
    public class EmployeeBasicsTests
    {
        EmployeeLogic employeeLogic;
        IMapper _mapper;
        

        public EmployeeBasicsTests()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = mockMapper.CreateMapper();
            employeeLogic = new EmployeeLogic(new EmployeeContextMock(), _mapper);
        }

        [Fact]
        public void Should_AddAnEmployee_WhenAddingAnEmployee()
        {
            //Arrange
            EmployeeModel employee = new EmployeeModel(10, "TimAddTest");

            //Act
            employeeLogic.AddEmployee(employee);
            
            //Assert
            Assert.True(employeeLogic.GetEmployeeById(10).Name == "TimAddTest");
        }

        [Fact]
        public void Should_GetEmployeesFromTheList_WhenGettingEmployees()
        {
            //Arrange
            EmployeeModel employee = new EmployeeModel(10, "TimGetTest");
            employeeLogic.AddEmployee(employee);
            bool found = false;

            //Act
            if (employeeLogic.GetEmployees()[4].Id == 10 && employeeLogic.GetEmployees()[4].Name == "TimGetTest")
            {
                found = true;
            }
            
            //Assert
            Assert.True(found);
        }
        

        [Fact]
        public void Should_EditAnEmployee_WhenEditingAnEmployee()
        {
            //Arrange
            List<EmployeeModel> employees = new List<EmployeeModel>();
            employees = employeeLogic.GetEmployees().ToList();
            EmployeeModel employee = new EmployeeModel(1, "TimEditTest");

            //Act
            employeeLogic.EditEmployee(employee);
            
            //Assert
            Assert.True(employeeLogic.GetEmployees()[0].Name == "TimEditTest");
        }

        [Fact]
        public void Should_ReturnAEmployee_WhenGettingAEmployeeById()
        {
            //Arrange
            employeeLogic.AddEmployee(new EmployeeModel(5, "GetByIdTest"));

            //Act
            EmployeeModel employee = employeeLogic.GetEmployeeById(5);

            //Assert
            Assert.True(employee.Id == 5 && employee.Name == "GetByIdTest");
        }

        [Fact]
        public void Should_DeleteAnEmployee_WhenDeleteingAnEmployee()
        {
            //Arrange
            List<EmployeeModel> employees = new List<EmployeeModel>();
            employees = employeeLogic.GetEmployees().ToList();
            string name = employees[0].Name;

            //Act
            employeeLogic.DeleteEmployee(employees[0].Id);
            
            //Assert
            Assert.False(employees[0].Name != name);
        }

        
    }
}
