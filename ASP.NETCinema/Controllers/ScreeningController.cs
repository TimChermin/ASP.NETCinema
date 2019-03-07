using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCinema.Controllers
{
    public class ScreeningController : Controller
    {
        ScreeningLogic screeningLogic = new ScreeningLogic();
        HallModel hallModel = new HallModel();
        HallLogic hallLogic = new HallLogic();

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        public ActionResult ListScreenings()
        {
            return View(screeningLogic.GetScreenings());
        }

        public ActionResult AddScreening()
        {
            return View();
        }
        

    }
}