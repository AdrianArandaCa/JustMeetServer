using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JustMeetWebService.Models;

namespace JustMeetWebService.Controllers
{
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly JustmeetContext _context;

        public GamesController(JustmeetContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [Route("api/games")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
          if (_context.Games == null)
          {
              return NotFound();
          }
            return await _context.Games.ToListAsync();
        }

        // GET: api/Games/5
        [Route("api/game/{id}")]
        [HttpGet()]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
          if (_context.Games == null)
          {
              return NotFound();
          }
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        // GET: api/Games/5
        [Route("api/usersFromGame/{id}")]
        [HttpGet()]
        public async Task<ActionResult<List<User>>> GetUsersFromGame(int id)
        {
            if (_context.Games == null)
            {
                return NotFound();
            }
            List<User> users = await _context.Games.Where(a=>a.IdGame == id).SelectMany(a=>a.UserGames).Select(a=>a.IdUserNavigation).ToListAsync();

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("api/game/{id}")]
        [HttpPut()]
        public async Task<IActionResult> PutGame(int id, Game game)
        {
            if (id != game.IdGame)
            {
                return BadRequest();
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("api/game")]
        [HttpPost]
        public async Task<Game> PostGame(Game game)
        {
          if (_context.Games == null)
          {
              //return Problem("Entity set 'JustmeetContext.Games'  is null.");
          }
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            game = await _context.Games.OrderByDescending(a=>a.IdGame).FirstOrDefaultAsync();

            return game;
        }

        // DELETE: api/Games/5
        [Route("api/game/{id}")]
        [HttpDelete()]
        public async Task<IActionResult> DeleteGame(int id)
        {
            if (_context.Games == null)
            {
                return NotFound();
            }
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameExists(int id)
        {
            return (_context.Games?.Any(e => e.IdGame == id)).GetValueOrDefault();
        }
    }
}
