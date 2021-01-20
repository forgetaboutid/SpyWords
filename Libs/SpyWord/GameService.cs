using SpyWord.Data;
using SpyWord.Data.Entities;

namespace SpyWord
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            this._gameRepository = gameRepository;
        }

        public Game GetNewGame()
        {
            var game = new Game(_gameRepository.GetWords());
            _gameRepository.SaveGame(game);
            return game;
        }

        public Game JoinGame(string gameId)
        {
            var game = _gameRepository.GetGame(gameId);
            var player = new Player();
            game.Players.Add(player);
            _gameRepository.SaveGame(game);
            return game;
        }
    }
}
