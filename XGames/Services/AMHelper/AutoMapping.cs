using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using XGames.DTModels;
using XGames.Models;

namespace XGames.Services.AMHelper
{
    public class AutoMapping : Profile
    { 
        public AutoMapping()
        {
            CreateMap<Game, GameDTO>(); // means you want to map from Game to GameDTO
            CreateMap<GamePicture, GamePictureDTO>();
        }
    }
}
