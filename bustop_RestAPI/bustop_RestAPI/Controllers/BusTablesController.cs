using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bustop_RestAPI.Models;

namespace bustop_RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusTablesController : ControllerBase
    {
        private readonly BusContext _context;

        public BusTablesController(BusContext context)
        {
            _context = context;
        }

        // GET: api/BusTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusTable>>> GetBusTables()
        {
          if (_context.BusTables == null)
          {
              return NotFound();
          }
            return await _context.BusTables.ToListAsync();
        }

        // GET: api/BusTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusTable>> GetBusTable(int id)
        {
          if (_context.BusTables == null)
          {
              return NotFound();
          }
            var busTable = await _context.BusTables.FindAsync(id);

            if (busTable == null)
            {
                return NotFound();
            }

            return busTable;
        }

        // PUT: api/BusTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusTable(int id, BusTable busTable)
        {
            if (id != busTable.BusIdx)
            {
                return BadRequest();
            }

            _context.Entry(busTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusTableExists(id))
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

        // POST: api/BusTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BusTable>> PostBusTable(BusTable busTable)
        {
          if (_context.BusTables == null)
          {
              return Problem("Entity set 'BusContext.BusTables'  is null.");
          }
            _context.BusTables.Add(busTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusTable", new { id = busTable.BusIdx }, busTable);
        }

        // DELETE: api/BusTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusTable(int id)
        {
            if (_context.BusTables == null)
            {
                return NotFound();
            }
            var busTable = await _context.BusTables.FindAsync(id);
            if (busTable == null)
            {
                return NotFound();
            }

            _context.BusTables.Remove(busTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusTableExists(int id)
        {
            return (_context.BusTables?.Any(e => e.BusIdx == id)).GetValueOrDefault();
        }
    }
}