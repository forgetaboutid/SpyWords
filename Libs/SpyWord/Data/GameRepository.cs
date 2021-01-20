using System.Collections.Generic;
using System.Linq;
using SpyWord.Data.Entities;

namespace SpyWord.Data
{
    public class GameRepository : IGameRepository
    {
        private readonly GameDbContext _gameDbContext;

        public GameRepository()
        {
            
        }

        public GameRepository(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }

        public List<string> GetWords()
        {
            //todo: get words from database
            return new List<string> { "dizzy", "nations", "investor", "doomsday", "shampoos", "squire", "portion", "ideation", "healthy", "course", "speedier", "unwound", "Viking", "spigot", "nausea", "village", "exhales", "flitting", "refuted", "pricier", "beating", "sublime", "overheat", "casket", "cracked" };
        }

        public Game GetGame(string id)
        {
            return _gameDbContext.Games.Single(g => g.Id == id);
        }

        public void SaveGame(Game game)
        {
            if (_gameDbContext != null)
            {
                _gameDbContext.Games.Add(game);
                _gameDbContext.SaveChanges();
            }
        }
    }
}
