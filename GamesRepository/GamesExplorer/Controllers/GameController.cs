using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamesExplorer.Models;
using GamesRepository;
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
        private readonly IGamesRepository gamesRepository;

        public GameController(IGamesRepository gamesRepository)
        {
            this.gamesRepository = gamesRepository;
        }

        public ActionResult Games()
        {
            var gameList = gamesRepository.GetAll().OrderByDescending(g => g.BuyDate).ToList();

            var dlcGames = gameList.Where(g => g.Dcl != null).ToList();

            var finalGameList = new List<Game>();

            foreach (var game in gameList.Where(g => g.Dcl == null))
            {
                finalGameList.Add(game);

                if (dlcGames.Any(l => l.Dcl == game.Id))
                {
                    finalGameList.AddRange(dlcGames.Where(d => d.Dcl == game.Id));
                }
            }


            return View(finalGameList.Select(g => new GameModel(null)
            {
                Title = g.Title,
                Price = g.Price,
                BuyDate = g.BuyDate,
                Platform = (Platform)Enum.Parse(typeof(Platform), g.Platform),
                ActivationServices = g.ActivationServices.Name,
                Shop = g.Shop.Name,
                Digital = g.Digital == 1,
                Dlc = g.Dcl.ToString() ?? null
            }));
        }

        public ActionResult NewGame()
        {
            return View(new GameModel(this.gamesRepository));
        }

        public ActionResult Add(GameModel gameModel)
        {
            gameModel.GamesRepository = this.gamesRepository;

            if (this.gamesRepository.GetAll().Any(g => g.Title.Contains(gameModel.Title ?? "")))
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

            if (game.Shop.Id != -1)
            {
                game.ShopId = game.Shop.Id;
                game.Shop = null;
            }

            if (game.ActivationServices.Id != -1)
            {
                game.ActivationServiceId = game.ActivationServices.Id;
                game.ActivationServices = null;
            }

            this.gamesRepository.Add(game);

            this.ModelState.Clear();

            return RedirectToAction("Games");
        }
    }
}