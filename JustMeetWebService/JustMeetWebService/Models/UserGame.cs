using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace JustMeetWebService.Models;

public partial class UserGame
{
    public int IdGame { get; set; }

    public int IdUser { get; set; }
    [JsonIgnore]
    public virtual Game IdGameNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual User IdUserNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
}
