namespace WebApplication1.Services
{
    internal class WeatherService : IWeatherService
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", 
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        public IReadOnlyList<WeatherForecast> GetWeatherInfo()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();        
        }

        public void ExceptionMethod()
        {
            throw new NotImplementedException();
        }
    }

    public interface IWeatherService
    {
        void ExceptionMethod();
        IReadOnlyList<WeatherForecast> GetWeatherInfo();
    }
}
