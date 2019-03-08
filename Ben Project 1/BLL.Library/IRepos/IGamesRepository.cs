using Project_1.BLL.Library.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1.BLL.Library.IRepos
{
    public interface IGamesRepository
    {
        IEnumerable<GamesImp> GetAllGames();

        GamesImp GetGameById(int Id);

        void AddGame(GamesImp game);

    }
}
