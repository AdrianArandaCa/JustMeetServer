using System;
using System.Collections.Generic;

namespace JustMeetWebService.Models;

public partial class Game
{
    public int IdGame { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public bool? Match { get; set; }

    public virtual ICollection<UserGame> UserGames { get; set; } = new List<UserGame>();

    public virtual ICollection<Question> IdQuestions { get; set; } = new List<Question>();
}
