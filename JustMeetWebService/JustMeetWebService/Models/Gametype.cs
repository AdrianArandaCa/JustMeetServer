using System;
using System.Collections.Generic;

namespace JustMeetWebService.Models;

public partial class Gametype
{
    public int IdGametype { get; set; }

    public string Type { get; set; } = null!;

    //public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    //public virtual ICollection<Setting> Settings { get; set; } = new List<Setting>();
}
