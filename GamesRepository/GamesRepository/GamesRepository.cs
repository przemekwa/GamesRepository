using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamesRepository.Dto;

namespace GamesRepository
{
    public class GamesRepository
    {
        private GamesRepositoryContext GamesRepositoryContext { get; set; }

        public GamesRepository()
        {
            GamesRepositoryContext = new GamesRepositoryContext();
        }

        public IEnumerable<Games> GetAll()
        {
            return this.GamesRepositoryContext.Games;
        }
    }
}
