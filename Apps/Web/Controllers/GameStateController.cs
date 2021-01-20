using Microsoft.AspNetCore.Mvc;
using SpyWord;
using SpyWord.Data.Entities;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameStateController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameStateController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public Game Get()
        {
            return _gameService.GetNewGame();
        }
    }
}
