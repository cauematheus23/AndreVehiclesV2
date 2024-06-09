using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreVehiclesV2Employee.Data;
using Models;
using AndreVehiclesV2AdressAPI.Integration.Interfaces;
using Models.DTO;

namespace AndreVehiclesV2Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AndreVehiclesV2EmployeeContext _context;
        private readonly ICepAPI _cepAPI;
        //Injetei as dependecias da API externa
        public EmployeesController(AndreVehiclesV2EmployeeContext context,ICepAPI cepAPI)
        {
            _context = context;
            _cepAPI = cepAPI;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await _context.Employee.Include(a => a.Adress).Include(p => p.Position).ToListAsync();
        }
        // GET: api/Employees/5
        [HttpGet("{document}")]
        public async Task<ActionResult<Employee>> GetEmployee(string document)
        {
            var employee = await _context.Employee.Include(a => a.Adress).Include(p => p.Position).Where(e => e.Document == document ).SingleOrDefaultAsync(e => e.Document == document);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{document}")]
        public async Task<IActionResult> PutEmployee(string document, EmployeeDTO DTO)
        {
            Employee employee = new Employee(DTO);
            employee.Document = DTO.Document;
            employee.Position = await _context.Position.FindAsync(employee.Position.Id);
            _context.Employee.Add(employee);
            if (document != employee.Document)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(document))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(EmployeeDTO employeeDTO)
        {
            //Chamando Adress da API
            var adress = await _cepAPI.GetAdressAPI(employeeDTO.Adress.Cep);
            if(adress == null)
            {
                return NotFound("Adress not found");
            }

            var address = new Adress(adress)
            {
                ZipCode = adress.Cep,
                Street = adress.Logradouro,
                Neighborhood = adress.Bairro,
                City = adress.Localidade,
                State = adress.Uf,
                Number = employeeDTO.Adress.Number,
                Complement = employeeDTO.Adress.Complement
            };

            Employee employee = new Employee(employeeDTO,address);
            employee.Document = employeeDTO.Document;
            employee.Name = employeeDTO.Name;
            employee.Position = await _context.FindAsync<Position>(employeeDTO.PositionId);
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEmployee", new { id = employee.Document }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{document}")]
        public async Task<IActionResult> DeleteEmployee(string document)
        {
            var employee = await _context.Employee.FindAsync(document);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(string id)
        {
            return _context.Employee.Any(e => e.Document == id);
        }
    }
}
