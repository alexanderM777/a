﻿using System;
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
    public class HistorialMedicoController : ControllerBase
    {
        private readonly RegistroClinicoContext _context;

        public HistorialMedicoController(RegistroClinicoContext context)
        {
            _context = context;
        }

        // GET: api/HistorialMedicoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialMedico>>> GetHistorialMedico()
        {
            return await _context.HistorialMedico.ToListAsync();
        }

        // GET: api/HistorialMedicoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialMedico>> GetHistorialMedico(int id)
        {
            var historialMedico = await _context.HistorialMedico.FindAsync(id);

            if (historialMedico == null)
            {
                return NotFound();
            }

            return historialMedico;
        }

        // PUT: api/HistorialMedicoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialMedico(int id, HistorialMedico historialMedico)
        {
            if (id != historialMedico.HistorialMedicoID)
            {
                return BadRequest();
            }

            _context.Entry(historialMedico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialMedicoExists(id))
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

        // POST: api/HistorialMedicoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistorialMedico>> PostHistorialMedico(HistorialMedico historialMedico)
        {
            _context.HistorialMedico.Add(historialMedico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorialMedico", new { id = historialMedico.HistorialMedicoID }, historialMedico);
        }

        // DELETE: api/HistorialMedicoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialMedico(int id)
        {
            var historialMedico = await _context.HistorialMedico.FindAsync(id);
            if (historialMedico == null)
            {
                return NotFound();
            }

            _context.HistorialMedico.Remove(historialMedico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialMedicoExists(int id)
        {
            return _context.HistorialMedico.Any(e => e.HistorialMedicoID == id);
        }
    }
}
