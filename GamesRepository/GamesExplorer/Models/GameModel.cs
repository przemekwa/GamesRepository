using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamesExplorer.Controllers;
using GamesRepository.Dto;

namespace GamesExplorer.Models
{
    public class GameModel
    {
        private readonly GamesRepository.GamesRepository gamesApi;

        public IEnumerable<SelectListItem> AvailableGames { get; }

        public GameModel()
        {
            gamesApi = new GamesRepository.GamesRepository();
            AvailableGames = gamesApi.GetAll().Select(g => new SelectListItem {Text = g.Title, Value = g.Id.ToString()});
        }


        public int Id { get; set; }
        public string Title { get; set; }
        public bool Digital { get; set; }
        public string ActivationServices { get; set; }
        public string Shop { get; set; }

        public string Dlc { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime BuyDate { get; set; }
        public Platform Platform { get; set; }
        public decimal Price { get; set; }


        public ActivationServices GetActivationServices()
        {
            var activationServices =
                this.gamesApi.GetActivationServices().SingleOrDefault(d => d.Name == this.ActivationServices);

            if (activationServices == null)
            {
                return new ActivationServices
                {
                    Id = -1,
                    Name = this.ActivationServices,
                };
            }

            return activationServices;
        }

        public Shop GetShops()
        {
            var shop =
                this.gamesApi.GetShops().SingleOrDefault(d => d.Name == this.Shop);

            if (shop == null)
            {
                return new Shop
                {
                    Id = -1,
                    Name = this.ActivationServices,
                };
            }

            return shop;
        }
    }
}