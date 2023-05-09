using System.Text.Json.Serialization;

namespace JustMeetWebService.Models
{
    public partial class UserAnswer
    {
        //public int IdGame { get; set; }

        //public int IdUser { get; set; }

        //public int IdQuestion { get; set; }

        //public int? IdAnswer { get; set; }
        [JsonIgnore]
        public virtual UserGame? Id { get; set; } = null!;
        [JsonIgnore]
        public virtual Answer? IdAnswerNavigation { get; set; }
        [JsonIgnore]
        public virtual Question? IdQuestionNavigation { get; set; } = null!;
    }
}
