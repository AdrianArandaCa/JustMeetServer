using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JustMeetWebService.Models;

public partial class Gametype
{
    public int IdGametype { get; set; }

    public string Type { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
    [JsonIgnore]
    public virtual ICollection<Setting> Settings { get; set; } = new List<Setting>();
}
