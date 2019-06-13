using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_sepomex.Models;
using ConciliatorServices.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_sepomex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("SepomexPolicy")]
    [ExceptionFilter]
    [Authorize("Bearer")]
    public class EmployeeController : ControllerBase
    {
        private readonly IntranetContext _context;

        public EmployeeController(IntranetContext context)
        {
            _context = context;
        }
        // GET api/employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return await _context.Employee.ToListAsync();
        }

        [HttpGet("{id}")]// GET api/employee/5
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var employee = await _context.Employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // POST api/employee
        [HttpPost]
        public async Task<ActionResult<Employee>> Post([FromBody]Employee employee)
        {
            int? max = _context.Employee.Count() > 0 ? _context.Employee.Select(c => c.EmployeeId).Max() : 0;
            _context.Employee.Add(new Employee
            {
                EmployeeId = max != 0 ? Convert.ToInt32(max) + 1 : 1,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                POB = employee.POB,
                UserID = 1,
                Active = employee.Active,
                ImageData = employee.ImageData,
                LastChange = DateTime.Now
            });
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = employee.EmployeeId }, employee);
        }

        // PUT api/employee/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Put(int id, [FromBody]Employee employee)
        {
            employee.LastChange = DateTime.Now;
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = employee.EmployeeId }, employee);
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}