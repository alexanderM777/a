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
    public class PrescripcionMedicasController : ControllerBase
    {
        private readonly RegistroClinicoContext _context;

        public PrescripcionMedicasController(RegistroClinicoContext context)
        {
            _context = context;
        }

        // GET: api/PrescripcionMedicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrescripcionMedica>>> GetPrescripcionMedica()
        {
            return await _context.PrescripcionMedica.ToListAsync();
        }

        // GET: api/PrescripcionMedicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrescripcionMedica>> GetPrescripcionMedica(int id)
        {
            var prescripcionMedica = await _context.PrescripcionMedica.FindAsync(id);

            if (prescripcionMedica == null)
            {
                return NotFound();
            }

            return prescripcionMedica;
        }

        // PUT: api/PrescripcionMedicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescripcionMedica(int id, PrescripcionMedica prescripcionMedica)
        {
            if (id != prescripcionMedica.PrescripcionMedicaID)
            {
                return BadRequest();
            }

            _context.Entry(prescripcionMedica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrescripcionMedicaExists(id))
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

        // POST: api/PrescripcionMedicas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PrescripcionMedica>> PostPrescripcionMedica(PrescripcionMedica prescripcionMedica)
        {
            _context.PrescripcionMedica.Add(prescripcionMedica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrescripcionMedica", new { id = prescripcionMedica.PrescripcionMedicaID }, prescripcionMedica);
        }

        // DELETE: api/PrescripcionMedicas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescripcionMedica(int id)
        {
            var prescripcionMedica = await _context.PrescripcionMedica.FindAsync(id);
            if (prescripcionMedica == null)
            {
                return NotFound();
            }

            _context.PrescripcionMedica.Remove(prescripcionMedica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrescripcionMedicaExists(int id)
        {
            return _context.PrescripcionMedica.Any(e => e.PrescripcionMedicaID == id);
        }
    }
}
