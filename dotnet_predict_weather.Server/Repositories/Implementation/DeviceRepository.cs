using dotnet_predict_weather.Server.Models.Data;
using dotnet_predict_weather.Server.Models.Domain;
using dotnet_predict_weather.Server.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace dotnet_predict_weather.Server.Repositories.Implementation
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ApplicationDbContext dbContext;
        public DeviceRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Device> CreateAsync(Device device)
        {
            await dbContext.Devices.AddAsync(device);
            await dbContext.SaveChangesAsync();

            return device;
        }

        public async Task<IEnumerable<Device>> GetAllAsync()
        {
            return await dbContext.Devices.ToListAsync();
        }
    }
}