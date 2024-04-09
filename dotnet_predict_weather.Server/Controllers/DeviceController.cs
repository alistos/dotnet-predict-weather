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
        public async Task<IActionResult> CreateDevice([FromBody] CreateDeviceRequestDto request)
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

        // GET: https://localhost:xxxx/api/device
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

        // GET: https://localhost:xxxx/api/device/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetDeviceById([FromRoute] Guid id)
        {
            var existingDevice = await deviceRepository.GetById(id);

            if (existingDevice == null)
            {
                return NotFound();
            }

            var response = new DeviceDto
            {
                Id = existingDevice.Id,
                Manufacturer = existingDevice.Manufacturer,
                Url = existingDevice.Url,
                Commands = existingDevice.Commands,
            };

            return Ok(response);
        }

        // PUT: https://localhost:xxxx/api/device/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditDevice([FromRoute] Guid id, EditDeviceRequestDto request)
        {
            // Convert DTO to Domain model
            var device = new Device
            {
                Id = id,
                Manufacturer = request.Manufacturer,
                Url = request.Url,
                Commands = request.Commands,
            };

            device = await deviceRepository.EditAsync(device);

            if (device == null) 
            {
                return NotFound();
            }

            // Convert Domain model to DTO
            var response = new DeviceDto
            {
                Id = device.Id,
                Manufacturer = request.Manufacturer,
                Url = request.Url,
                Commands = request.Commands,
            };

            return Ok(response);
        }

        // DELETE: https://localhost:xxxx/api/device/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteDevice([FromRoute] Guid id)
        {
            var device = await deviceRepository.DeleteAsync(id);

            if(device == null) 
            {
                return NotFound();
            }

            // Convert Domain model to DTO

            var response = new DeviceDto
            {
                Id = device.Id,
                Manufacturer = device.Manufacturer,
                Url = device.Url,
                Commands = device.Commands,
            };

            return Ok(response);
        }
    }
}