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
            var gameList = gamesApi.GetAll().OrderByDescending(g => g.BuyDate).ToList();

            var dlcGames = gameList.Where(g => g.Dcl != null).OrderByDescending(g=>g.BuyDate).ToList();

            var finalGameList = new List<Game>();

            foreach (var game in gameList.Where(g=>g.Dcl == null))
            {
                finalGameList.Add(game);

                if (dlcGames.Any(l => l.Dcl == game.Id))
                {
                    finalGameList.AddRange(dlcGames.Where(d => d.Dcl == game.Id));
                }
            }


            return View(finalGameList.Select(g => new GameModel
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