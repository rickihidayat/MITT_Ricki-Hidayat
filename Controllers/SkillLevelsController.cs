using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MITT_Ricki_Hidayat.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITT_Ricki_Hidayat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillLevelsController : ControllerBase
    {
        private readonly MITT_RickiHIdayatContext _context;

        public SkillLevelsController(MITT_RickiHIdayatContext context)
        {
            _context = context;
        }

        // GET: api/SkillLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillLevel>>> GetSkillLevels()
        {
            return await _context.SkillLevels.ToListAsync();
        }

        // GET: api/SkillLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SkillLevel>> GetSkillLevel(int id)
        {
            var skillLevel = await _context.SkillLevels.FindAsync(id);

            if (skillLevel == null)
            {
                return NotFound();
            }

            return skillLevel;
        }

        // PUT: api/SkillLevels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkillLevel(int id, SkillLevel skillLevel)
        {
            if (id != skillLevel.SkillLevelId)
            {
                return BadRequest();
            }

            _context.Entry(skillLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillLevelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SkillLevels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SkillLevel>> PostSkillLevel(SkillLevel skillLevel)
        {
            _context.SkillLevels.Add(skillLevel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SkillLevelExists(skillLevel.SkillLevelId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSkillLevel", new { id = skillLevel.SkillLevelId }, skillLevel);
        }

        // DELETE: api/SkillLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkillLevel(int id)
        {
            var skillLevel = await _context.SkillLevels.FindAsync(id);
            if (skillLevel == null)
            {
                return NotFound();
            }

            _context.SkillLevels.Remove(skillLevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SkillLevelExists(int id)
        {
            return _context.SkillLevels.Any(e => e.SkillLevelId == id);
        }
    }
}
