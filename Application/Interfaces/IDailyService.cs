using Application.Models;

namespace Application.Interfaces;

public interface IDailyService
{
    public Task<ValuteDto> GetValutesAsync(int page, int pageSize);
    public Task<ValuteData> GetValuteDataAsync(string valuteDataId);

}
