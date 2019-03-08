using DBContext.Library;
using Project_1.BLL.Library.Implementation;
using Project_1.BLL.Library.IRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1.DBContext.Library.Repositories
{
    public class GamesRepository : IGamesRepository
    {

        private readonly Project0Context _db;

        public GamesRepository(Project0Context db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<GamesImp> GetAllGames()
        {
            var value = _db.Games;
            return Mapper.Map(value);
        }

        public GamesImp GetGameById(int Id)
        {
            var value = _db.Games.Find(Id);
            return Mapper.Map(value);
        }

        public void AddGame(GamesImp game)
        {
            var value = Mapper.Map(game);
            _db.Add(value);
            _db.SaveChanges();
            game.Id = value.GameId;
        }

    }
}
