using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JustMeetWebService.Models;

public partial class Setting
{
    public int IdSetting { get; set; }

    public double? MaxDistance { get; set; }

    public int? MinAge { get; set; }

    public int? MaxAge { get; set; }

    public string? Genre { get; set; }

    public int? IdGametype { get; set; }

    public virtual Gametype? IdGametypeNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
