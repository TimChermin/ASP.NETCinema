using ASPNETCinema.DAL;
using ASPNETCinema.Models;
using AutoMapper;
using DAL;
using DAL.Repository;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Logic
{
    public class HallLogic : IHallLogic
    {
        private HallRepository Repository { get; }
        private IMapper _mapper;

        public HallLogic(IHallContext context, IMapper mapper)
        {
            Repository = new HallRepository(context);
            _mapper = mapper;
        }

        public HallModel GetHallById(int id)
        {
            return _mapper.Map<HallModel>(Repository.GetHallById(id));
        }

        public List<HallModel> GetHalls()
        {
            return _mapper.Map<List<HallModel>>(Repository.GetHalls());
        }

        public void AddHall(HallModel hall)
        {
            Repository.AddHall(hall);
        }

        public void EditHall(HallModel hall)
        {
            Repository.EditHall(hall);
        }

        public void DeleteHall(int id)
        {
            Repository.DeleteHall(id);
        }


    }
}
