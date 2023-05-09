using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JustMeetWebService.Models;
using System.Transactions;
using Microsoft.AspNetCore.Identity;

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

        // GET: api/UserAnswers
        [Route("api/userAnswer/{idGame}/{idUser}/{idQuestion}")]
        [HttpGet]
        public async Task<ActionResult<UserAnswer>> GetUserAnswer(int idGame, int idUser, int idQuestion)
        {
            if (_context.UserAnswers == null)
            {
                return NotFound();
            }
            var userAnswer = await _context.UserAnswers.Where(a => a.IdGame == idGame && a.IdUser == idUser && a.IdQuestion == idQuestion).FirstOrDefaultAsync();
            if (userAnswer == null)
            {
                return NotFound();
            }
            return userAnswer;
        }

        // GET: api/UserAnswersForUser/5
        [Route("api/userAnswerFromGame/{idGame}")]
        [HttpGet()]
        public async Task<ActionResult<List<UserAnswer>>> GetUserAnswerFromGame(int idGame)
        {
            if (_context.UserAnswers == null)
            {
                return NotFound();
            }
            var listUserAnswer = await _context.UserAnswers.Where(a => a.IdGame == idGame).ToListAsync();

            if (listUserAnswer == null)
            {
                return NotFound();
            }

            return listUserAnswer;
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

        // POST: api/UserAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("api/listUserAnswer")]
        [HttpPost]
        public async Task<ActionResult<List<UserAnswer>>> PostListUserAnswer(List<UserAnswer> listUserAnswer)
        {
            if (_context.UserAnswers == null)
            {
                return Problem("Entity set 'JustmeetContext.UserAnswers'  is null.");
            }
            _context.UserGames.Add(new UserGame(listUserAnswer.First().IdGame, listUserAnswer.First().IdUser));
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {

            }

            foreach (var userAnswer in listUserAnswer)
            {

                _context.UserAnswers.Add(userAnswer);
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                foreach (var userAnswer in listUserAnswer)
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
            }

            return CreatedAtAction("GetUserAnswer", listUserAnswer);
        }

        // DELETE: api/UserAnswers/5
        [Route("api/userAnswer/{idGame}")]
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
