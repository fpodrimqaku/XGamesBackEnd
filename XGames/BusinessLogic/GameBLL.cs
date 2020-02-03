using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XGames.BusinessLogic.BusinessLogicInterfaces;
using XGames.Data;
using XGames.Models;
using XGames.Repositories;
using XGames.Repositories.RepositoryInterfaces;

namespace XGames.BusinessLogic
{
    public class GameBLL : BaseBLL<Game> ,IGameBLL
    {
        IGameRepository gameRepository;
        public GameBLL([FromServices]IGameRepository gameRepo) :base(gameRepo) {
            this.gameRepository = gameRepo;
        }



        public List<Game> GetAll()
        {
            return gameRepository.GetAll();
        }
    }

   
   
}
