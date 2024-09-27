using WebApplication1.Services;

using Xunit;

namespace WebApplication1.Tests
{
    public class WeatherServiceTests
    {
        private readonly IWeatherService testService;

        public WeatherServiceTests()
        {
            //Arrange
            testService = new WeatherService();
        }

        [Fact]
        public void GetWeatherData_Success()
        {
            //Act
            var result = testService.GetWeatherInfo();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Count);
        }

        [Fact]
        public void ExceptionMethod_Exception()
        {
            //Act and Assert
            Assert.Throws<NotImplementedException>(() => testService.ExceptionMethod());
        }
    }
}
