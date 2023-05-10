using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JustMeetWebService.Models;

public partial class QuestionAnswer
{
    public int IdQuestion { get; set; }

    public int IdAnswer { get; set; }

    public bool? Exist { get; set; }
    public virtual Answer? IdAnswerNavigation { get; set; } = null!;
    public virtual Question? IdQuestionNavigation { get; set; } = null!;
}
