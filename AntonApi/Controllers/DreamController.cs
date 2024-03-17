using AntonApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AntonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DreamController : ControllerBase
    {
        private readonly DreamContext _context;
        public DreamController(DreamContext context)
        {
            _context = context;
        }

        // GET: api/Dream
        [HttpGet]
        public ActionResult<IEnumerable<Dream>> GetDreams()
        {
            return _context.Dream.ToList();
        }

        // GET: api/Dream/1
        [HttpGet("{id}")]
        public ActionResult<Dream> GetDream(int id)
        {
            var dream = _context.Dream.Find(id);
            if (dream == null)
            {
                return NotFound();
            }
            return dream;
        }

        // GET: api/Dream/latest
        [HttpGet("latest")]
        public ActionResult<Dream> GetLatest()
        {
            var latestDream = _context.Dream.OrderByDescending(d => d.DatePosted).FirstOrDefault();

            if (latestDream == null)
            {
                return NotFound();
            }
            return latestDream;
        }

        // POST: api/Dream
        [HttpPost]
        public ActionResult<Dream> CreateDream(Dream dream)
        {
            if (dream == null)
            {
                return BadRequest();
            }
            _context.Dream.Add(dream);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetDream), new { id = dream.Id }, dream);
        }

        // PATCH: api/Dream/5
        [HttpPatch("{id}")]
        [Consumes("application/json-patch+json")]
        public ActionResult<Dream> PatchDream(int id, [FromBody] JsonPatchDocument<Dream> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var dream = _context.Dream.Find(id);
            if (dream == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(dream, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SaveChanges();

            return Ok(dream);
        }


        // DELETE: api/Dream/0  
        [HttpDelete("{id}")]
        public ActionResult DeleteDream(int id)
        {
            var dream = _context.Dream.Find(id);
            if (dream == null)
            {
                return NotFound();
            }

            _context.Dream.Remove(dream);
            _context.SaveChanges();

            return NoContent();
        }

    }
}