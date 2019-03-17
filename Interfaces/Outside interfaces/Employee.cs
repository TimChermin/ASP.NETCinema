using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Outside_interfaces
{
    public class Employee : IEmployee
    {
        public string GetName(int id)
        {
            return "test " + id;
        }
    }
}
