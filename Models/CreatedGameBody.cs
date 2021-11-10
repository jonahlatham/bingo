using System.Collections.Generic;
using Bingo.Data.Entities;

namespace Bingo.Model
{
    public class CreatedGameBody
    {
        public Game Game { get; set; }
        public List<int> UserIds { get; set; }
        public List<string> Items { get; set; }
    }
}