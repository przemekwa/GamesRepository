using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamesExplorer.Models;
using GamesRepository.Dto;

namespace GamesExplorer.Controllers
{
    public enum Platform
    {
        PC,
        PS3
    }

    public class GameController : Controller
    {
        private readonly GamesRepository.GamesRepository gamesApi;

        public GameController()
        {
            gamesApi = new GamesRepository.GamesRepository();
        }

        public ActionResult Games()
        {
            return View(gamesApi.GetAll().Select(g=>new GameModel
            {
                Title = g.Title,
                Price = g.Price,
                BuyDate = g.BuyDate,
                Platform =  (Platform)Enum.Parse(typeof(Platform),g.Platform),
                ActivationServices = g.ActivationServices.Name,
                Shop = g.Shop.Name,
                Digital = g.Digital == 1
            }));
        }

        public ActionResult NewGame()
        {
            return View(new GameModel());
        }

        public ActionResult Add(GameModel gameModel)
        {
            var game = new Game
            {
                Title = gameModel.Title,
                BuyDate = gameModel.BuyDate,
                Shop = gameModel.GetShops(),
                ActivationServices = gameModel.GetActivationServices(),
                Digital = gameModel.Digital ?1:0,
                Price = gameModel.Price,
                Platform = gameModel.Platform.ToString(),
            };

            this.gamesApi.Add(game);

            return RedirectToAction("Games");
        }
    }
}