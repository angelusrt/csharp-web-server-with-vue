using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers {
    [Route("api/vote")]
    [ApiController]
    public class Controller : ControllerBase {
        private readonly ApplicationDbContext dbContext;

        public Controller(ApplicationDbContext dbContext) {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetVote() {
            var voteCounts = await dbContext.votes
                .GroupBy(v => v.vote)
                .Select(g => new { vote = g.Key, count = g.Count() })
                .ToListAsync();

            return Ok(voteCounts);
        }

        [HttpPost]
        public async Task<IActionResult> PostVote(PostVoteRequest request) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var pseudonym = new Pseudonym { pseudonym = request.pseudonym };
            var vote = new Vote { vote = request.pokemon, pseudonym_id = pseudonym.id };

            dbContext.pseudonyms.Add(pseudonym);
            dbContext.votes.Add(vote);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(PostVote), vote);
        }
    }
}
