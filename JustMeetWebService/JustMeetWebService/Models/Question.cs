using System;
using System.Collections.Generic;

namespace JustMeetWebService.Models;

public partial class Question
{
    public int IdQuestion { get; set; }

    public string Question1 { get; set; } = null!;

    public int IdGametype { get; set; }

    public virtual Gametype IdGametypeNavigation { get; set; } = null!;

    public virtual ICollection<Answer> IdAnswers { get; set; } = new List<Answer>();

    public virtual ICollection<Game> IdGames { get; set; } = new List<Game>();
}
