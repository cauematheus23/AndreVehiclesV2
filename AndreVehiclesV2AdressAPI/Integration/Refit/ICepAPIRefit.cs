using Models.APIs;
using Refit;

namespace AndreVehiclesV2AdressAPI.Integration.Refit
{
    public interface ICepAPIRefit
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ConsumingAdressAPI>> GetDatasByZipCode(string cep);
    }
}
