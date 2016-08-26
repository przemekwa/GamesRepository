using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamesExplorer.Controllers;
using GamesRepository;
using GamesRepository.Dto;

namespace GamesExplorer.Models
{
    public class GameModelxxx
    {
        public IGamesRepository GamesRepository { get; set; }

       

        public List<GameModel> GameModels { get; set; }

        public GameModelxxx()
        {
                
        }

        public GameModelxxx(IGamesRepository gamesRepository)
        {
            this.GamesRepository = gamesRepository;

        }


       
    }
}