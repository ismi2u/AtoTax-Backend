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
using System.Net;
using AtoTax.API.Repository.Interfaces;
using AtoTax.API.GenericRepository;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    //[Authorize(Roles="User")]
    public class FrequencyController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public FrequencyController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context)
        {
            _mapper = mapper;
            this._response= new();
            _context = context;
            _unitOfWork= unitOfWork;
        }

        // GET: api/Frequency
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetFrequency()
        {

            List<string> includelist = new List<string>();
             string[] arrIncludes = includelist.ToArray();

            try
            {

                
                IEnumerable<Frequency> FrequencyList = await _unitOfWork.Frequencies.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<FrequencyDTO>>(FrequencyList);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess= false;
                _response.ErrorMessages= new List<string>() { ex.ToString()};
            }
            return Ok(_response);
        }

        // GET: api/Frequency/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetFrequency(int id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("PaymentType");
            includelist.Add("GSTClient");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                Frequency Frequency = await _unitOfWork.Frequencies.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<FrequencyDTO>(Frequency);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);

        }


        //// POST: api/Frequency
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<APIResponse>> CreateFrequency(FrequencyCreateDTO FrequencyCreateDTO)
        //{
           
        //    try
        //    {

        //        var Frequency = _mapper.Map<Frequency>(FrequencyCreateDTO);


        //        //if(Frequency.ExpenseAmount==0)
        //        //{
        //        //    Frequency.ExpenseAmount = null;
        //        //}
        //        //if (Frequency.IncomeAmount == 0)
        //        //{
        //        //    Frequency.IncomeAmount = null;
        //        //}



        //        //Frequency.TransactionDate = DateTime.UtcNow;
        //        //Frequency.TransactionRecordedBy = User.Identity.Name;


        //        await _unitOfWork.Frequencies.CreateAsync(Frequency);

        //        await _unitOfWork.CompleteAsync();
        //        _response.Result = _mapper.Map<FrequencyDTO>(Frequency);
        //        _response.StatusCode = HttpStatusCode.Created;
        //        _response.IsSuccess = true;
        //        _response.SuccessMessage = "Account Ledger data entered successfully";
        //        _response.ErrorMessages =null;

        //        return CreatedAtAction("GetFrequency", new { id = Frequency.Id }, _response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.StatusCode = HttpStatusCode.BadRequest;
        //        _response.IsSuccess = false;
        //        _response.SuccessMessage = null;
        //        _response.ErrorMessages = new List<string>() { ex.ToString() };
        //    }
        //    return Ok(_response);
        //}
    }
}
