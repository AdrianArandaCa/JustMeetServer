using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JustMeetWebService.Models;

public partial class Game
{
    public int IdGame { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public bool? Match { get; set; }
    [JsonIgnore]
    public virtual ICollection<UserGame> UserGames { get; set; } = new List<UserGame>();
    [JsonIgnore]
    public virtual ICollection<Question> IdQuestions { get; set; } = new List<Question>();
}
