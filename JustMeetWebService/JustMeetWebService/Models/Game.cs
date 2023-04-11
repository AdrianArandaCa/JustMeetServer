using System;
using System.Collections.Generic;

namespace JustMeetWebService.Models;

public partial class Game
{
    public int IdGame { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public bool? Match { get; set; }

    public virtual ICollection<Question> IdQuestions { get; set; } = new List<Question>();

    public virtual ICollection<User> IdUsers { get; set; } = new List<User>();
}
