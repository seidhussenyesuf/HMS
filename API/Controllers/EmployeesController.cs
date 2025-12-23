using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            try
            {
                var employees = await _context.Employees
                    .Where(e => e.IsActive)
                    .OrderBy(e => e.Id)
                    .ToListAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // POST: api/employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee([FromBody] Employee employee)
        {
            try
            {
                Console.WriteLine($"API: Creating new employee - Name: {employee.Name}, Age: {employee.Age}");

                // Set default values
                employee.JoinDate = DateTime.UtcNow;
                employee.IsActive = true;

                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();

                Console.WriteLine($"API: Employee created with ID: {employee.Id}");
                return CreatedAtAction(nameof(GetEmployees), new { id = employee.Id }, employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"API Error in PostEmployee: {ex.Message}");
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT: api/employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, [FromBody] Employee employeeUpdate)
        {
            try
            {
                Console.WriteLine($"API: Updating employee ID: {id}");

                var employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                {
                    Console.WriteLine($"API: Employee with ID {id} not found");
                    return NotFound(new { error = $"Employee with ID {id} not found" });
                }

                // Update properties
                employee.Name = employeeUpdate.Name;
                employee.Age = employeeUpdate.Age;
                employee.Department = employeeUpdate.Department;
                employee.Position = employeeUpdate.Position;
                employee.Salary = employeeUpdate.Salary;
                employee.Phone = employeeUpdate.Phone ?? "";
                employee.Email = employeeUpdate.Email ?? "";
                employee.Address = employeeUpdate.Address ?? "";

                await _context.SaveChangesAsync();
                Console.WriteLine($"API: Employee ID {id} updated successfully");

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"API Error in PutEmployee: {ex.Message}");
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE: api/employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                Console.WriteLine($"API: Deleting employee ID: {id}");

                var employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                {
                    Console.WriteLine($"API: Employee with ID {id} not found");
                    return NotFound(new { error = $"Employee with ID {id} not found" });
                }

                employee.IsActive = false;
                await _context.SaveChangesAsync();

                Console.WriteLine($"API: Employee ID {id} marked as inactive");
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"API Error in DeleteEmployee: {ex.Message}");
                return BadRequest(new { error = ex.Message });
            }
        }

        // GET: api/employees/search?query=searchterm
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployees([FromQuery] string query)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(query))
                {
                    return await GetEmployees();
                }

                var employees = await _context.Employees
                    .Where(e => e.IsActive && (
                        e.Name.Contains(query) ||
                        e.Department.Contains(query) ||
                        e.Position.Contains(query) ||
                        e.Email.Contains(query) ||
                        e.Phone.Contains(query)
                    ))
                    .OrderBy(e => e.Id)
                    .ToListAsync();

                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}