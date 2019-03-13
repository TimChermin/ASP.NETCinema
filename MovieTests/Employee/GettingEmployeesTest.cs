using ASPNETCinema.Controllers;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Employee
{
    public class GettingEmployeesTest
    {
        EmployeeLogic employeeLogic = new EmployeeLogic();
        EmployeeController employeeController = new EmployeeController();
        List<EmployeeModel> employees = new List<EmployeeModel>();
        List<EmployeeModel> employee2 = new List<EmployeeModel>();
        ThingEqualityComparer comparer = new ThingEqualityComparer();

        [Fact]
        public void Should_ReturnTheMovieWithTHeSameId_WhenLoadingMovieDetials()
        {
            //Arrange
            employees = employeeLogic.GetEmployees();

            //Act
            int matchCount = 0;
            foreach (var employee in employees)
            {
                foreach (var employee2 in employeeLogic.GetEmployees())
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
