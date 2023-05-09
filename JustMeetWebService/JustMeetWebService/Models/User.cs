using System;
using System.Collections.Generic;

namespace JustMeetWebService.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Name { get; set; } = null!;

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Genre { get; set; }

    public int? Photo { get; set; }

    public string? Description { get; set; }

    public bool? Premium { get; set; }

    public int? IdSetting { get; set; }

    public int? Birthday { get; set; }

    public virtual Setting? IdSettingNavigation { get; set; }

    //public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    //public virtual ICollection<UserGame> UserGames { get; set; } = new List<UserGame>();
}
