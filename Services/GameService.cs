using System;
using System.Collections.Generic;
using System.Linq;
using Bingo.data;
using Bingo.Data.Entities;
using Bingo.Model;
using Microsoft.EntityFrameworkCore;

namespace Bingo.Services
{
    public interface IGameService
    {
        List<Game> GetGames(int userId);
        void CreatedGame(CreatedGameBody game);
        GameBuilder GetGame(int GameId);
    }
    public class GameService : IGameService
    {
        private CoreContext _context;
        public GameService(CoreContext context)
        {
            _context = context;
        }

        public List<Game> GetGames(int userId)
        {
            var adminRights = _context.Admin.Include(x => x.User).Include(x => x.Game).Where(e => e.UserId == userId).ToList();
            // var games = _context.Game.Where(e => adminRights.Contains(e.Id));
            var craps = adminRights.Select(e => new Game()
            {
                Id = e.Game.Id,
                Name = e.Game.Name,
                CreatorId = e.Game.CreatorId,
                BoardDimensions = e.Game.BoardDimensions,
                IsActive = e.Game.IsActive
            }).ToList();
            return craps;
        }

        public void CreatedGame(CreatedGameBody game)
        {
            var gameToAdd = new Game()
            {
                Name = game.Game.Name,
                CreatorId = game.Game.CreatorId,
                BoardDimensions = game.Game.BoardDimensions,
                IsActive = true
            };
            var gameResults = _context.Game.Add(gameToAdd);
            _context.SaveChanges();
            foreach (var i in game.UserIds)
            {
                _context.Admin.Add(new Admin()
                {
                    UserId = i,
                    GameId = gameToAdd.Id
                });
            }
            foreach (var i in game.Items)
            {
                _context.Item.Add(new Item()
                {
                    Name = i,
                    GameId = gameToAdd.Id
                });
            }
            _context.SaveChanges();
        }

        public GameBuilder GetGame(int GameId)
        {
            var rnd = new Random();
            var newGame = _context.Game.FirstOrDefault(e => e.Id == GameId);
            var newItems = _context.Item.Where(e => e.GameId == GameId).ToList()
            .OrderBy(a => rnd.Next())
            .Take(newGame.BoardDimensions).ToList();
            var response = new GameBuilder()
            {
                Game = newGame,
                Items = newItems
            };
            return response;
        }
    }
}