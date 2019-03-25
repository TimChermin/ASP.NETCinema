using DAL;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Screening.MockContext
{
    class ScreeningContextMock : IScreeningContext
    {
        public void AddScreening(IScreening screening)
        {
            throw new NotImplementedException();
        }

        public void DeleteScreening(int id)
        {
            throw new NotImplementedException();
        }

        public void EditScreening(IScreening screening)
        {
            throw new NotImplementedException();
        }

        public IHall GetHall(int idHall)
        {
            throw new NotImplementedException();
        }

        public IMovie GetMovie(int idMovie)
        {
            throw new NotImplementedException();
        }

        public IScreening GetScreeningById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IScreening> GetScreenings()
        {
            throw new NotImplementedException();
        }
    }
}
