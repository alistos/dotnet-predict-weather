namespace dotnet_predict_weather.Server.Models.DTO
{
    public class DeviceDto
    {
        public Guid Id { get; set; }
        public string Manufacturer { get; set; }
        public string Url { get; set; }
        public string[] Commands { get; set; }
    }
}