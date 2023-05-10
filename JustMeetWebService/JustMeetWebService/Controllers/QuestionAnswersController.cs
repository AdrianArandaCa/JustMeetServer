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
    public class QuestionAnswersController : ControllerBase
    {
        private readonly JustmeetContext _context;

        public QuestionAnswersController(JustmeetContext context)
        {
            _context = context;
        }

        // GET: api/QuestionAnswers
        [Route("api/questionsAnswers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionAnswer>>> GetQuestionAnswers()
        {
            if (_context.QuestionAnswers == null)
            {
                return NotFound();
            }
            return await _context.QuestionAnswers.ToListAsync();
        }

        // GET: api/QuestionAnswers/5
        [Route("api/questionAnswer/{idQuestion}/{idAnswer}")]
        [HttpGet()]
        public async Task<ActionResult<QuestionAnswer>> GetQuestionAnswer(int idQuestion, int idAnswer)
        {
            if (_context.QuestionAnswers == null)
            {
                return NotFound();
            }
            var questionAnswer = await _context.QuestionAnswers.Where(a => a.IdQuestion == idQuestion && a.IdAnswer == idAnswer).FirstOrDefaultAsync();

            if (questionAnswer == null)
            {
                return NotFound();
            }

            return questionAnswer;
        }

        // PUT: api/QuestionAnswers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("api/questionAnswer/{idQuestion}/{idAnswer}")]
        [HttpPut()]
        public async Task<IActionResult> PutQuestionAnswer(int idQuestion, int idAnswer, QuestionAnswer questionAnswer)
        {
            if (idQuestion != questionAnswer.IdQuestion || idAnswer != questionAnswer.IdAnswer)
            {
                return BadRequest();
            }

            _context.Entry(questionAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionAnswerExists(idQuestion) || !QuestionAnswerByAnswerExists(idAnswer))
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

        // POST: api/QuestionAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("api/questionAnswer")]
        [HttpPost()]
        public async Task<ActionResult<QuestionAnswer>> PostQuestionAnswer(QuestionAnswer questionAnswer)
        {
            if (_context.QuestionAnswers == null)
            {
                return Problem("Entity set 'JustmeetContext.QuestionAnswers'  is null.");
            }
            _context.QuestionAnswers.Add(questionAnswer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (QuestionAnswerExists(questionAnswer.IdQuestion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetQuestionAnswer", new { id = questionAnswer.IdQuestion }, questionAnswer);
        }

        // DELETE: api/QuestionAnswers/5
        [Route("api/questionAnswer/{idQuestion}/{idAnswer}")]
        [HttpDelete()]
        public async Task<IActionResult> DeleteQuestionAnswer(int idQuestion, int idAnswer)
        {
            if (_context.QuestionAnswers == null)
            {
                return NotFound();
            }
            var questionAnswer = await _context.QuestionAnswers.Where(a => a.IdQuestion == idQuestion && a.IdAnswer == idAnswer).FirstOrDefaultAsync();
            if (questionAnswer == null)
            {
                return NotFound();
            }

            _context.QuestionAnswers.Remove(questionAnswer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionAnswerExists(int id)
        {
            return (_context.QuestionAnswers?.Any(e => e.IdQuestion == id)).GetValueOrDefault();
        }
        private bool QuestionAnswerByAnswerExists(int id)
        {
            return (_context.QuestionAnswers?.Any(e => e.IdAnswer == id)).GetValueOrDefault();
        }
    }
}
