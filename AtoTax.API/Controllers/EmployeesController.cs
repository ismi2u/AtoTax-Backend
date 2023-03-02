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
    [Authorize(Roles="Admin")]
    public class EmployeesController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public EmployeesController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context)
        {
            _mapper = mapper;
            this._response= new();
            _context = context;
            _unitOfWork= unitOfWork;
        }

        // GET: api/Employee
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetEmployees()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            includelist.Add("EmpJobRole");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<Employee> EmployeeList = await _unitOfWork.Employees.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<EmployeeDTO>>(EmployeeList);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.SuccessMessage = null;
                _response.ErrorMessages = null;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = null;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { ex.Message.ToString() };
            }
            return Ok(_response);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetActiveEmployeesForDD()
        {
          
            try
            {
                IEnumerable<Employee> EmployeeList = await _unitOfWork.Employees.GetAllAsync(a => a.StatusId == (int)EStatus.active, 0, 0);

                _response.Result = _mapper.Map<IEnumerable<ActiveEmployeesForDD>>(EmployeeList);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.SuccessMessage = null;
                _response.ErrorMessages = null;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = null;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { ex.Message.ToString() };
            }
            return Ok(_response);
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
            includelist.Add("EmpJobRole");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                Employee Employee = await _unitOfWork.Employees.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<EmployeeDTO>(Employee);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.SuccessMessage = null;
                _response.ErrorMessages = null;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = null;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { ex.Message.ToString() };
            }
            return Ok(_response);
           
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateEmployee(Guid id, EmployeeUpdateDTO EmployeeUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = EmployeeUpdateDTO;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { "Employee modelstate invalid" };
                return Ok(_response);
            }

            try
            {
                if (id == Guid.Empty || !(id == EmployeeUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = EmployeeUpdateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "Update Employee failed" };
                    return Ok(_response);
                }


                var oldEmployee = await _unitOfWork.Employees.GetAsync(u => u.Id == id, tracked: false);

                if (oldEmployee == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.Result = EmployeeUpdateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "Employee data is Null" };
                    return Ok(_response);
                }

                var Employee = _mapper.Map<Employee>(EmployeeUpdateDTO);

                //// dont update the DOB number which is the Identity of the Employee
                Employee.DOB = oldEmployee.DOB;
               

                //// dont update the below field as they are not part of updateDTO  and hence will become null
                Employee.CreatedDate = oldEmployee.CreatedDate;

                await _unitOfWork.Employees.UpdateAsync(Employee);

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = Employee;
                _response.IsSuccess = true;
                _response.SuccessMessage = "Employee updated";
                _response.ErrorMessages = null;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = null;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { ex.Message.ToString() };
            }
            return Ok(_response);
        }

        // POST: api/Employee
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateEmployee(EmployeeCreateDTO EmployeeCreateDTO)
        {
            try
            {

                if (await _unitOfWork.Employees.GetAsync(u => u.FirstName == EmployeeCreateDTO.FirstName 
                                                && u.LastName == EmployeeCreateDTO.LastName
                                                && u.DOB == EmployeeCreateDTO.DOB) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = EmployeeCreateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "Employee not found" };
                    return Ok(_response);
                }
                var Employee = _mapper.Map<Employee>(EmployeeCreateDTO);
                Employee.CreatedDate= DateTime.UtcNow;
                await _unitOfWork.Employees.CreateAsync(Employee);

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.Created;
                _response.Result = _mapper.Map<EmployeeDTO>(Employee);
                _response.IsSuccess = false;
                _response.SuccessMessage = "New Employee created";
                _response.ErrorMessages = null;

                return CreatedAtAction("GetEmployee", new { id = Employee.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = null;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { ex.Message.ToString() };
            }
            return Ok(_response);
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
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "Employee Id not found" };
                    return Ok(_response);
                }
                var Employee = await _unitOfWork.Employees.GetAsync(u => u.Id == id);
                if (Employee == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "Employee not found" };
                    return Ok(_response);
                }

                await _unitOfWork.Employees.RemoveAsync(Employee);

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = Employee;
                _response.IsSuccess = true;
                _response.SuccessMessage = "Employee deleted";
                _response.ErrorMessages = null;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = null;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { ex.Message.ToString() };
            }
            return Ok(_response);
        }

    }
}
