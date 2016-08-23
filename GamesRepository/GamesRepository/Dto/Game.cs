using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesRepository.Dto
{
    [Table("games")]
    public class Game
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Digital { get; set; }

        [ForeignKey("ActivationServiceId")]
        public virtual ActivationServices ActivationServices { get; set; }

        [Column("activation_service_id")]
        public int ActivationServiceId { get; set; }

        [Column("shop_id")]
        public int ShopId { get; set; }

        [ForeignKey("ShopId")]
        public virtual Shop Shop { get; set; }

        [Column("dlc_for")]
        public int? Dcl { get; set; }

        [Column("buy_date")]
        public DateTime BuyDate { get; set; }

        public string Platform { get; set; }
        
        public decimal Price { get; set; }
    }
}
