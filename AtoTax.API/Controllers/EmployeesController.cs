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

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IEmployeeRepository _dbEmployee;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public EmployeesController(IEmployeeRepository dbEmployee, IMapper mapper, AtoTaxDbContext context)
        {
            _dbEmployee = dbEmployee;
            _mapper = mapper;
            this._response= new();
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetEmployee()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<Employee> EmployeeList = await _dbEmployee.GetAllAsync(null, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<EmployeeDTO>>(EmployeeList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess= false;
                _response.ErrorMessages= new List<string>() { ex.ToString()};
            }
            return _response;
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetEmployee(Guid id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                Employee Employee = await _dbEmployee.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<EmployeeDTO>(Employee);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
           
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateEmployee(Guid id, EmployeeUpdateDTO EmployeeUpdateDTO)
        {
            try
            {
                if (id == Guid.Empty || !(id == EmployeeUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldEmployee = await _dbEmployee.GetAsync(u => u.Id == id, tracked: false);

                if (oldEmployee == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                var Employee = _mapper.Map<Employee>(EmployeeUpdateDTO);

                //// dont update the DOB number which is the Identity of the Employee
                Employee.DOB = oldEmployee.DOB;
               

                //// dont update the below field as they are not part of updateDTO  and hence will become null
                Employee.CreatedDate = oldEmployee.CreatedDate;

                await _dbEmployee.UpdateAsync(Employee);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return _response;
                 }

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = Employee;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST: api/Employee
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateEmployee(EmployeeCreateDTO EmployeeCreateDTO)
        {
            try
            {

                if (await _dbEmployee.GetAsync(u => u.FirstName == EmployeeCreateDTO.FirstName 
                                                && u.LastName == EmployeeCreateDTO.LastName
                                                && u.DOB == EmployeeCreateDTO.DOB) != null)
                {
                    _response.ErrorMessages = new List<string>() { "Employee already Exists"};
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var Employee = _mapper.Map<Employee>(EmployeeCreateDTO);
                Employee.CreatedDate= DateTime.UtcNow;
                await _dbEmployee.CreateAsync(Employee);

                _response.Result = _mapper.Map<EmployeeDTO>(Employee);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction("GetEmployee", new { id = Employee.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE: api/Employee/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteEmployee(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var Employee = await _dbEmployee.GetAsync(u => u.Id == id);
                if (Employee == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _dbEmployee.RemoveAsync(Employee);

                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

    }
}
