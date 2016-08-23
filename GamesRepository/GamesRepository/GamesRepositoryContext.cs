using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamesRepository.Dto;

namespace GamesRepository
{
    internal class GamesRepositoryContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public GamesRepositoryContext() : base("games")
        {
         
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();
        }
    }
}
