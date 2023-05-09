using System.Text.Json.Serialization;

namespace JustMeetWebService.Models
{
    public partial class Answer
    {
        //public int IdAnswer { get; set; }

        //public string? Answer1 { get; set; }

        //public bool? Selected { get; set; }

        [JsonIgnore]
        public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; } = new List<QuestionAnswer>();

        public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
    }
}
