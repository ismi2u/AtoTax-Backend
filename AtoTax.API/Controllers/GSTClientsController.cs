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

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class GSTClientsController : ControllerBase
    {
        private readonly AtoTaxDbContext _context;
        private readonly IMapper _mapper;

        public GSTClientsController(AtoTaxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/GSTClients
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<GSTClientDTO>>> GetGSTClients()
        {
          if (_context.GSTClients == null)
          {
              return NotFound();
          }

            IEnumerable<GSTClient> ListGSTClients =  await _context.GSTClients.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<GSTClientDTO>>(ListGSTClients));
        }

        // GET: api/GSTClients/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GSTClient>> GetGSTClient(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var gstClient = await _context.GSTClients.FindAsync(id);

            if (gstClient == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GSTClientDTO>(gstClient));
        }

        // PUT: api/GSTClients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGSTClient(int id, GSTClient gSTClient)
        {
            if (id != gSTClient.Id)
            {
                return BadRequest();
            }

            _context.Entry(gSTClient).State = EntityState.Modified;



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
        public async Task<ActionResult<GSTClientDTO>> CreateGSTClient(GSTClientCreateDTO createDTO)
        {
          if (_context.GSTClients == null)
          {
              return Problem("Entity set 'AtoTaxDbContext.GSTClients'  is null.");
          }

            GSTClient gstClient = new GSTClient();

            gstClient.ProprietorName = createDTO.ProprietorName;
            gstClient.GSTIN = createDTO.GSTIN;
            gstClient.ContactName = createDTO.ContactName;
            gstClient.GSTUserName = createDTO.GSTUserName;
            gstClient.GSTUserPassword = createDTO.GSTUserPassword;
            gstClient.ProprietorName = createDTO.ProprietorName;
            gstClient.GSTRegDate = createDTO.GSTRegDate;
            gstClient.GSTSurrenderedDate = createDTO.GSTSurrenderedDate;
            gstClient.GSTRelievedDate = createDTO.GSTRelievedDate;
            gstClient.GSTAnnualTurnOver = createDTO.GSTAnnualTurnOver;
            gstClient.MobileNumber = createDTO.MobileNumber;
            gstClient.PhoneNumber = createDTO.PhoneNumber;
            gstClient.ContactEmailId = createDTO.ContactEmailId;
            gstClient.GSTEmailId = createDTO.GSTEmailId;
            gstClient.GSTEmailPassword = createDTO.GSTEmailPassword;
            gstClient.GSTRecoveryEmailId = createDTO.GSTRecoveryEmailId;
            gstClient.GSTRecoveryEmailPassword = createDTO.GSTRecoveryEmailPassword;
            gstClient.EWAYBillUserName = createDTO.EWAYBillUserName;
            gstClient.EWAYBillPassword = createDTO.EWAYBillPassword;
            gstClient.RackFileNo = createDTO.RackFileNo;
            gstClient.TallyDataFilePath = createDTO.TallyDataFilePath;
            gstClient.CreatedOn = DateTime.UtcNow;
            gstClient.UpdatedOn = DateTime.UtcNow;

            await _context.GSTClients.AddAsync(_mapper.Map<GSTClient>(createDTO));
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
            if(id== 0)
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
