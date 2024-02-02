using System.Text.Json;
using UseRinINApi.Model;

namespace UseRinINApi.services
{

    public class WeatherApiService
    {
        private readonly HttpClient _httpClient;

        public WeatherApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherApiResponse> GetWeatherDataAsync(string cityName, string apiKey)
        {

            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                WeatherApiResponse weatherApiResponse = JsonSerializer.Deserialize<WeatherApiResponse>(jsonResponse);
                return weatherApiResponse;
            }
            else
            {
                throw new HttpRequestException($"Failed to retrieve data. Status code: {response.StatusCode}");
            }
        }
    }

}
