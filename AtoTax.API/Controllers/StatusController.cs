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
    public class StatusController : ControllerBase
    {
        private readonly AtoTaxDbContext _context;
        private readonly IMapper _mapper;


        public StatusController(AtoTaxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Status
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<StatusDTO>>> GetStatus()
        {
          if (_context.Status == null)
          {
              return NotFound();
          }

            IEnumerable<Status> ListStatus = await _context.Status.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<StatusDTO>>(ListStatus));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Status>> CreateStatus(StatusCreateDTO statusCreateDTO)
        {
            if (_context.Status == null)
            {
                return Problem("Entity set 'Status'  is null.");
            }

            var status = _mapper.Map<Status>(statusCreateDTO);
            await _context.Status.AddAsync(status);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatus", new { id = status.Id }, status);
        }
    }
}
