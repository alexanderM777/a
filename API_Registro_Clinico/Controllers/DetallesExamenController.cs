using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Registro_Clinico.Data;
using SharedModels;

namespace API_Registro_Clinico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesExamenController : ControllerBase
    {
        private readonly RegistroClinicoContext _context;

        public DetallesExamenController(RegistroClinicoContext context)
        {
            _context = context;
        }

        // GET: api/DetallesExamen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallesExamen>>> GetDetallesExamen()
        {
            return await _context.DetallesExamen.ToListAsync();
        }

        // GET: api/DetallesExamen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallesExamen>> GetDetallesExamen(int id)
        {
            var detallesExamen = await _context.DetallesExamen.FindAsync(id);

            if (detallesExamen == null)
            {
                return NotFound();
            }

            return detallesExamen;
        }

        // PUT: api/DetallesExamen/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallesExamen(int id, DetallesExamen detallesExamen)
        {
            if (id != detallesExamen.DetallesExamenID)
            {
                return BadRequest();
            }

            _context.Entry(detallesExamen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallesExamenExists(id))
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

        // POST: api/DetallesExamen
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetallesExamen>> PostDetallesExamen(DetallesExamen detallesExamen)
        {
            _context.DetallesExamen.Add(detallesExamen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetallesExamen", new { id = detallesExamen.DetallesExamenID }, detallesExamen);
        }

        // DELETE: api/DetallesExamen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallesExamen(int id)
        {
            var detallesExamen = await _context.DetallesExamen.FindAsync(id);
            if (detallesExamen == null)
            {
                return NotFound();
            }

            _context.DetallesExamen.Remove(detallesExamen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetallesExamenExists(int id)
        {
            return _context.DetallesExamen.Any(e => e.DetallesExamenID == id);
        }
    }
}
