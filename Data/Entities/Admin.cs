namespace Bingo.Data.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}