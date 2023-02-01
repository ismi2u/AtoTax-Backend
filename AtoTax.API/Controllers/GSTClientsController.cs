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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateGSTClient(Guid id, GSTClientUpdateDTO gstClientUpdateDTO)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            if (!(id == gstClientUpdateDTO.Id))
            {
                return BadRequest();
            }

            if (await _dbGSTClient.GetAsync(u => u.Id == id) == null)
            {
                return NoContent();
            }

            var oldgstclient = await _dbGSTClient.GetAsync(u => u.Id == id, tracked:false);

            var gstClient = _mapper.Map<GSTClient>(gstClientUpdateDTO);
            gstClient.GSTIN = oldgstclient.GSTIN; // dont update the GSTIN number which is the Identity of the GST Client

            await _dbGSTClient.UpdateAsync(gstClient);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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

            if (await _dbGSTClient.GetAsync(u => u.GSTIN == gstClientCreateDTO.GSTIN) != null)
            {
                return BadRequest(gstClientCreateDTO);
            }
            if (await _dbGSTClient.GetAsync(u => u.ProprietorName == gstClientCreateDTO.ProprietorName) != null)
            {
                return BadRequest(gstClientCreateDTO);
            }
            var gstClient = _mapper.Map<GSTClient>(gstClientCreateDTO);
            await _dbGSTClient.CreateAsync(gstClient);
            return CreatedAtAction("GetGSTClient", new { id = gstClient.Id }, gstClient);
        }

        // DELETE: api/GSTClients/5
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGSTClient(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest();
            }
            var gstClient = await _dbGSTClient.GetAsync(u => u.Id == id);
            if (gstClient == null)
            {
                return NotFound();
            }

            await _dbGSTClient.RemoveAsync(gstClient);
            return NoContent();
        }

    }
}
