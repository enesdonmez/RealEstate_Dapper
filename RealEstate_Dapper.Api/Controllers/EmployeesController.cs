using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Api.Dtos.CategoryDtos;
using RealEstate_Dapper.Api.Dtos.EmployeeDtos;
using RealEstate_Dapper.Api.Repositories.EmployeeRepositories;

namespace RealEstate_Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeList()
        {
            var values = await _employeeRepository.GetAllEmployee();

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            await _employeeRepository.CreateEmployee(createEmployeeDto);
            return Ok("Employee eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
            return Ok("Employee Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            await _employeeRepository.UpdateEmployee(updateEmployeeDto);
            return Ok("Güncellendi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployee(id);
            return Ok(employee);
        }
    }
}
