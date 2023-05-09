using System.Text.Json.Serialization;

namespace JustMeetWebService.Models
{
    public partial class Question
    {
        //public int IdQuestion { get; set; }

        //public string? Question1 { get; set; }

        //public int? IdGametype { get; set; }

        //public virtual Gametype? IdGametypeNavigation { get; set; }

        //public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();

        //public virtual List<Answer> IdAnswers { get; set; } = new List<Answer>();
        [JsonIgnore]
        public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; } = new List<QuestionAnswer>();

        //public virtual ICollection<Game> IdGames { get; set; } = new List<Game>();
    }
}
