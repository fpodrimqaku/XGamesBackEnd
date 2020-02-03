using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XGames.BusinessLogic.BusinessLogicInterfaces;

using XGames.DTModels;
using XGames.Models;
using XGames.DTModels;

namespace XGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameBLL gamesBLL;
        private readonly IMapper _mapper;
        public GamesController(IGameBLL gameBLL,IMapper mapper)
        {
            gamesBLL = gameBLL;
            _mapper = mapper;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDTO>>> GetGame()
        {
            
            List<GameDTO> ienumerableDest = _mapper.Map<List<Game>,List<GameDTO>>(gamesBLL.GetAll());
            return ienumerableDest;


        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            try {
                var game = await gamesBLL.GetById(id);
                if (game == null)
                {
                    return NotFound();
                }

                return game;
            }
            catch (Exception exe) { return NotFound(); }
            
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<ActionResult<Game>> PutGame(int id, Game game)
        {
            if (id != game.ID)
            {
                return BadRequest();
            }

            try
            {
                gamesBLL.Update(id,game);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return game;
        }

        // POST: api/Games
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            gamesBLL.Create(game);

            return CreatedAtAction("GetGame", new { id = game.ID }, game);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteGame(int id)
        {
            bool result;
            try
            {
               result= await gamesBLL.Delete(id);
            }
            catch (Exception ) {
                return NotFound();
            }


            return result;
        }

        private bool GameExists(int id)
        {
            return gamesBLL.EntityExists(id);
        }

        [HttpGet("paged")]
        public async Task<ActionResult<PageModel<Game>>> getAllPaged(int ?pageIndex,int? pageSize) {
            return await gamesBLL.GetAllPaged(pageIndex,pageSize);
        }

    }
}
