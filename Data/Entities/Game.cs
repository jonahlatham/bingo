using System.Collections.Generic;

namespace Bingo.Data.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatorId { get; set; }
        public int BoardDimensions { get; set; }
        public bool? IsActive { get; set; }
    }
}