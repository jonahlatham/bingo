using System.Collections.Generic;
using Bingo.Data.Entities;
using Bingo.Model;
using Bingo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bingo.Controllers
{
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }


        [HttpGet]
        public List<Game> GetGames([FromQuery] int userId)
        {
            var results = _gameService.GetGames(userId);
            return results;
        }

        [HttpPost("createGame")]
        public void CreateGame([FromBody] CreatedGameBody game)
        {
            _gameService.CreatedGame(game);
        }

        [HttpGet("getGame")]
        public GameBuilder GetGame([FromQuery] int gameId)
        {
            var results = _gameService.GetGame(gameId);
            return results;
        }
    }
}