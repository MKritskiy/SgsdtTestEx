using Application.Interfaces;


namespace Infrastructure.Services;

public class DailyService : IDailyService
{
    private readonly IDailyHttpClient dailyHttpClient;

    public DailyService(IDailyHttpClient dailyHttpClient)
    {
        this.dailyHttpClient = dailyHttpClient;
    }

    public async Task<ValuteData> GetValuteDataAsync(string valuteDataId)
    {
        try
        {
            var daily = await dailyHttpClient.GetDailyAsync();
            var res = daily.Valute.Values.Where(v => v.Id == valuteDataId).FirstOrDefault();

            if (res==null) throw new KeyNotFoundException($"Значение с Id = {valuteDataId} не найдено");

            return res;
        } catch (Exception ex)
        {
            throw new Exception("Ошибка при получении данных о валюте", ex);
        }
    }

    public async Task<ValuteDto> GetValutesAsync(int page, int pageSize)
    {
        try
        {
            var daily = await dailyHttpClient.GetDailyAsync();
            var valute = daily.Valute;

            ValuteDto valuteDto = new ValuteDto() { Valute =  valute.Skip(page*pageSize).Take(pageSize).ToDictionary() };

            return valuteDto;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при получении данных о всех валютах", ex);
        }
    }
}
