using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XGames.BusinessLogic.BusinessLogicInterfaces;
using XGames.Data;
using XGames.Models;

namespace XGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameBLL gamesBLL;
        public GamesController(IGameBLL gameBLL)
        {
            gamesBLL = gameBLL;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGame()
        {
            return  gamesBLL.GetAll();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await gamesBLL.GetById(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, Game game)
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

            return NoContent();
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

    }
}
