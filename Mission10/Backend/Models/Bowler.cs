using System;
using System.Collections.Generic;
// bowlers class. 
namespace Backend.Models;

// holds all of the bowler information. scaffolding did like all of this. pretty cool stuff. 
public partial class Bowler
{
    public int BowlerId { get; set; }

    public string? BowlerLastName { get; set; }

    public string? BowlerFirstName { get; set; }

    public string? BowlerMiddleInit { get; set; }

    public string? BowlerAddress { get; set; }

    public string? BowlerCity { get; set; }

    public string? BowlerState { get; set; }

    public string? BowlerZip { get; set; }

    public string? BowlerPhoneNumber { get; set; }

    public int? TeamId { get; set; }

    public virtual ICollection<BowlerScore> BowlerScores { get; set; } = new List<BowlerScore>();

    // this is the team that the bowler is on. can be pulled and passed to the frontend, in our case we're only looking for the name
    public virtual Team? Team { get; set; }
}
