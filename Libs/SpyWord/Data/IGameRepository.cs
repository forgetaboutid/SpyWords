using System.Collections.Generic;
using SpyWord.Data.Entities;

namespace SpyWord.Data
{
    public interface IGameRepository
    {
        List<string> GetWords();
        Game GetGame(string id);
        void SaveGame(Game game);
    }
}