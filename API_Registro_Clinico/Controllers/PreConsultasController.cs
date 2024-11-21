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
    public class PreConsultasController : ControllerBase
    {
        private readonly RegistroClinicoContext _context;

        public PreConsultasController(RegistroClinicoContext context)
        {
            _context = context;
        }

        // GET: api/PreConsultas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreConsulta>>> GetPreConsulta()
        {
            return await _context.PreConsulta.ToListAsync();
        }

        // GET: api/PreConsultas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreConsulta>> GetPreConsulta(int id)
        {
            var preConsulta = await _context.PreConsulta.FindAsync(id);

            if (preConsulta == null)
            {
                return NotFound();
            }

            return preConsulta;
        }

        // PUT: api/PreConsultas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreConsulta(int id, PreConsulta preConsulta)
        {
            if (id != preConsulta.PreConsultaID)
            {
                return BadRequest();
            }

            _context.Entry(preConsulta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreConsultaExists(id))
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

        // POST: api/PreConsultas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PreConsulta>> PostPreConsulta(PreConsulta preConsulta)
        {
            _context.PreConsulta.Add(preConsulta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreConsulta", new { id = preConsulta.PreConsultaID }, preConsulta);
        }

        // DELETE: api/PreConsultas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreConsulta(int id)
        {
            var preConsulta = await _context.PreConsulta.FindAsync(id);
            if (preConsulta == null)
            {
                return NotFound();
            }

            _context.PreConsulta.Remove(preConsulta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PreConsultaExists(int id)
        {
            return _context.PreConsulta.Any(e => e.PreConsultaID == id);
        }
    }
}
