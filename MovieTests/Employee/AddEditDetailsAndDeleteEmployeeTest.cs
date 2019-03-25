using ASPNETCinema.Logic;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTests.Employee.MockContext;
using Xunit;

namespace EmployeeTests
{
    public class AddEditDetailsAndDeleteEmployeeTest
    {
        EmployeeLogic _employeeLogic;
        ThingEqualityComparer comparer = new ThingEqualityComparer();
        List<IEmployee> employees = new List<IEmployee>();
        List<IEmployee> employees2 = new List<IEmployee>();

        public AddEditDetailsAndDeleteEmployeeTest()
        {
            _employeeLogic = new EmployeeLogic(new EmployeeContextMock());
        }

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        [Fact]
        public void Should_AddAnEmployeeToTheList_WhenAddingAnEmployee()
        {
            //Arrange
            var employeeLogic = new EmployeeLogic(new EmployeeContextMock());
            employees = employeeLogic.GetEmployees().ToList();
            bool found = false;
            bool count = false;

            //Act
            employeeLogic.AddEmployee(10, "Tim");
            employees2 = employeeLogic.GetEmployees().ToList();
            if (employees.Count() != employees2.Count())
            {
                count = true;
            }

            foreach (var employee in employees2)
            {
                if (employee.Id == 10 && employee.Name == "Tim")
                {
                    found = true;
                }
            }

            //Assert
            Assert.True(count);
            Assert.True(found);
        }

        [Fact]
        public void Should_GetAnEmployeeFromTheList_WhenGettingAnEmployee()
        {
            //Arrange
            var employeeLogic = new EmployeeLogic(new EmployeeContextMock());
            employees = employeeLogic.GetEmployees().ToList();
            bool found = false;
            bool count = false;

            //Act
            employeeLogic.AddEmployee(10, "Tim");
            employees2 = employeeLogic.GetEmployees().ToList();
            if (employees.Count() != employees2.Count())
            {
                count = true;
            }

            if (employeeLogic.GetEmployeeById(10).Id == 10 && employeeLogic.GetEmployeeById(10).Name == "Tim")
            {
                found = true;
            }
            

            //Assert
            Assert.True(count);
            Assert.True(found);
        }

        [Fact]
        public void Should_EditAnEmployeeFromTheList_WhenEditingAnEmployee()
        {
            //Arrange
            var employeeLogic = new EmployeeLogic(new EmployeeContextMock());
            employees = employeeLogic.GetEmployees().ToList();
            int id = employees[0].Id;
            string name = employees[0].Name;
            bool found = false;
            bool count = false;

            //Act
            employeeLogic.EditEmployee(employees[0].Id, "Edited");
            employees2 = employeeLogic.GetEmployees().ToList();

            if (employees.Count() == employees2.Count())
            {
                count = true;
            }

            foreach (var employee in employees2)
            {
                if (employee.Id == id && employee.Name == "Edited")
                {
                    found = true;
                }
            }

            //Assert
            Assert.True(count);
            Assert.True(found);
        }

        [Fact]
        public void Should_DeleteAnEmployeeFromTheList_WhenDeleteingAnEmployee()
        {
            //Arrange
            var employeeLogic = new EmployeeLogic(new EmployeeContextMock());
            employees = employeeLogic.GetEmployees().ToList();
            int id = employees[0].Id;
            string name = employees[0].Name;
            bool found = false;
            bool count = false;

            //Act
            employeeLogic.DeleteEmployee(employees[0].Id);
            employees2 = employeeLogic.GetEmployees().ToList();

            if (employees.Count() != employees2.Count())
            {
                count = true;
            }

            foreach (var employee in employees2)
            {
                if (employee.Id == id && employee.Name == name)
                {
                    found = true;
                }
            }

            Assert.False(found);
            Assert.True(count);
        }

       

        class ThingEqualityComparer : IEqualityComparer<IEmployee>
        {
            public bool Equals(IEmployee x, IEmployee y)
            {
                if (x == null || y == null)
                    return false;

                return (x.Id == y.Id && x.Name == y.Name);
            }

            public int GetHashCode(IEmployee obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
