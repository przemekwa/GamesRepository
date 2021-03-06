﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamesRepository.Dto;

namespace GamesRepository
{
   public class GamesRepository : IGamesRepository
   {
        private GamesRepositoryContext GamesRepositoryContext { get; set; }

        public GamesRepository()
        {
            GamesRepositoryContext = new GamesRepositoryContext();
        }

        public IEnumerable<Game> GetAll()
        {
            return this.GamesRepositoryContext.Games;
        }

        public IEnumerable<ActivationServices> GetActivationServices()
        {
            return this.GamesRepositoryContext.ActivationServices;
        }

        public IEnumerable<Shop> GetShops()
        {
            return this.GamesRepositoryContext.Shop;
        }

        public void Add(Game game)
        {
            

            this.GamesRepositoryContext.Games.Add(game);

            this.GamesRepositoryContext.SaveChanges();
        }

        public void Remove(Game game)
        {
            this.GamesRepositoryContext.Games.Remove(game);

            this.GamesRepositoryContext.SaveChanges();
        }

    }
}
