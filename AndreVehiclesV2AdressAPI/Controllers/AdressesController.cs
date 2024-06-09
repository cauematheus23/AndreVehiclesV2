using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreVehiclesV2AdressAPI.Data;
using Models;
using AndreVehiclesV2AdressAPI.Integration.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AndreVehiclesV2AdressAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdressesController : ControllerBase
    {
        private readonly AndreVehiclesV2AdressAPIContext _context;
        private readonly ICepAPI _cepAPI;
        public AdressesController(AndreVehiclesV2AdressAPIContext context,ICepAPI cepAPI)
        {
            _context = context;
            _cepAPI = cepAPI;
        }
        [HttpGet("GetAdressByCorreios/{cep}")]
        public async Task<ActionResult<Adress>> GetAdressByCorreios(string cep,string number,string complement)
        {
            var adressAPI = await _cepAPI.GetAdressAPI(cep);

            if (adressAPI == null)
            {
                return NotFound();
            }
            var adress = new Adress
            {
                ZipCode = adressAPI.Cep
                , Street = adressAPI.Logradouro
                , Neighborhood = adressAPI.Bairro
                , City = adressAPI.Localidade
                , State = adressAPI.Uf
                , Number = number
                , Complement = complement
            };
            return Ok(adress);
        }
        
        // GET: api/Adresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adress>>> GetAdress()
        {
            return await _context.Adress.ToListAsync();
        }

        // GET: api/Adresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adress>> GetAdress(int id)
        {
            var adress = await _context.Adress.FindAsync(id);

            if (adress == null)
            {
                return NotFound();
            }

            return adress;
        }

        // PUT: api/Adresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdress(int id, Adress adress)
        {
            if (id != adress.Id)
            {
                return BadRequest();
            }

            _context.Entry(adress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdressExists(id))
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

        // POST: api/Adresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adress>> PostAdress(Adress adress)
        {
            _context.Adress.Add(adress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdress", new { id = adress.Id }, adress);
        }

        // DELETE: api/Adresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdress(int id)
        {
            var adress = await _context.Adress.FindAsync(id);
            if (adress == null)
            {
                return NotFound();
            }

            _context.Adress.Remove(adress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdressExists(int id)
        {
            return _context.Adress.Any(e => e.Id == id);
        }
    }
}
