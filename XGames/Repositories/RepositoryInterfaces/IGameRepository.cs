﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XGames.Models;


namespace XGames.Repositories.RepositoryInterfaces
{
    public interface IGameRepository : IBaseRepository<Game>
    {

        public List<Game> GetAll();
    }
}
