using Application.Interfaces;
using Newtonsoft.Json;

namespace Infrastructure.Data;

public class DailyHttpClient : IDailyHttpClient
{
    private readonly HttpClient _httpClient;
    private const string Url = "https://www.cbr-xml-daily.ru/daily_json.js";

    public DailyHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Daily> GetDailyAsync()
    {
        try
        {
            var responce = await _httpClient.GetAsync(_httpClient.BaseAddress);
            responce.EnsureSuccessStatusCode();

            var jsonResponce = await responce.Content.ReadAsStringAsync();
            var daily = JsonConvert.DeserializeObject<Daily>(jsonResponce);

            if (daily == null) throw new JsonSerializationException("Ошибка дессериализации");

            return daily;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при получении данны о валютах", ex);
        }
    }
}
