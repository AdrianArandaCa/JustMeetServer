

using System.Text.Json.Serialization;

namespace JustMeetWebService.Models
{
    public partial class QuestionAnswer
    {
        [JsonIgnore]
        public virtual Answer? IdAnswerNavigation { get; set; } = null!;
        [JsonIgnore]
        public virtual Question? IdQuestionNavigation { get; set; } = null!;
    }
}
