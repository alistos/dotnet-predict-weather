using dotnet_predict_weather.Server.Models.Domain;
using dotnet_predict_weather.Server.Models.DTO;
using dotnet_predict_weather.Server.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_predict_weather.Server.Controllers
{
    //https:/localhost:xxxx/api/device
    [Route("api/[controller]")]
    [ApiController]

    public class DeviceController : ControllerBase
    {
        private readonly IDeviceRepository deviceRepository;
        public DeviceController(IDeviceRepository deviceRepository)
        {
            this.deviceRepository = deviceRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDevice(CreateDeviceRequestDto request)
        {
            // Map DTO to Domain Model
            var device = new Device
            {
                Manufacturer = request.Manufacturer,
                Url = request.Url,
                Commands = request.Commands,
            };

            await deviceRepository.CreateAsync(device);

            // Domain Model to DTO
            var response = new DeviceDto
            {
                Id = device.Id,
                Manufacturer = device.Manufacturer,
                Url = device.Url,
                Commands = device.Commands,
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDevices()
        {
            var devices = await deviceRepository.GetAllAsync();

            // Map Domain model to DTO
            var response = new List<DeviceDto>();
            foreach (var device in devices) 
            {
                response.Add(new DeviceDto
                {
                    Id = device.Id,
                    Manufacturer = device.Manufacturer,
                    Url = device.Url,
                    Commands = device.Commands,
                });
            }

            return Ok(response);
        }
    }
}