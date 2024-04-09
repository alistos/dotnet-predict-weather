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

        public async Task<Device?> DeleteAsync(Guid id)
        {
            var existingDevice = await dbContext.Devices.FirstOrDefaultAsync(x => x.Id == id);
            if(existingDevice == null) 
            {
                return null;
            }

            dbContext.Devices.Remove(existingDevice);
            await dbContext.SaveChangesAsync();
            return existingDevice;
        }

        public async Task<Device?> EditAsync(Device device)
        {
            var existingDevice = await dbContext.Devices.FirstOrDefaultAsync(x => x.Id == device.Id);

            if (existingDevice != null) 
            {
                dbContext.Entry(existingDevice).CurrentValues.SetValues(device);
                await dbContext.SaveChangesAsync();
                return device;
            }

            return null;
        }

        public async Task<IEnumerable<Device>> GetAllAsync()
        {
            return await dbContext.Devices.ToListAsync();
        }

        public async Task<Device?> GetById(Guid id)
        {
            return await dbContext.Devices.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}