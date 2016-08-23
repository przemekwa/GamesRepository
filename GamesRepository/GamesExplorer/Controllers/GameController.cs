using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamesExplorer.Models;

namespace GamesExplorer.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Games()
        {
            var gamesApi = new GamesRepository.GamesRepository();

            var model = new GameDto
            {
                Games = gamesApi.GetAll().ToList()
            };

            return View(model);
        }
    }
}