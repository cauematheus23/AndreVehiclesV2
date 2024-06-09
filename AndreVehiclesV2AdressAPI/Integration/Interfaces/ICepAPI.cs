using Models.APIs;

namespace AndreVehiclesV2AdressAPI.Integration.Interfaces
{
    public interface ICepAPI
    {
        Task<ConsumingAdressAPI> GetAdressAPI(string cep);
    }
}
