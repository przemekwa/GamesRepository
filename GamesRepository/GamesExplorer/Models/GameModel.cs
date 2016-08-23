using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GamesExplorer.Controllers;
using GamesRepository.Dto;

namespace GamesExplorer.Models
{
    public class GameModel
    {
        private readonly GamesRepository.GamesRepository gamesApi;

        public GameModel()
        {
            gamesApi = new GamesRepository.GamesRepository();
        }


        public int Id { get; set; }
        public string Title { get; set; }
        public bool Digital { get; set; }
        public string ActivationServices { get; set; }
        public string Shop { get; set; }

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
                    Name = this.ActivationServices,
                };
            }

            return shop;
        }
    }
}