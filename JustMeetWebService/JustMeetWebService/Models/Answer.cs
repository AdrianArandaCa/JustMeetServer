using System;
using System.Collections.Generic;

namespace JustMeetWebService.Models;

public partial class Answer
{
    public int IdAnswer { get; set; }

    public string? Answer1 { get; set; }

    public bool? Selected { get; set; }

    public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();

    public virtual ICollection<Question> IdQuestions { get; set; } = new List<Question>();
}
