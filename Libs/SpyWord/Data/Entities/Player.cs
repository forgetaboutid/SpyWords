using System;

namespace SpyWord.Data.Entities
{
    public class Player
    {
        public string Id { get; }
        public Team Team { get; set; }
        public Role Role { get; set; }

        public Player()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
