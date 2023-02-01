using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using AtoTax.Domain.DTOs;
using AutoMapper;
using AtoTax.API.Repository;
using AtoTax.API.Repository.IRepository;

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class GSTClientsController : ControllerBase
    {
        private readonly IGSTClientRepository _dbGSTClient;
        private readonly IMapper _mapper;

        public GSTClientsController(IGSTClientRepository dbGSTClient, IMapper mapper)
        {
            _dbGSTClient = dbGSTClient;
            _mapper = mapper;
        }

        // GET: api/GSTClients
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<GSTClientDTO>>> GetGSTClients()
        {
            IEnumerable<GSTClient> GSTClientsList = await _dbGSTClient.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<GSTClientDTO>>(GSTClientsList));
        }

        // GET: api/GSTClients/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GSTClientDTO>> GetGSTClient(Guid id)
        {
            GSTClient GSTClient = await _dbGSTClient.GetAsync(u => u.Id == id);

            return Ok(_mapper.Map<GSTClientDTO>(GSTClient));
        }

        // PUT: api/GSTClients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGSTClient(Guid id, GSTClientUpdateDTO gstClientUpdateDTO)
        {
           if(_dbGSTClient.GetAsync(u => u.Id ))
            var oldgstclient = await _context.GSTClients.AsNoTracking().FirstOrDefaultAsync(g=> g.Id==gstClientUpdateDTO.Id);

            var gstClient = _mapper.Map<GSTClient>(gstClientUpdateDTO);
            gstClient.GSTIN = oldgstclient.GSTIN;
            _context.Entry(gstClient).State = EntityState.Modified;

            _context.GSTClients.Update(gstClient);
            await _context.SaveChangesAsync();


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }

            return NoContent();
        }

        // POST: api/GSTClients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GSTClient>> CreateGSTClient(GSTClientCreateDTO gstClientCreateDTO)
        {

            if (_context.GSTClients == null)
            {
                return Problem("Entity set 'AtoTaxDbContext.GSTClients'  is null.");
            }

            var gstClient = _mapper.Map<GSTClient>(gstClientCreateDTO);
            await _context.GSTClients.AddAsync(gstClient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGSTClient", new { id = gstClient.Id }, gstClient);
        }

        // DELETE: api/GSTClients/5
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGSTClient(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            if (_context.GSTClients == null)
            {
                return NotFound();
            }
            var gstClient = await _context.GSTClients.FindAsync(id);
            if (gstClient == null)
            {
                return NotFound();
            }

            _context.GSTClients.Remove(gstClient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
