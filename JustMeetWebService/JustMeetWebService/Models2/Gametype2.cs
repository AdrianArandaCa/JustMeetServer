using System.Text.Json.Serialization;

namespace JustMeetWebService.Models
{
    public partial class Gametype
    {
        [JsonIgnore]
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
        [JsonIgnore]
        public virtual ICollection<Setting> Settings { get; set; } = new List<Setting>();
    }
}
