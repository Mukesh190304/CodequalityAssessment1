using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaptchaGeneratorService.Data;
using CaptchaGeneratorService.Model;

namespace CaptchaGeneratorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaptchaGeneratorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CaptchaGeneratorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var generators = await _context.Generators.ToListAsync();
            return Ok(generators);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var generator = await _context.Generators.FindAsync(id);
            if (generator == null)
            {
                return NotFound();
            }
            return Ok(generator);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CaptchaGenerator generator)
        {
            _context.Generators.Add(generator);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), generator);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CaptchaGenerator generator)
        {
            var existingItem = await _context.Generators.FindAsync(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            existingItem.Type = generator.Type;
            existingItem.Description = generator.Description;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var generator = await _context.Generators.FindAsync(id);
            if (generator == null)
                return NotFound();
            _context.Generators.Remove(generator);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
