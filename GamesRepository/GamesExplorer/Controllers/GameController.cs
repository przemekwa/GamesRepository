using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesExplorer.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Games()
        {
            return View();
        }
    }
}