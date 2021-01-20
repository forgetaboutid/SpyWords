using System;
using System.Collections.Generic;
using System.Linq;

namespace SpyWord.Data.Entities
{
    public class Game
    {
        public string Id { get; }
        public virtual List<Player> Players { get; }
        public List<Card> Cards { get; }
        private const int NumberOfCardsInAGame = 25;
        private const int NumberOfRedTeamMembers = 9;
        private const int NumberOfBlueTeamMembers = 8;
        private const int NumberOfByStanders = 7;

        public Game(IReadOnlyList<string> words)
        {
            if (words == null || words.Count != NumberOfCardsInAGame)
            {
                throw new ArgumentException($"A game requires exactly {NumberOfCardsInAGame} words.");
            }

            Id = Guid.NewGuid().ToString();

            var teams = AssignTeams();
            Cards = new List<Card>();
            for (int i = 0; i < NumberOfCardsInAGame; i++)
            {
                Cards.Add(new Card(words[i],teams[i]));
            }

            Players = new List<Player>{new Player{Role = Role.Leader}};
        }

        private List<Team> AssignTeams()
        {
            var seed = new List<Team>();
            var result = new List<Team>();
            for (int i = 0; i < NumberOfRedTeamMembers; i++)
            {
                seed.Add(Team.Red);
            }
            for (int i = 0; i < NumberOfBlueTeamMembers; i++)
            {
                seed.Add(Team.Blue);
            }
            for (int i = 0; i < NumberOfByStanders; i++)
            {
                seed.Add(Team.ByStander);
            }
            seed.Add(Team.Assassin);

            Random random = new Random();
            while (seed.Any())
            {
                var index = random.Next(seed.Count);
                result.Add(seed[index]);
                seed.RemoveAt(index);
            }

            return result;
        }
    }
}
