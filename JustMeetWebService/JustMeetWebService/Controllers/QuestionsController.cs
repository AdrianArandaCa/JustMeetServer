using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JustMeetWebService.Models;
using JustMeetWebService.Models2;
using NuGet.Packaging;
using NuGet.Versioning;

namespace JustMeetWebService.Controllers
{
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly JustmeetContext _context;

        public QuestionsController(JustmeetContext context)
        {
            _context = context;
        }

        // GET: api/Questions
        [Route("api/questions")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetQuestions()
        {
            List<QuestionDTO> questionsDTO = new List<QuestionDTO>();
            if (_context.Questions == null)
            {
                return NotFound();
            }
            var questions = await _context.Questions.ToListAsync();

            foreach (var question in questions)
            {
                QuestionDTO questionDTO = new QuestionDTO(question.IdQuestion, question.Question1, question.IdGametype, question.IdGametypeNavigation);
                var questionsAnswers = await _context.QuestionAnswers.Where(a => a.IdQuestion == question.IdQuestion).ToListAsync();

                foreach (var questionAnswer in questionsAnswers)
                {
                    var answer = await _context.Answers.FindAsync(questionAnswer.IdAnswer);
                    if (answer != null)
                    {
                        questionDTO.Answers.Add(answer);
                    }
                }
                if (questionsDTO != null)
                {
                    questionsDTO.Add(questionDTO);
                }
            }
            return questionsDTO;
        }

        //[Route("api/questionsAnswers")]
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<QuestionAnswer>>> GetQuestionsAnswers()
        //{
        //    List<QuestionAnswer> questionAnswer = new List<QuestionAnswer>();
        //    List<Question> questions = null;
        //    if (_context.Questions == null)
        //    {
        //        return NotFound();
        //    }

        //    questions = await _context.Questions.ToListAsync();
        //    foreach (var q in questions)
        //    {
        //        var questionanswer = await _context.Questions.Where(a => a.IdQuestion == q.IdQuestion).SelectMany(a => a.IdAnswers).ToListAsync();
        //        foreach (var answer in questionanswer)
        //        {
        //            QuestionAnswer qAnswer = new QuestionAnswer(q.IdQuestion, answer.IdAnswer);
        //            questionAnswer.Add(qAnswer);
        //        }
        //    }
        //    return questionAnswer;
        //}

        // GET: api/Questions/5
        //[Route("api/question/{id}")]
        //[HttpGet()]
        //public async Task<ActionResult<Question>> GetQuestion(int id)
        //{
        //    if (_context.Questions == null)
        //    {
        //        return NotFound();
        //    }
        //    Question question = new Question();
        //    question = await _context.Questions.FindAsync(id);
        //    var result = await GetQuestionWithAnswer(question.IdQuestion);
        //    question.IdAnswers = result.Value;


        //    if (question == null)
        //    {
        //        return NotFound();
        //    }

        //    return question;
        //}

        //GET: api/Questions/5
        [Route("api/questionWithAnswer/{id}")]
        [HttpGet()]
        public async Task<ActionResult<List<Answer>>> GetQuestionWithAnswer(int id)
        {
            List<Answer> answers = new List<Answer>();
            if (_context.Questions == null)
            {
                return NotFound();
            }
            var questionAnswers = await _context.Questions.Where(a => a.IdQuestion == id).SelectMany(a => a.QuestionAnswers).ToListAsync();
            foreach (var qa in questionAnswers)
            {
                answers.Add(qa.IdAnswerNavigation);
            }

            return answers;
        }

        // PUT: api/Questions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("api/question/{id}")]
        [HttpPut()]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if (id != question.IdQuestion)
            {
                return BadRequest();
            }
            //foreach (var q in question.IdAnswers)
            //{
            //    _context.Entry(q).State = EntityState.Unchanged;
            //}
            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
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

        //[Route("api/questionAnswerTable")]
        //[HttpPut]
        //public async Task<ActionResult<Question>> PutQuestionAnswerTable(Question question)
        //{
        //    Question newManyToMany = _context.Questions.Find(question.IdQuestion);
        //    if (newManyToMany != null)
        //    {
        //        newManyToMany.IdAnswers = question.IdAnswers;
        //        _context.Entry(newManyToMany).State = EntityState.Modified;
        //    }

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!QuestionExists(question.IdQuestion))
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

        // POST: api/Questions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("api/question")]
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(Question question)
        {
            if (_context.Questions == null)
            {
                return Problem("Entity set 'JustmeetContext.Questions'  is null.");
            }
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestion", new { id = question.IdQuestion }, question);
        }


        // DELETE: api/Questions/5
        [Route("api/question/{id}")]
        [HttpDelete()]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            if (_context.Questions == null)
            {
                return NotFound();
            }
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionExists(int id)
        {
            return (_context.Questions?.Any(e => e.IdQuestion == id)).GetValueOrDefault();
        }

        //[Route("api/questionAnswerTable/{idQuestion}/{idAnswer}")]
        //[HttpDelete()]
        //public async Task<IActionResult> DeleteQuestionAnswertable(int idQuestion, int idAnswer)
        //{
        //    if (_context.Questions == null)
        //    {
        //        return NotFound();
        //    }
        //    Question question = _context.Questions.Find(idQuestion);
        //    Answer answer = _context.Answers.Find(idAnswer);
        //    if (question == null || answer == null)
        //    {
        //        return NotFound();
        //    }
        //    question.IdAnswers.Add(answer);
        //    _context.Entry(question.IdAnswers).State = EntityState.Deleted;

        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
    }
}
