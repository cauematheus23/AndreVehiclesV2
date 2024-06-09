using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreVehiclesV2CarJob.Data;
using Models;

namespace AndreVehiclesV2CarJob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarJobsController : ControllerBase
    {
        private readonly AndreVehiclesV2CarJobContext _context;

        public CarJobsController(AndreVehiclesV2CarJobContext context)
        {
            _context = context;
        }

        // GET: api/CarJobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarJob>>> GetCarJob()
        {
            return await _context.CarJob.Include(c => c.Car).Include(j => j.Job).ToListAsync();
        }

        // GET: api/CarJobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarJob>> GetCarJob(int id)
        {
            var carJob = await _context.CarJob.Include(c => c.Car).Include(j => j.Job).Where(cj => cj.Id == id).SingleOrDefaultAsync(cp => cp.Id == id);

            if (carJob == null)
            {
                return NotFound();
            }

            return carJob;
        }

        // PUT: api/CarJobs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarJob(int id, CarJob carJob)
        {
            if (id != carJob.Id)
            {
                return BadRequest();
            }

            _context.Entry(carJob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarJobExists(id))
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

        // POST: api/CarJobs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarJob>> PostCarJob(CarJob carJob)
        {
            _context.CarJob.Add(carJob);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarJob", new { id = carJob.Id }, carJob);
        }

        // DELETE: api/CarJobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarJob(int id)
        {
            var carJob = await _context.CarJob.FindAsync(id);
            if (carJob == null)
            {
                return NotFound();
            }

            _context.CarJob.Remove(carJob);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarJobExists(int id)
        {
            return _context.CarJob.Any(e => e.Id == id);
        }
    }
}
