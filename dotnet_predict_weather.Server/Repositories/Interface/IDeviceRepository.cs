using dotnet_predict_weather.Server.Models.Domain;

namespace dotnet_predict_weather.Server.Repositories.Interface
{
    public interface IDeviceRepository
    {
        Task<Device> CreateAsync(Device device);
        Task<IEnumerable<Device>> GetAllAsync();
    }
}