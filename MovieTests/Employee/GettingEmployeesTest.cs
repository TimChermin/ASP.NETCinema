using ASPNETCinema.Controllers;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using Interfaces;
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
        ThingEqualityComparer comparer = new ThingEqualityComparer();
        List<IEmployee> employees = new List<IEmployee>();
        List<IEmployee> employees2 = new List<IEmployee>();

        public GettingEmployeesTest()
        {
            _employeeLogic = new EmployeeLogic(new EmployeeContextMock());
        }

        [Fact]
        public void Should_ReturnTheSameEmployees_WhenGettingEmployees()
        {
            //Arrange
            var employeeLogic = new EmployeeLogic(new EmployeeContextMock());
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
