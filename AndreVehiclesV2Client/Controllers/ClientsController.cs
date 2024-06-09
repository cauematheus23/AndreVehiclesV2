using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreVehiclesV2Client.Data;
using Models;
using Models.DTO;
using Microsoft.Data.SqlClient;
using Dapper;
using AndreVehiclesV2AdressAPI.Integration.Interfaces;

namespace AndreVehiclesV2Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly AndreVehiclesV2ClientContext _context;
        private readonly ICepAPI _cepAPI;
        private string Conn { get; set;}
        public ClientsController(AndreVehiclesV2ClientContext context,ICepAPI cepAPI)
        {
            _context = context;
            _cepAPI = cepAPI;
            Conn = "Data Source=127.0.0.1; Initial Catalog=AndreVehiclesAPI; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=true;";
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClient()
        {
            return await _context.Client.Include(a => a.Adress).ToListAsync();
        }

        // GET: api/Clients/5
        [HttpGet("document")]
        public async Task<ActionResult<Client>> GetClient(string document)
        {
            var client = await _context.Client.Include(a => a.Adress).SingleOrDefaultAsync(d => d.Document == document);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{document}")]
        public async Task<IActionResult> PutClient(string id, Client client)
        {
            if (id != client.Document)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        [HttpGet("UsingDapper")]
        public async Task<ActionResult<IEnumerable<Client>>> GetClientUsingDapper()
        {
            using(SqlConnection connection = new SqlConnection(Conn))
            {
                connection.Open();
                var clients = connection.Query<Client,Adress,Client>(Client.SELECT,(client,adress) => { client.Adress = adress;return client; },splitOn:"Id");
                return Ok(clients);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(ClientDTO DTO)
        {
            var adress = await _cepAPI.GetAdressAPI(DTO.Adress.Cep);
            
            var address = new Adress(adress);
            address.Number = DTO.Adress.Number;
            address.Complement = DTO.Adress.Complement;

            var client = new Client(DTO, address);
           
            _context.Client.Add(client);
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetClient", new { id = client.Document }, client);
        }
        // DELETE: api/Clients/5
        [HttpDelete("{document}")]
        public async Task<IActionResult> DeleteClient(string document)
        {
            var client = await _context.Client.FindAsync(document);
            if (client == null)
            {
                return NotFound();
            }

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(string id)
        {
            return _context.Client.Any(e => e.Document == id);
        }
    }
}
