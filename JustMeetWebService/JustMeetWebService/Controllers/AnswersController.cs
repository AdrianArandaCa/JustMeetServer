﻿using System;
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
    public class AnswersController : ControllerBase
    {
        private readonly JustmeetContext _context;

        public AnswersController(JustmeetContext context)
        {
            _context = context;
        }

        //// GET: api/Answers
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Answer>>> GetAnswers()
        //{
        //  if (_context.Answers == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Answers.ToListAsync();
        //}

        //// GET: api/Answers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Answer>> GetAnswer(int id)
        //{
        //  if (_context.Answers == null)
        //  {
        //      return NotFound();
        //  }
        //    var answer = await _context.Answers.FindAsync(id);

        //    if (answer == null)
        //    {
        //        return NotFound();
        //    }

        //    return answer;
        //}

        //// PUT: api/Answers/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAnswer(int id, Answer answer)
        //{
        //    if (id != answer.IdAnswer)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(answer).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AnswerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Answers
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Answer>> PostAnswer(Answer answer)
        //{
        //  if (_context.Answers == null)
        //  {
        //      return Problem("Entity set 'JustmeetContext.Answers'  is null.");
        //  }
        //    _context.Answers.Add(answer);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAnswer", new { id = answer.IdAnswer }, answer);
        //}

        //// DELETE: api/Answers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAnswer(int id)
        //{
        //    if (_context.Answers == null)
        //    {
        //        return NotFound();
        //    }
        //    var answer = await _context.Answers.FindAsync(id);
        //    if (answer == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Answers.Remove(answer);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool AnswerExists(int id)
        //{
        //    return (_context.Answers?.Any(e => e.IdAnswer == id)).GetValueOrDefault();
        //}
        // GET: api/Answers
        [Route("api/answers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Answer>>> GetAnswers()
        {
            if (_context.Answers == null)
            {
                return NotFound();
            }
            var answer = await _context.Answers.ToListAsync();
            return answer;
        }

        // GET: api/Answers/5
        [Route("api/answer/{id}")]
        [HttpGet()]
        public async Task<ActionResult<Answer>> GetAnswer(int id)
        {
            if (_context.Answers == null)
            {
                return NotFound();
            }
            var answer = await _context.Answers.FindAsync(id);

            if (answer == null)
            {
                return NotFound();
            }

            return answer;
        }

        // PUT: api/Answers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("api/answer/{id}")]
        [HttpPut()]
        public async Task<IActionResult> PutAnswer(int id, Answer answer)
        {
            if (id != answer.IdAnswer)
            {
                return BadRequest();
            }

            _context.Entry(answer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerExists(id))
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

        // POST: api/Answers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("api/answer")]
        [HttpPost]
        public async Task<ActionResult<Answer>> PostAnswer(Answer answer)
        {
            if (_context.Answers == null)
            {
                return Problem("Entity set 'JustmeetContext.Answers'  is null.");
            }
            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnswer", new { id = answer.IdAnswer }, answer);
        }

        [Route("api/answers")]
        [HttpPost]
        public async Task<ActionResult<List<Answer>>> PostQuestions(List<Answer> answerList)
        {
            if (_context.Questions == null)
            {
                return Problem("Entity set 'JustmeetContext.Questions'  is null.");
            }
            _context.Answers.AddRange(answerList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestions", answerList);
        }

        // DELETE: api/Answers/5
        [Route("api/answer/{id}")]
        [HttpDelete()]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            if (_context.Answers == null)
            {
                return NotFound();
            }
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null)
            {
                return NotFound();
            }

            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnswerExists(int id)
        {
            return (_context.Answers?.Any(e => e.IdAnswer == id)).GetValueOrDefault();
        }
    }
}
