﻿using Microsoft.AspNetCore.Mvc;
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
    public class CartBLL : BaseBLL<Cart> ,ICartBLL
    {
        public CartBLL([FromServices]ICartRepository CartRepo):base(CartRepo) { }

    }
}
