using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XGames.Data;
using XGames.Models;
using XGames.Repositories.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace XGames.Repositories
{
    public class GameRepository : BaseRepository<Game>,IGameRepository
    {
        public GameRepository([FromServices]XGamesContext context) : base(context)
        {


          

        }

      //  public async Task<Game> GetById(int id)
      //  {
      //      Game entity = getDatabaseContext().Game.Where(item => item.ID==id).Include(i=>i.Pictures)
      //          
      //          .Single();
      //      
      //      if (entity == null)
      //      {
      //          throw new KeyNotFoundException();
      //      }
      //
      //      return entity;
      //  }
      //

    }
}
