using dotnet_predict_weather.Server.Models.Domain;

namespace dotnet_predict_weather.Server.Repositories.Interface
{
    public interface IDeviceRepository
    {
        Task<Device> CreateAsync(Device device);
        Task<IEnumerable<Device>> GetAllAsync();
        Task<Device?> GetById(Guid id);
        Task<Device?> EditAsync(Device device);
        Task<Device?> DeleteAsync(Guid id);
    }
}