using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab5.Models;

namespace Lab5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToWatchItemsController : ControllerBase
    {
        private readonly ToWatchContext _context;

        public ToWatchItemsController(ToWatchContext context)
        {
            _context = context;
        }

        // GET: api/ToWatchItems
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ToWatchItem>>> GetToWatchItems()
        {
            return await _context.ToWatchItems.ToListAsync();
        }

        // GET: api/ToWatchItems/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ToWatchItem>> GetToWatchItem(long id)
        {
            var toWatchItem = await _context.ToWatchItems.FindAsync(id);

            if (toWatchItem == null)
            {
                return NotFound();
            }

            return toWatchItem;
        }

        // PUT: api/ToWatchItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutToWatchItem(long id, ToWatchItem toWatchItem)
        {
            if (id != toWatchItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(toWatchItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToWatchItemExists(id))
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

        // POST: api/ToWatchItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ToWatchItem>> PostToWatchItem(ToWatchItem toWatchItem)
        {
            _context.ToWatchItems.Add(toWatchItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToWatchItem", new { id = toWatchItem.Id }, toWatchItem);
        }

        // DELETE: api/ToWatchItems/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteToWatchItem(long id)
        {
            var toWatchItem = await _context.ToWatchItems.FindAsync(id);
            if (toWatchItem == null)
            {
                return NotFound();
            }

            _context.ToWatchItems.Remove(toWatchItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToWatchItemExists(long id)
        {
            return _context.ToWatchItems.Any(e => e.Id == id);
        }
    }
}
