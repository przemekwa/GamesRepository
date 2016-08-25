using System.Collections.Generic;
using GamesRepository.Dto;

namespace GamesRepository
{
    public interface IGamesRepository
    {
        IEnumerable<Game> GetAll();
        IEnumerable<ActivationServices> GetActivationServices();
        IEnumerable<Shop> GetShops();
        void Add(Game game);
        void Remove(Game game);
    }
}