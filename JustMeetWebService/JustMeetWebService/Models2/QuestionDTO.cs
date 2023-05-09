using JustMeetWebService.Models;

namespace JustMeetWebService.Models2
{
    public class QuestionDTO
    {
        public int IdQuestion { get; set; }

        public string? Question1 { get; set; }

        public int? IdGametype { get; set; }

        public virtual Gametype? IdGametypeNavigation { get; set; }

        public ICollection<Answer>? Answers { get; set; } = new List<Answer>();

        public QuestionDTO(int idQuestion, string? question1, int? idGametype, Gametype? idGametypeNavigation)
        {
            IdQuestion = idQuestion;
            Question1 = question1;
            IdGametype = idGametype;
            IdGametypeNavigation = idGametypeNavigation;
        }

        public QuestionDTO()
        {
        }
    }


}
