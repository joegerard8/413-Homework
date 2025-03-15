using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
// team class
namespace Backend.Models;

public partial class Team
{
    public int TeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public int? CaptainId { get; set; }

    // creating a relationship with the bowler class. this is a one to many relationship. one team can have many bowlers.
    public virtual ICollection<Bowler> Bowlers { get; set; } = new List<Bowler>();

    public virtual ICollection<TourneyMatch> TourneyMatchEvenLaneTeams { get; set; } = new List<TourneyMatch>();

    public virtual ICollection<TourneyMatch> TourneyMatchOddLaneTeams { get; set; } = new List<TourneyMatch>();
}
