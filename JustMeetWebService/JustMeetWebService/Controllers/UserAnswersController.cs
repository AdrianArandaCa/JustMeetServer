using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JustMeetWebService.Models;
using System.Transactions;

namespace JustMeetWebService.Controllers
{
    [ApiController]
    public class UserAnswersController : ControllerBase
    {
        private readonly JustmeetContext _context;

        public UserAnswersController(JustmeetContext context)
        {
            _context = context;
        }

        // GET: api/UserAnswers
        [Route("api/userAnswers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAnswer>>> GetUserAnswers()
        {
          if (_context.UserAnswers == null)
          {
              return NotFound();
          }
            return await _context.UserAnswers.ToListAsync();
        }

        // GET: api/UserAnswersForUser/5
        [Route("api/userAnswer/{idUser}/{idGame}")]
        [HttpGet()]
        public async Task<ActionResult<UserAnswer>> GetUserAnswerForUser(int idGame, int idUser)
        {
            if (_context.UserAnswers == null)
            {
                return NotFound();
            }
            var userAnswer = await _context.UserAnswers.FindAsync(idGame, idUser);

            if (userAnswer == null)
            {
                return NotFound();
            }

            return userAnswer;
        }

        // GET: api/UserAnswersForUser/5
        [Route("api/userAnswerForUser/{idUser}")]
        [HttpGet()]
        public async Task<ActionResult<UserAnswer>> GetUserAnswerForUser(int idUser)
        {
          if (_context.UserAnswers == null)
          {
              return NotFound();
          }
            var userAnswer = await _context.UserAnswers.FindAsync(idUser);

            if (userAnswer == null)
            {
                return NotFound();
            }

            return userAnswer;
        }

        // GET: api/UserAnswersForGame/5
        [Route("api/userAnswerForGame/{idGame}")]
        [HttpGet()]
        public async Task<ActionResult<UserAnswer>> GetUserAnswerForGame(int idGame)
        {
            if (_context.UserAnswers == null)
            {
                return NotFound();
            }
            var userAnswer = await _context.UserAnswers.FindAsync(idGame);

            if (userAnswer == null)
            {
                return NotFound();
            }

            return userAnswer;
        }

        // PUT: api/UserAnswers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("api/userAnswer/{idUser}/{idGame}/{idQuestion}")]
        [HttpPut()]
        public async Task<IActionResult> PutUserAnswer(int idUser, int idGame, int IdQuestion, UserAnswer userAnswer)
        {
            _context.Entry(userAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAnswerExists(idGame, idUser, IdQuestion))
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

        // POST: api/UserAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("api/userAnswer")]
        [HttpPost]
        public async Task<ActionResult<UserAnswer>> PostUserAnswer(UserAnswer userAnswer)
        {
          if (_context.UserAnswers == null)
          {
              return Problem("Entity set 'JustmeetContext.UserAnswers'  is null.");
          }
            _context.UserAnswers.Add(userAnswer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserAnswerExists(userAnswer.IdGame, userAnswer.IdUser, userAnswer.IdQuestion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserAnswer", new { id = userAnswer.IdGame }, userAnswer);
        }

        // DELETE: api/UserAnswers/5
        [Route("api/userAnswer/{idUser}/{idGame}")]
        [HttpDelete()]
        public async Task<IActionResult> DeleteUserAnswer(int id)
        {
            if (_context.UserAnswers == null)
            {
                return NotFound();
            }
            var userAnswer = await _context.UserAnswers.FindAsync(id);
            if (userAnswer == null)
            {
                return NotFound();
            }

            _context.UserAnswers.Remove(userAnswer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserAnswerExists(int idGame, int idUser, int IdQuestion)
        {
            return (_context.UserAnswers?.Any(e => e.IdGame == idGame && e.IdUser == idUser && e.IdQuestion == IdQuestion)).GetValueOrDefault();
        }
    }
}
