using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesRepository.Dto
{
    [Table("shops")]
    public class Shop
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Column("user_name")]
        public string UserName { get; set; }
    }
}
