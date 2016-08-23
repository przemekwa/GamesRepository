using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamesRepository.Dto;
using Xunit;

namespace GamesRepository_Tests
{
    public class Tests
    {
        [Fact]
        public void Integration_Test()
        {
            var game = new GamesRepository.GamesRepository().GetAll().First();

            Assert.Equal(1, game.Id);

            Assert.Equal("Dying Light: The Following Edycja Rozszerzona ", game.Title);

            Assert.Equal(new DateTime(2016,07,05,20,31,16), game.BuyDate);
            
            Assert.Equal(114.90M, game.Price);

            Assert.Equal(null, game.Dcl);

            Assert.Equal(1, game.Digital);

            Assert.Equal("PC", game.Platform);

            Assert.NotNull(game.ActivationServices);

            Assert.Equal("Steam", game.ActivationServices.Name);

            Assert.Equal("goodeinstein", game.ActivationServices.UserName);

            Assert.NotNull(game);

            Assert.Equal("muve.pl", game.Shop.Name);

            Assert.Equal("przemekworld@gmail.com", game.Shop.UserName);
        }


        [Fact]
        public void Add_And_Remove_Test()
        {
            var gameRepository = new GamesRepository.GamesRepository();

            Assert.Equal(1, gameRepository.GetAll().Count());

            var game = new Game
            {
                Title = "sdsf",
                BuyDate = DateTime.Now,
                Price = 0,
                ShopId = 0,
                Digital = 1,
                ActivationServices = new ActivationServices
                {
                    Id = 1,
                    Name = "ssf",
                    UserName = "sds"
                },
                Platform = "PC"
            };

            gameRepository.Add(game);

            var actual = gameRepository.GetAll().ToList();

            Assert.Equal(2, actual.Count);

            gameRepository.Remove(game);

            Assert.Equal(1, gameRepository.GetAll().Count());

        }
    }
}
