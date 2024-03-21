using Microsoft.AspNetCore.Mvc;

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
            try {
                var voteCounts = Enum.GetValues(typeof(VoteEnum))
                    .Cast<VoteEnum>()
                    .Select(g => dbContext.votes.Count(v => (int)v.vote == (int)g))
                    .ToArray();

                return Ok(voteCounts);
            } catch (System.Exception err) {
                Console.WriteLine(err);
                return BadRequest("There was something wrong with the database");
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostVote(PostVoteRequest request) {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try {
                var pseudonym = new Pseudonym { pseudonym = request.pseudonym };
                dbContext.pseudonyms.Add(pseudonym);
                await dbContext.SaveChangesAsync();

                var vote = new Vote { vote = (int)request.pokemon, pseudonym_id = pseudonym.id };
                dbContext.votes.Add(vote);
                await dbContext.SaveChangesAsync();
                return Ok("Your vote was computed");
                
            } catch (System.Exception err) {
                Console.WriteLine(err);
                return BadRequest("There was a problem either with your request or with the database");
            }
        }
    }
}
