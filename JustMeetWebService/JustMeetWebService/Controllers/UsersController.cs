using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JustMeetWebService.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace JustMeetWebService.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly JustmeetContext _context;

        public UsersController(JustmeetContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [Route("api/users")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [Route("api/user/{id}")]
        [HttpGet()]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);
            if (user.IdSetting != null) 
            {
                var setting = await GetUserSetting((int)user.IdSetting);
                user.IdSettingNavigation = setting.Value;
            }
            

            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // GET: api/UserSetting/5
        [Route("api/userSetting/{id}")]
        [HttpGet()]
        public async Task<ActionResult<Setting>> GetUserSetting(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var setting = await _context.Settings.Where(a=>a.IdSetting == id).FirstOrDefaultAsync();
            if (setting.IdGametype != null) 
            {
                var gameType = await GetUserSettingGameType((int)setting.IdGametype);
                setting.IdGametypeNavigation = gameType.Value;
            }
            
            if (setting == null)
            {
                return NotFound();
            }

            return setting;
        }

        // GET: api/UserSetting/5
        [Route("api/userSettingGameType/{id}")]
        [HttpGet()]
        public async Task<ActionResult<Gametype>> GetUserSettingGameType(int idUser)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var gameType = await _context.Users.Where(a => a.IdUser == idUser).Select(a => a.IdSettingNavigation.IdGametypeNavigation).FirstOrDefaultAsync();

            if (gameType == null)
            {
                return NotFound();
            }

            return gameType;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("api/user/{id}")]
        [HttpPut()]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.IdUser)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("api/user")]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'JustmeetContext.Users'  is null.");
          }
            var existUser = _context.Users.Where(a => a.Name.Equals(user.Name)).FirstOrDefault();
            if (existUser != null) 
            {
                return BadRequest(new { message = "Usuari ja existeix" });
            }
            
            _context.Users.Add(user);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.IdUser }, user);
        }

        // DELETE: api/Users/5
        [Route("api/user/{id}")]
        [HttpDelete()]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.IdUser == id)).GetValueOrDefault();
        }
    }
}
