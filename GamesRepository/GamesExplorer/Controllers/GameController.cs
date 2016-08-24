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
            var gameList = gamesApi.GetAll().Select(g=>new GameModel
            {
                Title = g.Title,
                Price = g.Price,
                BuyDate = g.BuyDate,
                Platform =  (Platform)Enum.Parse(typeof(Platform),g.Platform),
                ActivationServices = g.ActivationServices.Name,
                Shop = g.Shop.Name,
                Digital = g.Digital == 1
            }).OrderByDescending(g=>g.BuyDate);


            return View(gameList);
        }

        public ActionResult NewGame()
        {
            return View(new GameModel());
        }

        public ActionResult Add(GameModel gameModel)
        {
            if (this.gamesApi.GetAll().Any(g => g.Title.Contains(gameModel.Title ?? "")))
            {
                this.ModelState.AddModelError("Title", "Taka gra już instnieje w Twojej kolekcji. ");
            }

            if (!this.ModelState.IsValid)
            {
                return View("NewGame", gameModel);
            }

            var game = new Game
            {
                Title = gameModel.Title,
                BuyDate = gameModel.BuyDate,
                Shop = gameModel.GetShops(),
                ActivationServices = gameModel.GetActivationServices(),
                Digital = gameModel.Digital ?1:0,
                Price = gameModel.Price,
                Platform = gameModel.Platform.ToString(),
                Dcl = string.IsNullOrEmpty(gameModel.Dlc) ? null : (int?) int.Parse(gameModel.Dlc)
            };

            this.gamesApi.Add(game);

         

            this.ModelState.Clear();

            return RedirectToAction("Games");
        }
    }
}