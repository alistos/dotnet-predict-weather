namespace dotnet_predict_weather.Server.Models.DTO
{
    public class CreateDeviceRequestDto
    {
        public string Manufacturer { get; set; }
        public string Url { get; set; }
        public string[] Commands { get; set; }
    }
}