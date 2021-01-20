namespace SpyWord.Data.Entities
{
    public class Card
    {
        public string Word { get;}
        public Team Team { get;}

        public Card(string word, Team team)
        {
            Word = word;
            Team = team;
        }
    }
}
