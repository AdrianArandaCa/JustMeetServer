using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace JustMeetWebService.Models;

public partial class Location
{
    public int? IdLocation { get; set; }

    public double? Longitud { get; set; }

    public double? Latitud { get; set; }

    public int IdUser { get; set; }
    [JsonIgnore]
    public virtual User? IdUserNavigation { get; set; } = null!;
}
