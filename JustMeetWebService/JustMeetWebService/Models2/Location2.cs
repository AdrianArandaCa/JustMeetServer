using System.Text.Json.Serialization;

namespace JustMeetWebService.Models
{
    public partial class Location
    {
        [JsonIgnore]
        public virtual User? IdUserNavigation { get; set; } = null!;
    }
}
