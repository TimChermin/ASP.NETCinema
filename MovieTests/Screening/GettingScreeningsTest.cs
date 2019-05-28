using ASPNETCinema;
using ASPNETCinema.Controllers;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using AutoMapper;
using DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTests;
using UnitTests.Screening.MockContext;
using Xunit;

namespace ScreeningTests
{
    /*
     * 
     * 
     * TEST VANUIT DE CONTROLLER NAAR DE LOGIC OMDAT ZE DAT WILLEN?
     * 
     * 
     * 
     */
    public class GettingScreeningsTest
    {
        ScreeningLogic _screeningLogic;
        IMapper _mapper;
        ThingEqualityComparer comparer = new ThingEqualityComparer();
        List<ScreeningModel> screenings = new List<ScreeningModel>();
        List<ScreeningModel> screenings2 = new List<ScreeningModel>();

        public GettingScreeningsTest()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = mockMapper.CreateMapper();

            _screeningLogic = new ScreeningLogic(new ScreeningContextMock(), _mapper);
        }
        

            [Fact]
        public void Should_ReturnAListOfScreenings_WhenLoadingScreenings()
        {
            //Arrange
            var screeningLogic = new ScreeningLogic(new ScreeningContextMock(), _mapper);
            screenings = _screeningLogic.GetScreenings().ToList();
            screenings2 = _screeningLogic.GetScreenings().ToList();

            //Act
            Assert.True(AreTheyInTheSameOrder(screenings, screenings2));
        }

        [Fact]
        public void Should_AddAScreeningToTheList_WhenAddingAScreening()
        {
            var screeningLogic = new ScreeningLogic(new ScreeningContextMock(), _mapper);
            //var result =  screeningLogic.GetAllCustomers();
            screenings = screeningLogic.GetScreenings().ToList();
            screeningLogic.AddScreening(new ScreeningModel { Id = 3, MovieId = 3, HallId = 3, DateOfScreening = new DateTime(2020, 1, 1), TimeOfScreening = new TimeSpan(1, 0, 0) });
            screenings2 = screeningLogic.GetScreenings().ToList();

            Assert.True(screenings.Count() != screenings2.Count());
        }

        [Fact]
        public void Should_NotAddAScreeningToTheList_WhenAddingAScreeningOnTheSameTimeInTheSameHall()
        {
            var screeningLogic = new ScreeningLogic(new ScreeningContextMock(), _mapper);
            ScreeningDto screening = new ScreeningDto
            {
                Id = 2,
                MovieId = 1,
                HallId = 1,
                DateOfScreening = new DateTime(2020, 1, 1),
                TimeOfScreening = new TimeSpan(1, 0, 0)
            };
            ScreeningDto screening2 = new ScreeningDto
            {
                Id = 2,
                MovieId = 1,
                HallId = 1,
                DateOfScreening = new DateTime(2020, 1, 1),
                TimeOfScreening = new TimeSpan(4, 0, 0)
            };

            Assert.False(screeningLogic.IsThisDateAndTimeAvailable(screening.HallId, screening.DateOfScreening, screening.TimeOfScreening, screening.MovieId, screening.Id));
            Assert.True(screeningLogic.IsThisDateAndTimeAvailable(screening2.HallId, screening2.DateOfScreening, screening2.TimeOfScreening, screening2.MovieId, screening2.Id));

        }

        [Fact]
        public void Should_ReturnAScreening_WhenGettingAScreeningById()
        {
            var screeningLogic = new ScreeningLogic(new ScreeningContextMock(), _mapper);
            ScreeningModel screening = new ScreeningModel
            {
                Id = 2,
                MovieId = 1,
                HallId = 1,
                DateOfScreening = new DateTime(2020, 1, 1),
                TimeOfScreening = new TimeSpan(1, 0, 0)
            };
            Assert.True(null == screeningLogic.GetScreeningById(2));

            screeningLogic.AddScreening(screening);
            ScreeningModel getscreening = screeningLogic.GetScreeningById(2);


            Assert.Equal(2, getscreening.Id);
        }




        public bool AreTheyInTheSameOrder(List<ScreeningModel> screenings, List<ScreeningModel> screenings2)
        {
            bool found;
            int screeningNr = 0;
            int screening2Nr = 0;
            foreach (var screening in screenings)
            {
                screening2Nr = 0;
                found = false;
                foreach (var screening2 in screenings2)
                {
                    if (comparer.Equals(screening, screening2) && screeningNr == screening2Nr)
                    {
                        found = true;
                    }
                    screening2Nr++;
                }
                if (found == false)
                {
                    return false;
                }
                screeningNr++;
            }
            return true;
        }


        class ThingEqualityComparer : List<ScreeningModel>
        {
            public bool Equals(ScreeningModel x, ScreeningModel y)
            {
                if (x == null || y == null)
                    return false;

                return (x.Id == y.Id && x.MovieId == y.MovieId && x.HallId == y.HallId && x.DateOfScreening == y.DateOfScreening
                    && x.TimeOfScreening == y.TimeOfScreening);
            }

            public int GetHashCode(ScreeningModel obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
