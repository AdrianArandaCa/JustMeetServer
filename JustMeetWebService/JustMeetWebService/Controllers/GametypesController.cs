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
    public class GametypesController : ControllerBase
    {
        private readonly JustmeetContext _context;

        public GametypesController(JustmeetContext context)
        {
            _context = context;
        }

        // GET: api/Gametypes
        [Route("api/gameTypes")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gametype>>> GetGametypes()
        {
          if (_context.Gametypes == null)
          {
              return NotFound();
          }
            return await _context.Gametypes.ToListAsync();
        }

        // GET: api/Gametypes/5
        [Route("api/gameType/{id}")]
        [HttpGet()]
        public async Task<ActionResult<Gametype>> GetGametype(int id)
        {
          if (_context.Gametypes == null)
          {
              return NotFound();
          }
            var gametype = await _context.Gametypes.FindAsync(id);

            if (gametype == null)
            {
                return NotFound();
            }

            return gametype;
        }

        // PUT: api/Gametypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("api/gameType/{id}")]
        [HttpPut()]
        public async Task<IActionResult> PutGametype(int id, Gametype gametype)
        {
            if (id != gametype.IdGametype)
            {
                return BadRequest();
            }

            _context.Entry(gametype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GametypeExists(id))
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

        // POST: api/Gametypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("api/gameType")]
        [HttpPost]
        public async Task<ActionResult<Gametype>> PostGametype(Gametype gametype)
        {
          if (_context.Gametypes == null)
          {
              return Problem("Entity set 'JustmeetContext.Gametypes'  is null.");
          }
            _context.Gametypes.Add(gametype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGametype", new { id = gametype.IdGametype }, gametype);
        }

        // DELETE: api/Gametypes/5
        [Route("api/gameType/{id}")]
        [HttpDelete()]
        public async Task<IActionResult> DeleteGametype(int id)
        {
            if (_context.Gametypes == null)
            {
                return NotFound();
            }
            var gametype = await _context.Gametypes.FindAsync(id);
            if (gametype == null)
            {
                return NotFound();
            }

            _context.Gametypes.Remove(gametype);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GametypeExists(int id)
        {
            return (_context.Gametypes?.Any(e => e.IdGametype == id)).GetValueOrDefault();
        }
    }
}
