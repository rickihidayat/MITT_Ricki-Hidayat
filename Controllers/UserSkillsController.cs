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
    public class UserSkillsController : ControllerBase
    {
        private readonly MITT_RickiHIdayatContext _context;

        public UserSkillsController(MITT_RickiHIdayatContext context)
        {
            _context = context;
        }

        // GET: api/UserSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSkill>>> GetUserSkills()
        {
            return await _context.UserSkills.ToListAsync();
        }

        // GET: api/UserSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserSkill>> GetUserSkill(string id)
        {
            var userSkill = await _context.UserSkills.FindAsync(id);

            if (userSkill == null)
            {
                return NotFound();
            }

            return userSkill;
        }

        // PUT: api/UserSkills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserSkill(string id, UserSkill userSkill)
        {
            if (id != userSkill.UserSkillId)
            {
                return BadRequest();
            }

            _context.Entry(userSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSkillExists(id))
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

        // POST: api/UserSkills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserSkill>> PostUserSkill(UserSkill userSkill)
        {
            _context.UserSkills.Add(userSkill);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserSkillExists(userSkill.UserSkillId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserSkill", new { id = userSkill.UserSkillId }, userSkill);
        }

        // DELETE: api/UserSkills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserSkill(string id)
        {
            var userSkill = await _context.UserSkills.FindAsync(id);
            if (userSkill == null)
            {
                return NotFound();
            }

            _context.UserSkills.Remove(userSkill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserSkillExists(string id)
        {
            return _context.UserSkills.Any(e => e.UserSkillId == id);
        }
    }
}
