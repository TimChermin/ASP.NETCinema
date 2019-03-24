using DAL;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Hall.MockContext
{
    class HallContextMock : IHallContext
    {
        public void AddHall(IHall hall)
        {
            throw new NotImplementedException();
        }

        public void DeleteHall(int id)
        {
            throw new NotImplementedException();
        }

        public void EditHall(IHall hall)
        {
            throw new NotImplementedException();
        }

        public IHall GetHallById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IHall> GetHalls()
        {
            throw new NotImplementedException();
        }
    }
}
