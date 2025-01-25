namespace Application.Interfaces;

public interface IDailyHttpClient
{
    Task<Daily> GetDailyAsync();
}
