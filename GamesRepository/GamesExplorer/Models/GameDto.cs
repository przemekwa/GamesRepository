using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamesRepository.Dto;

namespace GamesExplorer.Models
{
    public class GameDto
    {
        public IEnumerable<Game> Games { get; set; }
    }
}