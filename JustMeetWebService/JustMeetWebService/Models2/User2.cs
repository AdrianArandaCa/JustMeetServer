﻿using System.Text.Json.Serialization;

namespace JustMeetWebService.Models
{
    public partial class User
    {
        //public int IdUser { get; set; }

        //public string Name { get; set; } = null!;

        //public string? Password { get; set; }

        //public string? Email { get; set; }

        //public int? Birthday { get; set; }

        //public string? Genre { get; set; }

        public string? Photo { get; set; }

        //public string? Description { get; set; }

        //public bool? Premium { get; set; }

        //public int? IdSetting { get; set; }

        //public virtual Setting? IdSettingNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
        [JsonIgnore]
        public virtual ICollection<UserGame> UserGames { get; set; } = new List<UserGame>();
    }
}
