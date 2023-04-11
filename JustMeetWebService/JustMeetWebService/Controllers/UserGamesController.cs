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
    public class UserGamesController : ControllerBase
    {
        private readonly JustmeetContext _context;

        public UserGamesController(JustmeetContext context)
        {
            _context = context;
        }

        // GET: api/UserGames
        [Route("api/userGames")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGame>>> GetUserGames()
        {
          if (_context.UserGames == null)
          {
              return NotFound();
          }
            return await _context.UserGames.ToListAsync();
        }

        // GET: api/UserGames/5
        [Route("api/userGame/{idUser}")]
        [HttpGet()]
        public async Task<ActionResult<UserGame>> GetUserGame(int id)
        {
          if (_context.UserGames == null)
          {
              return NotFound();
          }
            var userGame = await _context.UserGames.FindAsync(id);

            if (userGame == null)
            {
                return NotFound();
            }

            return userGame;
        }

        // PUT: api/UserGames/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("api/userGame/{idUser}")]
        [HttpPut()]
        public async Task<IActionResult> PutUserGame(int id, UserGame userGame)
        {
            if (id != userGame.IdGame)
            {
                return BadRequest();
            }

            _context.Entry(userGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserGameExists(id))
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

        // POST: api/UserGames
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("api/userGame")]
        [HttpPost]
        public async Task<ActionResult<UserGame>> PostUserGame(UserGame userGame)
        {
          if (_context.UserGames == null)
          {
              return Problem("Entity set 'JustmeetContext.UserGames'  is null.");
          }
            _context.UserGames.Add(userGame);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserGameExists(userGame.IdGame))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserGame", new { id = userGame.IdGame }, userGame);
        }

        // DELETE: api/UserGames/5
        [Route("api/userGame/{idUser}")]
        [HttpDelete()]
        public async Task<IActionResult> DeleteUserGame(int id)
        {
            if (_context.UserGames == null)
            {
                return NotFound();
            }
            var userGame = await _context.UserGames.FindAsync(id);
            if (userGame == null)
            {
                return NotFound();
            }

            _context.UserGames.Remove(userGame);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserGameExists(int id)
        {
            return (_context.UserGames?.Any(e => e.IdGame == id)).GetValueOrDefault();
        }
    }
}
