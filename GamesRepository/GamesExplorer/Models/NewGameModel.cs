using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesExplorer.Models
{
    public class NewGameModel : GameModel
    {
        public List<SelectListItem> AvailableGames { get; set; }
    }
}