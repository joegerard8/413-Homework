using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    // controller for handling bowler requests. the route is /api/bowlers
    [Route("api/[controller]")]
    [ApiController]
    public class BowlersController : ControllerBase
    {
        private readonly AppDbContext _context;

        // constructor for the bowlers controller. takes in the appdbcontext to access the database.
        public BowlersController(AppDbContext context)
        {
            _context = context;
        }

        // http get method for api/Bowlers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bowler>>> GetBowlers()
        {
            // gets  all bowlers and then also pulls the team name from the team table.
            var bowlersWithTeams = await _context.Bowlers
                .Select(b => new
                    {
                        b.BowlerId,
                        b.BowlerFirstName,
                        b.BowlerMiddleInit,
                        b.BowlerLastName,
                        b.BowlerAddress,
                        b.BowlerCity,
                        b.BowlerState,
                        b.BowlerZip,
                        b.BowlerPhoneNumber,
                        TeamName = b.Team != null ? b.Team.TeamName : null // Only pulling the team name
                    })
                .ToListAsync();
            // returns the bowlers with their teams in a json format. nice. 
            return Ok(bowlersWithTeams);
        }
    }
}

