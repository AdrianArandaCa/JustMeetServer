using System;
using System.Collections.Generic;

namespace JustMeetWebService.Models;

public partial class UserGame
{
    public int IdGame { get; set; }

    public int IdUser { get; set; }

    public virtual Game IdGameNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
}
