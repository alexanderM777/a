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
    public class DetallesExamenesResultadosController : ControllerBase
    {
        private readonly RegistroClinicoContext _context;

        public DetallesExamenesResultadosController(RegistroClinicoContext context)
        {
            _context = context;
        }

        // GET: api/DetallesExamenesResultados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallesExamenesResultados>>> GetDetallesExamenesResultados()
        {
            return await _context.DetallesExamenesResultados.ToListAsync();
        }

        // GET: api/DetallesExamenesResultados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallesExamenesResultados>> GetDetallesExamenesResultados(int id)
        {
            var detallesExamenesResultados = await _context.DetallesExamenesResultados.FindAsync(id);

            if (detallesExamenesResultados == null)
            {
                return NotFound();
            }

            return detallesExamenesResultados;
        }

        // PUT: api/DetallesExamenesResultados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallesExamenesResultados(int id, DetallesExamenesResultados detallesExamenesResultados)
        {
            if (id != detallesExamenesResultados.DetallesExamenesResultadosID)
            {
                return BadRequest();
            }

            _context.Entry(detallesExamenesResultados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallesExamenesResultadosExists(id))
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

        // POST: api/DetallesExamenesResultados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetallesExamenesResultados>> PostDetallesExamenesResultados(DetallesExamenesResultados detallesExamenesResultados)
        {
            _context.DetallesExamenesResultados.Add(detallesExamenesResultados);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetallesExamenesResultados", new { id = detallesExamenesResultados.DetallesExamenesResultadosID }, detallesExamenesResultados);
        }

        // DELETE: api/DetallesExamenesResultados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallesExamenesResultados(int id)
        {
            var detallesExamenesResultados = await _context.DetallesExamenesResultados.FindAsync(id);
            if (detallesExamenesResultados == null)
            {
                return NotFound();
            }

            _context.DetallesExamenesResultados.Remove(detallesExamenesResultados);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetallesExamenesResultadosExists(int id)
        {
            return _context.DetallesExamenesResultados.Any(e => e.DetallesExamenesResultadosID == id);
        }
    }
}
