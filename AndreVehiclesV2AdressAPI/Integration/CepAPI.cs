using AndreVehiclesV2AdressAPI.Integration.Interfaces;
using AndreVehiclesV2AdressAPI.Integration.Refit;
using Microsoft.AspNetCore.Http.HttpResults;
using Models.APIs;

namespace AndreVehiclesV2AdressAPI.Integration
{
    public class CepAPI : ICepAPI
    {
        private readonly ICepAPIRefit _cepAPIService;
        public CepAPI(ICepAPIRefit cepAPIService)
        {
            _cepAPIService = cepAPIService;
        }
        public async Task<ConsumingAdressAPI> GetAdressAPI(string cep)
        {
            var response = await _cepAPIService.GetDatasByZipCode(cep);
            return response.Content ?? null;
        }
    }
}
