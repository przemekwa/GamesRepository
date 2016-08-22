using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GamesRepository_Tests
{
    public class Tests
    {
        [Fact]
        public void Integration_Test()
        {
            var games = new GamesRepository.GamesRepository().GetAll().ToList();

            Assert.Equal(1, games.Count);

        }
    }
}
