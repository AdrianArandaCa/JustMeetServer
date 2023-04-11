using System;
using System.Collections.Generic;

namespace JustMeetWebService.Models;

public partial class UserAnswer
{
    public int IdGame { get; set; }

    public int IdUser { get; set; }

    public int IdQuestion { get; set; }

    public int? IdAnswer { get; set; }

    public virtual UserGame Id { get; set; } = null!;

    public virtual Answer? IdAnswerNavigation { get; set; }

    public virtual Question IdQuestionNavigation { get; set; } = null!;
}
