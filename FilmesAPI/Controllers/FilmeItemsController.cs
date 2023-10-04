using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmesAPI.Model;

namespace FilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeItemsController : ControllerBase
    {
        private readonly FilmesContext _context;

        public FilmeItemsController(FilmesContext context)
        {
            _context = context;
        }

        // GET: api/FilmeItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmeItem>>> GetFimesItens()
        {
          if (_context.FimesItens == null)
          {
              return NotFound();
          }
            return await _context.FimesItens.ToListAsync();
        }

        // GET: api/FilmeItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmeItem>> GetFilmeItem(int id)
        {
          if (_context.FimesItens == null)
          {
              return NotFound();
          }
            var filmeItem = await _context.FimesItens.FindAsync(id);

            if (filmeItem == null)
            {
                return NotFound();
            }

            return filmeItem;
        }

        // PUT: api/FilmeItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmeItem(int id, FilmeItem filmeItem)
        {
            if (id != filmeItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(filmeItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmeItemExists(id))
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

        // POST: api/FilmeItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FilmeItem>> PostFilmeItem(FilmeItem filmeItem)
        {
          if (_context.FimesItens == null)
          {
              return Problem("Entity set 'FilmesContext.FimesItens'  is null.");
          }
            _context.FimesItens.Add(filmeItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFilmeItem), new { id = filmeItem.Id }, filmeItem);
        }

        // DELETE: api/FilmeItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilmeItem(int id)
        {
            if (_context.FimesItens == null)
            {
                return NotFound();
            }
            var filmeItem = await _context.FimesItens.FindAsync(id);
            if (filmeItem == null)
            {
                return NotFound();
            }

            _context.FimesItens.Remove(filmeItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmeItemExists(int id)
        {
            return (_context.FimesItens?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
