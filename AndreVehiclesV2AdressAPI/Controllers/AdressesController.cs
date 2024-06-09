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
        
       
        private bool AdressExists(int id)
        {
            return _context.Adress.Any(e => e.Id == id);
        }
    }
}
