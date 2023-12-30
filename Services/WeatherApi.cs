using Newtonsoft.Json;

namespace UsersAPI.Services
{
    public class WeatherApi
    {
        private const string API_KEY = "78a6f3bd041f4f2bb7b230613232912";
        //Get C temp for a location
        public static async Task<double> GetTempOflocation(string location)
        {
            string apiUrl = $"http://api.weatherapi.com/v1/current.json?key={API_KEY}&q={location}";
            WeatherApiResponse weatherResponse = await GetWeatherAsync(apiUrl);

            return weatherResponse != null ? weatherResponse.Current.TempC : 0;
        }

        public static async Task<WeatherApiResponse> GetWeatherAsync(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON string
                    return JsonConvert.DeserializeObject<WeatherApiResponse>(jsonResponse);
                }
                else
                {
                    // Handle the error, e.g., log or throw an exception
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return null;
                }
            }
        }
    }
    public class WeatherApiResponse
    {
        public Current Current { get; set; }
    }

    public class Current
    {
        [JsonProperty("temp_c")]
        public double TempC { get; set; }
    }
}