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
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public bool Digital { get; set; }

        [Required]
        public string ActivationServices { get; set; }

        [Required]
        public string Shop { get; set; }

        public string Dlc { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime BuyDate { get; set; }

        [Required]
        public Platform Platform { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
     }
}